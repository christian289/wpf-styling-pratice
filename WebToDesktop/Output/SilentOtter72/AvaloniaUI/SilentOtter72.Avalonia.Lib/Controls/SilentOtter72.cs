using Avalonia;
using Avalonia.Controls.Primitives;

namespace SilentOtter72.Avalonia.Lib.Controls;

/// <summary>
/// 체크마크 아이콘이 있는 토글 스위치 컨트롤
/// A toggle switch control with checkmark icon
/// From Uiverse.io by alexruix
/// </summary>
public sealed class SilentOtter72 : ToggleButton
{
    static SilentOtter72()
    {
        // DefaultStyleKey를 현재 타입으로 설정하여 Generic.axaml의 스타일을 사용
        // Set DefaultStyleKey to current type to use styles from Generic.axaml
    }
}
