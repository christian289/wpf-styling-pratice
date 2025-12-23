using System.Windows;
using System.Windows.Controls;

namespace BlackMouse53.Wpf.UI.Controls;

/// <summary>
/// Twitter(X) 새 로고를 CSS 아트 스타일로 표현하는 컨트롤입니다.
/// RadialGradientBrush를 사용하여 여러 원형 요소로 새 모양을 구성합니다.
/// </summary>
/// <remarks>
/// A control that displays the Twitter(X) bird logo in CSS art style.
/// Uses RadialGradientBrush to compose bird shape with multiple circular elements.
/// </remarks>
public sealed class BlackMouse53 : Control
{
    static BlackMouse53()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(BlackMouse53),
            new FrameworkPropertyMetadata(typeof(BlackMouse53)));
    }

    /// <summary>
    /// 새의 색상을 가져오거나 설정합니다.
    /// Gets or sets the bird color.
    /// </summary>
    public static readonly DependencyProperty BirdColorProperty =
        DependencyProperty.Register(
            nameof(BirdColor),
            typeof(System.Windows.Media.Color),
            typeof(BlackMouse53),
            new PropertyMetadata(System.Windows.Media.Colors.White));

    public System.Windows.Media.Color BirdColor
    {
        get => (System.Windows.Media.Color)GetValue(BirdColorProperty);
        set => SetValue(BirdColorProperty, value);
    }
}
