using System.Windows;
using System.Windows.Controls;

namespace HungryMoth59.Wpf.UI.Controls;

/// <summary>
/// 귀여운 강아지 로딩 애니메이션 컨트롤
/// Cute dog loading animation control
/// </summary>
public sealed class HungryMoth59 : Control
{
    static HungryMoth59()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(HungryMoth59),
            new FrameworkPropertyMetadata(typeof(HungryMoth59)));
    }
}
