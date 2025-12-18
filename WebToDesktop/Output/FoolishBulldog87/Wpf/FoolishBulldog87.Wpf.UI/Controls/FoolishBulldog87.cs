using System.Windows;
using System.Windows.Controls.Primitives;

namespace FoolishBulldog87.Wpf.UI.Controls;

/// <summary>
/// Crimson 스타일 체크박스 컨트롤 (stroke-dashoffset 애니메이션 체크마크)
/// Crimson style checkbox control with stroke-dashoffset animated checkmark
/// </summary>
public sealed class FoolishBulldog87 : ToggleButton
{
    static FoolishBulldog87()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(FoolishBulldog87),
            new FrameworkPropertyMetadata(typeof(FoolishBulldog87)));
    }
}
