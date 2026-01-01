using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PerfectLizard67.Wpf.UI.Controls;

/// <summary>
/// 확장형 검색 입력 컨트롤
/// Expandable search input control
/// </summary>
public sealed class PerfectLizard67 : TextBox
{
    static PerfectLizard67()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(PerfectLizard67),
            new FrameworkPropertyMetadata(typeof(PerfectLizard67)));
    }

    /// <summary>
    /// 확장 여부를 나타내는 DependencyProperty
    /// DependencyProperty indicating whether the control is expanded
    /// </summary>
    public static readonly DependencyProperty IsExpandedProperty =
        DependencyProperty.Register(
            nameof(IsExpanded),
            typeof(bool),
            typeof(PerfectLizard67),
            new FrameworkPropertyMetadata(false));

    /// <summary>
    /// 확장 여부
    /// Whether the control is expanded
    /// </summary>
    public bool IsExpanded
    {
        get => (bool)GetValue(IsExpandedProperty);
        set => SetValue(IsExpandedProperty, value);
    }

    /// <summary>
    /// 축소된 상태의 너비
    /// Width when collapsed
    /// </summary>
    public static readonly DependencyProperty CollapsedWidthProperty =
        DependencyProperty.Register(
            nameof(CollapsedWidth),
            typeof(double),
            typeof(PerfectLizard67),
            new FrameworkPropertyMetadata(50.0));

    public double CollapsedWidth
    {
        get => (double)GetValue(CollapsedWidthProperty);
        set => SetValue(CollapsedWidthProperty, value);
    }

    /// <summary>
    /// 확장된 상태의 너비
    /// Width when expanded
    /// </summary>
    public static readonly DependencyProperty ExpandedWidthProperty =
        DependencyProperty.Register(
            nameof(ExpandedWidth),
            typeof(double),
            typeof(PerfectLizard67),
            new FrameworkPropertyMetadata(250.0));

    public double ExpandedWidth
    {
        get => (double)GetValue(ExpandedWidthProperty);
        set => SetValue(ExpandedWidthProperty, value);
    }

    protected override void OnGotFocus(RoutedEventArgs e)
    {
        base.OnGotFocus(e);
        IsExpanded = true;
    }

    protected override void OnLostFocus(RoutedEventArgs e)
    {
        base.OnLostFocus(e);
        // 텍스트가 비어있으면 축소
        // Collapse if text is empty
        if (string.IsNullOrEmpty(Text))
        {
            IsExpanded = false;
        }
    }

    protected override void OnPreviewMouseLeftButtonDown(MouseButtonEventArgs e)
    {
        base.OnPreviewMouseLeftButtonDown(e);
        if (!IsExpanded)
        {
            IsExpanded = true;
            Focus();
        }
    }
}
