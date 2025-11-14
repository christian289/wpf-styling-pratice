# Modern UI Controls

A modern, customizable WPF custom control library with beautiful styling and smooth animations.

## Features

### 🎨 Modern Color Palette
- Primary, Success, Warning, Danger color schemes
- Consistent design language across all controls
- Gradient support for progress bars

### 🎯 Available Controls

#### ModernButton
- Multiple styles: Primary, Success, Warning, Danger, Outline
- Icon support
- Hover and press animations
- Shadow effects
- Customizable corner radius

**Properties:**
- `ButtonStyle`: Primary, Success, Warning, Danger, Outline
- `CornerRadius`: Custom corner radius (default: 8)
- `Icon`: Icon text/emoji

#### ModernTextBox
- Placeholder text support
- Icon support
- Focus animations
- Smooth border transitions
- Customizable corner radius

**Properties:**
- `Placeholder`: Placeholder text
- `Icon`: Icon text/emoji
- `CornerRadius`: Custom corner radius (default: 8)

#### ModernToggleSwitch
- Smooth slide animation
- Custom ON/OFF text
- Hover effects
- Shadow effects

**Properties:**
- `OnText`: Text when checked (default: "ON")
- `OffText`: Text when unchecked (default: "OFF")

#### ModernCard
- Elevation/shadow effects
- Hover animations
- Optional header
- Customizable corner radius

**Properties:**
- `Header`: Card header content
- `CornerRadius`: Custom corner radius (default: 12)
- `Elevation`: Shadow blur radius (default: 4)
- `IsHoverable`: Enable hover effect (default: true)

#### ModernProgressBar
- Gradient fill
- Percentage display option
- Smooth animations
- Custom colors
- Customizable corner radius

**Properties:**
- `CornerRadius`: Custom corner radius (default: 10)
- `ProgressColor`: Custom progress bar color
- `ShowPercentage`: Display percentage text (default: false)

## Installation

1. Build the ModernUIControls project
2. Reference the library in your WPF application
3. Add the resource dictionary to your App.xaml

```xml
<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceDictionary Source="pack://application:,,,/ModernUIControls;component/Themes/Generic.xaml"/>
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

## Usage

### XAML Namespace
```xml
xmlns:ui="clr-namespace:ModernUIControls;assembly=ModernUIControls"
```

### Examples

#### Button
```xml
<ui:ModernButton Content="Click Me"
                 ButtonStyle="Primary"
                 Click="Button_Click"/>
```

#### TextBox
```xml
<ui:ModernTextBox Placeholder="Enter your name..."
                  Width="300"/>
```

#### Toggle Switch
```xml
<ui:ModernToggleSwitch IsChecked="True"
                       OnText="ON"
                       OffText="OFF"/>
```

#### Card
```xml
<ui:ModernCard Elevation="8">
    <StackPanel>
        <TextBlock Text="Card Title" FontSize="18" FontWeight="SemiBold"/>
        <TextBlock Text="Card content goes here..." />
    </StackPanel>
</ui:ModernCard>
```

#### Progress Bar
```xml
<ui:ModernProgressBar Value="75"
                      Maximum="100"
                      ShowPercentage="True"
                      Height="24"/>
```

## Color Palette

- **Primary**: #6C5CE7 (Purple)
- **Accent**: #00CEC9 (Turquoise)
- **Success**: #00B894 (Green)
- **Warning**: #FDCB6E (Yellow)
- **Danger**: #FF7675 (Red)
- **Dark**: #2D3436
- **Light**: #DFE6E9
- **Background**: #F8F9FA
- **Surface**: #FFFFFF

## Building

```bash
cd ModernUIControls/ModernUIControls
dotnet build
```

## Gallery Application

The ModernUIGallery project provides a comprehensive showcase of all available controls with various configurations and examples. Run the gallery to see all controls in action.

```bash
cd ModernUIGallery/ModernUIGallery
dotnet run
```

## Requirements

- .NET 9.0 or higher
- WPF

## License

This project is open source and available for use in your projects.
