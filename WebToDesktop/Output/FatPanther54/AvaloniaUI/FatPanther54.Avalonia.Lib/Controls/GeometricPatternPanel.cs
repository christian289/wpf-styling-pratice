using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;

namespace FatPanther54.Avalonia.Lib.Controls;

/// <summary>
/// conic-gradient 기반 기하학적 삼각형 패턴 배경을 표시하는 커스텀 컨트롤
/// A custom control that displays a geometric triangle pattern background based on conic-gradient
/// </summary>
public sealed class GeometricPatternPanel : ContentControl
{
    /// <summary>
    /// 패턴 크기 (CSS --s 변수에 해당)
    /// Pattern size (corresponds to CSS --s variable)
    /// </summary>
    public static readonly StyledProperty<double> PatternSizeProperty =
        AvaloniaProperty.Register<GeometricPatternPanel, double>(nameof(PatternSize), 37.0);

    /// <summary>
    /// 삼각형 색상 (CSS #2fb8ac에 해당)
    /// Triangle color (corresponds to CSS #2fb8ac)
    /// </summary>
    public static readonly StyledProperty<Color> TriangleColorProperty =
        AvaloniaProperty.Register<GeometricPatternPanel, Color>(nameof(TriangleColor), Color.Parse("#2fb8ac"));

    /// <summary>
    /// 배경 색상 (CSS #ecbe13에 해당)
    /// Background color (corresponds to CSS #ecbe13)
    /// </summary>
    public static readonly StyledProperty<Color> BackgroundColorProperty =
        AvaloniaProperty.Register<GeometricPatternPanel, Color>(nameof(BackgroundColor), Color.Parse("#ecbe13"));

    public double PatternSize
    {
        get => GetValue(PatternSizeProperty);
        set => SetValue(PatternSizeProperty, value);
    }

    public Color TriangleColor
    {
        get => GetValue(TriangleColorProperty);
        set => SetValue(TriangleColorProperty, value);
    }

    public Color BackgroundColor
    {
        get => GetValue(BackgroundColorProperty);
        set => SetValue(BackgroundColorProperty, value);
    }

    static GeometricPatternPanel()
    {
        AffectsRender<GeometricPatternPanel>(PatternSizeProperty, TriangleColorProperty, BackgroundColorProperty);
    }

    public override void Render(DrawingContext context)
    {
        var bounds = new Rect(0, 0, Bounds.Width, Bounds.Height);

        // 배경 색상으로 전체 영역 채우기
        // Fill entire area with background color
        context.FillRectangle(new SolidColorBrush(BackgroundColor), bounds);

        var s = PatternSize;
        var triangleBrush = new SolidColorBrush(TriangleColor);

        // 패턴 타일 크기: 2*s x 3.46*s (CSS background-size에 해당)
        // Pattern tile size: 2*s x 3.46*s (corresponds to CSS background-size)
        var tileWidth = 2 * s;
        var tileHeight = 3.46 * s;

        // 삼각형 높이 (정삼각형 기준)
        // Triangle height (equilateral triangle)
        var triangleHeight = s * 0.866; // sin(60°) ≈ 0.866
        var halfS = s * 0.5;

        // 화면을 타일로 채우기
        // Fill screen with tiles
        for (double y = -tileHeight; y < Bounds.Height + tileHeight; y += tileHeight)
        {
            for (double x = -s; x < Bounds.Width + s; x += s)
            {
                var row = (int)Math.Round(y / tileHeight);
                var col = (int)Math.Round(x / s);

                // 삼각형 방향 결정 (체커보드 패턴)
                // Determine triangle direction (checkerboard pattern)
                var isPointingUp = (row + col) % 2 == 0;

                // 삼각형 그리기
                // Draw triangle
                DrawTriangle(context, triangleBrush, x, y, s, triangleHeight, isPointingUp);
            }
        }

        base.Render(context);
    }

    private static void DrawTriangle(DrawingContext context, IBrush brush, double x, double y, double width, double height, bool pointingUp)
    {
        var geometry = new StreamGeometry();
        using (var ctx = geometry.Open())
        {
            if (pointingUp)
            {
                // 위를 향하는 삼각형
                // Upward pointing triangle
                ctx.BeginFigure(new Point(x, y + height), true);
                ctx.LineTo(new Point(x + width, y + height));
                ctx.LineTo(new Point(x + width / 2, y));
                ctx.EndFigure(true);
            }
            else
            {
                // 아래를 향하는 삼각형
                // Downward pointing triangle
                ctx.BeginFigure(new Point(x, y), true);
                ctx.LineTo(new Point(x + width, y));
                ctx.LineTo(new Point(x + width / 2, y + height));
                ctx.EndFigure(true);
            }
        }

        context.DrawGeometry(brush, null, geometry);
    }
}
