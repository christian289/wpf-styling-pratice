using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ModernUIControls;

public class ModernTextBox : TextBox
{
    static ModernTextBox()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(ModernTextBox),
            new FrameworkPropertyMetadata(typeof(ModernTextBox)));
    }

    public static readonly DependencyProperty CornerRadiusProperty =
        DependencyProperty.Register(nameof(CornerRadius), typeof(CornerRadius), typeof(ModernTextBox),
            new PropertyMetadata(new CornerRadius(8)));

    public CornerRadius CornerRadius
    {
        get => (CornerRadius)GetValue(CornerRadiusProperty);
        set => SetValue(CornerRadiusProperty, value);
    }

    public static readonly DependencyProperty PlaceholderProperty =
        DependencyProperty.Register(nameof(Placeholder), typeof(string), typeof(ModernTextBox),
            new PropertyMetadata(string.Empty));

    public string Placeholder
    {
        get => (string)GetValue(PlaceholderProperty);
        set => SetValue(PlaceholderProperty, value);
    }

    public static readonly DependencyProperty IconProperty =
        DependencyProperty.Register(nameof(Icon), typeof(string), typeof(ModernTextBox),
            new PropertyMetadata(string.Empty));

    public string Icon
    {
        get => (string)GetValue(IconProperty);
        set => SetValue(IconProperty, value);
    }
}
