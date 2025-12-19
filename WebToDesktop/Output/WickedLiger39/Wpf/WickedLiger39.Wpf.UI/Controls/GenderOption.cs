using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WickedLiger39.Wpf.UI.Controls;

/// <summary>
/// 성별 선택을 위한 라디오 버튼 옵션.
/// A radio button option for gender selection.
/// </summary>
public sealed class GenderOption : RadioButton
{
    static GenderOption()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(GenderOption),
            new FrameworkPropertyMetadata(typeof(GenderOption)));
    }

    #region Icon Property

    public static readonly DependencyProperty IconProperty =
        DependencyProperty.Register(
            nameof(Icon),
            typeof(Geometry),
            typeof(GenderOption),
            new PropertyMetadata(null));

    public Geometry? Icon
    {
        get => (Geometry?)GetValue(IconProperty);
        set => SetValue(IconProperty, value);
    }

    #endregion

    #region IconBrush Property

    public static readonly DependencyProperty IconBrushProperty =
        DependencyProperty.Register(
            nameof(IconBrush),
            typeof(Brush),
            typeof(GenderOption),
            new PropertyMetadata(Brushes.Gray));

    public Brush IconBrush
    {
        get => (Brush)GetValue(IconBrushProperty);
        set => SetValue(IconBrushProperty, value);
    }

    #endregion

    #region IconStroke Property

    public static readonly DependencyProperty IconStrokeProperty =
        DependencyProperty.Register(
            nameof(IconStroke),
            typeof(Brush),
            typeof(GenderOption),
            new PropertyMetadata(null));

    public Brush? IconStroke
    {
        get => (Brush?)GetValue(IconStrokeProperty);
        set => SetValue(IconStrokeProperty, value);
    }

    #endregion

    #region RingBrush Property

    public static readonly DependencyProperty RingBrushProperty =
        DependencyProperty.Register(
            nameof(RingBrush),
            typeof(Brush),
            typeof(GenderOption),
            new PropertyMetadata(Brushes.Gray));

    public Brush RingBrush
    {
        get => (Brush)GetValue(RingBrushProperty);
        set => SetValue(RingBrushProperty, value);
    }

    #endregion

    #region RippleBrush Property

    public static readonly DependencyProperty RippleBrushProperty =
        DependencyProperty.Register(
            nameof(RippleBrush),
            typeof(Brush),
            typeof(GenderOption),
            new PropertyMetadata(Brushes.LightGray));

    public Brush RippleBrush
    {
        get => (Brush)GetValue(RippleBrushProperty);
        set => SetValue(RippleBrushProperty, value);
    }

    #endregion
}
