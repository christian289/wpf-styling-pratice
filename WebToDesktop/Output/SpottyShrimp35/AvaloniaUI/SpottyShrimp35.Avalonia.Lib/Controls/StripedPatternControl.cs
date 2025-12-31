using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;

namespace SpottyShrimp35.Avalonia.Lib.Controls;

/// <summary>
/// 대각선 스트라이프 패턴을 표시하는 커스텀 컨트롤입니다.
/// A custom control that displays diagonal stripe patterns.
/// </summary>
/// <remarks>
/// CSS repeating-linear-gradient를 AvaloniaUI DrawingBrush로 구현합니다.
/// Implements CSS repeating-linear-gradient as AvaloniaUI DrawingBrush.
/// </remarks>
public sealed class StripedPatternControl : ContentControl
{
    /// <summary>
    /// 첫 번째 스트라이프 색상입니다.
    /// The first stripe color.
    /// </summary>
    public static readonly StyledProperty<Color> Stripe1ColorProperty =
        AvaloniaProperty.Register<StripedPatternControl, Color>(
            nameof(Stripe1Color),
            Color.Parse("#0050fc"));

    /// <summary>
    /// 두 번째 스트라이프 색상입니다.
    /// The second stripe color.
    /// </summary>
    public static readonly StyledProperty<Color> Stripe2ColorProperty =
        AvaloniaProperty.Register<StripedPatternControl, Color>(
            nameof(Stripe2Color),
            Color.Parse("#0684fa"));

    /// <summary>
    /// 스트라이프 너비(픽셀)입니다.
    /// The stripe width in pixels.
    /// </summary>
    public static readonly StyledProperty<double> StripeWidthProperty =
        AvaloniaProperty.Register<StripedPatternControl, double>(
            nameof(StripeWidth),
            20.0);

    public Color Stripe1Color
    {
        get => GetValue(Stripe1ColorProperty);
        set => SetValue(Stripe1ColorProperty, value);
    }

    public Color Stripe2Color
    {
        get => GetValue(Stripe2ColorProperty);
        set => SetValue(Stripe2ColorProperty, value);
    }

    public double StripeWidth
    {
        get => GetValue(StripeWidthProperty);
        set => SetValue(StripeWidthProperty, value);
    }

    static StripedPatternControl()
    {
        AffectsRender<StripedPatternControl>(
            Stripe1ColorProperty,
            Stripe2ColorProperty,
            StripeWidthProperty);
    }
}
