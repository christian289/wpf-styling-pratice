using Avalonia;
using Avalonia.Controls;

namespace ChillyDonkey13.Avalonia.Lib.Controls;

/// <summary>
/// 인디고→보라→핑크 그라디언트 배경과 호버 애니메이션을 가진 버튼 컨트롤.
/// A button control with indigo→purple→pink gradient background and hover animation.
/// </summary>
public sealed class GradientButton : Button
{
    static GradientButton()
    {
        // DefaultStyleKeyProperty 등록하여 Generic.axaml의 스타일 참조
        // Register DefaultStyleKeyProperty to reference style from Generic.axaml
    }
}
