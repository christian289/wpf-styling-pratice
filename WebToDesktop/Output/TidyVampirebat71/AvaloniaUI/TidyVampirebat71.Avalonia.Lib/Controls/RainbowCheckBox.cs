using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace TidyVampirebat71.Avalonia.Lib.Controls;

/// <summary>
/// 무지개색 애니메이션 효과가 있는 체크박스 컨트롤.
/// Rainbow animation checkbox control with rotating bars.
/// </summary>
public sealed class RainbowCheckBox : ToggleButton
{
    static RainbowCheckBox()
    {
        // DefaultStyleKeyProperty 설정은 AvaloniaUI에서 불필요
        // Not needed in AvaloniaUI as styles are resolved via selectors
    }
}
