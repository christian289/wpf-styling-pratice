using System.Windows;
using System.Windows.Controls;

namespace GlassmorphismLib;

public class GlassProgressBar : ProgressBar
{
    static GlassProgressBar()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(GlassProgressBar),
            new FrameworkPropertyMetadata(typeof(GlassProgressBar)));
    }

    public static readonly DependencyProperty CornerRadiusProperty =
        DependencyProperty.Register(nameof(CornerRadius), typeof(CornerRadius), typeof(GlassProgressBar),
            new PropertyMetadata(new CornerRadius(12)));

    public CornerRadius CornerRadius
    {
        get => (CornerRadius)GetValue(CornerRadiusProperty);
        set => SetValue(CornerRadiusProperty, value);
    }
}
