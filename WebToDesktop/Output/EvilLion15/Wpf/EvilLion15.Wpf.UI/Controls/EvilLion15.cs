using System.Windows;
using System.Windows.Controls.Primitives;

namespace EvilLion15.Wpf.UI.Controls;

/// <summary>
/// Neumorphism/Glassmorphism 스타일의 슬라이딩 토글 스위치 컨트롤.
/// Sliding toggle switch control with Neumorphism/Glassmorphism style.
/// </summary>
public sealed class EvilLion15 : ToggleButton
{
    static EvilLion15()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(EvilLion15),
            new FrameworkPropertyMetadata(typeof(EvilLion15)));
    }
}
