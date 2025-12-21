using Avalonia;
using Avalonia.Controls.Primitives;

namespace TerribleKangaroo96.Avalonia.Lib.Controls;

/// <summary>
/// 원형 체크박스 컨트롤.
/// A circular checkbox control with animated checkmark.
/// </summary>
public sealed class CircleCheckBox : ToggleButton
{
    static CircleCheckBox()
    {
        // DefaultStyleKey 설정으로 Generic.axaml에서 스타일 참조
        // Set DefaultStyleKey to reference style from Generic.axaml
    }
}
