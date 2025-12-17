using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace GoodQuail97.Wpf.UI.Controls;

/// <summary>
/// 네온 글로우 애니메이션이 적용된 라디오 버튼 컨트롤입니다.
/// A radio button control with neon glow animation effect.
/// </summary>
public sealed class GoodQuail97 : ToggleButton
{
    static GoodQuail97()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(GoodQuail97),
            new FrameworkPropertyMetadata(typeof(GoodQuail97)));
    }
}
