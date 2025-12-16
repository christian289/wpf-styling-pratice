using System.Windows;
using System.Windows.Controls;

namespace GentleFly78.Wpf.UI.Controls;

/// <summary>
/// 이모지 버튼이 무한 슬라이딩하는 카드 컨트롤
/// Emoji buttons sliding infinitely card control
/// </summary>
public sealed class GentleFly78 : ItemsControl
{
    static GentleFly78()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(GentleFly78),
            new FrameworkPropertyMetadata(typeof(GentleFly78)));
    }

    /// <summary>
    /// 슬라이딩 애니메이션 지속 시간 (초)
    /// Sliding animation duration in seconds
    /// </summary>
    public static readonly DependencyProperty SlideDurationProperty =
        DependencyProperty.Register(
            nameof(SlideDuration),
            typeof(double),
            typeof(GentleFly78),
            new PropertyMetadata(5.0));

    public double SlideDuration
    {
        get => (double)GetValue(SlideDurationProperty);
        set => SetValue(SlideDurationProperty, value);
    }

    /// <summary>
    /// Hover 시 애니메이션 일시정지 여부
    /// Whether to pause animation on hover
    /// </summary>
    public static readonly DependencyProperty PauseOnHoverProperty =
        DependencyProperty.Register(
            nameof(PauseOnHover),
            typeof(bool),
            typeof(GentleFly78),
            new PropertyMetadata(false));

    public bool PauseOnHover
    {
        get => (bool)GetValue(PauseOnHoverProperty);
        set => SetValue(PauseOnHoverProperty, value);
    }
}
