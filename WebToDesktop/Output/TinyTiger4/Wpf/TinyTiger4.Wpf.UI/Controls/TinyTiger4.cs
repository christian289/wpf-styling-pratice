using System.Windows;
using System.Windows.Controls;

namespace TinyTiger4.Wpf.UI.Controls;

/// <summary>
/// 버블 효과가 있는 라디오 버튼 스타일 컨트롤
/// Bubble-style radio button control with flashy animation effect
/// </summary>
public sealed class TinyTiger4 : RadioButton
{
    static TinyTiger4()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(TinyTiger4),
            new FrameworkPropertyMetadata(typeof(TinyTiger4)));
    }
}
