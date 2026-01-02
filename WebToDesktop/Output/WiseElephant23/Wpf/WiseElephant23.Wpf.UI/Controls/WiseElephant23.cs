using System.Windows;
using System.Windows.Controls.Primitives;

namespace WiseElephant23.Wpf.UI.Controls;

/// <summary>
/// 원형 체크박스 커스텀 컨트롤입니다.
/// A circular checkbox custom control.
/// </summary>
public sealed class WiseElephant23 : ToggleButton
{
    static WiseElephant23()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(WiseElephant23),
            new FrameworkPropertyMetadata(typeof(WiseElephant23)));
    }
}
