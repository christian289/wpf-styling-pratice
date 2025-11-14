using System.Windows;
using System.Windows.Controls;

namespace ModernUIControls;

public class ModernProgressBar : ProgressBar
{
    static ModernProgressBar()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(ModernProgressBar),
            new FrameworkPropertyMetadata(typeof(ModernProgressBar)));
    }

    public static readonly DependencyProperty CornerRadiusProperty =
        DependencyProperty.Register(nameof(CornerRadius), typeof(CornerRadius), typeof(ModernProgressBar),
            new PropertyMetadata(new CornerRadius(10)));

    public CornerRadius CornerRadius
    {
        get => (CornerRadius)GetValue(CornerRadiusProperty);
        set => SetValue(CornerRadiusProperty, value);
    }

    public static readonly DependencyProperty ProgressColorProperty =
        DependencyProperty.Register(nameof(ProgressColor), typeof(System.Windows.Media.Brush), typeof(ModernProgressBar),
            new PropertyMetadata(null));

    public System.Windows.Media.Brush ProgressColor
    {
        get => (System.Windows.Media.Brush)GetValue(ProgressColorProperty);
        set => SetValue(ProgressColorProperty, value);
    }

    public static readonly DependencyProperty ShowPercentageProperty =
        DependencyProperty.Register(nameof(ShowPercentage), typeof(bool), typeof(ModernProgressBar),
            new PropertyMetadata(false));

    public bool ShowPercentage
    {
        get => (bool)GetValue(ShowPercentageProperty);
        set => SetValue(ShowPercentageProperty, value);
    }
}
