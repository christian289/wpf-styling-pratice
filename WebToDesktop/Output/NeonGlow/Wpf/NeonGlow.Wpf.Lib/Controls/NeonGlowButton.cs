using System.Windows;
using System.Windows.Controls;

namespace NeonGlow.Wpf.Lib.Controls;

/// <summary>
/// Realism 스타일의 네온 글로우 버튼 커스텀 컨트롤
/// CSS의 radial-gradient와 box-shadow 효과를 WPF로 구현
/// </summary>
public class NeonGlowButton : Button
{
    static NeonGlowButton()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(NeonGlowButton),
            new FrameworkPropertyMetadata(typeof(NeonGlowButton)));
    }
}
