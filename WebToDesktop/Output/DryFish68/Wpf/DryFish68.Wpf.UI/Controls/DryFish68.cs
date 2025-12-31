using System.Windows;
using System.Windows.Controls;

namespace DryFish68.Wpf.UI.Controls;

/// <summary>
/// Download CV 버튼 - hover 시 배경이 아래에서 위로 사라지는 효과
/// Download CV button - background slides down on hover effect
/// </summary>
public sealed class DryFish68 : Button
{
    static DryFish68()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(DryFish68),
            new FrameworkPropertyMetadata(typeof(DryFish68)));
    }
}
