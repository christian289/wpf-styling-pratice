using System.Windows;
using System.Windows.Controls;

namespace LovelyBulldog50.Wpf.UI.Controls;

public sealed class LovelyBulldog50 : TextBox
{
    static LovelyBulldog50()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(LovelyBulldog50),
            new FrameworkPropertyMetadata(typeof(LovelyBulldog50)));
    }

    public static readonly DependencyProperty IsValidProperty =
        DependencyProperty.Register(
            nameof(IsValid),
            typeof(bool),
            typeof(LovelyBulldog50),
            new PropertyMetadata(false));

    public bool IsValid
    {
        get => (bool)GetValue(IsValidProperty);
        set => SetValue(IsValidProperty, value);
    }

    public static readonly DependencyProperty PlaceholderTextProperty =
        DependencyProperty.Register(
            nameof(PlaceholderText),
            typeof(string),
            typeof(LovelyBulldog50),
            new PropertyMetadata(string.Empty));

    public string PlaceholderText
    {
        get => (string)GetValue(PlaceholderTextProperty);
        set => SetValue(PlaceholderTextProperty, value);
    }

    protected override void OnTextChanged(TextChangedEventArgs e)
    {
        base.OnTextChanged(e);
        IsValid = !string.IsNullOrEmpty(Text);
    }
}
