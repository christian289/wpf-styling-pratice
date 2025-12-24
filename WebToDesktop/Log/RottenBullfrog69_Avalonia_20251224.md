# RottenBullfrog69 AvaloniaUI 변환 로그

- **변환 날짜**: 2024-12-24
- **원본**: uiverse.io by shadowmurphy
- **설명**: ChatGPT 스타일의 채팅 UI 컴포넌트

## 프로젝트 구조

```
RottenBullfrog69/AvaloniaUI/
├── RottenBullfrog69.Avalonia.slnx
├── RottenBullfrog69.Avalonia.Lib/
│   ├── Controls/
│   │   └── ChatControl.cs
│   └── Themes/
│       ├── Generic.axaml
│       └── ChatControl.axaml
└── RottenBullfrog69.Avalonia.Gallery/
    ├── App.axaml / App.axaml.cs
    ├── MainWindow.axaml / MainWindow.axaml.cs
    └── Program.cs
```

## 컴파일 에러 및 수정

### 에러 1: AVLN2000 - ResourceDictionary vs IStyle 타입 불일치

**에러 메시지:**
```
Avalonia error AVLN2000: Resource "avares://RottenBullfrog69.Avalonia.Lib/Themes/Generic.axaml"
is defined as "Avalonia.Controls.ResourceDictionary" type in the "RottenBullfrog69.Avalonia.Lib"
assembly, but expected "Avalonia.Styling.IStyle".
```

**원인:**
- `Application.Styles`에서 `StyleInclude`를 사용하여 `ResourceDictionary`를 참조함
- `StyleInclude`는 `IStyle` 타입만 허용하며, `ResourceDictionary`는 허용되지 않음

**수정 방법:**
`Application.Styles` 대신 `Application.Resources`에서 `ResourceInclude`를 사용하여 `ResourceDictionary`를 병합

**수정 전:**
```xml
<Application.Styles>
    <FluentTheme />
    <StyleInclude Source="avares://RottenBullfrog69.Avalonia.Lib/Themes/Generic.axaml" />
</Application.Styles>
```

**수정 후:**
```xml
<Application.Styles>
    <FluentTheme />
</Application.Styles>
<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceInclude Source="avares://RottenBullfrog69.Avalonia.Lib/Themes/Generic.axaml" />
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

## 런타임 에러 가능성 (직접 확인 필요)

### 1. TextBox Watermark 스타일링

**위치:** `ChatControl.axaml` - TextBox 컨트롤

**잠재적 문제:**
- AvaloniaUI의 TextBox Watermark는 FluentTheme의 기본 스타일에 따라 렌더링됨
- Placeholder 색상(`#828E9E`)이 FluentTheme과 충돌하여 의도한 대로 표시되지 않을 수 있음

**확인 사항:**
- TextBox의 Watermark 텍스트 색상이 `#828E9E`로 표시되는지 확인
- 필요 시 TextBox의 Watermark 스타일을 별도로 정의

### 2. RotateTransform 중심점

**위치:** `ChatControl.axaml` - Close 버튼의 X 표시

**잠재적 문제:**
- `RotateTransform`의 기본 중심점이 Border의 중앙이 아닐 수 있음
- X 표시가 의도한 위치에서 벗어나 렌더링될 가능성

**확인 사항:**
- Close 버튼의 X 표시가 정확히 중앙에서 회전하는지 확인
- 필요 시 `RenderTransformOrigin="0.5,0.5"` 추가

### 3. Path Geometry 렌더링

**위치:** `ChatControl.axaml` - Send 버튼의 아이콘

**잠재적 문제:**
- SVG에서 추출한 Path Data가 AvaloniaUI에서 다르게 렌더링될 수 있음
- 아이콘 크기나 비율이 CSS 원본과 다를 수 있음

**확인 사항:**
- Send 아이콘이 올바르게 표시되는지 확인
- 필요 시 `Stretch` 속성이나 크기 조정

## CSS → AXAML 변환 노트

| CSS 속성 | AXAML 변환 |
|----------|-----------|
| `display: flex; flex-direction: column` | `Grid` with `RowDefinitions` |
| `justify-content: space-between` | `Grid` with `ColumnDefinitions="*,Auto"` |
| `align-items: center` | `VerticalAlignment="Center"` |
| `border-radius: 8px` | `CornerRadius="8"` |
| `transform: rotate(45deg)` | `RotateTransform Angle="45"` |
| `cursor: pointer` | `Cursor="Hand"` |
| `gap: 5px` | `Margin` 또는 `Spacing` |

## RadialGradientBrush 관련

- 이 컴포넌트에서는 RadialGradientBrush가 사용되지 않음
- AvaloniaUI Issue #19888 해당 없음
