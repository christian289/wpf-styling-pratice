using System.Windows;
using System.Windows.Controls;

namespace CurlyBullfrog98.Wpf.UI.Controls;

/// <summary>
/// 3D 회전 큐브 로딩 애니메이션 컨트롤
/// 3D rotating cube loading animation control
/// </summary>
public sealed class CurlyBullfrog98 : Control
{
    static CurlyBullfrog98()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(CurlyBullfrog98),
            new FrameworkPropertyMetadata(typeof(CurlyBullfrog98)));
    }

    /// <summary>
    /// 애니메이션 지속 시간 (초)
    /// Animation duration in seconds
    /// </summary>
    public static readonly DependencyProperty DurationProperty =
        DependencyProperty.Register(
            nameof(Duration),
            typeof(double),
            typeof(CurlyBullfrog98),
            new PropertyMetadata(4.0));

    public double Duration
    {
        get => (double)GetValue(DurationProperty);
        set => SetValue(DurationProperty, value);
    }

    /// <summary>
    /// 큐브 크기
    /// Cube size
    /// </summary>
    public static readonly DependencyProperty CubeSizeProperty =
        DependencyProperty.Register(
            nameof(CubeSize),
            typeof(double),
            typeof(CurlyBullfrog98),
            new PropertyMetadata(200.0));

    public double CubeSize
    {
        get => (double)GetValue(CubeSizeProperty);
        set => SetValue(CubeSizeProperty, value);
    }
}
