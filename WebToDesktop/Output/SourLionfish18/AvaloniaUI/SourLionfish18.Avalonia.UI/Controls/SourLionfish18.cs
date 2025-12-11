using Avalonia;
using Avalonia.Controls.Primitives;

namespace SourLionfish18.Avalonia.UI.Controls;

/// <summary>
/// 애니메이션 체크마크가 있는 둥근 체크박스 컨트롤
/// Rounded checkbox control with animated checkmark
/// </summary>
public sealed class SourLionfish18 : ToggleButton
{
    static SourLionfish18()
    {
        AffectsRender<SourLionfish18>(IsCheckedProperty);
    }
}
