using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace HeavyDragonfly92.Wpf.UI.Controls;

/// <summary>
/// HeavyDragonfly92 컨트롤의 개별 탭 아이템
/// Individual tab item for HeavyDragonfly92 control
/// </summary>
public sealed class HeavyDragonfly92Item : ContentControl
{
    static HeavyDragonfly92Item()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(HeavyDragonfly92Item),
            new FrameworkPropertyMetadata(typeof(HeavyDragonfly92Item)));
    }

    /// <summary>
    /// 알림 배지에 표시할 숫자
    /// Notification badge count
    /// </summary>
    public static readonly DependencyProperty NotificationCountProperty =
        DependencyProperty.Register(
            nameof(NotificationCount),
            typeof(int),
            typeof(HeavyDragonfly92Item),
            new PropertyMetadata(0));

    public int NotificationCount
    {
        get => (int)GetValue(NotificationCountProperty);
        set => SetValue(NotificationCountProperty, value);
    }

    /// <summary>
    /// 알림 배지 표시 여부
    /// Whether to show notification badge
    /// </summary>
    public static readonly DependencyProperty ShowNotificationProperty =
        DependencyProperty.Register(
            nameof(ShowNotification),
            typeof(bool),
            typeof(HeavyDragonfly92Item),
            new PropertyMetadata(false));

    public bool ShowNotification
    {
        get => (bool)GetValue(ShowNotificationProperty);
        set => SetValue(ShowNotificationProperty, value);
    }

    /// <summary>
    /// 선택 상태
    /// Selection state
    /// </summary>
    public static readonly DependencyProperty IsSelectedProperty =
        Selector.IsSelectedProperty.AddOwner(
            typeof(HeavyDragonfly92Item),
            new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

    public bool IsSelected
    {
        get => (bool)GetValue(IsSelectedProperty);
        set => SetValue(IsSelectedProperty, value);
    }
}
