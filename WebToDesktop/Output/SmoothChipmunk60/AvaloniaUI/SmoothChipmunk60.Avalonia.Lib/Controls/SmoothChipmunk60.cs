using Avalonia;
using Avalonia.Controls.Primitives;

namespace SmoothChipmunk60.Avalonia.Lib.Controls;

/// <summary>
/// 햄버거 메뉴 토글 버튼 - 체크 시 X 표시로 변환되는 애니메이션 스위치
/// Hamburger menu toggle button - animated switch that transforms to X when checked
/// </summary>
public sealed class SmoothChipmunk60 : ToggleButton
{
    static SmoothChipmunk60()
    {
        // DefaultStyleKey 설정 - Generic.axaml에서 스타일을 찾도록 함
        // Set DefaultStyleKey to find style from Generic.axaml
    }
}
