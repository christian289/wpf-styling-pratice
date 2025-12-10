using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace UIComponentsBySwetaShahWithBehanceLibrary;

public class UIComponentsBySwetaShahWithBehanceButton : Button
{
    static UIComponentsBySwetaShahWithBehanceButton()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(UIComponentsBySwetaShahWithBehanceButton),
            new FrameworkPropertyMetadata(typeof(UIComponentsBySwetaShahWithBehanceButton)));
    }

    public static readonly DependencyProperty CornerRadiusProperty =
        DependencyProperty.Register(nameof(CornerRadius), typeof(CornerRadius), typeof(UIComponentsBySwetaShahWithBehanceButton),
            new PropertyMetadata(new CornerRadius(8)));

    public CornerRadius CornerRadius
    {
        get => (CornerRadius)GetValue(CornerRadiusProperty);
        set => SetValue(CornerRadiusProperty, value);
    }

    public static readonly DependencyProperty ButtonStyleProperty =
        DependencyProperty.Register(nameof(ButtonStyle), typeof(UIComponentsBySwetaShahWithBehanceButtonStyle), typeof(UIComponentsBySwetaShahWithBehanceButton),
            new PropertyMetadata(UIComponentsBySwetaShahWithBehanceButtonStyle.Primary));

    public UIComponentsBySwetaShahWithBehanceButtonStyle ButtonStyle
    {
        get => (UIComponentsBySwetaShahWithBehanceButtonStyle)GetValue(ButtonStyleProperty);
        set => SetValue(ButtonStyleProperty, value);
    }

    public static readonly DependencyProperty IconProperty =
        DependencyProperty.Register(nameof(Icon), typeof(string), typeof(UIComponentsBySwetaShahWithBehanceButton),
            new PropertyMetadata(string.Empty));

    public string Icon
    {
        get => (string)GetValue(IconProperty);
        set => SetValue(IconProperty, value);
    }
}

public enum UIComponentsBySwetaShahWithBehanceButtonStyle
{
    Primary,
    Secondary,
    Success,
    Warning,
    Danger,
    Outline
}
