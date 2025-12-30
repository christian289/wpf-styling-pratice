using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;

namespace BrownCheetah84.Avalonia.Lib.Controls;

/// <summary>
/// 대각선 체크 패턴 배경 컨트롤
/// Diagonal check pattern background control
/// </summary>
public sealed class PatternBackground : ContentControl
{
    public static readonly StyledProperty<IBrush?> PatternBrushProperty =
        AvaloniaProperty.Register<PatternBackground, IBrush?>(nameof(PatternBrush));

    public static readonly StyledProperty<double> PatternOpacityProperty =
        AvaloniaProperty.Register<PatternBackground, double>(nameof(PatternOpacity), 0.8);

    public static readonly StyledProperty<double> PatternSizeProperty =
        AvaloniaProperty.Register<PatternBackground, double>(nameof(PatternSize), 20.0);

    public IBrush? PatternBrush
    {
        get => GetValue(PatternBrushProperty);
        set => SetValue(PatternBrushProperty, value);
    }

    public double PatternOpacity
    {
        get => GetValue(PatternOpacityProperty);
        set => SetValue(PatternOpacityProperty, value);
    }

    public double PatternSize
    {
        get => GetValue(PatternSizeProperty);
        set => SetValue(PatternSizeProperty, value);
    }
}
