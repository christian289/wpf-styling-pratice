# PerfectLizard67 변환 로그

## 변환 일자
2026-01-01

## 컴파일 에러

### 에러 1: MC4111 - Trigger 대상을 찾을 수 없음

**에러 내용:**
```
error MC4111: Trigger 대상 'PART_Shadow'을(를) 찾을 수 없습니다.
대상은 모든 Setters, Triggers 또는 대상을 사용하는 Conditions 앞에 표시되어야 합니다.
```

**원인:**
- `DropShadowEffect`가 `Border.Effect` 속성 내부에 정의되어 있어 직접 TargetName으로 참조 불가
- WPF에서 Effect 내부의 요소는 시각적 트리의 일부가 아니므로 TargetName으로 직접 접근 불가

**수정 방법:**
```xml
<!-- Before (오류) -->
<Setter TargetName="PART_Shadow" Property="Opacity" Value="0" />

<!-- After (수정) -->
<Setter TargetName="PART_MainBorder" Property="Effect" Value="{x:Null}" />
```

**설명:**
- `DropShadowEffect`의 개별 속성(Opacity)을 변경하는 대신 Border의 `Effect` 속성 전체를 `{x:Null}`로 설정하여 그림자를 제거

## 잠재적 런타임 에러

### 1. 플레이스홀더 텍스트 표시 로직
- **위험도:** 낮음
- **내용:** 여러 Trigger가 플레이스홀더 Visibility를 제어하여 의도치 않은 동작 가능성
- **확인 필요:** 확장/축소 상태와 텍스트 유무에 따른 플레이스홀더 표시 여부 테스트 필요

### 2. 애니메이션 Easing 함수
- **위험도:** 매우 낮음
- **내용:** CSS `cubic-bezier(0, 0.110, 0.35, 2)`를 `BackEase(Amplitude=0.3)`로 근사 변환
- **확인 필요:** 원본 CSS와 애니메이션 곡선 비교 확인

### 3. 폰트 폴백
- **위험도:** 낮음
- **내용:** FontFamily에 "Trebuchet MS" 등 여러 폰트 지정, 시스템에 없을 경우 대체 폰트 적용됨
- **확인 필요:** 대상 시스템에서 의도한 폰트가 적용되는지 확인

## CSS → WPF 변환 주요 포인트

| CSS 속성 | WPF 변환 |
|---------|---------|
| `border-radius: 50%` | `CornerRadius="25"` (Width/2) |
| `box-shadow: 0 0 3px` | `DropShadowEffect BlurRadius="3" ShadowDepth="0"` |
| `transition: 500ms cubic-bezier` | `Storyboard Duration="0:0:0.5" BackEase` |
| `:focus` 상태 | `IsExpanded` DependencyProperty + Trigger |
| `border-bottom: 3px solid` | `BorderThickness="0,0,0,3"` |
