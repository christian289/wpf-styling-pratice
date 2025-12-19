using System.Windows;
using System.Windows.Controls.Primitives;

namespace BrightTiger84.Wpf.UI.Controls;

/// <summary>
/// 좋아요(thumbs up) 스타일의 토글 버튼 컨트롤입니다.
/// A thumbs-up style toggle button control.
/// </summary>
public sealed class BrightTiger84 : ToggleButton
{
    static BrightTiger84()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(BrightTiger84),
            new FrameworkPropertyMetadata(typeof(BrightTiger84)));
    }
}
