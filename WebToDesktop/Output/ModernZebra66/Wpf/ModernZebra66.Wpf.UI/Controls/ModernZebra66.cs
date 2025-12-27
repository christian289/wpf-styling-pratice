using System.Windows;
using System.Windows.Controls;

namespace ModernZebra66.Wpf.UI.Controls;

/// <summary>
/// CSS repeating-conic-gradient 기반 육각형 패턴 배경 컨트롤.
/// DrawingBrush와 TileMode를 사용하여 패턴을 구현합니다.
/// </summary>
/// <remarks>
/// CSS repeating-conic-gradient based hexagonal pattern background control.
/// Implements the pattern using DrawingBrush and TileMode.
/// </remarks>
public sealed class ModernZebra66 : Control
{
    static ModernZebra66()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(ModernZebra66),
            new FrameworkPropertyMetadata(typeof(ModernZebra66)));
    }
}
