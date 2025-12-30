using Avalonia;
using Avalonia.Controls;

namespace PlasticMule29.Avalonia.Lib.Controls;

/// <summary>
/// 3D 입체 효과가 있는 버튼 컨트롤.
/// CSS ::before와 ::after pseudo-element를 활용한 inset box-shadow 효과 재현.
/// 3D button control with inset shadow effects.
/// Reproduces CSS ::before and ::after pseudo-element inset box-shadow effects.
/// </summary>
public sealed class PlasticMule29Button : Button
{
    static PlasticMule29Button()
    {
        // DefaultStyleKey를 설정하여 Generic.axaml에서 스타일을 찾도록 함
        // Set DefaultStyleKey to locate style in Generic.axaml
        AffectsRender<PlasticMule29Button>(
            BackgroundProperty,
            ForegroundProperty);
    }
}
