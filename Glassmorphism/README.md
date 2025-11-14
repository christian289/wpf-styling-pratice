# Glassmorphism WPF Controls

A modern WPF control library featuring beautiful glassmorphism design - semi-transparent, frosted glass effects with elegant styling.

## 🎨 What is Glassmorphism?

Glassmorphism is a modern UI design trend characterized by:
- **Semi-transparent backgrounds** with blur effects
- **Subtle borders** with light colors
- **Layered approach** creating depth and hierarchy
- **Vibrant colors** with frosted glass appearance

## 📦 Solution Structure

```
Glassmorphism/
├── Glassmorphism.slnx                    # Solution file
├── GlassmorphismLib/                     # Custom control library
│   ├── GlassButton.cs
│   ├── GlassTextBox.cs
│   ├── GlassCard.cs
│   ├── GlassCheckBox.cs
│   ├── GlassProgressBar.cs
│   ├── Themes/
│   │   └── Generic.xaml
│   └── GlassmorphismLib.csproj
├── GlassmorphismGallery/                 # Gallery application
│   ├── App.xaml
│   ├── MainWindow.xaml
│   └── GlassmorphismGallery.csproj
└── README.md
```

## 🎯 Available Controls

### GlassButton
Modern button with glassmorphic styling and multiple variants.

**Features:**
- Semi-transparent background with gradient
- Smooth hover and press animations
- Multiple variants: Default, Primary, Success, Warning, Danger
- Customizable corner radius
- Shadow effects

**Properties:**
- `CornerRadius`: Custom corner radius (default: 12)
- `ButtonVariant`: Default, Primary, Success, Warning, Danger

**Example:**
```xml
<glass:GlassButton Content="Click Me"
                   ButtonVariant="Primary"/>
```

### GlassTextBox
Elegant text input with glass effect.

**Features:**
- Semi-transparent background
- Placeholder text support
- Focus glow effect
- Smooth border transitions
- Customizable corner radius

**Properties:**
- `Placeholder`: Placeholder text
- `CornerRadius`: Custom corner radius (default: 12)

**Example:**
```xml
<glass:GlassTextBox Placeholder="Enter text..."
                    Width="300"/>
```

### GlassCard
Versatile container with glassmorphic design.

**Features:**
- Semi-transparent background with blur
- Optional header
- Hover elevation effect
- Subtle border glow
- Perfect for content organization

**Properties:**
- `Header`: Optional header content
- `CornerRadius`: Custom corner radius (default: 16)

**Example:**
```xml
<glass:GlassCard>
    <StackPanel>
        <TextBlock Text="Card Title" FontSize="18" FontWeight="Bold"/>
        <TextBlock Text="Card content goes here..."/>
    </StackPanel>
</glass:GlassCard>
```

### GlassCheckBox
Checkbox with elegant glass styling.

**Features:**
- Glass-effect checkbox
- Smooth check animation
- Hover effects
- Custom checkmark design

**Example:**
```xml
<glass:GlassCheckBox Content="Enable feature"
                     IsChecked="True"/>
```

### GlassProgressBar
Progress indicator with glassmorphic design.

**Features:**
- Semi-transparent track
- Gradient progress fill
- Glow effect on indicator
- Customizable height and corner radius

**Properties:**
- `CornerRadius`: Custom corner radius (default: 12)

**Example:**
```xml
<glass:GlassProgressBar Value="75"
                        Maximum="100"
                        Height="20"/>
```

## 🎨 Color Palette

The library uses a beautiful gradient-based color scheme:

- **Primary**: Purple gradient (#667EEA → #764BA2)
- **Success**: Green (#48BB78)
- **Warning**: Orange (#F6AD55)
- **Danger**: Red (#FC8181)
- **Glass White**: Semi-transparent white overlays
- **Glass Border**: Subtle white border (#60FFFFFF)

## 🚀 Installation

### 1. Add Reference
Add a reference to `GlassmorphismLib` in your WPF application project.

### 2. Merge Resource Dictionary
Add the resource dictionary to your `App.xaml`:

```xml
<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceDictionary Source="pack://application:,,,/GlassmorphismLib;component/Themes/Generic.xaml"/>
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

### 3. Add Namespace
In your XAML files, add the namespace:

```xml
xmlns:glass="clr-namespace:GlassmorphismLib;assembly=GlassmorphismLib"
```

## 💡 Usage Tips

### Background Recommendations
Glassmorphism works best with vibrant, gradient backgrounds. Example:

```xml
<Grid.Background>
    <LinearGradientBrush StartPoint="0,0" EndPoint="1,1">
        <GradientStop Color="#667EEA" Offset="0"/>
        <GradientStop Color="#764BA2" Offset="0.5"/>
        <GradientStop Color="#F093FB" Offset="1"/>
    </LinearGradientBrush>
</Grid.Background>
```

### Layering
Stack glass elements to create depth:
```xml
<Grid>
    <glass:GlassCard>
        <glass:GlassCard Margin="20">
            <!-- Nested content -->
        </glass:GlassCard>
    </glass:GlassCard>
</Grid>
```

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

The `GlassmorphismGallery` project provides a comprehensive showcase of all controls with various configurations. Run it to see:

- Button variants and sizes
- Text input examples
- CheckBox demonstrations
- Progress bar variations
- Card layouts
- Interactive examples

## 🎭 Design Principles

This library follows modern glassmorphism design principles:

1. **Transparency**: All controls use semi-transparent backgrounds (40-80% opacity)
2. **Blur**: Subtle blur effects create the frosted glass appearance
3. **Borders**: Light, semi-transparent borders (60% white)
4. **Shadows**: Soft drop shadows for depth and elevation
5. **Gradients**: Smooth gradients for visual interest
6. **Hierarchy**: Layering creates clear visual hierarchy

## 🌟 Key Features

- ✨ Modern glassmorphism design
- 🎨 Beautiful gradient-based color palette
- 🔄 Smooth animations and transitions
- 📱 Responsive and interactive
- 🎯 Easy to use and customize
- 🌈 Vibrant visual effects
- 💎 Premium look and feel

## 📋 Requirements

- .NET 9.0 or higher
- WPF

## 📄 License

Open source and available for use in your projects.

---

**Note**: For the best glassmorphism effect, use this library with vibrant gradient backgrounds. The semi-transparent nature of the controls allows the background colors to show through, creating the signature frosted glass appearance.
