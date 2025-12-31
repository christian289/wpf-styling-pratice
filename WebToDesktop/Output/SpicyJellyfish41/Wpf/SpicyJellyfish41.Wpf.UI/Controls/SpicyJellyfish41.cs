using System.Windows;
using System.Windows.Controls.Primitives;

namespace SpicyJellyfish41.Wpf.UI.Controls;

/// <summary>
/// 햄버거 메뉴 토글 버튼 컨트롤
/// Hamburger menu toggle button control
/// </summary>
public sealed class SpicyJellyfish41 : ToggleButton
{
    static SpicyJellyfish41()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(SpicyJellyfish41),
            new FrameworkPropertyMetadata(typeof(SpicyJellyfish41)));
    }
}
