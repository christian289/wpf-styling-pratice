using System.Windows;
using System.Windows.Controls.Primitives;

namespace TidyVampirebat71.Wpf.UI.Controls;

/// <summary>
/// 무지개색 막대가 회전하며 나타나는 애니메이션 체크박스 컨트롤.
/// A rainbow bar animated checkbox control.
/// </summary>
public sealed class TidyVampirebat71 : ToggleButton
{
    static TidyVampirebat71()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(TidyVampirebat71),
            new FrameworkPropertyMetadata(typeof(TidyVampirebat71)));
    }
}
