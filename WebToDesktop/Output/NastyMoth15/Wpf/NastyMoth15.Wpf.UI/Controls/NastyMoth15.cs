using System.Windows;
using System.Windows.Controls.Primitives;

namespace NastyMoth15.Wpf.UI.Controls;

/// <summary>
/// 스파클 애니메이션이 있는 토글 스위치 컨트롤입니다.
/// A toggle switch control with sparkle animation effect.
/// </summary>
public sealed class NastyMoth15 : ToggleButton
{
    static NastyMoth15()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(NastyMoth15),
            new FrameworkPropertyMetadata(typeof(NastyMoth15)));
    }
}
