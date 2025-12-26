using System.Windows;
using System.Windows.Controls;

namespace SeriousSheep31.Wpf.UI.Controls;

/// <summary>
/// Neumorphism 스타일의 RadioButton 그룹 컨테이너입니다.
/// Neumorphic-styled RadioButton group container.
/// </summary>
public sealed class NeumorphicRadioButtonGroup : ItemsControl
{
    static NeumorphicRadioButtonGroup()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(NeumorphicRadioButtonGroup),
            new FrameworkPropertyMetadata(typeof(NeumorphicRadioButtonGroup)));
    }

    protected override bool IsItemItsOwnContainerOverride(object item)
    {
        return item is NeumorphicRadioButton;
    }

    protected override DependencyObject GetContainerForItemOverride()
    {
        return new NeumorphicRadioButton();
    }
}
