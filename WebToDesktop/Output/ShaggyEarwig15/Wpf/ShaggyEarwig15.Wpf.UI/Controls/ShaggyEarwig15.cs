using System.Windows;
using System.Windows.Controls.Primitives;

namespace ShaggyEarwig15.Wpf.UI.Controls;

/// <summary>
/// Hamburger menu toggle button with X transformation animation.
/// 햄버거 메뉴 토글 버튼으로, 클릭 시 X 아이콘으로 변환되는 애니메이션이 적용됩니다.
/// </summary>
public sealed class ShaggyEarwig15 : ToggleButton
{
    static ShaggyEarwig15()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(ShaggyEarwig15),
            new FrameworkPropertyMetadata(typeof(ShaggyEarwig15)));
    }
}
