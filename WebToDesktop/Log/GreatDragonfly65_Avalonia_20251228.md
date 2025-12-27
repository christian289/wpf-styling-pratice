# GreatDragonfly65 AvaloniaUI 변환 로그

## 변환 정보

- **원본**: GreatDragonfly65.html (SmookyDev의 Uiverse.io 버튼)
- **변환 대상**: AvaloniaUI CustomControl
- **변환 일자**: 2025-12-28

## 원본 분석

### HTML 구조
Tailwind CSS 클래스를 사용한 버튼으로, 다음 요소들로 구성:
- 메인 버튼: rose-900 to pink-700 그라데이션 배경
- `::before` pseudo-element: 왼쪽 클립 영역, polygon clip-path 적용
- `::after` pseudo-element: 오른쪽 클립 영역, polygon clip-path 적용

### CSS 특징
- `clip-path: polygon(...)`: 복잡한 다각형 클리핑
- `transform: rotate(), skewY(), scale()`: 호버 시 변환
- `transition: all 0.7s`: 부드러운 애니메이션
- `origin-bottom-left/right`: 변환 원점 설정

## 컴파일 에러 및 수정

### 에러 1: XAML 태그 불일치

**에러 내용**:
```
Avalonia error AVLN1001: The 'Setter' start tag on line 171 position 26 does not match the end tag of 'TransformGroup'. Line 178, position 27.
```

**원인**: HoverButton.axaml 171-178 라인에서 `</TransformGroup>` 태그가 중복 작성됨

**수정 방법**: 중복된 `</TransformGroup>` 태그 제거

**수정 전**:
```xml
<Setter Property="RenderTransform">
    <TransformGroup>
        <TranslateTransform X="-1"/>
        <RotateTransform Angle="100"/>
        <SkewTransform AngleY="6"/>
        <ScaleTransform ScaleX="0.5"/>
    </TransformGroup>
</TransformGroup>  <!-- 중복 -->
</Setter>
```

**수정 후**:
```xml
<Setter Property="RenderTransform">
    <TransformGroup>
        <TranslateTransform X="-1"/>
        <RotateTransform Angle="100"/>
        <SkewTransform AngleY="6"/>
        <ScaleTransform ScaleX="0.5"/>
    </TransformGroup>
</Setter>
```

### 에러 2: ResourceDictionary 타입 불일치

**에러 내용**:
```
Avalonia error AVLN2000: Resource "avares://GreatDragonfly65.Avalonia.Lib/Themes/Generic.axaml" is defined as "Avalonia.Controls.ResourceDictionary" type in the "GreatDragonfly65.Avalonia.Lib" assembly, but expected "Avalonia.Styling.IStyle".
```

**원인**: `Application.Styles`에 ResourceDictionary를 직접 포함시킴 (StyleInclude 사용)

**수정 방법**: ResourceDictionary는 `Application.Resources`에서 병합해야 함

**수정 전**:
```xml
<Application.Styles>
    <FluentTheme/>
    <StyleInclude Source="avares://GreatDragonfly65.Avalonia.Lib/Themes/Generic.axaml"/>
</Application.Styles>
```

**수정 후**:
```xml
<Application.Styles>
    <FluentTheme/>
</Application.Styles>

<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceInclude Source="avares://GreatDragonfly65.Avalonia.Lib/Themes/Generic.axaml"/>
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

## 잠재적 런타임 에러 (직접 확인 필요)

### 1. PathGeometry 클리핑 좌표 문제

**설명**: CSS의 `clip-path: polygon()` 좌표를 고정 픽셀 값(Width=140, Height=52 가정)으로 변환함.
실제 버튼 크기가 다를 경우 클리핑 영역이 올바르게 표시되지 않을 수 있음.

**확인 방법**: 실행 후 버튼 클리핑 영역이 올바르게 표시되는지 확인

**해결 방법**: 필요시 컨트롤 크기에 맞춰 PathGeometry 좌표 조정 또는 동적 클리핑 구현

### 2. 애니메이션 TransformGroup 호환성

**설명**: AvaloniaUI에서 애니메이션 내 TransformGroup 설정은 WPF와 다르게 동작할 수 있음.
특히 `:pointerover` 상태에서 여러 Transform을 동시에 적용할 때 예상치 못한 동작 가능.

**확인 방법**: 호버 시 회전, 스케일, 스큐 애니메이션이 모두 올바르게 동작하는지 확인

### 3. 텍스트 바인딩 업데이트

**설명**: `:pointerover` 상태에서 TextBlock의 Text 속성을 `TemplatedParent` 바인딩으로 변경하는데,
AvaloniaUI의 스타일 셀렉터에서 바인딩 업데이트가 즉시 반영되지 않을 수 있음.

**확인 방법**: 호버 시 "Hover ME" → "SMOOKY DEV" 텍스트 변경이 올바르게 동작하는지 확인

### 4. RenderTransformOrigin 백분율 표기

**설명**: `RenderTransformOrigin="100%,100%"` 형식이 AvaloniaUI에서 올바르게 해석되는지 확인 필요.
일부 버전에서는 `1,1` 형식(0~1 범위)이 필요할 수 있음.

**확인 방법**: 회전/스케일 변환의 원점이 올바르게 설정되어 있는지 확인

## CSS → AvaloniaUI 변환 매핑

| CSS | AvaloniaUI |
|-----|------------|
| `from-rose-900 to-pink-700` | `LinearGradientBrush` (#881337 → #BE185D) |
| `hover:scale-105` | `ScaleTransform ScaleX="1.05" ScaleY="1.05"` |
| `duration-700` | `Animation Duration="0:0:0.7"` |
| `rounded-e` | `CornerRadius="0,4,4,0"` |
| `px-10 py-4` | `Padding="40,16"` |
| `clip-path: polygon(...)` | `PathGeometry` 클리핑 |
| `:hover` | `:pointerover` |
| `transform: rotate()` | `RotateTransform` |
| `transform: skewY()` | `SkewTransform` |
| `origin-bottom-right` | `RenderTransformOrigin="100%,100%"` |
| `origin-bottom-left` | `RenderTransformOrigin="0%,100%"` |

## 빌드 결과

- **최종 빌드 상태**: 성공
- **경고**: 0개
- **오류**: 0개
