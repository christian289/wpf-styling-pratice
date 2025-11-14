using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ModernUIControls;

public class ModernButton : Button
{
    static ModernButton()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(ModernButton),
            new FrameworkPropertyMetadata(typeof(ModernButton)));
    }

    public static readonly DependencyProperty CornerRadiusProperty =
        DependencyProperty.Register(nameof(CornerRadius), typeof(CornerRadius), typeof(ModernButton),
            new PropertyMetadata(new CornerRadius(8)));

    public CornerRadius CornerRadius
    {
        get => (CornerRadius)GetValue(CornerRadiusProperty);
        set => SetValue(CornerRadiusProperty, value);
    }

    public static readonly DependencyProperty ButtonStyleProperty =
        DependencyProperty.Register(nameof(ButtonStyle), typeof(ModernButtonStyle), typeof(ModernButton),
            new PropertyMetadata(ModernButtonStyle.Primary));

    public ModernButtonStyle ButtonStyle
    {
        get => (ModernButtonStyle)GetValue(ButtonStyleProperty);
        set => SetValue(ButtonStyleProperty, value);
    }

    public static readonly DependencyProperty IconProperty =
        DependencyProperty.Register(nameof(Icon), typeof(string), typeof(ModernButton),
            new PropertyMetadata(string.Empty));

    public string Icon
    {
        get => (string)GetValue(IconProperty);
        set => SetValue(IconProperty, value);
    }
}

public enum ModernButtonStyle
{
    Primary,
    Secondary,
    Success,
    Warning,
    Danger,
    Outline
}
