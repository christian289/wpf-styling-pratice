using System.Windows;
using System.Windows.Controls;

namespace SeriousSheep31.Wpf.UI.Controls;

/// <summary>
/// Neumorphism 스타일의 RadioButton 커스텀 컨트롤입니다.
/// Neumorphic-styled RadioButton custom control.
/// </summary>
public sealed class NeumorphicRadioButton : RadioButton
{
    static NeumorphicRadioButton()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(NeumorphicRadioButton),
            new FrameworkPropertyMetadata(typeof(NeumorphicRadioButton)));
    }
}
