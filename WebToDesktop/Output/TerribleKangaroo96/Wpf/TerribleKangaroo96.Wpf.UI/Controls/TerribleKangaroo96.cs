using System.Windows;
using System.Windows.Controls.Primitives;

namespace TerribleKangaroo96.Wpf.UI.Controls;

/// <summary>
/// 원형 체크박스 컨트롤
/// Circular checkbox control with checkmark animation
/// </summary>
public sealed class TerribleKangaroo96 : ToggleButton
{
    static TerribleKangaroo96()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(TerribleKangaroo96),
            new FrameworkPropertyMetadata(typeof(TerribleKangaroo96)));
    }
}
