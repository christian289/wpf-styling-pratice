using System.Windows;
using System.Windows.Controls.Primitives;

namespace SmoothDuck62.Wpf.UI.Controls;

/// <summary>
/// 체크 시 45도 회전하여 체크마크 형태가 되는 체크박스 컨트롤
/// A checkbox control that rotates 45 degrees to form a checkmark when checked
/// </summary>
public sealed class SmoothDuck62 : ToggleButton
{
    static SmoothDuck62()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(SmoothDuck62),
            new FrameworkPropertyMetadata(typeof(SmoothDuck62)));
    }
}
