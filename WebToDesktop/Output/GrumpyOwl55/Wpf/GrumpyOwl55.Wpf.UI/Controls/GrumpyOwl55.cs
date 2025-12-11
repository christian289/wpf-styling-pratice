using System.Windows;
using System.Windows.Controls;

namespace GrumpyOwl55.Wpf.UI.Controls;

/// <summary>
/// 기하학적 패턴 배경 컨트롤
/// Geometric pattern background control
/// </summary>
public sealed class GrumpyOwl55 : Control
{
    static GrumpyOwl55()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(GrumpyOwl55),
            new FrameworkPropertyMetadata(typeof(GrumpyOwl55)));
    }
}
