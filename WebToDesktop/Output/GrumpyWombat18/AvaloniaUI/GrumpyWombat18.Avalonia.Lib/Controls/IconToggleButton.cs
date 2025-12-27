using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Media;

namespace GrumpyWombat18.Avalonia.Lib.Controls;

/// <summary>
/// 체크/해제 상태에 따라 다른 아이콘과 텍스트를 표시하는 토글 버튼 컨트롤.
/// A toggle button control that displays different icons and text based on checked/unchecked state.
/// </summary>
public sealed class IconToggleButton : ToggleButton
{
    /// <summary>
    /// 해제 상태(Unchecked)의 아이콘 Geometry.
    /// Icon Geometry for unchecked state.
    /// </summary>
    public static readonly StyledProperty<Geometry?> UncheckedIconProperty =
        AvaloniaProperty.Register<IconToggleButton, Geometry?>(nameof(UncheckedIcon));

    /// <summary>
    /// 체크 상태(Checked)의 아이콘 Geometry.
    /// Icon Geometry for checked state.
    /// </summary>
    public static readonly StyledProperty<Geometry?> CheckedIconProperty =
        AvaloniaProperty.Register<IconToggleButton, Geometry?>(nameof(CheckedIcon));

    /// <summary>
    /// 해제 상태(Unchecked)의 텍스트.
    /// Text for unchecked state.
    /// </summary>
    public static readonly StyledProperty<string?> UncheckedTextProperty =
        AvaloniaProperty.Register<IconToggleButton, string?>(nameof(UncheckedText));

    /// <summary>
    /// 체크 상태(Checked)의 텍스트.
    /// Text for checked state.
    /// </summary>
    public static readonly StyledProperty<string?> CheckedTextProperty =
        AvaloniaProperty.Register<IconToggleButton, string?>(nameof(CheckedText));

    /// <summary>
    /// 아이콘 크기.
    /// Icon size.
    /// </summary>
    public static readonly StyledProperty<double> IconSizeProperty =
        AvaloniaProperty.Register<IconToggleButton, double>(nameof(IconSize), 30);

    /// <summary>
    /// 해제 상태 배경색.
    /// Background color for unchecked state.
    /// </summary>
    public static readonly StyledProperty<IBrush?> UncheckedBackgroundProperty =
        AvaloniaProperty.Register<IconToggleButton, IBrush?>(nameof(UncheckedBackground));

    /// <summary>
    /// 체크 상태 배경색.
    /// Background color for checked state.
    /// </summary>
    public static readonly StyledProperty<IBrush?> CheckedBackgroundProperty =
        AvaloniaProperty.Register<IconToggleButton, IBrush?>(nameof(CheckedBackground));

    public Geometry? UncheckedIcon
    {
        get => GetValue(UncheckedIconProperty);
        set => SetValue(UncheckedIconProperty, value);
    }

    public Geometry? CheckedIcon
    {
        get => GetValue(CheckedIconProperty);
        set => SetValue(CheckedIconProperty, value);
    }

    public string? UncheckedText
    {
        get => GetValue(UncheckedTextProperty);
        set => SetValue(UncheckedTextProperty, value);
    }

    public string? CheckedText
    {
        get => GetValue(CheckedTextProperty);
        set => SetValue(CheckedTextProperty, value);
    }

    public double IconSize
    {
        get => GetValue(IconSizeProperty);
        set => SetValue(IconSizeProperty, value);
    }

    public IBrush? UncheckedBackground
    {
        get => GetValue(UncheckedBackgroundProperty);
        set => SetValue(UncheckedBackgroundProperty, value);
    }

    public IBrush? CheckedBackground
    {
        get => GetValue(CheckedBackgroundProperty);
        set => SetValue(CheckedBackgroundProperty, value);
    }
}
