using System.Windows;
using System.Windows.Controls.Primitives;

namespace SilentOtter72.Wpf.UI.Controls;

/// <summary>
/// 체크마크 아이콘이 있는 토글 스위치 컨트롤
/// Toggle switch control with checkmark icon
/// </summary>
public sealed class SilentOtter72 : ToggleButton
{
    static SilentOtter72()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(SilentOtter72),
            new FrameworkPropertyMetadata(typeof(SilentOtter72)));
    }
}
