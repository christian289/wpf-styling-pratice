using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace ItchyMule52.Avalonia.Lib.Controls;

/// <summary>
/// 네온 스타일 토글 스위치 컨트롤
/// Neon style toggle switch control
/// </summary>
public sealed class NeonToggleSwitch : ToggleButton
{
    static NeonToggleSwitch()
    {
        // ToggleButton 기반이므로 IsChecked 속성을 그대로 사용
        // Using IsChecked property as it's based on ToggleButton
    }
}
