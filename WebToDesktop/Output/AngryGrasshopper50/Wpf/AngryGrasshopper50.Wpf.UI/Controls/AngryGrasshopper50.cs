using System.Windows;
using System.Windows.Controls.Primitives;

namespace AngryGrasshopper50.Wpf.UI.Controls;

/// <summary>
/// 햄버거 메뉴 아이콘 토글 버튼. 클릭 시 X 아이콘으로 변환되는 애니메이션 효과.
/// Hamburger menu icon toggle button. Animates to X icon on click.
/// </summary>
public sealed class AngryGrasshopper50 : ToggleButton
{
    static AngryGrasshopper50()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(AngryGrasshopper50),
            new FrameworkPropertyMetadata(typeof(AngryGrasshopper50)));
    }
}
