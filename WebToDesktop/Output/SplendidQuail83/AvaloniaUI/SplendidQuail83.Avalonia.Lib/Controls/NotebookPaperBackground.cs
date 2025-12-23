using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;

namespace SplendidQuail83.Avalonia.Lib.Controls;

/// <summary>
/// 공책 줄무늬 패턴 배경 컨트롤
/// Notebook paper pattern background control
/// </summary>
public sealed class NotebookPaperBackground : Control
{
    public static readonly StyledProperty<IBrush?> BackgroundColorProperty =
        AvaloniaProperty.Register<NotebookPaperBackground, IBrush?>(
            nameof(BackgroundColor),
            new SolidColorBrush(Color.Parse("#f1f1f1")));

    public static readonly StyledProperty<Color> MarginLineColorProperty =
        AvaloniaProperty.Register<NotebookPaperBackground, Color>(
            nameof(MarginLineColor),
            Color.Parse("#ffb4b8"));

    public static readonly StyledProperty<Color> HorizontalLineColorProperty =
        AvaloniaProperty.Register<NotebookPaperBackground, Color>(
            nameof(HorizontalLineColor),
            Color.Parse("#e1e1e1"));

    public static readonly StyledProperty<double> MarginLeftProperty =
        AvaloniaProperty.Register<NotebookPaperBackground, double>(
            nameof(MarginLeft),
            50.0);

    public static readonly StyledProperty<double> MarginLineThicknessProperty =
        AvaloniaProperty.Register<NotebookPaperBackground, double>(
            nameof(MarginLineThickness),
            2.0);

    public static readonly StyledProperty<double> LineSpacingProperty =
        AvaloniaProperty.Register<NotebookPaperBackground, double>(
            nameof(LineSpacing),
            30.0);

    public static readonly StyledProperty<double> HorizontalLineThicknessProperty =
        AvaloniaProperty.Register<NotebookPaperBackground, double>(
            nameof(HorizontalLineThickness),
            1.2);

    public IBrush? BackgroundColor
    {
        get => GetValue(BackgroundColorProperty);
        set => SetValue(BackgroundColorProperty, value);
    }

    public Color MarginLineColor
    {
        get => GetValue(MarginLineColorProperty);
        set => SetValue(MarginLineColorProperty, value);
    }

    public Color HorizontalLineColor
    {
        get => GetValue(HorizontalLineColorProperty);
        set => SetValue(HorizontalLineColorProperty, value);
    }

    public double MarginLeft
    {
        get => GetValue(MarginLeftProperty);
        set => SetValue(MarginLeftProperty, value);
    }

    public double MarginLineThickness
    {
        get => GetValue(MarginLineThicknessProperty);
        set => SetValue(MarginLineThicknessProperty, value);
    }

    public double LineSpacing
    {
        get => GetValue(LineSpacingProperty);
        set => SetValue(LineSpacingProperty, value);
    }

    public double HorizontalLineThickness
    {
        get => GetValue(HorizontalLineThicknessProperty);
        set => SetValue(HorizontalLineThicknessProperty, value);
    }

    static NotebookPaperBackground()
    {
        AffectsRender<NotebookPaperBackground>(
            BackgroundColorProperty,
            MarginLineColorProperty,
            HorizontalLineColorProperty,
            MarginLeftProperty,
            MarginLineThicknessProperty,
            LineSpacingProperty,
            HorizontalLineThicknessProperty);
    }

    public override void Render(DrawingContext context)
    {
        var bounds = Bounds;

        // 배경색 렌더링
        // Render background color
        if (BackgroundColor is not null)
        {
            context.FillRectangle(BackgroundColor, new Rect(0, 0, bounds.Width, bounds.Height));
        }

        // 수평선 렌더링 (공책 줄)
        // Render horizontal lines (notebook ruled lines)
        var horizontalLinePen = new Pen(new SolidColorBrush(HorizontalLineColor), HorizontalLineThickness);
        var lineCount = (int)(bounds.Height / LineSpacing) + 1;
        for (var i = 0; i < lineCount; i++)
        {
            var y = i * LineSpacing;
            context.DrawLine(horizontalLinePen, new Point(0, y), new Point(bounds.Width, y));
        }

        // 수직 마진 라인 렌더링 (분홍색 선)
        // Render vertical margin line (pink line)
        var marginLinePen = new Pen(new SolidColorBrush(MarginLineColor), MarginLineThickness);
        context.DrawLine(marginLinePen, new Point(MarginLeft, 0), new Point(MarginLeft, bounds.Height));
    }
}
