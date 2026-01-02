using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace SpottyZebra83.Avalonia.Lib.Controls;

/// <summary>
/// 호버 시 툴팁과 배경 슬라이드 애니메이션이 있는 버튼 컨트롤
/// A button control with tooltip and background slide animation on hover
/// </summary>
public sealed class TooltipButton : TemplatedControl
{
    /// <summary>
    /// 버튼에 표시되는 메인 텍스트
    /// Main text displayed on the button
    /// </summary>
    public static readonly StyledProperty<string> TextProperty =
        AvaloniaProperty.Register<TooltipButton, string>(nameof(Text), "Tooltip 👆");

    /// <summary>
    /// 툴팁에 표시되는 텍스트
    /// Text displayed in the tooltip
    /// </summary>
    public static readonly StyledProperty<string> TooltipTextProperty =
        AvaloniaProperty.Register<TooltipButton, string>(nameof(TooltipText), "Uiverse.io");

    /// <summary>
    /// 호버 시 표시되는 텍스트
    /// Text displayed when hovered
    /// </summary>
    public static readonly StyledProperty<string> HoverTextProperty =
        AvaloniaProperty.Register<TooltipButton, string>(nameof(HoverText), "Hello! 👋");

    public string Text
    {
        get => GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public string TooltipText
    {
        get => GetValue(TooltipTextProperty);
        set => SetValue(TooltipTextProperty, value);
    }

    public string HoverText
    {
        get => GetValue(HoverTextProperty);
        set => SetValue(HoverTextProperty, value);
    }
}
