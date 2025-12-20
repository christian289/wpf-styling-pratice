using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace CurvyEarwig22.Avalonia.Lib.Controls;

/// <summary>
/// A neon-glowing search box with animated border effects.
/// 네온 빛 효과와 애니메이션 테두리가 있는 검색 박스 컨트롤.
/// </summary>
public sealed class NeonSearchBox : TemplatedControl
{
    /// <summary>
    /// Defines the <see cref="Text"/> property.
    /// </summary>
    public static readonly StyledProperty<string?> TextProperty =
        AvaloniaProperty.Register<NeonSearchBox, string?>(nameof(Text));

    /// <summary>
    /// Defines the <see cref="Watermark"/> property.
    /// </summary>
    public static readonly StyledProperty<string?> WatermarkProperty =
        AvaloniaProperty.Register<NeonSearchBox, string?>(nameof(Watermark), "Search...");

    /// <summary>
    /// Gets or sets the text content of the search box.
    /// </summary>
    public string? Text
    {
        get => GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    /// <summary>
    /// Gets or sets the watermark (placeholder) text.
    /// </summary>
    public string? Watermark
    {
        get => GetValue(WatermarkProperty);
        set => SetValue(WatermarkProperty, value);
    }
}
