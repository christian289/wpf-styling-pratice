using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Media;

namespace GrumpyWombat18.Avalonia.Lib.Controls;

/// <summary>
/// A toggle button that displays different icons and text based on checked state.
/// 체크 상태에 따라 다른 아이콘과 텍스트를 표시하는 토글 버튼.
/// </summary>
public sealed class IconToggleButton : ToggleButton
{
    /// <summary>
    /// Defines the UncheckedIcon property.
    /// 체크되지 않은 상태의 아이콘 정의.
    /// </summary>
    public static readonly StyledProperty<Geometry?> UncheckedIconProperty =
        AvaloniaProperty.Register<IconToggleButton, Geometry?>(nameof(UncheckedIcon));

    /// <summary>
    /// Defines the CheckedIcon property.
    /// 체크된 상태의 아이콘 정의.
    /// </summary>
    public static readonly StyledProperty<Geometry?> CheckedIconProperty =
        AvaloniaProperty.Register<IconToggleButton, Geometry?>(nameof(CheckedIcon));

    /// <summary>
    /// Defines the UncheckedText property.
    /// 체크되지 않은 상태의 텍스트 정의.
    /// </summary>
    public static readonly StyledProperty<string> UncheckedTextProperty =
        AvaloniaProperty.Register<IconToggleButton, string>(nameof(UncheckedText), "ball");

    /// <summary>
    /// Defines the CheckedText property.
    /// 체크된 상태의 텍스트 정의.
    /// </summary>
    public static readonly StyledProperty<string> CheckedTextProperty =
        AvaloniaProperty.Register<IconToggleButton, string>(nameof(CheckedText), "Game");

    /// <summary>
    /// Defines the UncheckedBackground property.
    /// 체크되지 않은 상태의 배경색 정의.
    /// </summary>
    public static readonly StyledProperty<IBrush?> UncheckedBackgroundProperty =
        AvaloniaProperty.Register<IconToggleButton, IBrush?>(nameof(UncheckedBackground));

    /// <summary>
    /// Defines the CheckedBackground property.
    /// 체크된 상태의 배경색 정의.
    /// </summary>
    public static readonly StyledProperty<IBrush?> CheckedBackgroundProperty =
        AvaloniaProperty.Register<IconToggleButton, IBrush?>(nameof(CheckedBackground));

    /// <summary>
    /// Defines the IconSize property.
    /// 아이콘 크기 정의.
    /// </summary>
    public static readonly StyledProperty<double> IconSizeProperty =
        AvaloniaProperty.Register<IconToggleButton, double>(nameof(IconSize), 30);

    /// <summary>
    /// Gets or sets the icon for unchecked state.
    /// 체크되지 않은 상태의 아이콘.
    /// </summary>
    public Geometry? UncheckedIcon
    {
        get => GetValue(UncheckedIconProperty);
        set => SetValue(UncheckedIconProperty, value);
    }

    /// <summary>
    /// Gets or sets the icon for checked state.
    /// 체크된 상태의 아이콘.
    /// </summary>
    public Geometry? CheckedIcon
    {
        get => GetValue(CheckedIconProperty);
        set => SetValue(CheckedIconProperty, value);
    }

    /// <summary>
    /// Gets or sets the text for unchecked state.
    /// 체크되지 않은 상태의 텍스트.
    /// </summary>
    public string UncheckedText
    {
        get => GetValue(UncheckedTextProperty);
        set => SetValue(UncheckedTextProperty, value);
    }

    /// <summary>
    /// Gets or sets the text for checked state.
    /// 체크된 상태의 텍스트.
    /// </summary>
    public string CheckedText
    {
        get => GetValue(CheckedTextProperty);
        set => SetValue(CheckedTextProperty, value);
    }

    /// <summary>
    /// Gets or sets the background for unchecked state.
    /// 체크되지 않은 상태의 배경색.
    /// </summary>
    public IBrush? UncheckedBackground
    {
        get => GetValue(UncheckedBackgroundProperty);
        set => SetValue(UncheckedBackgroundProperty, value);
    }

    /// <summary>
    /// Gets or sets the background for checked state.
    /// 체크된 상태의 배경색.
    /// </summary>
    public IBrush? CheckedBackground
    {
        get => GetValue(CheckedBackgroundProperty);
        set => SetValue(CheckedBackgroundProperty, value);
    }

    /// <summary>
    /// Gets or sets the icon size.
    /// 아이콘 크기.
    /// </summary>
    public double IconSize
    {
        get => GetValue(IconSizeProperty);
        set => SetValue(IconSizeProperty, value);
    }
}
