using System.Windows;
using System.Windows.Controls;

namespace BitterMoth36.Wpf.UI.Controls;

/// <summary>
/// 두 개의 원이 서로 반대 위치에서 스케일 애니메이션을 하며 회전하는 로딩 컨트롤
/// A loading control with two circles scaling at opposite positions while rotating
/// </summary>
public sealed class BitterMoth36 : Control
{
    static BitterMoth36()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(BitterMoth36),
            new FrameworkPropertyMetadata(typeof(BitterMoth36)));
    }
}
