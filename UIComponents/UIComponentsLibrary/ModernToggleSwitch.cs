using System.Windows;
using System.Windows.Controls.Primitives;

namespace UIComponentsLibrary;

public class ModernToggleSwitch : ToggleButton
{
    static ModernToggleSwitch()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(ModernToggleSwitch),
            new FrameworkPropertyMetadata(typeof(ModernToggleSwitch)));
    }

    public static readonly DependencyProperty OnTextProperty =
        DependencyProperty.Register(nameof(OnText), typeof(string), typeof(ModernToggleSwitch),
            new PropertyMetadata("ON"));

    public string OnText
    {
        get => (string)GetValue(OnTextProperty);
        set => SetValue(OnTextProperty, value);
    }

    public static readonly DependencyProperty OffTextProperty =
        DependencyProperty.Register(nameof(OffText), typeof(string), typeof(ModernToggleSwitch),
            new PropertyMetadata("OFF"));

    public string OffText
    {
        get => (string)GetValue(OffTextProperty);
        set => SetValue(OffTextProperty, value);
    }
}
