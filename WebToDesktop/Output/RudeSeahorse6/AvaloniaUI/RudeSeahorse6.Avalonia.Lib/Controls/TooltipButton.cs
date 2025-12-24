using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace RudeSeahorse6.Avalonia.Lib.Controls;

/// <summary>
/// hover 시 애니메이션 tooltip이 나타나는 그라데이션 버튼 컨트롤
/// A gradient button control with animated tooltip that appears on hover
/// </summary>
public sealed class TooltipButton : TemplatedControl
{
    public static readonly StyledProperty<string> TextProperty =
        AvaloniaProperty.Register<TooltipButton, string>(nameof(Text), "uiverse");

    public static readonly StyledProperty<string> TooltipTitleProperty =
        AvaloniaProperty.Register<TooltipButton, string>(nameof(TooltipTitle), "LET'S CREATE!");

    public static readonly StyledProperty<string> TooltipItem1Property =
        AvaloniaProperty.Register<TooltipButton, string>(nameof(TooltipItem1), "1 - Explore");

    public static readonly StyledProperty<string> TooltipItem2Property =
        AvaloniaProperty.Register<TooltipButton, string>(nameof(TooltipItem2), "2 - Have fun!");

    /// <summary>
    /// 버튼에 표시되는 텍스트
    /// Text displayed on the button
    /// </summary>
    public string Text
    {
        get => GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    /// <summary>
    /// 툴팁의 제목 텍스트
    /// Title text of the tooltip
    /// </summary>
    public string TooltipTitle
    {
        get => GetValue(TooltipTitleProperty);
        set => SetValue(TooltipTitleProperty, value);
    }

    /// <summary>
    /// 툴팁의 첫 번째 항목 텍스트
    /// First item text of the tooltip
    /// </summary>
    public string TooltipItem1
    {
        get => GetValue(TooltipItem1Property);
        set => SetValue(TooltipItem1Property, value);
    }

    /// <summary>
    /// 툴팁의 두 번째 항목 텍스트
    /// Second item text of the tooltip
    /// </summary>
    public string TooltipItem2
    {
        get => GetValue(TooltipItem2Property);
        set => SetValue(TooltipItem2Property, value);
    }
}
