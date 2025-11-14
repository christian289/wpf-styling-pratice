using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace UIComponentsBySwetaShahWithBehanceLibrary;

public class UIComponentsBySwetaShahWithBehanceCard : ContentControl
{
    static UIComponentsBySwetaShahWithBehanceCard()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(UIComponentsBySwetaShahWithBehanceCard),
            new FrameworkPropertyMetadata(typeof(UIComponentsBySwetaShahWithBehanceCard)));
    }

    public static readonly DependencyProperty CornerRadiusProperty =
        DependencyProperty.Register(nameof(CornerRadius), typeof(CornerRadius), typeof(UIComponentsBySwetaShahWithBehanceCard),
            new PropertyMetadata(new CornerRadius(12)));

    public CornerRadius CornerRadius
    {
        get => (CornerRadius)GetValue(CornerRadiusProperty);
        set => SetValue(CornerRadiusProperty, value);
    }

    public static readonly DependencyProperty ElevationProperty =
        DependencyProperty.Register(nameof(Elevation), typeof(double), typeof(UIComponentsBySwetaShahWithBehanceCard),
            new PropertyMetadata(4.0));

    public double Elevation
    {
        get => (double)GetValue(ElevationProperty);
        set => SetValue(ElevationProperty, value);
    }

    public static readonly DependencyProperty HeaderProperty =
        DependencyProperty.Register(nameof(Header), typeof(object), typeof(UIComponentsBySwetaShahWithBehanceCard),
            new PropertyMetadata(null));

    public object Header
    {
        get => GetValue(HeaderProperty);
        set => SetValue(HeaderProperty, value);
    }

    public static readonly DependencyProperty IsHoverableProperty =
        DependencyProperty.Register(nameof(IsHoverable), typeof(bool), typeof(UIComponentsBySwetaShahWithBehanceCard),
            new PropertyMetadata(true));

    public bool IsHoverable
    {
        get => (bool)GetValue(IsHoverableProperty);
        set => SetValue(IsHoverableProperty, value);
    }
}
