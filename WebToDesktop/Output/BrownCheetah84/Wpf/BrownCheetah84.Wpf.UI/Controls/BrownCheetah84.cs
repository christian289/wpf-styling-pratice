using System.Windows;
using System.Windows.Controls;

namespace BrownCheetah84.Wpf.UI.Controls;

/// <summary>
/// 대각선 체크무늬 패턴 배경을 제공하는 컨트롤
/// A control that provides a diagonal checkered pattern background
/// </summary>
public sealed class BrownCheetah84 : Control
{
    static BrownCheetah84()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(BrownCheetah84),
            new FrameworkPropertyMetadata(typeof(BrownCheetah84)));
    }
}
