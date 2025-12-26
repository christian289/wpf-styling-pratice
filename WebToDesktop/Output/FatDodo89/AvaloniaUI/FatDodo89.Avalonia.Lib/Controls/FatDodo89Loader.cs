using Avalonia;
using Avalonia.Controls.Primitives;

namespace FatDodo89.Avalonia.Lib.Controls;

/// <summary>
/// 눈과 입이 있는 이모티콘 스타일 로딩 스피너 컨트롤.
/// Emoticon-style loading spinner control with eyes and mouth.
/// </summary>
public sealed class FatDodo89Loader : TemplatedControl
{
    /// <summary>
    /// 상단 레이어 색상 (청록색).
    /// Top layer color (cyan).
    /// </summary>
    public static readonly StyledProperty<string> TopColorProperty =
        AvaloniaProperty.Register<FatDodo89Loader, string>(nameof(TopColor), "hsl(193, 90%, 50%)");

    /// <summary>
    /// 하단 레이어 색상 (파란색).
    /// Bottom layer color (blue).
    /// </summary>
    public static readonly StyledProperty<string> BottomColorProperty =
        AvaloniaProperty.Register<FatDodo89Loader, string>(nameof(BottomColor), "hsl(223, 90%, 50%)");

    /// <summary>
    /// 로더 크기 (기본 108px).
    /// Loader size (default 108px).
    /// </summary>
    public static readonly StyledProperty<double> LoaderSizeProperty =
        AvaloniaProperty.Register<FatDodo89Loader, double>(nameof(LoaderSize), 108.0);

    public string TopColor
    {
        get => GetValue(TopColorProperty);
        set => SetValue(TopColorProperty, value);
    }

    public string BottomColor
    {
        get => GetValue(BottomColorProperty);
        set => SetValue(BottomColorProperty, value);
    }

    public double LoaderSize
    {
        get => GetValue(LoaderSizeProperty);
        set => SetValue(LoaderSizeProperty, value);
    }
}
