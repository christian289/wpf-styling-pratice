# GentleFly78 - AvaloniaUI Conversion Log

## Source
- **URL**: Uiverse.io by devkatyall
- **Tags**: card
- **Description**: Emoji sliding card control (이모지 슬라이딩 카드 컨트롤)

## Project Structure

```
GentleFly78/AvaloniaUI/
├── GentleFly78.Avalonia.slnx
├── GentleFly78.Avalonia.Lib/
│   ├── Controls/
│   │   └── GentleFly78Control.cs
│   └── Themes/
│       ├── Generic.axaml
│       └── GentleFly78Control.axaml
└── GentleFly78.Avalonia.Gallery/
    ├── App.axaml / App.axaml.cs
    ├── MainWindow.axaml / MainWindow.axaml.cs
    └── Program.cs
```

## Compile Errors & Fixes

### Error 1: Style in ResourceDictionary

**Error Message**:
```
AVLN3000: Unable to find suitable setter or adder for property Content of type ResourceDictionary for argument Style
```

**Cause**:
- AvaloniaUI의 ResourceDictionary는 직접적으로 Style 요소를 자식으로 가질 수 없음
- AvaloniaUI ResourceDictionary cannot have Style elements as direct children

**Fix**:
- `Button.emoji` 클래스 스타일을 제거하고, ControlTheme 내부의 nested Style로 버튼 스타일을 정의
- Removed `Button.emoji` class style and defined button styles as nested Style within ControlTheme
- 버튼 속성을 ControlTemplate 내에서 직접 인라인으로 지정
- Button properties specified inline directly in ControlTemplate

### Error 2: StyleInclude for ResourceDictionary

**Error Message**:
```
AVLN2000: Resource "avares://GentleFly78.Avalonia.Lib/Themes/Generic.axaml" is defined as "ResourceDictionary" type, but expected "IStyle"
```

**Cause**:
- `Application.Styles`에서 `StyleInclude`로 ResourceDictionary를 로드하려 함
- Tried to load ResourceDictionary using StyleInclude in Application.Styles

**Fix**:
- `Application.Resources`에서 `ResourceDictionary.MergedDictionaries`를 사용하여 ResourceInclude로 로드
- Load using ResourceInclude in Application.Resources with ResourceDictionary.MergedDictionaries

**Before**:
```xml
<Application.Styles>
    <FluentTheme />
    <StyleInclude Source="avares://GentleFly78.Avalonia.Lib/Themes/Generic.axaml" />
</Application.Styles>
```

**After**:
```xml
<Application.Styles>
    <FluentTheme />
</Application.Styles>
<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceInclude Source="avares://GentleFly78.Avalonia.Lib/Themes/Generic.axaml" />
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

## Potential Runtime Issues

### 1. Canvas.Left Animation Value

**Issue**:
- CSS 원본에서는 `translateX(-101%)`로 상대적 이동을 사용하지만, AXAML에서는 고정값 `-356`을 사용
- Original CSS uses relative `translateX(-101%)` but AXAML uses fixed value `-356`

**Impact**:
- 이모지 개수나 크기가 변경되면 애니메이션이 매끄럽지 않을 수 있음
- Animation may not be smooth if emoji count or size changes

**Recommendation**:
- 런타임에 실제 StackPanel 너비를 측정하여 애니메이션 값을 동적으로 조정하는 코드 추가 필요
- Need to add code that measures actual StackPanel width at runtime and dynamically adjusts animation values

### 2. Hover Animation on Moving Elements

**Issue**:
- 슬라이딩 중인 버튼에 hover 애니메이션이 적용될 때 시각적으로 부자연스러울 수 있음
- Hover animation on sliding buttons may look visually unnatural

**Recommendation**:
- 실제 동작 확인 후 필요시 hover 애니메이션 제거 또는 조정
- Check actual behavior and remove/adjust hover animation if needed

### 3. RadialGradientBrush

**Note**:
- 이 컴포넌트는 RadialGradientBrush를 사용하지 않으므로 AvaloniaUI Issue #19888 영향 없음
- This component does not use RadialGradientBrush, so not affected by AvaloniaUI Issue #19888

## CSS to AXAML Conversion Summary

| CSS Property | AXAML Property |
|--------------|----------------|
| `background: rgba(41,41,41,0.07)` | `Background="#12292929"` |
| `border-radius: 50px` | `CornerRadius="50"` |
| `box-shadow: -10px 0px 33px...` | `BoxShadow="-10 0 33 0 #3A000000, 10 0 33 0 #3A000000"` |
| `overflow: hidden` | `ClipToBounds="True"` |
| `display: inline-block` | `StackPanel Orientation="Horizontal"` |
| `animation: 5s sliding infinite linear` | `Animation Duration="0:0:5" IterationCount="Infinite" Easing="LinearEasing"` |
| `transform: scale(1.1)` | `ScaleTransform ScaleX="1.1" ScaleY="1.1"` |
| `transition: 0.5s ease` | `Animation Duration="0:0:0.5" Easing="CubicEaseOut"` |
| `:hover` | `:pointerover` |

## Build Result

- **Status**: SUCCESS
- **Warnings**: 0
- **Errors**: 0
