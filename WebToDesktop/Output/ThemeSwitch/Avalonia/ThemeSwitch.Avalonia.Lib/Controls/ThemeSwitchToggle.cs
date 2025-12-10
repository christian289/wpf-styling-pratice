using Avalonia.Controls.Primitives;

namespace ThemeSwitch.Avalonia.Lib.Controls;

public sealed class ThemeSwitchToggle : ToggleButton
{
    protected override Type StyleKeyOverride => typeof(ThemeSwitchToggle);
}
