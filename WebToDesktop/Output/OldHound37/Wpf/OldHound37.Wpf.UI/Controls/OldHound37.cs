using System.Windows;
using System.Windows.Controls;

namespace OldHound37.Wpf.UI.Controls;

/// <summary>
/// 기하학적 패턴 배경을 제공하는 CustomControl입니다.
/// Geometric pattern background CustomControl.
/// </summary>
public sealed class OldHound37 : Control
{
    static OldHound37()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(OldHound37),
            new FrameworkPropertyMetadata(typeof(OldHound37)));
    }

    /// <summary>
    /// 패턴 타일 크기를 가져오거나 설정합니다.
    /// Gets or sets the pattern tile size.
    /// </summary>
    public static readonly DependencyProperty TileSizeProperty =
        DependencyProperty.Register(
            nameof(TileSize),
            typeof(double),
            typeof(OldHound37),
            new FrameworkPropertyMetadata(200.0, FrameworkPropertyMetadataOptions.AffectsRender));

    public double TileSize
    {
        get => (double)GetValue(TileSizeProperty);
        set => SetValue(TileSizeProperty, value);
    }
}
