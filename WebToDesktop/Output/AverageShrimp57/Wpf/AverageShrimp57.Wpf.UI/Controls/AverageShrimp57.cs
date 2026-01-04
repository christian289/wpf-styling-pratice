using System.Windows;
using System.Windows.Controls.Primitives;

namespace AverageShrimp57.Wpf.UI.Controls;

/// <summary>
/// On/Off 텍스트가 있는 3D 효과 토글 스위치 컨트롤
/// A 3D effect toggle switch control with On/Off text
/// </summary>
public sealed class AverageShrimp57 : ToggleButton
{
    static AverageShrimp57()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(AverageShrimp57),
            new FrameworkPropertyMetadata(typeof(AverageShrimp57)));
    }

    #region OnText DependencyProperty

    /// <summary>
    /// 토글이 켜졌을 때 표시할 텍스트
    /// Text to display when toggle is on
    /// </summary>
    public static readonly DependencyProperty OnTextProperty =
        DependencyProperty.Register(
            nameof(OnText),
            typeof(string),
            typeof(AverageShrimp57),
            new PropertyMetadata("On"));

    public string OnText
    {
        get => (string)GetValue(OnTextProperty);
        set => SetValue(OnTextProperty, value);
    }

    #endregion

    #region OffText DependencyProperty

    /// <summary>
    /// 토글이 꺼졌을 때 표시할 텍스트
    /// Text to display when toggle is off
    /// </summary>
    public static readonly DependencyProperty OffTextProperty =
        DependencyProperty.Register(
            nameof(OffText),
            typeof(string),
            typeof(AverageShrimp57),
            new PropertyMetadata("Off"));

    public string OffText
    {
        get => (string)GetValue(OffTextProperty);
        set => SetValue(OffTextProperty, value);
    }

    #endregion
}
