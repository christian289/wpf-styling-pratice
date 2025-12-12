using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;

namespace TinyMayfly20.Avalonia.Lib.Controls;

/// <summary>
/// CSS box-shadow 기반 픽셀 아트를 렌더링하는 컨트롤.
/// Control that renders pixel art based on CSS box-shadow.
/// </summary>
public sealed class PixelArtControl : Control
{
    private static readonly int PixelSize = 10;

    public static readonly StyledProperty<PixelData[]?> PixelsProperty =
        AvaloniaProperty.Register<PixelArtControl, PixelData[]?>(nameof(Pixels));

    public static readonly StyledProperty<double> OffsetYProperty =
        AvaloniaProperty.Register<PixelArtControl, double>(nameof(OffsetY), 0);

    public PixelData[]? Pixels
    {
        get => GetValue(PixelsProperty);
        set => SetValue(PixelsProperty, value);
    }

    public double OffsetY
    {
        get => GetValue(OffsetYProperty);
        set => SetValue(OffsetYProperty, value);
    }

    static PixelArtControl()
    {
        AffectsRender<PixelArtControl>(PixelsProperty, OffsetYProperty);
    }

    public override void Render(DrawingContext context)
    {
        base.Render(context);

        var pixels = Pixels;
        if (pixels is null || pixels.Length == 0)
            return;

        var centerX = Bounds.Width / 2;
        var offsetY = OffsetY;

        foreach (var pixel in pixels)
        {
            if (pixel.Color == Colors.Transparent)
                continue;

            var brush = new SolidColorBrush(pixel.Color);
            var rect = new Rect(
                centerX + pixel.X,
                offsetY + pixel.Y,
                PixelSize,
                PixelSize);

            context.FillRectangle(brush, rect);
        }
    }
}

public readonly record struct PixelData(int X, int Y, Color Color);
