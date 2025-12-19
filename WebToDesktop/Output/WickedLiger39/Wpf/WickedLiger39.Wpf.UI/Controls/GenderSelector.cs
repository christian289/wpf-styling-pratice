using System.Windows;
using System.Windows.Controls;

namespace WickedLiger39.Wpf.UI.Controls;

/// <summary>
/// 성별 선택을 위한 라디오 버튼 그룹 컨테이너.
/// A radio button group container for gender selection.
/// </summary>
public sealed class GenderSelector : ItemsControl
{
    static GenderSelector()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(GenderSelector),
            new FrameworkPropertyMetadata(typeof(GenderSelector)));
    }

    #region Header Property

    public static readonly DependencyProperty HeaderProperty =
        DependencyProperty.Register(
            nameof(Header),
            typeof(string),
            typeof(GenderSelector),
            new PropertyMetadata("Please select your gender"));

    public string Header
    {
        get => (string)GetValue(HeaderProperty);
        set => SetValue(HeaderProperty, value);
    }

    #endregion

    #region SelectedValue Property

    public static readonly DependencyProperty SelectedValueProperty =
        DependencyProperty.Register(
            nameof(SelectedValue),
            typeof(string),
            typeof(GenderSelector),
            new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

    public string? SelectedValue
    {
        get => (string?)GetValue(SelectedValueProperty);
        set => SetValue(SelectedValueProperty, value);
    }

    #endregion

    protected override bool IsItemItsOwnContainerOverride(object item)
    {
        return item is GenderOption;
    }

    protected override DependencyObject GetContainerForItemOverride()
    {
        return new GenderOption();
    }
}
