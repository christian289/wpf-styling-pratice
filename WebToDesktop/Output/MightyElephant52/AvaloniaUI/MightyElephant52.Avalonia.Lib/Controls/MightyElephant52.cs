using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace MightyElephant52.Avalonia.Lib.Controls;

/// <summary>
/// Tooltip이 있는 Follow 버튼 컨트롤.
/// uiverse.io by vinodjangid07 디자인 기반.
/// A Follow button control with tooltip.
/// Based on uiverse.io design by vinodjangid07.
/// </summary>
public sealed class MightyElephant52 : TemplatedControl
{
    /// <summary>
    /// 툴팁에 표시될 텍스트를 정의합니다.
    /// Defines the text to be displayed in the tooltip.
    /// </summary>
    public static readonly StyledProperty<string> TooltipTextProperty =
        AvaloniaProperty.Register<MightyElephant52, string>(nameof(TooltipText), "45k");

    /// <summary>
    /// 버튼에 표시될 텍스트를 정의합니다.
    /// Defines the text to be displayed on the button.
    /// </summary>
    public static readonly StyledProperty<string> ButtonTextProperty =
        AvaloniaProperty.Register<MightyElephant52, string>(nameof(ButtonText), "Follow");

    /// <summary>
    /// 툴팁에 표시될 텍스트를 가져오거나 설정합니다.
    /// Gets or sets the text displayed in the tooltip.
    /// </summary>
    public string TooltipText
    {
        get => GetValue(TooltipTextProperty);
        set => SetValue(TooltipTextProperty, value);
    }

    /// <summary>
    /// 버튼에 표시될 텍스트를 가져오거나 설정합니다.
    /// Gets or sets the text displayed on the button.
    /// </summary>
    public string ButtonText
    {
        get => GetValue(ButtonTextProperty);
        set => SetValue(ButtonTextProperty, value);
    }
}
