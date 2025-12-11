using System.Windows;
using System.Windows.Controls;

namespace SourLionfish18.Wpf.UI.Controls;

/// <summary>
/// 애니메이션 체크마크가 있는 둥근 체크박스 컨트롤
/// Rounded checkbox control with animated checkmark
/// </summary>
public sealed class SourLionfish18 : CheckBox
{
    static SourLionfish18()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(SourLionfish18),
            new FrameworkPropertyMetadata(typeof(SourLionfish18)));
    }
}
