---
description: HTML/CSS to AvaloniaUI AXAML conversion command
allowed-tools: Bash(find:*), Bash(ls:*), Bash(cat:*), Read
argument-hint: <HTML file path> [CSS file path]
---

# HTML/CSS to AvaloniaUI AXAML Conversion

## Argument Information

- Received arguments: $ARGUMENTS
- Argument format: `<HTML file> [CSS file]`
  - 1st argument (required): HTML file path (.html extension)
  - 2nd argument (optional): CSS file path (.css extension)

## Execution Procedure

### Step 1: Argument Parsing and Validation

- Parse arguments by splitting with spaces
- If 1st argument is missing, output error message and abort
- Verify HTML file existence
- If 2nd argument exists, verify CSS file existence

### Step 2: Read and Analyze Source Files
```bash
# Read HTML file
cat {HTML_FILE_PATH}

# Read CSS file if provided
cat {CSS_FILE_PATH}
```

### Step 3: HTML to AXAML Conversion

#### 3.1 Element Mapping Rules

| HTML Element | AvaloniaUI Control |
|--------------|-------------------|
| `<div>` | `<Border>` or `<Panel>` or `<StackPanel>` or `<Grid>` |
| `<span>` | `<TextBlock>` |
| `<p>` | `<TextBlock>` |
| `<h1>`~`<h6>` | `<TextBlock>` with FontSize |
| `<button>` | `<Button>` |
| `<input type="text">` | `<TextBox>` |
| `<input type="checkbox">` | `<CheckBox>` |
| `<input type="radio">` | `<RadioButton>` |
| `<select>` | `<ComboBox>` |
| `<textarea>` | `<TextBox AcceptsReturn="True">` |
| `<img>` | `<Image>` |
| `<a>` | `<Button>` or `<HyperlinkButton>` |
| `<ul>`, `<ol>` | `<ItemsControl>` or `<ListBox>` |
| `<li>` | `<ListBoxItem>` or item template |
| `<table>` | `<DataGrid>` or `<Grid>` |
| `<label>` | `<TextBlock>` or `<Label>` |
| `<form>` | `<StackPanel>` or `<Grid>` |
| `<header>`, `<footer>`, `<section>` | `<Border>` or `<DockPanel>` |
| `<nav>` | `<StackPanel Orientation="Horizontal">` |
| `<svg>` | `<Path>` or `<DrawingImage>` |

#### 3.2 Layout Conversion Rules

| CSS Layout | AvaloniaUI Layout |
|------------|-------------------|
| `display: flex; flex-direction: row` | `<StackPanel Orientation="Horizontal">` |
| `display: flex; flex-direction: column` | `<StackPanel Orientation="Vertical">` |
| `display: grid` | `<Grid>` with RowDefinitions/ColumnDefinitions |
| `position: absolute` | `<Canvas>` with Canvas.Left/Top |
| `position: relative` | `<Panel>` or `<Grid>` |

#### 3.3 CSS to AXAML Property Mapping

| CSS Property | AvaloniaUI Property |
|--------------|---------------------|
| `color` | `Foreground` |
| `background-color` | `Background` |
| `background: linear-gradient(...)` | `<LinearGradientBrush>` |
| `background: radial-gradient(...)` | `<RadialGradientBrush>` (Note: Differs from WPF) |
| `border` | `BorderBrush`, `BorderThickness` |
| `border-radius` | `CornerRadius` |
| `padding` | `Padding` |
| `margin` | `Margin` |
| `width` | `Width` |
| `height` | `Height` |
| `min-width` | `MinWidth` |
| `max-width` | `MaxWidth` |
| `font-size` | `FontSize` |
| `font-weight` | `FontWeight` |
| `font-family` | `FontFamily` |
| `text-align` | `TextAlignment` or `HorizontalContentAlignment` |
| `opacity` | `Opacity` |
| `cursor: pointer` | `Cursor="Hand"` |
| `overflow: hidden` | `ClipToBounds="True"` |
| `box-shadow` | `<BoxShadow>` or `Effect` |

#### 3.4 CSS Pseudo-class to AvaloniaUI Pseudo-class Mapping

| CSS Pseudo-class | AvaloniaUI Selector |
|------------------|---------------------|
| `:hover` | `:pointerover` |
| `:active` | `:pressed` |
| `:focus` | `:focus` |
| `:disabled` | `:disabled` |
| `:checked` | `:checked` |
| `:first-child` | `:nth-child(1)` |
| `:last-child` | `:nth-last-child(1)` |

#### 3.5 CSS Unit Conversion

| CSS Unit | AvaloniaUI Value |
|----------|------------------|
| `px` | Direct numeric value (device-independent pixels) |
| `em`, `rem` | Calculate relative to base font size (default 12) |
| `%` | Use `*` in Grid or binding |
| `vw`, `vh` | Use binding to window size |
| `auto` | `Auto` in Grid, `NaN` for Width/Height |

### Step 4: Generate Output Structure

#### 4.1 Output File Format

Generate two separate outputs:

**1. Resource Dictionary (for reusable styles/themes)**
```xml
<ResourceDictionary xmlns="https://github.com/avaloniaui"
                    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">
    
    <!-- Color Resources -->
    <Color x:Key="Primary.Color">#3498db</Color>
    <SolidColorBrush x:Key="Primary.Brush" Color="{StaticResource Primary.Color}"/>
    
    <!-- Size Resources -->
    <x:Double x:Key="Control.CornerRadius">8</x:Double>
    <Thickness x:Key="Control.Padding">16,8</Thickness>
    
    <!-- Styles -->
    <Style Selector="Button.primary">
        <Setter Property="Background" Value="{StaticResource Primary.Brush}"/>
        <Setter Property="Foreground" Value="White"/>
        <Setter Property="Padding" Value="{StaticResource Control.Padding}"/>
        <Setter Property="CornerRadius" Value="{StaticResource Control.CornerRadius}"/>
    </Style>
    
    <!-- Hover State -->
    <Style Selector="Button.primary:pointerover">
        <Setter Property="Background" Value="#2980b9"/>
    </Style>
    
</ResourceDictionary>
```

**2. Control AXAML (for layout structure)**
```xml
<UserControl xmlns="https://github.com/avaloniaui"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             x:Class="YourNamespace.ConvertedControl">
    
    <!-- Converted layout structure -->
    <Border Background="{StaticResource Primary.Brush}"
            CornerRadius="8"
            Padding="16">
        <StackPanel Spacing="8">
            <TextBlock Text="Title" FontSize="24" FontWeight="Bold"/>
            <Button Classes="primary" Content="Click Me"/>
        </StackPanel>
    </Border>
    
</UserControl>
```

### Step 5: Special Conversion Cases

#### 5.1 Flexbox to AvaloniaUI

**CSS Flexbox:**
```css
.container {
    display: flex;
    justify-content: space-between;
    align-items: center;
    gap: 10px;
}
```

**AvaloniaUI Equivalent:**
```xml
<Grid ColumnDefinitions="Auto,*,Auto">
    <ContentControl Grid.Column="0" Content="{...}"/>
    <ContentControl Grid.Column="2" Content="{...}"/>
</Grid>
<!-- Or use DockPanel -->
<DockPanel>
    <ContentControl DockPanel.Dock="Left"/>
    <ContentControl DockPanel.Dock="Right"/>
    <ContentControl/> <!-- Fills remaining space -->
</DockPanel>
```

#### 5.2 CSS Grid to AvaloniaUI Grid

**CSS Grid:**
```css
.grid {
    display: grid;
    grid-template-columns: 1fr 2fr 1fr;
    grid-template-rows: auto 1fr auto;
    gap: 10px;
}
```

**AvaloniaUI Equivalent:**
```xml
<Grid ColumnDefinitions="*,2*,*"
      RowDefinitions="Auto,*,Auto">
    <Grid.Styles>
        <Style Selector="Grid > Control">
            <Setter Property="Margin" Value="5"/>
        </Style>
    </Grid.Styles>
    <!-- Grid children with Grid.Row and Grid.Column -->
</Grid>
```

#### 5.3 CSS Animation to AvaloniaUI Animation

**CSS Animation:**
```css
.button:hover {
    transform: scale(1.05);
    transition: transform 0.2s ease;
}
```

**AvaloniaUI Equivalent:**
```xml
<Style Selector="Button:pointerover">
    <Style.Animations>
        <Animation Duration="0:0:0.2" Easing="QuadraticEaseOut">
            <KeyFrame Cue="100%">
                <Setter Property="RenderTransform">
                    <ScaleTransform ScaleX="1.05" ScaleY="1.05"/>
                </Setter>
            </KeyFrame>
        </Animation>
    </Style.Animations>
</Style>
```

#### 5.4 Box Shadow to AvaloniaUI

**CSS:**
```css
.card {
    box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
}
```

**AvaloniaUI Equivalent:**
```xml
<Border BoxShadow="0 4 6 #1A000000">
    <!-- Content -->
</Border>
```

### Step 6: Report Results

Output the conversion results in the following format:

1. **Resource Dictionary AXAML** - Contains all extracted colors, brushes, sizes, and reusable styles
2. **Control AXAML** - Contains the converted layout structure
3. **Conversion Notes** - List of manual adjustments that may be needed
4. **Usage Instructions** - How to integrate the converted AXAML into an AvaloniaUI project

## Common Conversion Mistakes to Avoid

1. **RadialGradientBrush Differences**: AvaloniaUI's RadialGradientBrush uses different coordinate system than CSS
2. **Pseudo-class Syntax**: Use `:pointerover` instead of `:hover`
3. **Namespace**: Always use `https://github.com/avaloniaui` as default namespace
4. **Style Selector**: AvaloniaUI uses CSS-like selectors, not `TargetType` like WPF
5. **CornerRadius**: Can be specified as single value or `TopLeft,TopRight,BottomRight,BottomLeft`
6. **Margin/Padding**: Order is `Left,Top,Right,Bottom` (differs from CSS `Top,Right,Bottom,Left`)

## Usage Examples
```bash
# Basic HTML conversion
/project:html-to-avalonia ./designs/card.html

# HTML with CSS file
/project:html-to-avalonia ./designs/card.html ./designs/styles.css
```

## Integration Guide

After conversion, integrate the output:

1. **Add Resource Dictionary to App.axaml:**
```xml
<Application.Styles>
    <FluentTheme/>
    <StyleInclude Source="/Styles/ConvertedStyles.axaml"/>
</Application.Styles>
```

2. **Or merge into Window/UserControl:**
```xml
<Window.Styles>
    <StyleInclude Source="/Styles/ConvertedStyles.axaml"/>
</Window.Styles>
```