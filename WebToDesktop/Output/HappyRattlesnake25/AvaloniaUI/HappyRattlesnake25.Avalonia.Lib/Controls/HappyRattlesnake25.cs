using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;

namespace HappyRattlesnake25.Avalonia.Lib.Controls;

/// <summary>
/// Material Design 스타일의 기하학적 패턴 배경 컨트롤.
/// Conic gradient를 사용한 육각형/삼각형 타일 패턴을 표현합니다.
/// Material Design style geometric pattern background control.
/// Represents hexagonal/triangular tile pattern using conic gradient.
/// </summary>
public sealed class HappyRattlesnake25 : Control
{
    /// <summary>
    /// 패턴의 크기를 제어합니다 (CSS --s 변수에 해당).
    /// Controls the size of the pattern (corresponds to CSS --s variable).
    /// </summary>
    public static readonly StyledProperty<double> PatternSizeProperty =
        AvaloniaProperty.Register<HappyRattlesnake25, double>(nameof(PatternSize), 65.0);

    /// <summary>
    /// 첫 번째 색상 (밝은 회색, CSS --c1에 해당).
    /// First color (light gray, corresponds to CSS --c1).
    /// </summary>
    public static readonly StyledProperty<Color> Color1Property =
        AvaloniaProperty.Register<HappyRattlesnake25, Color>(nameof(Color1), Color.Parse("#dadee1"));

    /// <summary>
    /// 두 번째 색상 (청록색, CSS --c2에 해당).
    /// Second color (teal, corresponds to CSS --c2).
    /// </summary>
    public static readonly StyledProperty<Color> Color2Property =
        AvaloniaProperty.Register<HappyRattlesnake25, Color>(nameof(Color2), Color.Parse("#4a99b4"));

    /// <summary>
    /// 세 번째 색상 (민트색, CSS --c3에 해당).
    /// Third color (mint, corresponds to CSS --c3).
    /// </summary>
    public static readonly StyledProperty<Color> Color3Property =
        AvaloniaProperty.Register<HappyRattlesnake25, Color>(nameof(Color3), Color.Parse("#9cceb5"));

    public double PatternSize
    {
        get => GetValue(PatternSizeProperty);
        set => SetValue(PatternSizeProperty, value);
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

    static HappyRattlesnake25()
    {
        AffectsRender<HappyRattlesnake25>(PatternSizeProperty, Color1Property, Color2Property, Color3Property);
    }

    public override void Render(DrawingContext context)
    {
        var bounds = new Rect(0, 0, Bounds.Width, Bounds.Height);
        if (bounds.Width <= 0 || bounds.Height <= 0)
            return;

        var s = PatternSize;
        var tileWidth = 2 * s;
        var tileHeight = s;

        // 배경 기본 색상 채우기
        // Fill background base color
        context.FillRectangle(new SolidColorBrush(Color1), bounds);

        // 타일 패턴 그리기
        // Draw tile pattern
        var cols = (int)Math.Ceiling(bounds.Width / tileWidth) + 2;
        var rows = (int)Math.Ceiling(bounds.Height / tileHeight) + 2;

        for (var row = -1; row < rows; row++)
        {
            for (var col = -1; col < cols; col++)
            {
                var offsetX = col * tileWidth;
                var offsetY = row * tileHeight;

                // 행에 따른 오프셋 (staggered pattern)
                // Offset based on row (staggered pattern)
                if (row % 2 == 1)
                {
                    offsetX += s;
                }

                DrawTile(context, offsetX, offsetY, s);
            }
        }
    }

    private void DrawTile(DrawingContext context, double x, double y, double size)
    {
        var brush1 = new SolidColorBrush(Color1);
        var brush2 = new SolidColorBrush(Color2);
        var brush3 = new SolidColorBrush(Color3);

        // 육각형 타일 기반 패턴 생성
        // Create hexagonal tile based pattern
        var halfSize = size / 2;
        var quarterSize = size / 4;

        // 왼쪽 삼각형 (Color2)
        // Left triangle (Color2)
        var leftTriangle = new StreamGeometry();
        using (var ctx = leftTriangle.Open())
        {
            ctx.BeginFigure(new Point(x, y + halfSize), true);
            ctx.LineTo(new Point(x + halfSize, y));
            ctx.LineTo(new Point(x + halfSize, y + size));
            ctx.EndFigure(true);
        }
        context.DrawGeometry(brush2, null, leftTriangle);

        // 오른쪽 삼각형 (Color2)
        // Right triangle (Color2)
        var rightTriangle = new StreamGeometry();
        using (var ctx = rightTriangle.Open())
        {
            ctx.BeginFigure(new Point(x + 2 * size, y + halfSize), true);
            ctx.LineTo(new Point(x + 1.5 * size, y));
            ctx.LineTo(new Point(x + 1.5 * size, y + size));
            ctx.EndFigure(true);
        }
        context.DrawGeometry(brush2, null, rightTriangle);

        // 상단 마름모 (Color1)
        // Top diamond (Color1)
        var topDiamond = new StreamGeometry();
        using (var ctx = topDiamond.Open())
        {
            ctx.BeginFigure(new Point(x + halfSize, y), true);
            ctx.LineTo(new Point(x + size, y + halfSize));
            ctx.LineTo(new Point(x + 1.5 * size, y));
            ctx.EndFigure(true);
        }
        context.DrawGeometry(brush1, null, topDiamond);

        // 하단 마름모 (Color1)
        // Bottom diamond (Color1)
        var bottomDiamond = new StreamGeometry();
        using (var ctx = bottomDiamond.Open())
        {
            ctx.BeginFigure(new Point(x + halfSize, y + size), true);
            ctx.LineTo(new Point(x + size, y + halfSize));
            ctx.LineTo(new Point(x + 1.5 * size, y + size));
            ctx.EndFigure(true);
        }
        context.DrawGeometry(brush1, null, bottomDiamond);

        // 중앙 육각형 영역 (Color3 악센트)
        // Center hexagon area (Color3 accent)
        var centerHex = new StreamGeometry();
        using (var ctx = centerHex.Open())
        {
            ctx.BeginFigure(new Point(x + halfSize + quarterSize, y + quarterSize), true);
            ctx.LineTo(new Point(x + size + quarterSize, y + quarterSize));
            ctx.LineTo(new Point(x + size + halfSize, y + halfSize));
            ctx.LineTo(new Point(x + size + quarterSize, y + size - quarterSize));
            ctx.LineTo(new Point(x + halfSize + quarterSize, y + size - quarterSize));
            ctx.LineTo(new Point(x + halfSize, y + halfSize));
            ctx.EndFigure(true);
        }
        context.DrawGeometry(brush3, null, centerHex);
    }
}
