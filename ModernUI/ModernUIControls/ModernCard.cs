using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ModernUIControls;

public class ModernCard : ContentControl
{
    static ModernCard()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(ModernCard),
            new FrameworkPropertyMetadata(typeof(ModernCard)));
    }

    public static readonly DependencyProperty CornerRadiusProperty =
        DependencyProperty.Register(nameof(CornerRadius), typeof(CornerRadius), typeof(ModernCard),
            new PropertyMetadata(new CornerRadius(12)));

    public CornerRadius CornerRadius
    {
        get => (CornerRadius)GetValue(CornerRadiusProperty);
        set => SetValue(CornerRadiusProperty, value);
    }

    public static readonly DependencyProperty ElevationProperty =
        DependencyProperty.Register(nameof(Elevation), typeof(double), typeof(ModernCard),
            new PropertyMetadata(4.0));

    public double Elevation
    {
        get => (double)GetValue(ElevationProperty);
        set => SetValue(ElevationProperty, value);
    }

    public static readonly DependencyProperty HeaderProperty =
        DependencyProperty.Register(nameof(Header), typeof(object), typeof(ModernCard),
            new PropertyMetadata(null));

    public object Header
    {
        get => GetValue(HeaderProperty);
        set => SetValue(HeaderProperty, value);
    }

    public static readonly DependencyProperty IsHoverableProperty =
        DependencyProperty.Register(nameof(IsHoverable), typeof(bool), typeof(ModernCard),
            new PropertyMetadata(true));

    public bool IsHoverable
    {
        get => (bool)GetValue(IsHoverableProperty);
        set => SetValue(IsHoverableProperty, value);
    }
}
