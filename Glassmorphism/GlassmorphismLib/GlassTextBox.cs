using System.Windows;
using System.Windows.Controls;

namespace GlassmorphismLib;

public class GlassTextBox : TextBox
{
    static GlassTextBox()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(GlassTextBox),
            new FrameworkPropertyMetadata(typeof(GlassTextBox)));
    }

    public static readonly DependencyProperty CornerRadiusProperty =
        DependencyProperty.Register(nameof(CornerRadius), typeof(CornerRadius), typeof(GlassTextBox),
            new PropertyMetadata(new CornerRadius(12)));

    public CornerRadius CornerRadius
    {
        get => (CornerRadius)GetValue(CornerRadiusProperty);
        set => SetValue(CornerRadiusProperty, value);
    }

    public static readonly DependencyProperty PlaceholderProperty =
        DependencyProperty.Register(nameof(Placeholder), typeof(string), typeof(GlassTextBox),
            new PropertyMetadata(string.Empty));

    public string Placeholder
    {
        get => (string)GetValue(PlaceholderProperty);
        set => SetValue(PlaceholderProperty, value);
    }
}
