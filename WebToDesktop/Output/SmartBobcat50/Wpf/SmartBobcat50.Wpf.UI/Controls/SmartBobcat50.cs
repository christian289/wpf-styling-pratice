using System.Windows;
using System.Windows.Controls;

namespace SmartBobcat50.Wpf.UI.Controls;

/// <summary>
/// 하트 모양의 Like/Unlike 체크박스 컨트롤
/// Heart-shaped Like/Unlike checkbox control
/// </summary>
public sealed class SmartBobcat50 : CheckBox
{
    static SmartBobcat50()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(SmartBobcat50),
            new FrameworkPropertyMetadata(typeof(SmartBobcat50)));
    }
}
