using System.Windows;
using System.Windows.Controls;

namespace FatPanther54.Wpf.UI.Controls;

/// <summary>
/// conic-gradient 기반 기하학적 삼각형 패턴 배경 컨트롤
/// Geometric triangle pattern background control based on conic-gradient
/// </summary>
public sealed class FatPanther54 : Control
{
    static FatPanther54()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(FatPanther54),
            new FrameworkPropertyMetadata(typeof(FatPanther54)));
    }

    /// <summary>
    /// 패턴 타일 크기 (CSS --s 변수에 해당)
    /// Pattern tile size (corresponds to CSS --s variable)
    /// </summary>
    public static readonly DependencyProperty PatternSizeProperty =
        DependencyProperty.Register(
            nameof(PatternSize),
            typeof(double),
            typeof(FatPanther54),
            new FrameworkPropertyMetadata(37.0, FrameworkPropertyMetadataOptions.AffectsRender));

    public double PatternSize
    {
        get => (double)GetValue(PatternSizeProperty);
        set => SetValue(PatternSizeProperty, value);
    }
}
