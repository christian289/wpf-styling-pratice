using System.Windows;
using System.Windows.Controls;

namespace GreatDragonfly65.Wpf.UI.Controls;

/// <summary>
/// rose-900에서 pink-700으로 그라데이션이 적용된 버튼.
/// hover 시 ::before/::after pseudo-element가 회전하며 텍스트가 변경되는 효과.
/// A button with gradient from rose-900 to pink-700.
/// On hover, ::before/::after pseudo-elements rotate with text change effect.
/// </summary>
public sealed class GreatDragonfly65 : Button
{
    static GreatDragonfly65()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(GreatDragonfly65),
            new FrameworkPropertyMetadata(typeof(GreatDragonfly65)));
    }

    /// <summary>
    /// hover 시 before pseudo-element에 표시할 텍스트
    /// Text to display on before pseudo-element when hovered
    /// </summary>
    public static readonly DependencyProperty BeforeHoverTextProperty =
        DependencyProperty.Register(
            nameof(BeforeHoverText),
            typeof(string),
            typeof(GreatDragonfly65),
            new PropertyMetadata("SMOOKY"));

    public string BeforeHoverText
    {
        get => (string)GetValue(BeforeHoverTextProperty);
        set => SetValue(BeforeHoverTextProperty, value);
    }

    /// <summary>
    /// before pseudo-element에 표시할 기본 텍스트
    /// Default text to display on before pseudo-element
    /// </summary>
    public static readonly DependencyProperty BeforeTextProperty =
        DependencyProperty.Register(
            nameof(BeforeText),
            typeof(string),
            typeof(GreatDragonfly65),
            new PropertyMetadata("Hover ME"));

    public string BeforeText
    {
        get => (string)GetValue(BeforeTextProperty);
        set => SetValue(BeforeTextProperty, value);
    }

    /// <summary>
    /// hover 시 after pseudo-element에 표시할 텍스트
    /// Text to display on after pseudo-element when hovered
    /// </summary>
    public static readonly DependencyProperty AfterHoverTextProperty =
        DependencyProperty.Register(
            nameof(AfterHoverText),
            typeof(string),
            typeof(GreatDragonfly65),
            new PropertyMetadata("SMOOKY DEV"));

    public string AfterHoverText
    {
        get => (string)GetValue(AfterHoverTextProperty);
        set => SetValue(AfterHoverTextProperty, value);
    }

    /// <summary>
    /// after pseudo-element에 표시할 기본 텍스트
    /// Default text to display on after pseudo-element
    /// </summary>
    public static readonly DependencyProperty AfterTextProperty =
        DependencyProperty.Register(
            nameof(AfterText),
            typeof(string),
            typeof(GreatDragonfly65),
            new PropertyMetadata("Hover ME"));

    public string AfterText
    {
        get => (string)GetValue(AfterTextProperty);
        set => SetValue(AfterTextProperty, value);
    }
}
