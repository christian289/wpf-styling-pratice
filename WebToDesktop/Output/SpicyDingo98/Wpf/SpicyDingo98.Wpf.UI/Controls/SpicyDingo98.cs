using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace SpicyDingo98.Wpf.UI.Controls;

/// <summary>
/// 아이콘이 있는 라디오 버튼 그룹 컨트롤입니다.
/// A radio button group control with icons.
/// </summary>
public sealed class SpicyDingo98 : Selector
{
    static SpicyDingo98()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(SpicyDingo98),
            new FrameworkPropertyMetadata(typeof(SpicyDingo98)));
    }

    protected override bool IsItemItsOwnContainerOverride(object item)
    {
        return item is SpicyDingo98Item;
    }

    protected override DependencyObject GetContainerForItemOverride()
    {
        return new SpicyDingo98Item();
    }
}
