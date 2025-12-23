using System.Windows;
using System.Windows.Controls;

namespace SplendidQuail83.Wpf.UI.Controls;

/// <summary>
/// 노트 패드/종이 스타일의 패턴 배경 컨트롤.
/// A notebook/paper style pattern background control.
/// </summary>
public sealed class SplendidQuail83 : ContentControl
{
    static SplendidQuail83()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(SplendidQuail83),
            new FrameworkPropertyMetadata(typeof(SplendidQuail83)));
    }
}
