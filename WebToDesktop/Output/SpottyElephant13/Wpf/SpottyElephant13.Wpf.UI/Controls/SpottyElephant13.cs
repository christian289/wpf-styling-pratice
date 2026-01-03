using System.Windows;
using System.Windows.Controls;

namespace SpottyElephant13.Wpf.UI.Controls;

/// <summary>
/// 펄스 애니메이션이 있는 커스텀 체크박스 컨트롤
/// Custom checkbox control with pulse animation
/// </summary>
public sealed class SpottyElephant13 : CheckBox
{
    static SpottyElephant13()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(SpottyElephant13),
            new FrameworkPropertyMetadata(typeof(SpottyElephant13)));
    }
}
