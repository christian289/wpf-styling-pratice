using System.Windows;
using System.Windows.Controls;

namespace FreshFrog39.Wpf.UI.Controls;

/// <summary>
/// 3개의 원이 순차적으로 페이드되는 로딩 스피너 컨트롤
/// A loading spinner control with three dots that fade sequentially
/// </summary>
public sealed class FreshFrog39 : Control
{
    static FreshFrog39()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(FreshFrog39),
            new FrameworkPropertyMetadata(typeof(FreshFrog39)));
    }

    #region DotColor DependencyProperty

    /// <summary>
    /// 점의 색상을 지정합니다.
    /// Gets or sets the color of the dots.
    /// </summary>
    public static readonly DependencyProperty DotColorProperty =
        DependencyProperty.Register(
            nameof(DotColor),
            typeof(System.Windows.Media.Brush),
            typeof(FreshFrog39),
            new PropertyMetadata(null));

    public System.Windows.Media.Brush DotColor
    {
        get => (System.Windows.Media.Brush)GetValue(DotColorProperty);
        set => SetValue(DotColorProperty, value);
    }

    #endregion

    #region DotSize DependencyProperty

    /// <summary>
    /// 각 점의 크기를 지정합니다.
    /// Gets or sets the size of each dot.
    /// </summary>
    public static readonly DependencyProperty DotSizeProperty =
        DependencyProperty.Register(
            nameof(DotSize),
            typeof(double),
            typeof(FreshFrog39),
            new PropertyMetadata(20.0));

    public double DotSize
    {
        get => (double)GetValue(DotSizeProperty);
        set => SetValue(DotSizeProperty, value);
    }

    #endregion

    #region DotGap DependencyProperty

    /// <summary>
    /// 점 사이의 간격을 지정합니다.
    /// Gets or sets the gap between dots.
    /// </summary>
    public static readonly DependencyProperty DotGapProperty =
        DependencyProperty.Register(
            nameof(DotGap),
            typeof(double),
            typeof(FreshFrog39),
            new PropertyMetadata(6.0));

    public double DotGap
    {
        get => (double)GetValue(DotGapProperty);
        set => SetValue(DotGapProperty, value);
    }

    #endregion

    #region IsAnimating DependencyProperty

    /// <summary>
    /// 애니메이션 실행 여부를 지정합니다.
    /// Gets or sets whether the animation is running.
    /// </summary>
    public static readonly DependencyProperty IsAnimatingProperty =
        DependencyProperty.Register(
            nameof(IsAnimating),
            typeof(bool),
            typeof(FreshFrog39),
            new PropertyMetadata(true));

    public bool IsAnimating
    {
        get => (bool)GetValue(IsAnimatingProperty);
        set => SetValue(IsAnimatingProperty, value);
    }

    #endregion
}
