using System.Windows;
using System.Windows.Controls.Primitives;

namespace ThemeSwitch.Wpf.Lib.Controls;

public sealed class ThemeSwitchToggle : ToggleButton
{
    static ThemeSwitchToggle()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(ThemeSwitchToggle),
            new FrameworkPropertyMetadata(typeof(ThemeSwitchToggle)));
    }
}
