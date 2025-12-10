# Neumorphism - WPF Soft UI Library

A modern WPF control library featuring Neumorphism (Soft UI) design - the 2021 UI trend characterized by soft, extruded surfaces with subtle 3D effects.

## Overview

Neumorphism creates a subtle, three-dimensional appearance by using dual shadow systems. Elements appear to extrude from or press into the background, creating a soft, tactile interface.

## Key Features

### Design Principles

- **Dual Shadow System**: Combines light and dark shadows to create depth
  - Light shadow: `#FFFFFF` (top-left, 315°)
  - Dark shadow: `#A3B1C6` (bottom-right, 135°)
- **Light Background**: Uses `#E0E5EC` for optimal contrast
- **Soft Rounded Corners**: Large border radius (15-20px) enhances the effect
- **3D Depth**: Elements appear raised or pressed into the surface

### Interaction States

| State | Effect | Shadow Direction |
|-------|--------|------------------|
| **Default** | Raised/Extruded | Light: 315°, Dark: 135° |
| **Hover** | Enhanced depth | Increased blur radius |
| **Pressed** | Inset/Depressed | Light: 135°, Dark: 315° (reversed) |
| **Focus** | Accent highlight | Colored shadow overlay |

### Styled Controls

All basic WPF controls feature neumorphic styling:

| Control | Neumorphism Effect |
|---------|-------------------|
| **Button** | Raised with dual shadows, inset when pressed |
| **ToggleButton** | Toggles between raised and pressed states |
| **TextBox** | Inset appearance with inner shadows |
| **CheckBox** | Soft square with elevated checkmark |
| **RadioButton** | Soft circle with elevated indicator |
| **ProgressBar** | Inset track with elevated progress |
| **Slider** | Inset track with raised thumb |
| **ComboBox** | Raised container with elevated dropdown |
| **ListBox** | Inset container with accent selection |
| **TabControl** | Raised tabs with inset content area |
| **TabItem** | Pressed when selected, raised otherwise |
| **GroupBox** | Raised container with soft borders |

## Project Structure

```
Neumorphism/
├── Neumorphism.slnx                    # Solution file
├── NeumorphismLib/                     # Control library
│   ├── Themes/
│   │   └── Generic.xaml                # All neumorphic styles
│   └── NeumorphismLib.csproj
├── NeumorphismGallery/                 # Demo application
│   ├── App.xaml
│   ├── App.xaml.cs
│   ├── MainWindow.xaml                 # Interactive gallery
│   ├── MainWindow.xaml.cs
│   └── NeumorphismGallery.csproj
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
cd Neumorphism

# Restore and build
dotnet restore
dotnet build
```

### Running the Gallery

```bash
# Run the gallery application
cd NeumorphismGallery
dotnet run
```

Or open `Neumorphism.slnx` in Visual Studio 2022+ and run the NeumorphismGallery project.

## Usage

### In Your Own Project

1. Reference the NeumorphismLib project or DLL
2. Merge the resource dictionary in your App.xaml:

```xml
<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceDictionary Source="pack://application:,,,/NeumorphismLib;component/Themes/Generic.xaml"/>
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

3. Set your window/app background to the neumorphic color:

```xml
<Window Background="#E0E5EC">
    <!-- Your content -->
</Window>
```

4. Use standard WPF controls - they'll automatically have neumorphic styling!

```xml
<Button Content="Click Me" Padding="24,12"/>
<TextBox Padding="12,10"/>
<CheckBox Content="Enable feature"/>
```

## Technical Implementation

### Shadow System

Neumorphism uses WPF's `DropShadowEffect` with specific parameters:

```xml
<!-- Light Shadow (raised elements) -->
<DropShadowEffect ShadowDepth="0"
                  Direction="315"
                  Color="#FFFFFF"
                  BlurRadius="15"
                  Opacity="1"/>

<!-- Dark Shadow (raised elements) -->
<DropShadowEffect ShadowDepth="0"
                  Direction="135"
                  Color="#A3B1C6"
                  BlurRadius="15"
                  Opacity="0.8"/>
```

### State Transitions

Pressed states reverse the shadow directions to create an inset effect:

```xml
<!-- Pressed State -->
<Trigger Property="IsPressed" Value="True">
    <Setter Property="Direction" Value="135"/>  <!-- Light shadow flips -->
    <Setter Property="Direction" Value="315"/>  <!-- Dark shadow flips -->
</Trigger>
```

## Color Palette

```
Background:     #E0E5EC  (Light gray-blue)
Light Shadow:   #FFFFFF  (White)
Dark Shadow:    #A3B1C6  (Blue-gray)
Text:           #4A5568  (Dark gray)
Accent:         #6366F1  (Indigo)
Secondary Text: #718096  (Medium gray)
```

## Design Guidelines

### Best Practices

✅ **Do:**
- Use on light backgrounds (#E0E5EC or similar)
- Keep shadow blur radius between 10-20px
- Use consistent corner radius (12-20px)
- Maintain sufficient color contrast for accessibility
- Use for modern, minimalist interfaces

❌ **Don't:**
- Use on dark backgrounds (won't work)
- Mix with other design systems (skeuomorphism, flat design)
- Overuse - can be visually overwhelming
- Use for small elements (minimum 24x24px)
- Ignore accessibility concerns (low contrast)

### Accessibility Considerations

Neumorphism can present accessibility challenges:
- Low contrast between elements and background
- Difficult to distinguish for users with visual impairments
- Always test with accessibility tools
- Consider providing a high-contrast mode

## Gallery Features

The NeumorphismGallery application showcases:

- **Interactive Navigation**: Soft UI sidebar with categorized sections
- **Categorized Controls**:
  - Buttons (raised and pressed states)
  - Input Controls (inset text fields)
  - Selection Controls (checkboxes, radios, dropdowns)
  - Navigation (tabs with state changes)
  - Progress & Sliders (mixed inset/raised)
  - All Controls Overview
- **Live Demonstrations**: Interact with every control to see state changes
- **Design Explanations**: Learn about shadow systems and 3D effects

## Browser Support

The library styles these WPF controls:

- Button
- ToggleButton
- TextBox
- CheckBox
- RadioButton
- ComboBox / ComboBoxItem
- ListBox / ListBoxItem
- TabControl / TabItem
- ProgressBar
- Slider
- Label
- GroupBox

## History & Inspiration

Neumorphism (New + Skeuomorphism) emerged in 2020-2021 as a design trend:
- Popularized by designer Alexander Plyuto
- Also called "Soft UI"
- Inspired by iOS design and skeuomorphism
- Creates a soft, extruded plastic appearance
- Peak popularity: 2021

## License

This is a demonstration project for WPF styling and neumorphic design patterns.

## References

- [Neumorphism UI](https://neumorphism.io/) - Shadow generator
- [Dribbble: Neumorphism](https://dribbble.com/tags/neumorphism) - Design inspiration
- [UX Design: Neumorphism](https://uxdesign.cc/neumorphism-in-user-interfaces-b47cef3bf3a6) - Design article

---

**Built with .NET 9.0 and WPF**

*Demonstrating 2021's Soft UI trend with subtle 3D effects and dual shadow systems*
