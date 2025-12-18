using System.Windows;
using System.Windows.Controls;

namespace PopularCrab99.Wpf.UI.Controls;

/// <summary>
/// 4개의 색상 박스가 시계 방향으로 회전하는 로더 컨트롤
/// A loader control with 4 colored boxes rotating clockwise
/// </summary>
public sealed class PopularCrab99 : Control
{
    static PopularCrab99()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(PopularCrab99),
            new FrameworkPropertyMetadata(typeof(PopularCrab99)));
    }
}
