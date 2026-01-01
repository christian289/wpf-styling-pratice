using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace BlackRabbit68.Avalonia.Lib.Controls;

/// <summary>
/// 회전하는 비트코인 동전 애니메이션 컨트롤
/// Rotating Bitcoin coin animation control
/// </summary>
/// <remarks>
/// 원본 출처: Uiverse.io by JohnnyCSilva
/// Original source: Uiverse.io by JohnnyCSilva
/// </remarks>
public sealed class BitcoinCoin : TemplatedControl
{
    /// <summary>
    /// 동전 크기 (기본값: 200)
    /// Coin size (default: 200)
    /// </summary>
    public static readonly StyledProperty<double> CoinSizeProperty =
        AvaloniaProperty.Register<BitcoinCoin, double>(nameof(CoinSize), 200.0);

    public double CoinSize
    {
        get => GetValue(CoinSizeProperty);
        set => SetValue(CoinSizeProperty, value);
    }

    /// <summary>
    /// 애니메이션 지속 시간 (초) (기본값: 7)
    /// Animation duration in seconds (default: 7)
    /// </summary>
    public static readonly StyledProperty<double> AnimationDurationProperty =
        AvaloniaProperty.Register<BitcoinCoin, double>(nameof(AnimationDuration), 7.0);

    public double AnimationDuration
    {
        get => GetValue(AnimationDurationProperty);
        set => SetValue(AnimationDurationProperty, value);
    }
}
