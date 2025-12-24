using System.Windows;
using System.Windows.Controls;

namespace YoungBulldog90.Wpf.UI.Controls;

/// <summary>
/// 회전하는 원형 로딩 스피너 컨트롤입니다.
/// A rotating circular loading spinner control.
/// </summary>
public sealed class YoungBulldog90 : Control
{
    static YoungBulldog90()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(YoungBulldog90),
            new FrameworkPropertyMetadata(typeof(YoungBulldog90)));
    }
}
