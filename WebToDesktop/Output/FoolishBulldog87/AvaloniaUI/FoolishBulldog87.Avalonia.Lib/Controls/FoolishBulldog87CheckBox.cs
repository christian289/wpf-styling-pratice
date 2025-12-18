using Avalonia;
using Avalonia.Controls.Primitives;

namespace FoolishBulldog87.Avalonia.Lib.Controls;

/// <summary>
/// SVG 체크마크 애니메이션이 있는 커스텀 체크박스 컨트롤.
/// Custom checkbox control with animated SVG checkmark.
/// </summary>
/// <remarks>
/// Original design by elijahgummer from Uiverse.io
/// </remarks>
public sealed class FoolishBulldog87CheckBox : ToggleButton
{
    static FoolishBulldog87CheckBox()
    {
        // DefaultStyleKeyProperty 설정 - Generic.axaml에서 스타일 참조
        // Set DefaultStyleKeyProperty to reference style from Generic.axaml
    }
}
