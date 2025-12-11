using System.Windows;
using System.Windows.Controls;

namespace SillyGrasshopper43.Wpf.UI.Controls;

/// <summary>
/// 두 개의 원이 좌우로 이동하면서 크기가 변하는 로더 컨트롤
/// Two circles moving horizontally while scaling - loader control
/// </summary>
public sealed class SillyGrasshopper43 : Control
{
    static SillyGrasshopper43()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(SillyGrasshopper43),
            new FrameworkPropertyMetadata(typeof(SillyGrasshopper43)));
    }
}
