# QuietHorse20 AvaloniaUI Conversion Log

## Source Information

- **Source**: Uiverse.io by aurellsoleil
- **Tags**: icon, white, button, hover, active, rounded, modern, hover effect
- **Component**: Send Message Button with Paper Plane Icon
- **Conversion Date**: 2025-12-18

## Project Structure

```
QuietHorse20/AvaloniaUI/
├── QuietHorse20.Avalonia.slnx
├── QuietHorse20.Avalonia.Lib/
│   ├── Controls/
│   │   └── SendMessageButton.cs
│   └── Themes/
│       ├── Generic.axaml
│       └── SendMessageButton.axaml
└── QuietHorse20.Avalonia.Gallery/
    ├── App.axaml
    ├── App.axaml.cs
    ├── MainWindow.axaml
    ├── MainWindow.axaml.cs
    └── Program.cs
```

## Compile Errors and Fixes

### Error 1: StrokeLineJoin Property Not Found

**Error Message**:
```
Avalonia error AVLN2000: Unable to resolve suitable regular or attached property StrokeLineJoin on type Avalonia.Controls:Avalonia.Controls.Shapes.Path
```

**Cause**:
- AvaloniaUI에서 Path 컨트롤의 속성명이 WPF와 다름
- WPF: `StrokeLineJoin`
- AvaloniaUI: `StrokeJoin`

**Fix**:
```xml
<!-- Before -->
<Path StrokeLineJoin="Round" ... />

<!-- After -->
<Path StrokeJoin="Round" ... />
```

### Error 2: ResourceDictionary vs IStyle Type Mismatch

**Error Message**:
```
Avalonia error AVLN2000: Resource "avares://QuietHorse20.Avalonia.Lib/Themes/Generic.axaml" is defined as "Avalonia.Controls.ResourceDictionary" type in the "QuietHorse20.Avalonia.Lib" assembly, but expected "Avalonia.Styling.IStyle".
```

**Cause**:
- AvaloniaUI에서 `StyleInclude`는 IStyle 타입만 허용
- ResourceDictionary는 `ResourceInclude`를 사용해야 함

**Fix**:
```xml
<!-- Before -->
<Application.Styles>
    <FluentTheme/>
    <StyleInclude Source="avares://QuietHorse20.Avalonia.Lib/Themes/Generic.axaml"/>
</Application.Styles>

<!-- After -->
<Application.Styles>
    <FluentTheme/>
</Application.Styles>
<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceInclude Source="avares://QuietHorse20.Avalonia.Lib/Themes/Generic.axaml"/>
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

## CSS to AXAML Conversion Details

### Linear Gradient Conversion

**CSS**:
```css
background: linear-gradient(to bottom, #dadada 0%, #eeeeee 25%, #ffffff 100%);
```

**AXAML**:
```xml
<LinearGradientBrush StartPoint="0%,0%" EndPoint="0%,100%">
    <GradientStop Color="#DADADA" Offset="0"/>
    <GradientStop Color="#EEEEEE" Offset="0.25"/>
    <GradientStop Color="#FFFFFF" Offset="1"/>
</LinearGradientBrush>
```

### Box Shadow Conversion

**CSS**:
```css
box-shadow: 4px 2px 10px -1px rgba(12, 12, 12, 0.6);
```

**AXAML**:
```xml
<Border BoxShadow="4 2 10 -1 #990C0C0C">
```

Note: AvaloniaUI BoxShadow format is `offsetX offsetY blur spread color`

### Hover/Active State Conversion

**CSS**:
```css
.container:hover { box-shadow: 1px 0px 3px 0px rgba(12, 12, 12, 0.6); }
.container:active { box-shadow: 0.5px 0px 1px 0px rgba(12, 12, 12, 0.6); }
```

**AXAML**:
```xml
<Style Selector="^:pointerover /template/ Border#Container">
    <Setter Property="BoxShadow" Value="1 0 3 0 #990C0C0C"/>
</Style>
<Style Selector="^:pressed /template/ Border#Container">
    <Setter Property="BoxShadow" Value="0 0 1 0 #990C0C0C"/>
</Style>
```

## Potential Runtime Issues

### 1. SVG Path Rendering
- **Issue**: SVG Path가 복잡한 경우 렌더링이 다를 수 있음
- **Check Required**: Paper Plane 아이콘이 의도대로 렌더링되는지 확인 필요

### 2. BoxShadow Spread Value
- **Issue**: AvaloniaUI BoxShadow의 spread 값이 음수(-1)인 경우 CSS와 다르게 렌더링될 수 있음
- **Check Required**: 그림자 효과가 원본과 동일한지 확인 필요

### 3. Animation Transitions
- **Issue**: 원본 CSS에는 `transition: all 0.3s`가 있으나, AvaloniaUI에서는 별도 Animation 구현 필요
- **Current Status**: 애니메이션 미구현 (즉각적인 상태 변화)
- **Enhancement Suggestion**: hover/pressed 상태 전환에 Animation 추가 가능

## Build Result

- **Status**: SUCCESS
- **Warnings**: 0
- **Errors**: 0 (after fixes)
