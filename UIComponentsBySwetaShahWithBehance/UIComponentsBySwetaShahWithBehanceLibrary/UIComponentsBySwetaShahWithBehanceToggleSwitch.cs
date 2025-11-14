using System.Windows;
using System.Windows.Controls.Primitives;

namespace UIComponentsBySwetaShahWithBehanceLibrary;

public class UIComponentsBySwetaShahWithBehanceToggleSwitch : ToggleButton
{
    static ModernToggleSwitch()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(UIComponentsBySwetaShahWithBehanceToggleSwitch),
            new FrameworkPropertyMetadata(typeof(UIComponentsBySwetaShahWithBehanceToggleSwitch)));
    }

    public static readonly DependencyProperty OnTextProperty =
        DependencyProperty.Register(nameof(OnText), typeof(string), typeof(UIComponentsBySwetaShahWithBehanceToggleSwitch),
            new PropertyMetadata("ON"));

    public string OnText
    {
        get => (string)GetValue(OnTextProperty);
        set => SetValue(OnTextProperty, value);
    }

    public static readonly DependencyProperty OffTextProperty =
        DependencyProperty.Register(nameof(OffText), typeof(string), typeof(UIComponentsBySwetaShahWithBehanceToggleSwitch),
            new PropertyMetadata("OFF"));

    public string OffText
    {
        get => (string)GetValue(OffTextProperty);
        set => SetValue(OffTextProperty, value);
    }
}
