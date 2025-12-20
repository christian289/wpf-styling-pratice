using System.Windows;
using System.Windows.Controls.Primitives;

namespace FreshMoth58.Wpf.UI.Controls;

/// <summary>
/// Neumorphism 스타일의 토글 스위치 컨트롤
/// Neumorphism style toggle switch control
/// </summary>
public sealed class FreshMoth58 : ToggleButton
{
    static FreshMoth58()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(FreshMoth58),
            new FrameworkPropertyMetadata(typeof(FreshMoth58)));
    }
}
