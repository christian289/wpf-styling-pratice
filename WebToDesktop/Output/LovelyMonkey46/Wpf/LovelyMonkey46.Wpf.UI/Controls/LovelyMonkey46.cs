using System.Windows;
using System.Windows.Controls;

namespace LovelyMonkey46.Wpf.UI.Controls;

/// <summary>
/// 여러 개의 radial-gradient와 linear-gradient를 조합한 패턴 배경 컨트롤
/// A pattern background control that combines multiple radial-gradients and linear-gradient
/// </summary>
public sealed class LovelyMonkey46 : ContentControl
{
    static LovelyMonkey46()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(LovelyMonkey46),
            new FrameworkPropertyMetadata(typeof(LovelyMonkey46)));
    }
}
