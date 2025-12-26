using System.Windows;
using System.Windows.Controls;

namespace FatDodo89.Wpf.UI.Controls;

/// <summary>
/// 스마일 얼굴 로딩 애니메이션 컨트롤
/// Smile face loading animation control
/// 원본: https://uiverse.io/fanishah/fat-dodo-89
/// </summary>
public sealed class FatDodo89 : Control
{
    static FatDodo89()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(FatDodo89),
            new FrameworkPropertyMetadata(typeof(FatDodo89)));
    }
}
