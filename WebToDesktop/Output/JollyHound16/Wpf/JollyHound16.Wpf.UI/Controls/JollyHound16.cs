using System.Windows;
using System.Windows.Controls;

namespace JollyHound16.Wpf.UI.Controls;

/// <summary>
/// 피자 슬라이스 애니메이션이 있는 로더 컨트롤
/// Pizza slice loader control with animated slices
/// </summary>
public sealed class JollyHound16 : Control
{
    static JollyHound16()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(JollyHound16),
            new FrameworkPropertyMetadata(typeof(JollyHound16)));
    }
}
