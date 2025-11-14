using System.Windows;
using System.Windows.Controls;

namespace GlassmorphismLib;

public class GlassCard : ContentControl
{
    static GlassCard()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(GlassCard),
            new FrameworkPropertyMetadata(typeof(GlassCard)));
    }

    public static readonly DependencyProperty CornerRadiusProperty =
        DependencyProperty.Register(nameof(CornerRadius), typeof(CornerRadius), typeof(GlassCard),
            new PropertyMetadata(new CornerRadius(16)));

    public CornerRadius CornerRadius
    {
        get => (CornerRadius)GetValue(CornerRadiusProperty);
        set => SetValue(CornerRadiusProperty, value);
    }

    public static readonly DependencyProperty HeaderProperty =
        DependencyProperty.Register(nameof(Header), typeof(object), typeof(GlassCard),
            new PropertyMetadata(null));

    public object Header
    {
        get => GetValue(HeaderProperty);
        set => SetValue(HeaderProperty, value);
    }
}
