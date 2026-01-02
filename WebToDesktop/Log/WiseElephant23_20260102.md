# WiseElephant23 변환 로그

## 변환 정보

- **변환 날짜**: 2026-01-02
- **원본**: HTML/CSS (uiverse.io)
- **대상**: WPF CustomControl

## 빌드 결과

**성공** - 경고 0개, 오류 0개

## 컴파일 에러

없음

## 수정 사항

### 초기 상태 문제 수정

**문제**: `IsChecked="True"`로 초기화된 컨트롤의 경우, Trigger의 EnterActions가 로드 시점에 실행되지 않아 초기에 체크된 상태로 설정된 컨트롤이 회색 배경으로 표시될 수 있었음

**해결 방법**: Trigger에 Setter를 추가하여 초기 상태가 올바르게 표시되도록 수정

```xml
<Trigger Property="IsChecked" Value="True">
    <!-- 초기 상태 설정 (Setter) - 로드 시 올바른 상태 표시 -->
    <Setter TargetName="PART_Background" Property="Background" Value="{StaticResource WiseElephant23.Background.Checked}"/>
    <Setter TargetName="PART_Checkmark" Property="Opacity" Value="1"/>
    <!-- EnterActions/ExitActions는 상태 변경 시 애니메이션용 -->
</Trigger>
```

## 잠재적 런타임 오류 (확인 필요)

### 1. Path 체크마크 렌더링

**설명**: 체크마크가 Path로 구현되어 있으며, CSS의 border 기반 체크마크와 약간 다르게 보일 수 있습니다.

**영향**: 시각적 차이 (기능에는 영향 없음)

## CSS → WPF 변환 매핑

| CSS 속성 | WPF 구현 |
|---------|---------|
| `background-color: #ccc` | `SolidColorBrush` |
| `background-color: limegreen` | `SolidColorBrush Color="LimeGreen"` |
| `border-radius: 25px` | `CornerRadius="13"` (원형) |
| `transition: 0.15s` | `ColorAnimation Duration="0:0:0.15"` |
| `::after` (체크마크) | `Path` with `RotateTransform` |
| `input:checked ~` | `Trigger IsChecked="True"` |
| `display: none/block` | `Opacity="0/1"` with animation |
| `transform: rotate(45deg)` | `RotateTransform Angle="45"` |
