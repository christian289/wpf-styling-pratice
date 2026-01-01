# OrangeFox41 AvaloniaUI 변환 로그

## 변환 정보

- **원본**: HTML/CSS (Material Design 3 Tooltip by SteveBloX from Uiverse.io)
- **대상**: AvaloniaUI CustomControl
- **변환 일시**: 2026-01-02

## 프로젝트 구조

```
WebToDesktop/Output/OrangeFox41/AvaloniaUI/
├── OrangeFox41.Avalonia.slnx
├── OrangeFox41.Avalonia.Lib/
│   ├── Controls/
│   │   └── OrangeFox41.cs
│   └── Themes/
│       ├── Generic.axaml
│       └── OrangeFox41.axaml
└── OrangeFox41.Avalonia.Gallery/
    ├── App.axaml / App.axaml.cs
    ├── MainWindow.axaml / MainWindow.axaml.cs
    └── Program.cs
```

## 컴파일 에러 및 수정

### 에러 1: AVLN2000 - ResourceDictionary vs IStyle 타입 불일치

**에러 메시지**:
```
Avalonia error AVLN2000: Resource "avares://OrangeFox41.Avalonia.Lib/Themes/Generic.axaml"
is defined as "Avalonia.Controls.ResourceDictionary" type in the "OrangeFox41.Avalonia.Lib" assembly,
but expected "Avalonia.Styling.IStyle". Line 7, position 23.
```

**원인**:
- `Application.Styles` 내에서 `StyleInclude`를 사용하여 `ResourceDictionary`를 포함하려고 함
- `StyleInclude`는 `IStyle` 타입만 허용하지만 `Generic.axaml`은 `ResourceDictionary` 타입임

**수정 방법**:
- `StyleInclude`를 `Application.Styles`에서 제거
- `Application.Resources`에 `ResourceDictionary.MergedDictionaries`를 사용하여 `ResourceInclude`로 포함

**수정 전 (App.axaml)**:
```xml
<Application.Styles>
    <FluentTheme />
    <StyleInclude Source="avares://OrangeFox41.Avalonia.Lib/Themes/Generic.axaml" />
</Application.Styles>
```

**수정 후 (App.axaml)**:
```xml
<Application.Styles>
    <FluentTheme />
</Application.Styles>
<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceInclude Source="avares://OrangeFox41.Avalonia.Lib/Themes/Generic.axaml" />
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

## 잠재적 런타임 오류

### 1. 툴팁 애니메이션 동작

**위험도**: 중간

**설명**: CSS의 `scale` 변환과 AvaloniaUI의 `ScaleTransform` 애니메이션은 동작 방식이 다를 수 있음. CSS에서는 `transform-origin: center left`를 사용했지만, AvaloniaUI에서는 `RenderTransformOrigin="0.5,0"`으로 변환함.

**확인 필요**: 호버 시 툴팁의 스케일 애니메이션이 의도대로 동작하는지 확인 필요

### 2. 툴팁 위치

**위험도**: 낮음

**설명**: CSS에서 `position: absolute`, `top: 130%`, `left: 50%`, `transform: translate(-50%, -10px)`로 툴팁 위치를 지정했지만, AvaloniaUI에서는 `Panel` 내에서 `Margin`을 사용하여 위치 조정함. 실제 렌더링 결과가 다를 수 있음.

### 3. 폰트 폴백

**위험도**: 낮음

**설명**: CSS에서 `font-family: Montserrat, sans-serif`를 사용했지만 Montserrat 폰트가 시스템에 설치되어 있지 않으면 Segoe UI로 폴백됨.

### 4. BoxShadow 렌더링

**위험도**: 낮음

**설명**: CSS `box-shadow: 0 1px 2px rgba(0, 0, 0, 0.3), 0 2px 6px 2px rgba(0, 0, 0, 0.15)`를 AvaloniaUI `BoxShadow="0 1 2 0 #4D000000, 0 2 6 2 #26000000"`로 변환함. 색상 알파값 변환이 정확하지 않을 수 있음.

## CSS → AvaloniaUI 변환 매핑

| CSS 속성 | AvaloniaUI 속성 |
|---------|----------------|
| `background: #e8def8` | `Background="#E8DEF8"` |
| `border-radius: 50px` | `CornerRadius="50"` |
| `padding: 0.7em 1.8em` | `Padding="31,12"` (17px * 1.8, 17px * 0.7) |
| `font-weight: bold` | `FontWeight="Bold"` |
| `font-weight: semibold` | `FontWeight="DemiBold"` |
| `cursor: pointer` | `Cursor="Hand"` |
| `box-shadow` | `BoxShadow` |
| `:hover` | `:pointerover` |
| `scale: 0 → 1` | `ScaleTransform` Animation |
| `transition: all 0.25s` | `Animation Duration="0:0:0.25"` |

## 빌드 결과

- **빌드 상태**: 성공
- **경고**: 0개
- **오류**: 0개 (수정 후)
