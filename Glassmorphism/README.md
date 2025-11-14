# Glassmorphism WPF Control Library

A comprehensive WPF control library featuring modern glassmorphism design - semi-transparent, frosted glass effects with elegant styling for all basic WPF controls.

## 🎨 What is Glassmorphism?

Glassmorphism is a cutting-edge UI design trend characterized by:
- **Semi-transparent backgrounds** (40-80% opacity) with blur effects
- **Subtle borders** with light, semi-transparent colors
- **Layered approach** creating depth and visual hierarchy
- **Vibrant gradient backgrounds** that show through the glass effect
- **Soft shadows** for elevation and depth

## 📦 Solution Structure

```
Glassmorphism/
├── Glassmorphism.slnx              # Solution file
├── GlassmorphismLib/               # Control library
│   ├── Themes/
│   │   └── Generic.xaml            # All control styles
│   └── GlassmorphismLib.csproj
├── GlassmorphismGallery/           # Demo application
│   ├── App.xaml
│   ├── MainWindow.xaml
│   └── GlassmorphismGallery.csproj
└── README.md
```

## 🎯 Styled Controls

All basic WPF controls are styled with glassmorphism design:

### ✅ Included Controls:
1. **Button** - Glass buttons with hover/press animations
2. **TextBox** - Semi-transparent text inputs with focus glow
3. **CheckBox** - Glass checkboxes with smooth check animation
4. **RadioButton** - Glass radio buttons with circular indicators
5. **ProgressBar** - Glass progress bars with gradient fill
6. **Slider** - Glass sliders with elegant thumb control
7. **Label** - Styled labels for text display
8. **ComboBox** - Dropdown with glass popup
9. **ListBox** - Glass list container with selectable items
10. **TabControl** - Glass tabs with smooth transitions
11. **GroupBox** - Glass containers for grouping controls
12. **ToggleButton** - Glass toggle buttons for on/off states

## 🚀 Quick Start

### 1. Installation

Add a reference to `GlassmorphismLib` in your WPF project.

### 2. Merge Resource Dictionary

Add to your `App.xaml`:

```xml
<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceDictionary Source="pack://application:,,,/GlassmorphismLib;component/Themes/Generic.xaml"/>
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

### 3. Use the Controls

All standard WPF controls will automatically use the glassmorphism style:

```xml
<Button Content="Glass Button"/>
<TextBox Text="Glass TextBox"/>
<CheckBox Content="Glass CheckBox"/>
<ProgressBar Value="75" Maximum="100"/>
```

## 💡 Usage Examples

### Button
```xml
<Button Content="Click Me" Padding="20,10"/>
<Button Content="Large Button" FontSize="16" Padding="28,14"/>
<Button Content="Disabled" IsEnabled="False"/>
```

### TextBox
```xml
<TextBox Width="300" Height="35"/>
<TextBox Text="Disabled Input" IsEnabled="False"/>
```

### CheckBox
```xml
<CheckBox Content="Enable notifications"/>
<CheckBox Content="Auto-save" IsChecked="True"/>
```

### RadioButton
```xml
<RadioButton Content="Option 1" GroupName="Options"/>
<RadioButton Content="Option 2" GroupName="Options" IsChecked="True"/>
```

### ProgressBar
```xml
<ProgressBar Value="45" Maximum="100" Height="20"/>
<ProgressBar Value="75" Maximum="100" Height="24"/>
```

### Slider
```xml
<Slider Minimum="0" Maximum="100" Value="50"/>
```

### ComboBox
```xml
<ComboBox Width="300">
    <ComboBoxItem Content="Item 1" IsSelected="True"/>
    <ComboBoxItem Content="Item 2"/>
    <ComboBoxItem Content="Item 3"/>
</ComboBox>
```

### ListBox
```xml
<ListBox Height="200">
    <ListBoxItem Content="Item 1"/>
    <ListBoxItem Content="Item 2" IsSelected="True"/>
    <ListBoxItem Content="Item 3"/>
</ListBox>
```

### TabControl
```xml
<TabControl Height="300">
    <TabItem Header="Tab 1">
        <TextBlock Text="Content for Tab 1"/>
    </TabItem>
    <TabItem Header="Tab 2">
        <TextBlock Text="Content for Tab 2"/>
    </TabItem>
</TabControl>
```

### GroupBox
```xml
<GroupBox Header="User Information">
    <StackPanel>
        <Label Content="Name:"/>
        <TextBox/>
    </StackPanel>
</GroupBox>
```

### ToggleButton
```xml
<ToggleButton Content="Toggle Me"/>
<ToggleButton Content="Enabled" IsChecked="True"/>
```

## 🎨 Design Principles

### Color Palette

The library uses a beautiful gradient-based color scheme:

- **Primary**: #667EEA (Purple)
- **Secondary**: #764BA2 (Deep Purple)
- **Accent**: #F093FB (Pink)
- **Success**: #48BB78 (Green)
- **Warning**: #F6AD55 (Orange)
- **Danger**: #FC8181 (Red)
- **Glass Background**: Semi-transparent white (#40FFFFFF - #30FFFFFF)
- **Glass Border**: 60% transparent white (#60FFFFFF)

### Visual Effects

1. **Background**: Linear gradient from 40% to 30% white opacity
2. **Border**: 60% transparent white, 1px thickness
3. **Corner Radius**: 10-12px for rounded corners
4. **Drop Shadow**: Soft shadows with 10-20px blur
5. **Hover Effects**: Increased opacity and shadow on hover
6. **Focus Effects**: Colored glow for focused elements

## 🌈 Best Practices

### 1. Use Vibrant Gradient Backgrounds

Glassmorphism works best with vibrant, gradient backgrounds:

```xml
<Grid.Background>
    <LinearGradientBrush StartPoint="0,0" EndPoint="1,1">
        <GradientStop Color="#667EEA" Offset="0"/>
        <GradientStop Color="#764BA2" Offset="0.5"/>
        <GradientStop Color="#F093FB" Offset="1"/>
    </LinearGradientBrush>
</Grid.Background>
```

### 2. Layer Glass Elements

Create depth by stacking glass elements:

```xml
<Border Background="#20FFFFFF"
        BorderBrush="#60FFFFFF"
        BorderThickness="1"
        CornerRadius="16"
        Padding="30">
    <Border.Effect>
        <DropShadowEffect ShadowDepth="4" BlurRadius="30" Opacity="0.3"/>
    </Border.Effect>
    <!-- Your content here -->
</Border>
```

### 3. Maintain Hierarchy

Use varying levels of transparency to create visual hierarchy:
- Primary containers: 20-40% white
- Controls: 40-60% white
- Hover states: +10% opacity

## 🔧 Building

```bash
# Build the solution
cd Glassmorphism
dotnet build Glassmorphism.slnx

# Run the gallery
cd GlassmorphismGallery
dotnet run
```

## 📱 Gallery Application

The **GlassmorphismGallery** application provides a comprehensive showcase of all controls:

- ✅ All basic WPF controls demonstrated
- ✅ Multiple variations and states shown
- ✅ Interactive examples
- ✅ Beautiful gradient background
- ✅ Real-world usage patterns
- ✅ Design principles explained

Run the gallery to see all controls in action and understand how to use them effectively.

## 🌟 Key Features

- 💎 **Modern Design**: Latest glassmorphism trend
- 🎨 **Complete Coverage**: All basic WPF controls styled
- ✨ **Smooth Animations**: Hover, focus, and state transitions
- 🌈 **Vibrant Colors**: Beautiful gradient-based palette
- 📱 **Ready to Use**: Just merge resource dictionary
- 🔧 **Customizable**: Easy to modify styles
- 📖 **Well Documented**: Comprehensive examples and guide

## 🎭 Glassmorphism Characteristics

This library implements true glassmorphism with:

1. **Semi-Transparency**: 40-80% opacity on all controls
2. **Blur Effect**: Frosted glass appearance (simulated with opacity layers)
3. **Light Borders**: Subtle 60% white borders
4. **Soft Shadows**: 10-30px blur drop shadows
5. **Gradients**: Smooth color transitions
6. **Depth**: Layered approach for visual hierarchy
7. **Vibrant Backdrop**: Requires colorful backgrounds

## 📋 Requirements

- **.NET 9.0** or higher
- **WPF** framework
- **Windows** operating system

## 🎯 Use Cases

Perfect for:
- Modern desktop applications
- Dashboard applications
- Admin panels
- Creative tools
- Portfolio applications
- Settings interfaces
- Content management systems

## ⚠️ Important Notes

1. **Background Required**: Glassmorphism requires a vibrant gradient background to show the frosted glass effect
2. **Performance**: Semi-transparency and effects may impact performance on older hardware
3. **Accessibility**: Ensure sufficient contrast for text readability
4. **Browser-Only Effect**: True blur effects are limited in WPF; this library simulates the effect with opacity layers

## 📄 License

Open source and available for use in your projects.

---

**Tip**: For the best glassmorphism effect, always use this library with vibrant gradient backgrounds. The semi-transparent nature of the controls allows background colors to show through, creating the signature frosted glass appearance that defines glassmorphism design.
