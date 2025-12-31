using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace SpicyJellyfish41.Avalonia.Lib.Controls;

/// <summary>
/// 햄버거 메뉴 버튼 - 체크 시 X 모양으로 변환되는 애니메이션 버튼
/// Hamburger menu button - Animated button that transforms to X shape when checked
/// </summary>
public sealed class HamburgerButton : ToggleButton
{
    static HamburgerButton()
    {
        // DefaultStyleKey 설정 - Generic.axaml에서 스타일 자동 적용
        // Set DefaultStyleKey - Auto-apply style from Generic.axaml
    }
}
