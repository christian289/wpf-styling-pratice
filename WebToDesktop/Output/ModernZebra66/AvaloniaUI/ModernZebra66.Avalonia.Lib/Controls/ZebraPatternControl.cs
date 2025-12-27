using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;

namespace ModernZebra66.Avalonia.Lib.Controls;

/// <summary>
/// CSS repeating-conic-gradient 기반의 육각형 지브라 패턴을 렌더링하는 컨트롤
/// A control that renders a hexagonal zebra pattern based on CSS repeating-conic-gradient
/// </summary>
public sealed class ZebraPatternControl : Control
{
    /// <summary>
    /// 패턴 타일 크기 (픽셀)
    /// Pattern tile size in pixels
    /// </summary>
    public static readonly StyledProperty<double> TileSizeProperty =
        AvaloniaProperty.Register<ZebraPatternControl, double>(nameof(TileSize), 200.0);

    /// <summary>
    /// 첫 번째 색상 (가장 어두운)
    /// First color (darkest)
    /// </summary>
    public static readonly StyledProperty<Color> Color1Property =
        AvaloniaProperty.Register<ZebraPatternControl, Color>(nameof(Color1), Color.Parse("#1d1d1d"));

    /// <summary>
    /// 두 번째 색상 (중간)
    /// Second color (medium)
    /// </summary>
    public static readonly StyledProperty<Color> Color2Property =
        AvaloniaProperty.Register<ZebraPatternControl, Color>(nameof(Color2), Color.Parse("#4e4f51"));

    /// <summary>
    /// 세 번째 색상 (밝은)
    /// Third color (lighter)
    /// </summary>
    public static readonly StyledProperty<Color> Color3Property =
        AvaloniaProperty.Register<ZebraPatternControl, Color>(nameof(Color3), Color.Parse("#3c3c3c"));

    public double TileSize
    {
        get => GetValue(TileSizeProperty);
        set => SetValue(TileSizeProperty, value);
    }

    public Color Color1
    {
        get => GetValue(Color1Property);
        set => SetValue(Color1Property, value);
    }

    public Color Color2
    {
        get => GetValue(Color2Property);
        set => SetValue(Color2Property, value);
    }

    public Color Color3
    {
        get => GetValue(Color3Property);
        set => SetValue(Color3Property, value);
    }

    static ZebraPatternControl()
    {
        AffectsRender<ZebraPatternControl>(TileSizeProperty, Color1Property, Color2Property, Color3Property);
    }

    public override void Render(DrawingContext context)
    {
        base.Render(context);

        var bounds = Bounds;
        if (bounds.Width <= 0 || bounds.Height <= 0)
            return;

        var tileSize = TileSize;
        // 육각형 패턴의 높이 비율 (tan(30°) ≈ 0.577)
        // Hexagonal pattern height ratio (tan(30°) ≈ 0.577)
        var tileHeight = tileSize * 0.577;

        var brush1 = new SolidColorBrush(Color1);
        var brush2 = new SolidColorBrush(Color2);
        var brush3 = new SolidColorBrush(Color3);

        // 배경을 Color1로 채우기
        // Fill background with Color1
        context.DrawRectangle(brush1, null, new Rect(0, 0, bounds.Width, bounds.Height));

        // 육각형 패턴을 타일링
        // Tile the hexagonal pattern
        var colCount = (int)Math.Ceiling(bounds.Width / tileSize) + 2;
        var rowCount = (int)Math.Ceiling(bounds.Height / tileHeight) + 2;

        for (var row = -1; row < rowCount; row++)
        {
            for (var col = -1; col < colCount; col++)
            {
                var offsetX = col * tileSize;
                var offsetY = row * tileHeight;

                // 행에 따라 오프셋 적용 (벌집 패턴)
                // Apply offset based on row (honeycomb pattern)
                if (row % 2 == 1)
                {
                    offsetX += tileSize * 0.5;
                }

                DrawHexagonTile(context, offsetX, offsetY, tileSize, tileHeight, brush1, brush2, brush3);
            }
        }
    }

    private static void DrawHexagonTile(DrawingContext context, double x, double y,
        double width, double height, IBrush brush1, IBrush brush2, IBrush brush3)
    {
        // 중심점
        // Center point
        var centerX = x + width / 2;
        var centerY = y + height / 2;

        // 각 60도씩 6개의 삼각형 그리기 (30도에서 시작)
        // Draw 6 triangles, each 60 degrees (starting from 30 degrees)
        var radius = Math.Min(width, height) * 0.5;

        for (var i = 0; i < 6; i++)
        {
            // 30도에서 시작하여 60도씩 증가
            // Start from 30 degrees and increment by 60 degrees
            var startAngle = (30 + i * 60) * Math.PI / 180;
            var endAngle = (30 + (i + 1) * 60) * Math.PI / 180;

            var x1 = centerX + radius * Math.Cos(startAngle);
            var y1 = centerY + radius * Math.Sin(startAngle);
            var x2 = centerX + radius * Math.Cos(endAngle);
            var y2 = centerY + radius * Math.Sin(endAngle);

            // 삼각형 색상 결정 (CSS와 동일한 패턴)
            // Determine triangle color (same pattern as CSS)
            // 0-60: Color1, 60-120: Color2, 120-180: Color3 (반복)
            // 0-60: Color1, 60-120: Color2, 120-180: Color3 (repeating)
            var brush = (i % 3) switch
            {
                0 => brush1,
                1 => brush2,
                _ => brush3
            };

            var geometry = new StreamGeometry();
            using (var ctx = geometry.Open())
            {
                ctx.BeginFigure(new Point(centerX, centerY), true);
                ctx.LineTo(new Point(x1, y1));
                ctx.LineTo(new Point(x2, y2));
                ctx.EndFigure(true);
            }

            context.DrawGeometry(brush, null, geometry);
        }
    }
}
