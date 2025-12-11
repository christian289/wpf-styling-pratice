using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;

namespace GrumpyOwl55.Avalonia.Lib.Controls;

/// <summary>
/// 기하학적 패턴 배경을 렌더링하는 커스텀 컨트롤.
/// CSS conic-gradient, radial-gradient, linear-gradient를 조합한 패턴을 구현.
/// Geometric pattern background control.
/// Implements a combination of CSS conic-gradient, radial-gradient, and linear-gradient patterns.
/// </summary>
/// <remarks>
/// 원본: Uiverse.io by vikas7754 - Tags: simple, clean, pattern
/// Original: Uiverse.io by vikas7754 - Tags: simple, clean, pattern
/// </remarks>
public sealed class GrumpyOwl55Pattern : Control
{
    /// <summary>
    /// 패턴 크기 (CSS --sz 변수에 해당).
    /// Pattern size (corresponds to CSS --sz variable).
    /// </summary>
    public static readonly StyledProperty<double> PatternSizeProperty =
        AvaloniaProperty.Register<GrumpyOwl55Pattern, double>(nameof(PatternSize), 15.0);

    /// <summary>
    /// 기본 색상 (CSS --c0 변수에 해당).
    /// Primary color (corresponds to CSS --c0 variable).
    /// </summary>
    public static readonly StyledProperty<Color> PrimaryColorProperty =
        AvaloniaProperty.Register<GrumpyOwl55Pattern, Color>(nameof(PrimaryColor), Color.Parse("#000000"));

    /// <summary>
    /// 보조 색상 (CSS --c1 변수에 해당).
    /// Secondary color (corresponds to CSS --c1 variable).
    /// </summary>
    public static readonly StyledProperty<Color> SecondaryColorProperty =
        AvaloniaProperty.Register<GrumpyOwl55Pattern, Color>(nameof(SecondaryColor), Color.Parse("#c71175"));

    public double PatternSize
    {
        get => GetValue(PatternSizeProperty);
        set => SetValue(PatternSizeProperty, value);
    }

    public Color PrimaryColor
    {
        get => GetValue(PrimaryColorProperty);
        set => SetValue(PrimaryColorProperty, value);
    }

    public Color SecondaryColor
    {
        get => GetValue(SecondaryColorProperty);
        set => SetValue(SecondaryColorProperty, value);
    }

    static GrumpyOwl55Pattern()
    {
        AffectsRender<GrumpyOwl55Pattern>(PatternSizeProperty, PrimaryColorProperty, SecondaryColorProperty);
    }

    public override void Render(DrawingContext context)
    {
        base.Render(context);

        var bounds = Bounds;
        if (bounds.Width <= 0 || bounds.Height <= 0) return;

        var sz = PatternSize;
        var tileWidth = sz * 8;
        var tileHeight = sz * 16;

        var primaryBrush = new SolidColorBrush(PrimaryColor);
        var secondaryBrush = new SolidColorBrush(SecondaryColor);

        // 타일 패턴 반복 렌더링
        // Render repeating tile pattern
        for (double y = 0; y < bounds.Height; y += tileHeight)
        {
            for (double x = 0; x < bounds.Width; x += tileWidth)
            {
                using (context.PushTransform(Matrix.CreateTranslation(x, y)))
                {
                    RenderTile(context, tileWidth, tileHeight, sz, primaryBrush, secondaryBrush);
                }
            }
        }
    }

    private static void RenderTile(DrawingContext context, double tileWidth, double tileHeight,
        double sz, IBrush primaryBrush, IBrush secondaryBrush)
    {
        // 기본 배경: 수직 줄무늬 (repeating-linear-gradient)
        // Base background: vertical stripes (repeating-linear-gradient)
        var stripeWidth = tileWidth * 0.25;
        for (double x = 0; x < tileWidth; x += stripeWidth)
        {
            var isSecondary = ((int)(x / stripeWidth) % 2) == 1;
            var stripeBrush = isSecondary ? secondaryBrush : primaryBrush;
            var stripeRect = new Rect(x, 0, stripeWidth * 0.2, tileHeight);
            context.FillRectangle(stripeBrush, stripeRect);

            var stripeRect2 = new Rect(x + stripeWidth * 0.2, 0, stripeWidth * 0.8, tileHeight);
            context.FillRectangle(isSecondary ? primaryBrush : secondaryBrush, stripeRect2);
        }

        // 대각선 그라데이션 효과 (linear-gradient -45deg)
        // Diagonal gradient effect (linear-gradient -45deg)
        var diagonalGradient = new LinearGradientBrush
        {
            StartPoint = new RelativePoint(0, 0, RelativeUnit.Relative),
            EndPoint = new RelativePoint(1, 1, RelativeUnit.Relative),
            GradientStops =
            [
                new GradientStop(Colors.Transparent, 0),
                new GradientStop(Colors.Transparent, 0.3225),
                new GradientStop(Color.FromArgb(0x22, 0, 0, 0), 0.5),
                new GradientStop(Colors.Black, 0.775)
            ]
        };
        context.FillRectangle(diagonalGradient, new Rect(0, 0, tileWidth, tileHeight));

        // 계단형 블록 패턴 (conic-gradient 시뮬레이션)
        // Stair-step block pattern (conic-gradient simulation)
        RenderConicBlocks(context, tileWidth, tileHeight, primaryBrush, secondaryBrush);

        // 원형 도트 패턴 (radial-gradient)
        // Circular dot pattern (radial-gradient)
        var dotRadius = sz * 0.78;
        RenderDots(context, tileWidth, tileHeight, dotRadius, secondaryBrush);
    }

    private static void RenderConicBlocks(DrawingContext context, double tileWidth, double tileHeight,
        IBrush primaryBrush, IBrush secondaryBrush)
    {
        // CSS conic-gradient를 사각형 블록으로 근사
        // Approximate CSS conic-gradient with rectangular blocks
        var blockPositions = new (double x, double y, double w, double h, bool isPrimary)[]
        {
            // cg1: at 5% 51%
            (0, tileHeight * 0.51, tileWidth * 0.05, tileHeight * 0.49, true),
            // cg2: at 25% 50%
            (tileWidth * 0.05, tileHeight * 0.50, tileWidth * 0.20, tileHeight * 0.50, false),
            // cg3: at 30% 38.5%
            (tileWidth * 0.25, tileHeight * 0.385, tileWidth * 0.05, tileHeight * 0.115, true),
            // cg4: at 50% 37.5%
            (tileWidth * 0.30, tileHeight * 0.375, tileWidth * 0.20, tileHeight * 0.125, false),
            // cg5: at 55% 26%
            (tileWidth * 0.50, tileHeight * 0.26, tileWidth * 0.05, tileHeight * 0.115, true),
            // cg6: at 75% 25%
            (tileWidth * 0.55, tileHeight * 0.25, tileWidth * 0.20, tileHeight * 0.125, false),
            // cg7: at 80% 13.5%
            (tileWidth * 0.75, tileHeight * 0.135, tileWidth * 0.05, tileHeight * 0.115, true),
            // cg8: at 100% 12.5%
            (tileWidth * 0.80, tileHeight * 0.125, tileWidth * 0.20, tileHeight * 0.125, false),
        };

        foreach (var (x, y, w, h, isPrimary) in blockPositions)
        {
            var brush = isPrimary ? primaryBrush : secondaryBrush;
            context.FillRectangle(brush, new Rect(x, y, w, h));
        }
    }

    private static void RenderDots(DrawingContext context, double tileWidth, double tileHeight,
        double radius, IBrush brush)
    {
        // 상단 도트 (at 90%, 65%, 40%, 15% 0%)
        // Top dots
        double[] topXPositions = [0.90, 0.65, 0.40, 0.15];
        foreach (var xRatio in topXPositions)
        {
            var center = new Point(tileWidth * xRatio, 0);
            context.DrawEllipse(brush, null, center, radius, radius);
        }

        // 하단 도트 (at 90%, 65%, 40%, 15% 100%)
        // Bottom dots
        foreach (var xRatio in topXPositions)
        {
            var center = new Point(tileWidth * xRatio, tileHeight);
            context.DrawEllipse(brush, null, center, radius, radius);
        }

        // 중간 도트 (계단식 배치)
        // Middle dots (stair-step arrangement)
        var middleDots = new (double x, double y)[]
        {
            (0.90, 0.125),
            (0.65, 0.25),
            (0.40, 0.375),
            (0.15, 0.50)
        };

        foreach (var (xRatio, yRatio) in middleDots)
        {
            var center = new Point(tileWidth * xRatio, tileHeight * yRatio);
            context.DrawEllipse(brush, null, center, radius, radius);
        }
    }
}
