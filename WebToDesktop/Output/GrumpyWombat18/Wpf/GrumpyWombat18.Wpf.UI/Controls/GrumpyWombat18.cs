using System.Windows;
using System.Windows.Controls.Primitives;

namespace GrumpyWombat18.Wpf.UI.Controls;

public sealed class GrumpyWombat18 : ToggleButton
{
    public static readonly DependencyProperty UncheckedIconProperty =
        DependencyProperty.Register(
            nameof(UncheckedIcon),
            typeof(object),
            typeof(GrumpyWombat18),
            new PropertyMetadata(null));

    public static readonly DependencyProperty CheckedIconProperty =
        DependencyProperty.Register(
            nameof(CheckedIcon),
            typeof(object),
            typeof(GrumpyWombat18),
            new PropertyMetadata(null));

    public static readonly DependencyProperty UncheckedTextProperty =
        DependencyProperty.Register(
            nameof(UncheckedText),
            typeof(string),
            typeof(GrumpyWombat18),
            new PropertyMetadata("ball"));

    public static readonly DependencyProperty CheckedTextProperty =
        DependencyProperty.Register(
            nameof(CheckedText),
            typeof(string),
            typeof(GrumpyWombat18),
            new PropertyMetadata("Game"));

    static GrumpyWombat18()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(GrumpyWombat18),
            new FrameworkPropertyMetadata(typeof(GrumpyWombat18)));
    }

    public object? UncheckedIcon
    {
        get => GetValue(UncheckedIconProperty);
        set => SetValue(UncheckedIconProperty, value);
    }

    public object? CheckedIcon
    {
        get => GetValue(CheckedIconProperty);
        set => SetValue(CheckedIconProperty, value);
    }

    public string UncheckedText
    {
        get => (string)GetValue(UncheckedTextProperty);
        set => SetValue(UncheckedTextProperty, value);
    }

    public string CheckedText
    {
        get => (string)GetValue(CheckedTextProperty);
        set => SetValue(CheckedTextProperty, value);
    }
}
