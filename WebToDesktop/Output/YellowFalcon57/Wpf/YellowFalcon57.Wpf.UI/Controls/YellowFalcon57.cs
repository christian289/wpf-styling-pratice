using System.Windows;
using System.Windows.Controls;

namespace YellowFalcon57.Wpf.UI.Controls;

/// <summary>
/// 다운로드 버튼 커스텀 컨트롤
/// Download button custom control
/// </summary>
public sealed class YellowFalcon57 : Button
{
    static YellowFalcon57()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(YellowFalcon57),
            new FrameworkPropertyMetadata(typeof(YellowFalcon57)));
    }
}
