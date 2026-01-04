using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace AverageShrimp57.Avalonia.Lib.Controls;

/// <summary>
/// On/Off 라이트 스위치 스타일의 토글 컨트롤
/// A light switch style toggle control with On/Off labels
/// </summary>
public sealed class LightSwitch : ToggleButton
{
    /// <summary>
    /// 체크되지 않은 상태의 텍스트 (기본값: "On")
    /// Text displayed when unchecked (default: "On")
    /// </summary>
    public static readonly StyledProperty<string> UncheckedTextProperty =
        AvaloniaProperty.Register<LightSwitch, string>(nameof(UncheckedText), "On");

    /// <summary>
    /// 체크된 상태의 텍스트 (기본값: "Off")
    /// Text displayed when checked (default: "Off")
    /// </summary>
    public static readonly StyledProperty<string> CheckedTextProperty =
        AvaloniaProperty.Register<LightSwitch, string>(nameof(CheckedText), "Off");

    public string UncheckedText
    {
        get => GetValue(UncheckedTextProperty);
        set => SetValue(UncheckedTextProperty, value);
    }

    public string CheckedText
    {
        get => GetValue(CheckedTextProperty);
        set => SetValue(CheckedTextProperty, value);
    }

    static LightSwitch()
    {
        // 기본 스타일 키 설정
        // Set default style key
    }
}
