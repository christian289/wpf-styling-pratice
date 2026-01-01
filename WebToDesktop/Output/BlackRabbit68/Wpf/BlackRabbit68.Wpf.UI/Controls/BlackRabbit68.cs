using System.Windows;
using System.Windows.Controls;

namespace BlackRabbit68.Wpf.UI.Controls;

/// <summary>
/// 3D 회전하는 비트코인 코인 애니메이션 컨트롤
/// 3D rotating Bitcoin coin animation control
/// </summary>
public sealed class BlackRabbit68 : Control
{
    static BlackRabbit68()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(BlackRabbit68),
            new FrameworkPropertyMetadata(typeof(BlackRabbit68)));
    }

    /// <summary>
    /// 애니메이션 지속 시간 (초 단위)
    /// Animation duration in seconds
    /// </summary>
    public static readonly DependencyProperty AnimationDurationProperty =
        DependencyProperty.Register(
            nameof(AnimationDuration),
            typeof(double),
            typeof(BlackRabbit68),
            new PropertyMetadata(7.0));

    public double AnimationDuration
    {
        get => (double)GetValue(AnimationDurationProperty);
        set => SetValue(AnimationDurationProperty, value);
    }

    /// <summary>
    /// 코인 크기 (font-size 기준 em 단위로 계산됨)
    /// Coin size (calculated in em units based on font-size)
    /// </summary>
    public static readonly DependencyProperty CoinSizeProperty =
        DependencyProperty.Register(
            nameof(CoinSize),
            typeof(double),
            typeof(BlackRabbit68),
            new PropertyMetadata(200.0));

    public double CoinSize
    {
        get => (double)GetValue(CoinSizeProperty);
        set => SetValue(CoinSizeProperty, value);
    }
}
