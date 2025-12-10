# UI Components by Sweta Shah (Behance)

A modern, customizable WPF custom control library with beautiful styling and smooth animations.

## Solution Structure

```
UIComponentsBySwetaShahWithBehance/
├── UIComponentsBySwetaShahWithBehance.slnx                    # Solution file
├── UIComponentsBySwetaShahWithBehanceLibrary/                 # Custom control library
│   ├── UIComponentsBySwetaShahWithBehanceButton.cs
│   ├── UIComponentsBySwetaShahWithBehanceTextBox.cs
│   ├── UIComponentsBySwetaShahWithBehanceToggleSwitch.cs
│   ├── UIComponentsBySwetaShahWithBehanceCard.cs
│   ├── UIComponentsBySwetaShahWithBehanceProgressBar.cs
│   ├── Converters/
│   │   └── ValueConverters.cs
│   ├── Themes/
│   │   └── Generic.xaml
│   └── UIComponentsBySwetaShahWithBehanceLibrary.csproj
├── UIComponentsBySwetaShahWithBehanceGallery/                 # Gallery application
│   ├── App.xaml
│   ├── MainWindow.xaml
│   └── UIComponentsBySwetaShahWithBehanceGallery.csproj
└── README.md
```

## Features

### 🎨 Modern Color Palette
- Primary, Success, Warning, Danger color schemes
- Consistent design language across all controls
- Gradient support for progress bars

### 🎯 Available Controls

#### UIComponentsBySwetaShahWithBehanceButton
- Multiple styles: Primary, Success, Warning, Danger, Outline
- Icon support
- Hover and press animations
- Shadow effects
- Customizable corner radius

**Properties:**
- `ButtonStyle`: Primary, Success, Warning, Danger, Outline
- `CornerRadius`: Custom corner radius (default: 8)
- `Icon`: Icon text/emoji

#### UIComponentsBySwetaShahWithBehanceTextBox
- Placeholder text support
- Icon support
- Focus animations
- Smooth border transitions
- Customizable corner radius

**Properties:**
- `Placeholder`: Placeholder text
- `Icon`: Icon text/emoji
- `CornerRadius`: Custom corner radius (default: 8)

#### UIComponentsBySwetaShahWithBehanceToggleSwitch
- Smooth slide animation
- Custom ON/OFF text
- Hover effects
- Shadow effects

**Properties:**
- `OnText`: Text when checked (default: "ON")
- `OffText`: Text when unchecked (default: "OFF")

#### UIComponentsBySwetaShahWithBehanceCard
- Elevation/shadow effects
- Hover animations
- Optional header
- Customizable corner radius

**Properties:**
- `Header`: Card header content
- `CornerRadius`: Custom corner radius (default: 12)
- `Elevation`: Shadow blur radius (default: 4)
- `IsHoverable`: Enable hover effect (default: true)

#### UIComponentsBySwetaShahWithBehanceProgressBar
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

1. Build the UIComponentsBySwetaShahWithBehanceControls project
2. Reference the library in your WPF application
3. Add the resource dictionary to your App.xaml

```xml
<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceDictionary Source="pack://application:,,,/UIComponentsBySwetaShahWithBehanceControls;component/Themes/Generic.xaml"/>
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

## Usage

### XAML Namespace
```xml
xmlns:ui="clr-namespace:UIComponentsBySwetaShahWithBehanceControls;assembly=UIComponentsBySwetaShahWithBehanceControls"
```

### Examples

#### Button
```xml
<ui:UIComponentsBySwetaShahWithBehanceButton Content="Click Me"
                 ButtonStyle="Primary"
                 Click="Button_Click"/>
```

#### TextBox
```xml
<ui:UIComponentsBySwetaShahWithBehanceTextBox Placeholder="Enter your name..."
                  Width="300"/>
```

#### Toggle Switch
```xml
<ui:UIComponentsBySwetaShahWithBehanceToggleSwitch IsChecked="True"
                       OnText="ON"
                       OffText="OFF"/>
```

#### Card
```xml
<ui:UIComponentsBySwetaShahWithBehanceCard Elevation="8">
    <StackPanel>
        <TextBlock Text="Card Title" FontSize="18" FontWeight="SemiBold"/>
        <TextBlock Text="Card content goes here..." />
    </StackPanel>
</ui:UIComponentsBySwetaShahWithBehanceCard>
```

#### Progress Bar
```xml
<ui:UIComponentsBySwetaShahWithBehanceProgressBar Value="75"
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

### Build the entire solution
```bash
cd UIComponentsBySwetaShahWithBehance
dotnet build UIComponentsBySwetaShahWithBehance.slnx
```

### Build individual projects
```bash
# Build controls library
cd UIComponentsBySwetaShahWithBehance/UIComponentsBySwetaShahWithBehanceControls
dotnet build

# Build gallery application
cd UIComponentsBySwetaShahWithBehance/UIComponentsBySwetaShahWithBehanceGallery
dotnet build
```

## Gallery Application

The UIComponentsBySwetaShahWithBehanceGallery project provides a comprehensive showcase of all available controls with various configurations and examples. Run the gallery to see all controls in action.

```bash
cd UIComponentsBySwetaShahWithBehance/UIComponentsBySwetaShahWithBehanceGallery
dotnet run
```

## Opening in Visual Studio

Open `UIComponentsBySwetaShahWithBehance.slnx` in Visual Studio 2022 or later to work with both projects in a single solution.

## Requirements

- .NET 9.0 or higher
- WPF

## License

This project is open source and available for use in your projects.
