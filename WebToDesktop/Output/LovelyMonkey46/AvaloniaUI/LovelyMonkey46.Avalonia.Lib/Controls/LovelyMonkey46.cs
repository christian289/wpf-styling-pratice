using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;

namespace LovelyMonkey46.Avalonia.Lib.Controls;

/// <summary>
/// 여러 RadialGradient와 LinearGradient를 조합한 패턴 배경 컨트롤
/// A pattern background control combining multiple RadialGradients and LinearGradient
/// </summary>
/// <remarks>
/// 원본 CSS: From Uiverse.io by csemszepp - Source: http://twitter.com/okke29
/// Original CSS: From Uiverse.io by csemszepp - Source: http://twitter.com/okke29
/// </remarks>
public sealed class LovelyMonkey46 : Control
{
    /// <summary>
    /// 배경 색상 (기본값: #840b2a)
    /// Background color (default: #840b2a)
    /// </summary>
    public static readonly StyledProperty<IBrush?> BackgroundProperty =
        AvaloniaProperty.Register<LovelyMonkey46, IBrush?>(nameof(Background));

    public IBrush? Background
    {
        get => GetValue(BackgroundProperty);
        set => SetValue(BackgroundProperty, value);
    }

    static LovelyMonkey46()
    {
        AffectsRender<LovelyMonkey46>(BackgroundProperty);
    }

    public override void Render(DrawingContext context)
    {
        var bounds = new Rect(Bounds.Size);
        if (bounds.Width <= 0 || bounds.Height <= 0)
            return;

        // 1. 배경색 (fallback)
        // 1. Background color (fallback)
        var backgroundColor = Background ?? new SolidColorBrush(Color.Parse("#840b2a"));
        context.FillRectangle(backgroundColor, bounds);

        // 2. 베이스 LinearGradient (45deg, 무지개 색상)
        // 2. Base LinearGradient (45deg, rainbow colors)
        var linearGradient = new LinearGradientBrush
        {
            StartPoint = new RelativePoint(0, 1, RelativeUnit.Relative),
            EndPoint = new RelativePoint(1, 0, RelativeUnit.Relative),
            GradientStops =
            [
                new GradientStop(Color.Parse("#343702"), 0.0),
                new GradientStop(Color.Parse("#184500"), 0.2),
                new GradientStop(Color.Parse("#187546"), 0.3),
                new GradientStop(Color.Parse("#006782"), 0.4),
                new GradientStop(Color.Parse("#0b1284"), 0.5),
                new GradientStop(Color.Parse("#760ea1"), 0.6),
                new GradientStop(Color.Parse("#83096e"), 0.7),
                new GradientStop(Color.Parse("#840b2a"), 0.8),
                new GradientStop(Color.Parse("#b13e12"), 0.9),
                new GradientStop(Color.Parse("#e27412"), 1.0)
            ]
        };
        context.FillRectangle(linearGradient, bounds);

        // 3. 여러 RadialGradient 레이어 (타일링 효과 시뮬레이션)
        // 3. Multiple RadialGradient layers (tiling effect simulation)
        // AvaloniaUI에서는 CSS처럼 background-size와 background-position을 직접 지원하지 않으므로
        // 대략적인 효과를 여러 원형 그라디언트로 구현
        // AvaloniaUI doesn't directly support CSS background-size/position,
        // so we approximate the effect with multiple radial gradients

        DrawRadialGradientPattern(context, bounds);
    }

    private static void DrawRadialGradientPattern(DrawingContext context, Rect bounds)
    {
        // 반복 패턴을 위한 타일 크기 정의
        // Define tile sizes for repeating pattern
        var tileSizes = new (double width, double height, double radius, double opacity)[]
        {
            (470, 470, 0.33, 0.30),   // 첫 번째 radial-gradient
            (970, 970, 0.14, 0.30),   // 두 번째 radial-gradient
            (410, 410, 0.20, 0.43),   // 세 번째 radial-gradient
            (610, 610, 0.14, 0.40),   // 네 번째 radial-gradient
            (530, 530, 0.14, 0.40),   // 다섯 번째 radial-gradient
            (730, 730, 0.14, 0.20),   // 여섯 번째 radial-gradient
        };

        foreach (var (tileWidth, tileHeight, radiusRatio, peakOpacity) in tileSizes)
        {
            // 타일 패턴 반복
            // Repeat tile pattern
            for (double x = 0; x < bounds.Width + tileWidth; x += tileWidth)
            {
                for (double y = 0; y < bounds.Height + tileHeight; y += tileHeight)
                {
                    var centerX = x + tileWidth / 2;
                    var centerY = y + tileHeight / 2;
                    var radius = Math.Min(tileWidth, tileHeight) * radiusRatio;

                    // 링 형태의 RadialGradient 생성
                    // Create ring-shaped RadialGradient
                    // AvaloniaUI Issue #19888: GradientOrigin과 Center가 동일해야 함
                    // AvaloniaUI Issue #19888: GradientOrigin and Center must be the same
                    var innerRadius = radius * 0.9;
                    var outerRadius = radius;

                    var ringBrush = new RadialGradientBrush
                    {
                        Center = new RelativePoint(0.5, 0.5, RelativeUnit.Relative),
                        GradientOrigin = new RelativePoint(0.5, 0.5, RelativeUnit.Relative),
                        RadiusX = new RelativeScalar(0.5, RelativeUnit.Relative),
                        RadiusY = new RelativeScalar(0.5, RelativeUnit.Relative),
                        GradientStops =
                        [
                            new GradientStop(Color.FromArgb(0, 255, 255, 255), 0.0),
                            new GradientStop(Color.FromArgb((byte)(peakOpacity * 0.5 * 255), 255, 255, 255), 0.85),
                            new GradientStop(Color.FromArgb((byte)(peakOpacity * 255), 255, 255, 255), 0.95),
                            new GradientStop(Color.FromArgb(0, 255, 255, 255), 1.0)
                        ]
                    };

                    var ellipseRect = new Rect(
                        centerX - outerRadius,
                        centerY - outerRadius,
                        outerRadius * 2,
                        outerRadius * 2
                    );

                    // bounds 내에 있는 부분만 그리기
                    // Only draw parts within bounds
                    if (ellipseRect.Intersects(bounds))
                    {
                        context.FillRectangle(ringBrush, ellipseRect);
                    }
                }
            }
        }
    }
}
