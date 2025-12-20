using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace HeavyDragonfly92.Wpf.UI.Controls;

/// <summary>
/// 슬라이딩 글라이더 효과가 있는 탭 스타일 라디오 버튼 컨트롤
/// Sliding glider effect tab-style radio button control
/// </summary>
public sealed class HeavyDragonfly92 : Selector
{
    static HeavyDragonfly92()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(HeavyDragonfly92),
            new FrameworkPropertyMetadata(typeof(HeavyDragonfly92)));
    }
}
