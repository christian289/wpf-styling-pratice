using System.Windows;
using System.Windows.Controls;

namespace GrumpyBaboon32.Wpf.UI.Controls;

/// <summary>
/// 기하학적 패턴 배경을 제공하는 커스텀 컨트롤
/// Geometric pattern background custom control
/// </summary>
public sealed class GrumpyBaboon32 : Control
{
    static GrumpyBaboon32()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(GrumpyBaboon32),
            new FrameworkPropertyMetadata(typeof(GrumpyBaboon32)));
    }

    /// <summary>
    /// 패턴 타일 크기 (CSS --s 변수에 해당)
    /// Pattern tile size (corresponds to CSS --s variable)
    /// </summary>
    public static readonly DependencyProperty PatternSizeProperty =
        DependencyProperty.Register(
            nameof(PatternSize),
            typeof(double),
            typeof(GrumpyBaboon32),
            new FrameworkPropertyMetadata(25.0, FrameworkPropertyMetadataOptions.AffectsRender));

    public double PatternSize
    {
        get => (double)GetValue(PatternSizeProperty);
        set => SetValue(PatternSizeProperty, value);
    }
}
