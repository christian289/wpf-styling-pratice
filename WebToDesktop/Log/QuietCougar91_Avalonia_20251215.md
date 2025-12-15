# QuietCougar91 AvaloniaUI 변환 로그

## 변환 정보

- **원본**: Uiverse.io by kyle1dev (Tooltip Button)
- **날짜**: 2025-12-15
- **변환 대상**: HTML/CSS → AvaloniaUI Custom Control

## 프로젝트 구조

```
WebToDesktop/Output/QuietCougar91/AvaloniaUI/
├── QuietCougar91.Avalonia.slnx
├── QuietCougar91.Avalonia.Lib/
│   ├── Controls/
│   │   └── QuietCougar91Button.cs
│   └── Themes/
│       ├── Generic.axaml
│       └── QuietCougar91Button.axaml
└── QuietCougar91.Avalonia.Gallery/
    ├── App.axaml / App.axaml.cs
    ├── MainWindow.axaml / MainWindow.axaml.cs
    └── Program.cs
```

## 컴파일 에러 및 수정

### 에러 1: AVLN2000 - ResourceDictionary vs IStyle 타입 불일치

**에러 내용**:
```
Avalonia error AVLN2000: Resource "avares://QuietCougar91.Avalonia.Lib/Themes/Generic.axaml"
is defined as "Avalonia.Controls.ResourceDictionary" type in the "QuietCougar91.Avalonia.Lib" assembly,
but expected "Avalonia.Styling.IStyle".
```

**원인**:
- `Application.Styles`에서 `StyleInclude`를 사용하여 `ResourceDictionary`를 로드하려고 함
- `StyleInclude`는 `IStyle` 타입을 기대하지만, `Generic.axaml`은 `ResourceDictionary` 타입임

**수정 방법**:
- `Application.Styles` 대신 `Application.Resources`에서 `ResourceInclude` 사용

**수정 전 (App.axaml)**:
```xml
<Application.Styles>
    <FluentTheme />
    <StyleInclude Source="avares://QuietCougar91.Avalonia.Lib/Themes/Generic.axaml" />
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
            <ResourceInclude Source="avares://QuietCougar91.Avalonia.Lib/Themes/Generic.axaml" />
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

## CSS → AXAML 변환 매핑

| CSS 속성 | AvaloniaUI 속성 |
|---------|----------------|
| `background: linear-gradient(to right, #333, #000)` | `<LinearGradientBrush StartPoint="0%,50%" EndPoint="100%,50%">` |
| `box-shadow: 0 4px 8px rgba(0,0,0,0.5)` | `BoxShadow="0 4 8 #80000000"` |
| `border-radius: 6px` | `CornerRadius="6"` |
| `padding: 15px 30px` | `Padding="30,15"` |
| `cursor: pointer` | `Cursor="Hand"` |
| `:hover` | `:pointerover` |
| `:active` | `:pressed` |
| `transition: transform 0.4s ease` | `<Animation Duration="0:0:0.4" Easing="CubicEaseOut">` |
| `transform: translateY(-10px)` | `<TranslateTransform Y="-10" />` |
| `transform: scale(0.95)` | `<ScaleTransform ScaleX="0.95" ScaleY="0.95" />` |

## 잠재적 런타임 오류 가능성

1. **애니메이션 복귀 문제**: CSS의 `transition`은 자동으로 원래 상태로 복귀하지만, AvaloniaUI의 `Animation`은 `FillMode="Forward"`로 인해 최종 상태에서 멈춤. 마우스가 떠나도 원래 상태로 돌아가지 않을 수 있음.

2. **툴팁 위치**: CSS의 `bottom: 125%; transform: translateX(-50%)`를 AvaloniaUI에서 `Margin="0,-50,0,0"`과 `HorizontalAlignment="Center"`로 대체했으나, 버튼 크기에 따라 위치가 달라질 수 있음.

3. **SVG Path 데이터**: 원본 SVG의 `viewBox="0 0 24 24"`를 기반으로 PathIcon에 Data를 적용했으나, 복잡한 Path 데이터가 정확히 렌더링되지 않을 수 있음.

## RadialGradientBrush 사용 여부

- 이 컴포넌트는 `RadialGradientBrush`를 사용하지 않음
- `LinearGradientBrush`만 사용하므로 AvaloniaUI Issue #19888 해당 없음

## 빌드 결과

- **빌드 성공**: 경고 0개, 오류 0개
- **빌드 명령**: `dotnet build QuietCougar91.Avalonia.slnx`
