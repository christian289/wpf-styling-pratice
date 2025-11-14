# MicroInteractions - WPF Animation Library

A modern WPF control library featuring 2020-era micro-interaction animation patterns, specifically **Menu Conversion Animation** and **Navigation Activate Animation**.

## Overview

MicroInteractions brings delightful, subtle animations to standard WPF controls, enhancing user experience through carefully crafted motion design. Every interaction provides visual feedback through smooth, professionally designed animations.

## Key Features

### 2020 Animation Patterns

- **Menu Conversion Animation**: Smooth morphing transitions for menu items and interactive elements
- **Navigation Activate Animation**: Animated indicators that slide to show active navigation items (featured in TabControl)

### Animated Controls

All basic WPF controls include micro-interactions:

| Control | Animation Type | Easing Function |
|---------|---------------|-----------------|
| **Button** | Ripple effect + Scale | CubicEase |
| **ToggleButton** | 360° Flip rotation | BackEase |
| **CheckBox** | 360° Rotation spin | BackEase |
| **RadioButton** | Elastic bounce | ElasticEase |
| **TextBox** | Focus scale | CubicEase |
| **ComboBox** | Dropdown scale + Arrow rotation | BackEase |
| **ComboBoxItem** | Slide-in (TranslateTransform) | CubicEase |
| **ListBox** | Hover scale | - |
| **ListBoxItem** | Slide-in (TranslateTransform) | CubicEase |
| **TabControl** | Bottom indicator slide | BackEase |
| **TabItem** | Indicator scale | CubicEase |
| **ProgressBar** | Smooth fill | - |
| **Slider** | Thumb scale on hover | BackEase |

## Project Structure

```
MicroInteractions/
├── MicroInteractions.slnx              # Solution file
├── MicroInteractionsLib/               # Control library
│   ├── Themes/
│   │   └── Generic.xaml                # All control styles and animations
│   └── MicroInteractionsLib.csproj
├── MicroInteractionsGallery/           # Demo application
│   ├── App.xaml
│   ├── App.xaml.cs
│   ├── MainWindow.xaml                 # Interactive gallery showcase
│   ├── MainWindow.xaml.cs
│   └── MicroInteractionsGallery.csproj
└── README.md
```

## Getting Started

### Prerequisites

- .NET 9.0 SDK
- Visual Studio 2022 or later (for .slnx support)
- Windows OS

### Building the Project

```bash
# Navigate to the solution directory
cd MicroInteractions

# Restore and build
dotnet restore
dotnet build
```

### Running the Gallery

```bash
# Run the gallery application
cd MicroInteractionsGallery
dotnet run
```

Or open `MicroInteractions.slnx` in Visual Studio 2022+ and run the MicroInteractionsGallery project.

## Usage

### In Your Own Project

1. Reference the MicroInteractionsLib project or DLL
2. Merge the resource dictionary in your App.xaml:

```xml
<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceDictionary Source="pack://application:,,,/MicroInteractionsLib;component/Themes/Generic.xaml"/>
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

3. Use standard WPF controls - they'll automatically have animations!

```xml
<Button Content="Click Me!" Padding="20,10"/>
<TabControl>
    <TabItem Header="Home">
        <!-- Content -->
    </TabItem>
    <TabItem Header="Profile">
        <!-- Content -->
    </TabItem>
</TabControl>
```

## Animation Details

### Ripple Effect (Button)
- Expands from click point
- Fades out smoothly
- Duration: 600ms
- Uses Ellipse geometry for circular ripple

### Navigation Activate Animation (TabControl)
- Bottom indicator bar slides to active tab
- BackEase easing for smooth deceleration
- Duration: 300ms
- Clear visual feedback for tab switching

### Rotation Animations
- **CheckBox**: 360° spin when checked/unchecked
- **ToggleButton**: 360° flip on toggle
- Both use BackEase for satisfying motion

### Elastic Bounce (RadioButton)
- ElasticEase with Oscillations=2, Springiness=3
- Duration: 400ms
- Playful feedback on selection

### Slide-in Animations (ComboBoxItem, ListBoxItem)
- TranslateTransform from left (-20px)
- Fade in simultaneously
- Duration: 250ms
- Staggered effect for lists

## Color Palette

- **Primary**: `#3B82F6` (Blue)
- **Accent**: `#8B5CF6` (Purple)
- **Success**: `#10B981` (Green)
- **Warning**: `#F59E0B` (Orange)
- **Danger**: `#EF4444` (Red)
- **Background**: `#0A0A0A` (Near Black)
- **Surface**: `#1A1A1A` (Dark Gray)
- **Border**: `#2A2A2A` (Medium Gray)

## Gallery Features

The MicroInteractionsGallery application showcases:

- **Interactive Navigation**: Left sidebar with menu conversion animations
- **Categorized Sections**:
  - Buttons
  - Input Controls
  - Selection Controls
  - Navigation (TabControl showcase)
  - Progress & Sliders
  - All Controls Overview
- **Live Demos**: Interact with every control to see animations in action
- **Code-Free**: All animations are automatic through styling

## Technical Implementation

- **Storyboards**: For complex multi-property animations
- **Triggers**: Property and Event triggers for interaction-based animations
- **RenderTransforms**: ScaleTransform, RotateTransform, TranslateTransform for smooth animations
- **Easing Functions**: BackEase, ElasticEase, CubicEase for natural motion
- **Templates**: Full ControlTemplate overrides for complete visual control

## Browser

The library automatically styles these WPF controls:

- Button
- ToggleButton
- CheckBox
- RadioButton
- TextBox
- ComboBox / ComboBoxItem
- ListBox / ListBoxItem
- TabControl / TabItem
- ProgressBar
- Slider
- Label
- GroupBox

## License

This is a demonstration project for WPF styling and animation patterns.

## Inspiration

Based on 2020-era micro-interaction design patterns that emphasize:
- Clear visual feedback
- Smooth, natural motion
- Subtle but noticeable animations
- Enhanced user experience through motion design
- Menu conversion and navigation activate patterns

---

**Built with .NET 9.0 and WPF**
