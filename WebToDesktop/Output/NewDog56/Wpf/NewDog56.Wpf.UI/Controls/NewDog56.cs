using System.Windows;
using System.Windows.Controls;

namespace NewDog56.Wpf.UI.Controls;

/// <summary>
/// Primary button with gradient hover effect.
/// 그라데이션 호버 효과가 있는 기본 버튼.
/// </summary>
public sealed class NewDog56 : Button
{
    static NewDog56()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(NewDog56),
            new FrameworkPropertyMetadata(typeof(NewDog56)));
    }
}
