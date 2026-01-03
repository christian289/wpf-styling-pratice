using System.Windows;
using System.Windows.Controls;

namespace WetQuail86.Wpf.UI.Controls;

/// <summary>
/// Hover 시 Title 툴팁이 나타나는 Input 컨트롤
/// Input control with title tooltip appearing on hover
/// </summary>
public sealed class WetQuail86 : Control
{
    static WetQuail86()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(WetQuail86),
            new FrameworkPropertyMetadata(typeof(WetQuail86)));
    }

    /// <summary>
    /// Title 텍스트
    /// Title text
    /// </summary>
    public static readonly DependencyProperty TitleProperty =
        DependencyProperty.Register(
            nameof(Title),
            typeof(string),
            typeof(WetQuail86),
            new PropertyMetadata("Title"));

    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    /// <summary>
    /// Input 텍스트
    /// Input text
    /// </summary>
    public static readonly DependencyProperty TextProperty =
        DependencyProperty.Register(
            nameof(Text),
            typeof(string),
            typeof(WetQuail86),
            new FrameworkPropertyMetadata(
                string.Empty,
                FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    /// <summary>
    /// Placeholder 텍스트
    /// Placeholder text
    /// </summary>
    public static readonly DependencyProperty PlaceholderProperty =
        DependencyProperty.Register(
            nameof(Placeholder),
            typeof(string),
            typeof(WetQuail86),
            new PropertyMetadata(string.Empty));

    public string Placeholder
    {
        get => (string)GetValue(PlaceholderProperty);
        set => SetValue(PlaceholderProperty, value);
    }
}
