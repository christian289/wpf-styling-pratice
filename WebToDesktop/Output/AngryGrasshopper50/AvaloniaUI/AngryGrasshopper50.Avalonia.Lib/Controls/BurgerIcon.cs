using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace AngryGrasshopper50.Avalonia.Lib.Controls;

/// <summary>
/// 햄버거 메뉴 아이콘 컨트롤. 클릭 시 X 형태로 애니메이션됨.
/// Hamburger menu icon control. Animates to X shape when clicked.
/// </summary>
public sealed class BurgerIcon : ToggleButton
{
    static BurgerIcon()
    {
        // DefaultStyleKey를 설정하여 Generic.axaml에서 스타일을 찾도록 함
        // Set DefaultStyleKey to find style in Generic.axaml
    }

    public BurgerIcon()
    {
        // ToggleButton 기본 동작 사용
        // Use ToggleButton default behavior
    }
}
