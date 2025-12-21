using System.Windows;
using System.Windows.Controls;

namespace PinkCheetah76.Wpf.UI.Controls;

/// <summary>
/// 3D 효과가 있는 버튼 컨트롤입니다.
/// A button control with 3D press effect.
/// </summary>
public sealed class PinkCheetah76 : Button
{
    static PinkCheetah76()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(PinkCheetah76),
            new FrameworkPropertyMetadata(typeof(PinkCheetah76)));
    }
}
