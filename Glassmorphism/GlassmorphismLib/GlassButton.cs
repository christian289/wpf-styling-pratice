using System.Windows;
using System.Windows.Controls;

namespace GlassmorphismLib;

public class GlassButton : Button
{
    static GlassButton()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(GlassButton),
            new FrameworkPropertyMetadata(typeof(GlassButton)));
    }

    public static readonly DependencyProperty CornerRadiusProperty =
        DependencyProperty.Register(nameof(CornerRadius), typeof(CornerRadius), typeof(GlassButton),
            new PropertyMetadata(new CornerRadius(12)));

    public CornerRadius CornerRadius
    {
        get => (CornerRadius)GetValue(CornerRadiusProperty);
        set => SetValue(CornerRadiusProperty, value);
    }

    public static readonly DependencyProperty ButtonVariantProperty =
        DependencyProperty.Register(nameof(ButtonVariant), typeof(GlassButtonVariant), typeof(GlassButton),
            new PropertyMetadata(GlassButtonVariant.Default));

    public GlassButtonVariant ButtonVariant
    {
        get => (GlassButtonVariant)GetValue(ButtonVariantProperty);
        set => SetValue(ButtonVariantProperty, value);
    }
}

public enum GlassButtonVariant
{
    Default,
    Primary,
    Success,
    Warning,
    Danger
}
