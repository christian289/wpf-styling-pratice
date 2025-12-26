using System.Windows;
using System.Windows.Controls;

namespace UglyBear28.Wpf.UI.Controls;

/// <summary>
/// 점 패턴을 표시하는 커스텀 컨트롤입니다.
/// Displays a dot pattern custom control.
/// </summary>
public sealed class UglyBear28 : Control
{
    static UglyBear28()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(UglyBear28),
            new FrameworkPropertyMetadata(typeof(UglyBear28)));
    }
}
