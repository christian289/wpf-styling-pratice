using System.Windows;
using System.Windows.Controls;

namespace HardRabbit4.Wpf.UI.Controls;

/// <summary>
/// 도트 패턴 배경을 가진 컨테이너 컨트롤
/// A container control with dot pattern background
/// </summary>
public sealed class HardRabbit4 : ContentControl
{
    static HardRabbit4()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(HardRabbit4),
            new FrameworkPropertyMetadata(typeof(HardRabbit4)));
    }
}
