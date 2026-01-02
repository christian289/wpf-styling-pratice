using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;

namespace GrumpyBaboon32.Avalonia.Lib.Controls;

/// <summary>
/// CSS 패턴 배경을 표시하는 커스텀 컨트롤
/// CSS pattern background custom control
///
/// 원본 CSS:
/// - linear-gradient(45deg, ...) + linear-gradient(135deg, ...) + radial-gradient(...)
/// - 타일 크기: 25px
/// - 색상: #1eaaee (cyan), #171717 (dark)
/// </summary>
public sealed class GrumpyBaboon32PatternBackground : Control
{
    /// <summary>
    /// 타일 크기 (CSS --s 변수에 해당)
    /// Tile size (corresponds to CSS --s variable)
    /// </summary>
    public static readonly StyledProperty<double> TileSizeProperty =
        AvaloniaProperty.Register<GrumpyBaboon32PatternBackground, double>(nameof(TileSize), 25.0);

    /// <summary>
    /// 기본 색상 (CSS --c1 변수에 해당)
    /// Primary color (corresponds to CSS --c1 variable)
    /// </summary>
    public static readonly StyledProperty<Color> PrimaryColorProperty =
        AvaloniaProperty.Register<GrumpyBaboon32PatternBackground, Color>(nameof(PrimaryColor), Color.Parse("#1eaaee"));

    /// <summary>
    /// 배경 색상 (CSS --c2 변수에 해당)
    /// Background color (corresponds to CSS --c2 variable)
    /// </summary>
    public static readonly StyledProperty<Color> BackgroundColorProperty =
        AvaloniaProperty.Register<GrumpyBaboon32PatternBackground, Color>(nameof(BackgroundColor), Color.Parse("#171717"));

    public double TileSize
    {
        get => GetValue(TileSizeProperty);
        set => SetValue(TileSizeProperty, value);
    }

    public Color PrimaryColor
    {
        get => GetValue(PrimaryColorProperty);
        set => SetValue(PrimaryColorProperty, value);
    }

    public Color BackgroundColor
    {
        get => GetValue(BackgroundColorProperty);
        set => SetValue(BackgroundColorProperty, value);
    }

    static GrumpyBaboon32PatternBackground()
    {
        AffectsRender<GrumpyBaboon32PatternBackground>(TileSizeProperty, PrimaryColorProperty, BackgroundColorProperty);
    }

    public override void Render(DrawingContext context)
    {
        base.Render(context);

        var bounds = new Rect(0, 0, Bounds.Width, Bounds.Height);
        if (bounds.Width <= 0 || bounds.Height <= 0)
            return;

        var tileSize = TileSize;
        var primaryColor = PrimaryColor;
        var backgroundColor = BackgroundColor;

        // 배경색 채우기
        // Fill background color
        context.FillRectangle(new SolidColorBrush(backgroundColor), bounds);

        // 타일 패턴 그리기
        // Draw tile pattern
        // CSS 패턴은 radial-gradient + 2개의 linear-gradient를 조합
        // CSS pattern combines radial-gradient + 2 linear-gradients

        var columns = (int)Math.Ceiling(bounds.Width / tileSize) + 2;
        var rows = (int)Math.Ceiling(bounds.Height / tileSize) + 2;

        var primaryBrush = new SolidColorBrush(primaryColor);

        for (int row = -1; row < rows; row++)
        {
            for (int col = -1; col < columns; col++)
            {
                var x = col * tileSize;
                var y = row * tileSize;

                // radial-gradient: 원형 (35% 반지름)
                // radial-gradient: circle (35% radius)
                var circleRadius = tileSize * 0.35;
                var centerX = x + tileSize / 2;
                var centerY = y + tileSize / 2;

                var circleGeometry = new EllipseGeometry
                {
                    Center = new Point(centerX, centerY),
                    RadiusX = circleRadius,
                    RadiusY = circleRadius
                };

                context.DrawGeometry(primaryBrush, null, circleGeometry);

                // linear-gradient 45deg: 대각선 라인 (71%~79% 범위)
                // linear-gradient 45deg: diagonal line (71%~79% range)
                DrawDiagonalLine(context, primaryBrush, x - tileSize / 2, y, tileSize, 45, 0.71, 0.79);

                // linear-gradient 135deg: 반대 대각선 라인 (71%~79% 범위)
                // linear-gradient 135deg: opposite diagonal line (71%~79% range)
                DrawDiagonalLine(context, primaryBrush, x + tileSize / 2, y, tileSize, 135, 0.71, 0.79);
            }
        }
    }

    private void DrawDiagonalLine(DrawingContext context, IBrush brush, double x, double y,
        double size, double angle, double startRatio, double endRatio)
    {
        // 대각선 라인을 작은 사각형으로 근사
        // Approximate diagonal line with small rectangle
        var halfSize = size / 2;
        var lineWidth = size * (endRatio - startRatio);
        var lineCenter = size * ((startRatio + endRatio) / 2);

        var radians = angle * Math.PI / 180;
        var sin = Math.Sin(radians);
        var cos = Math.Cos(radians);

        // 대각선 방향의 얇은 평행사변형 그리기
        // Draw thin parallelogram in diagonal direction
        var points = new Point[4];
        var perpX = -sin * lineWidth / 2;
        var perpY = cos * lineWidth / 2;

        // 라인의 시작과 끝 지점 계산
        // Calculate start and end points of line
        var startX = x + halfSize - cos * halfSize;
        var startY = y + halfSize - sin * halfSize;
        var endX = x + halfSize + cos * halfSize;
        var endY = y + halfSize + sin * halfSize;

        // 얇은 스트라이프 영역만 그리기 (71%~79%)
        // Draw only thin stripe area (71%~79%)
        var stripeStartX = startX + cos * size * startRatio;
        var stripeStartY = startY + sin * size * startRatio;
        var stripeEndX = startX + cos * size * endRatio;
        var stripeEndY = startY + sin * size * endRatio;

        points[0] = new Point(stripeStartX + perpX, stripeStartY + perpY);
        points[1] = new Point(stripeEndX + perpX, stripeEndY + perpY);
        points[2] = new Point(stripeEndX - perpX, stripeEndY - perpY);
        points[3] = new Point(stripeStartX - perpX, stripeStartY - perpY);

        var geometry = new PolylineGeometry(points, true);
        context.DrawGeometry(brush, null, geometry);
    }
}
