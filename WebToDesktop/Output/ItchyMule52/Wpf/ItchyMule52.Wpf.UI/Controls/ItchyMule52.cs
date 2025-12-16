using System.Windows;
using System.Windows.Controls.Primitives;

namespace ItchyMule52.Wpf.UI.Controls;

/// <summary>
/// 네온 스타일 토글 스위치 컨트롤
/// Neon style toggle switch control
/// </summary>
public sealed class ItchyMule52 : ToggleButton
{
    static ItchyMule52()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(ItchyMule52),
            new FrameworkPropertyMetadata(typeof(ItchyMule52)));
    }
}
