using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;

namespace HardRabbit4.Avalonia.Lib.Controls;

/// <summary>
/// 점 패턴 배경을 가진 컨테이너 컨트롤
/// A container control with a dot pattern background
/// </summary>
public sealed class DotPatternBackground : ContentControl
{
    /// <summary>
    /// 배경색
    /// Background color
    /// </summary>
    public static readonly StyledProperty<Color> BackgroundColorProperty =
        AvaloniaProperty.Register<DotPatternBackground, Color>(
            nameof(BackgroundColor),
            Color.FromArgb(230, 29, 31, 32)); // rgba(29, 31, 32, 0.904)

    /// <summary>
    /// 점 색상
    /// Dot color
    /// </summary>
    public static readonly StyledProperty<Color> DotColorProperty =
        AvaloniaProperty.Register<DotPatternBackground, Color>(
            nameof(DotColor),
            Color.FromArgb(181, 255, 255, 255)); // rgba(255, 255, 255, 0.712)

    /// <summary>
    /// 점 크기 (패턴 셀 크기)
    /// Dot size (pattern cell size)
    /// </summary>
    public static readonly StyledProperty<double> DotSizeProperty =
        AvaloniaProperty.Register<DotPatternBackground, double>(
            nameof(DotSize),
            11.0);

    /// <summary>
    /// 점 반지름 비율 (셀 크기 대비)
    /// Dot radius ratio (relative to cell size)
    /// </summary>
    public static readonly StyledProperty<double> DotRadiusRatioProperty =
        AvaloniaProperty.Register<DotPatternBackground, double>(
            nameof(DotRadiusRatio),
            0.10); // 10% of cell size

    public Color BackgroundColor
    {
        get => GetValue(BackgroundColorProperty);
        set => SetValue(BackgroundColorProperty, value);
    }

    public Color DotColor
    {
        get => GetValue(DotColorProperty);
        set => SetValue(DotColorProperty, value);
    }

    public double DotSize
    {
        get => GetValue(DotSizeProperty);
        set => SetValue(DotSizeProperty, value);
    }

    public double DotRadiusRatio
    {
        get => GetValue(DotRadiusRatioProperty);
        set => SetValue(DotRadiusRatioProperty, value);
    }

    static DotPatternBackground()
    {
        AffectsRender<DotPatternBackground>(
            BackgroundColorProperty,
            DotColorProperty,
            DotSizeProperty,
            DotRadiusRatioProperty);
    }

    public override void Render(DrawingContext context)
    {
        var bounds = Bounds;

        // 배경색 그리기
        // Draw background color
        context.FillRectangle(
            new SolidColorBrush(BackgroundColor),
            new Rect(0, 0, bounds.Width, bounds.Height));

        // 점 패턴 그리기
        // Draw dot pattern
        var dotBrush = new SolidColorBrush(DotColor);
        var cellSize = DotSize;
        var dotRadius = cellSize * DotRadiusRatio;

        for (double y = cellSize / 2; y < bounds.Height; y += cellSize)
        {
            for (double x = cellSize / 2; x < bounds.Width; x += cellSize)
            {
                context.DrawEllipse(
                    dotBrush,
                    null,
                    new Point(x, y),
                    dotRadius,
                    dotRadius);
            }
        }

        base.Render(context);
    }
}
