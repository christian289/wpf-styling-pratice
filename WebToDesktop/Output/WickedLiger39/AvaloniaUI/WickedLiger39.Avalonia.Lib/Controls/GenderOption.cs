using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Media;

namespace WickedLiger39.Avalonia.Lib.Controls;

/// <summary>
/// 성별 옵션을 나타내는 단일 라디오 버튼 컨트롤
/// Represents a single gender option radio button control
/// </summary>
public sealed class GenderOption : RadioButton
{
    public static readonly StyledProperty<Geometry?> IconDataProperty =
        AvaloniaProperty.Register<GenderOption, Geometry?>(nameof(IconData));

    public static readonly StyledProperty<IBrush?> IconFillProperty =
        AvaloniaProperty.Register<GenderOption, IBrush?>(nameof(IconFill));

    public static readonly StyledProperty<IBrush?> IconStrokeProperty =
        AvaloniaProperty.Register<GenderOption, IBrush?>(nameof(IconStroke));

    public static readonly StyledProperty<double> IconStrokeThicknessProperty =
        AvaloniaProperty.Register<GenderOption, double>(nameof(IconStrokeThickness), 0);

    public static readonly StyledProperty<IBrush?> CircleBackgroundProperty =
        AvaloniaProperty.Register<GenderOption, IBrush?>(nameof(CircleBackground));

    public static readonly StyledProperty<IBrush?> RippleBackgroundProperty =
        AvaloniaProperty.Register<GenderOption, IBrush?>(nameof(RippleBackground));

    public static readonly StyledProperty<IBrush?> RingBrushProperty =
        AvaloniaProperty.Register<GenderOption, IBrush?>(nameof(RingBrush));

    /// <summary>
    /// 아이콘의 Path 데이터
    /// Path data for the icon
    /// </summary>
    public Geometry? IconData
    {
        get => GetValue(IconDataProperty);
        set => SetValue(IconDataProperty, value);
    }

    /// <summary>
    /// 아이콘의 채우기 브러시
    /// Fill brush for the icon
    /// </summary>
    public IBrush? IconFill
    {
        get => GetValue(IconFillProperty);
        set => SetValue(IconFillProperty, value);
    }

    /// <summary>
    /// 아이콘의 테두리 브러시
    /// Stroke brush for the icon
    /// </summary>
    public IBrush? IconStroke
    {
        get => GetValue(IconStrokeProperty);
        set => SetValue(IconStrokeProperty, value);
    }

    /// <summary>
    /// 아이콘의 테두리 두께
    /// Stroke thickness for the icon
    /// </summary>
    public double IconStrokeThickness
    {
        get => GetValue(IconStrokeThicknessProperty);
        set => SetValue(IconStrokeThicknessProperty, value);
    }

    /// <summary>
    /// 원형 배경 브러시
    /// Circle background brush
    /// </summary>
    public IBrush? CircleBackground
    {
        get => GetValue(CircleBackgroundProperty);
        set => SetValue(CircleBackgroundProperty, value);
    }

    /// <summary>
    /// 선택 시 확산되는 리플 배경 브러시
    /// Ripple background brush when selected
    /// </summary>
    public IBrush? RippleBackground
    {
        get => GetValue(RippleBackgroundProperty);
        set => SetValue(RippleBackgroundProperty, value);
    }

    /// <summary>
    /// 선택 시 표시되는 링 색상
    /// Ring color when selected
    /// </summary>
    public IBrush? RingBrush
    {
        get => GetValue(RingBrushProperty);
        set => SetValue(RingBrushProperty, value);
    }
}
