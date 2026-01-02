using System.Windows;
using System.Windows.Controls;

namespace WhiteKangaroo0.Wpf.UI.Controls;

/// <summary>
/// 톱니바퀴 회전 애니메이션이 있는 로더 컨트롤입니다.
/// A loader control with rotating gear animation.
/// </summary>
public sealed class WhiteKangaroo0 : Control
{
    static WhiteKangaroo0()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(WhiteKangaroo0),
            new FrameworkPropertyMetadata(typeof(WhiteKangaroo0)));
    }
}
