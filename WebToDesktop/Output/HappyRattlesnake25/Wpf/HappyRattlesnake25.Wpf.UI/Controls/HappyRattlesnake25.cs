using System.Windows;
using System.Windows.Controls;

namespace HappyRattlesnake25.Wpf.UI.Controls;

/// <summary>
/// 기하학적 패턴 배경을 표시하는 컨트롤입니다.
/// conic-gradient 기반의 Material Design 스타일 패턴을 구현합니다.
/// A control that displays a geometric pattern background.
/// Implements a Material Design style pattern based on conic-gradient.
/// </summary>
public sealed class HappyRattlesnake25 : Control
{
    static HappyRattlesnake25()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(HappyRattlesnake25),
            new FrameworkPropertyMetadata(typeof(HappyRattlesnake25)));
    }

    #region TileSize DependencyProperty

    /// <summary>
    /// 패턴 타일의 크기를 제어합니다 (CSS --s 변수에 해당).
    /// Controls the size of pattern tiles (corresponds to CSS --s variable).
    /// </summary>
    public static readonly DependencyProperty TileSizeProperty =
        DependencyProperty.Register(
            nameof(TileSize),
            typeof(double),
            typeof(HappyRattlesnake25),
            new FrameworkPropertyMetadata(65.0, FrameworkPropertyMetadataOptions.AffectsRender));

    public double TileSize
    {
        get => (double)GetValue(TileSizeProperty);
        set => SetValue(TileSizeProperty, value);
    }

    #endregion

    #region Color1 DependencyProperty

    /// <summary>
    /// 첫 번째 색상입니다 (CSS --c1 변수에 해당, 기본값: #dadee1).
    /// The first color (corresponds to CSS --c1 variable, default: #dadee1).
    /// </summary>
    public static readonly DependencyProperty Color1Property =
        DependencyProperty.Register(
            nameof(Color1),
            typeof(System.Windows.Media.Color),
            typeof(HappyRattlesnake25),
            new FrameworkPropertyMetadata(
                System.Windows.Media.Color.FromRgb(0xda, 0xde, 0xe1),
                FrameworkPropertyMetadataOptions.AffectsRender));

    public System.Windows.Media.Color Color1
    {
        get => (System.Windows.Media.Color)GetValue(Color1Property);
        set => SetValue(Color1Property, value);
    }

    #endregion

    #region Color2 DependencyProperty

    /// <summary>
    /// 두 번째 색상입니다 (CSS --c2 변수에 해당, 기본값: #4a99b4).
    /// The second color (corresponds to CSS --c2 variable, default: #4a99b4).
    /// </summary>
    public static readonly DependencyProperty Color2Property =
        DependencyProperty.Register(
            nameof(Color2),
            typeof(System.Windows.Media.Color),
            typeof(HappyRattlesnake25),
            new FrameworkPropertyMetadata(
                System.Windows.Media.Color.FromRgb(0x4a, 0x99, 0xb4),
                FrameworkPropertyMetadataOptions.AffectsRender));

    public System.Windows.Media.Color Color2
    {
        get => (System.Windows.Media.Color)GetValue(Color2Property);
        set => SetValue(Color2Property, value);
    }

    #endregion

    #region Color3 DependencyProperty

    /// <summary>
    /// 세 번째 색상입니다 (CSS --c3 변수에 해당, 기본값: #9cceb5).
    /// The third color (corresponds to CSS --c3 variable, default: #9cceb5).
    /// </summary>
    public static readonly DependencyProperty Color3Property =
        DependencyProperty.Register(
            nameof(Color3),
            typeof(System.Windows.Media.Color),
            typeof(HappyRattlesnake25),
            new FrameworkPropertyMetadata(
                System.Windows.Media.Color.FromRgb(0x9c, 0xce, 0xb5),
                FrameworkPropertyMetadataOptions.AffectsRender));

    public System.Windows.Media.Color Color3
    {
        get => (System.Windows.Media.Color)GetValue(Color3Property);
        set => SetValue(Color3Property, value);
    }

    #endregion
}
