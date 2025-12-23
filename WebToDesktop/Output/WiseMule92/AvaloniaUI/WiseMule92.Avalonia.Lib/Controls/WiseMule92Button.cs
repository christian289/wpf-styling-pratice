using Avalonia;
using Avalonia.Controls.Primitives;

namespace WiseMule92.Avalonia.Lib.Controls;

/// <summary>
/// 鬼滅の刃 스타일 버튼 - hover 시 색상 반전 및 텍스트 회전 애니메이션
/// Demon Slayer style button - color inversion and text rotation animation on hover
/// </summary>
public sealed class WiseMule92Button : TemplatedControl
{
    /// <summary>
    /// 버튼에 표시할 텍스트
    /// Text to display on the button
    /// </summary>
    public static readonly StyledProperty<string> TextProperty =
        AvaloniaProperty.Register<WiseMule92Button, string>(nameof(Text), "鬼滅の刃");

    public string Text
    {
        get => GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }
}
