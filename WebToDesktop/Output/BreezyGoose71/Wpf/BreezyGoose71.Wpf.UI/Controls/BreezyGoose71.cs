using System.Windows;
using System.Windows.Controls.Primitives;

namespace BreezyGoose71.Wpf.UI.Controls;

/// <summary>
/// 북마크 토글 버튼 컨트롤
/// Bookmark toggle button control
/// </summary>
public sealed class BreezyGoose71 : ToggleButton
{
    static BreezyGoose71()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(BreezyGoose71),
            new FrameworkPropertyMetadata(typeof(BreezyGoose71)));
    }
}
