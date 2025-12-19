using Avalonia;
using Avalonia.Controls.Primitives;

namespace BrightTiger84.Avalonia.Lib.Controls;

/// <summary>
/// 좋아요(엄지척) 스타일의 체크박스 컨트롤.
/// A thumb-up style checkbox control for "like" interactions.
/// </summary>
public sealed class ThumbLikeCheckBox : ToggleButton
{
    static ThumbLikeCheckBox()
    {
        // AvaloniaUI에서는 WPF와 달리 DefaultStyleKey 설정이 필요 없음
        // 스타일은 Generic.axaml에서 Selector로 지정됨
        // In AvaloniaUI, DefaultStyleKey is not needed unlike WPF
        // Styles are specified via Selector in Generic.axaml
    }
}
