using System.Windows;
using System.Windows.Controls;

namespace RottenCatfish64.Wpf.UI.Controls;

/// <summary>
/// 대각선 줄무늬 패턴 배경 컨트롤
/// Diagonal stripe pattern background control
/// </summary>
public sealed class RottenCatfish64 : Control
{
    static RottenCatfish64()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(RottenCatfish64),
            new FrameworkPropertyMetadata(typeof(RottenCatfish64)));
    }
}
