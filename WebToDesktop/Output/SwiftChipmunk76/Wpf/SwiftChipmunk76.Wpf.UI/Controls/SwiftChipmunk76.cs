using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace SwiftChipmunk76.Wpf.UI.Controls;

/// <summary>
/// 별점 평가 컨트롤 (Star Rating Control)
/// 사용자가 1~5개의 별을 클릭하여 평점을 매길 수 있습니다.
/// </summary>
public sealed class SwiftChipmunk76 : Control
{
    static SwiftChipmunk76()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(SwiftChipmunk76),
            new FrameworkPropertyMetadata(typeof(SwiftChipmunk76)));
    }

    /// <summary>
    /// 현재 선택된 평점 값 (1~5)
    /// Current selected rating value (1~5)
    /// </summary>
    public static readonly DependencyProperty ValueProperty =
        DependencyProperty.Register(
            nameof(Value),
            typeof(int),
            typeof(SwiftChipmunk76),
            new FrameworkPropertyMetadata(
                0,
                FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                OnValueChanged,
                CoerceValue));

    /// <summary>
    /// 최대 별 개수 (기본값: 5)
    /// Maximum number of stars (default: 5)
    /// </summary>
    public static readonly DependencyProperty MaxRatingProperty =
        DependencyProperty.Register(
            nameof(MaxRating),
            typeof(int),
            typeof(SwiftChipmunk76),
            new PropertyMetadata(5));

    /// <summary>
    /// 현재 호버 중인 별 인덱스 (1-based, 0이면 호버 없음)
    /// Current hovered star index (1-based, 0 means no hover)
    /// </summary>
    public static readonly DependencyProperty HoverValueProperty =
        DependencyProperty.Register(
            nameof(HoverValue),
            typeof(int),
            typeof(SwiftChipmunk76),
            new PropertyMetadata(0));

    /// <summary>
    /// 읽기 전용 여부
    /// Whether the control is read-only
    /// </summary>
    public static readonly DependencyProperty IsReadOnlyProperty =
        DependencyProperty.Register(
            nameof(IsReadOnly),
            typeof(bool),
            typeof(SwiftChipmunk76),
            new PropertyMetadata(false));

    public int Value
    {
        get => (int)GetValue(ValueProperty);
        set => SetValue(ValueProperty, value);
    }

    public int MaxRating
    {
        get => (int)GetValue(MaxRatingProperty);
        set => SetValue(MaxRatingProperty, value);
    }

    public int HoverValue
    {
        get => (int)GetValue(HoverValueProperty);
        set => SetValue(HoverValueProperty, value);
    }

    public bool IsReadOnly
    {
        get => (bool)GetValue(IsReadOnlyProperty);
        set => SetValue(IsReadOnlyProperty, value);
    }

    /// <summary>
    /// 평점 값이 변경될 때 발생하는 이벤트
    /// Event raised when the rating value changes
    /// </summary>
    public static readonly RoutedEvent ValueChangedEvent =
        EventManager.RegisterRoutedEvent(
            nameof(ValueChanged),
            RoutingStrategy.Bubble,
            typeof(RoutedPropertyChangedEventHandler<int>),
            typeof(SwiftChipmunk76));

    public event RoutedPropertyChangedEventHandler<int> ValueChanged
    {
        add => AddHandler(ValueChangedEvent, value);
        remove => RemoveHandler(ValueChangedEvent, value);
    }

    private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is SwiftChipmunk76 rating)
        {
            var args = new RoutedPropertyChangedEventArgs<int>(
                (int)e.OldValue,
                (int)e.NewValue,
                ValueChangedEvent);
            rating.RaiseEvent(args);
        }
    }

    private static object CoerceValue(DependencyObject d, object baseValue)
    {
        if (d is SwiftChipmunk76 rating && baseValue is int value)
        {
            return Math.Clamp(value, 0, rating.MaxRating);
        }
        return baseValue;
    }

    private ToggleButton? _star1;
    private ToggleButton? _star2;
    private ToggleButton? _star3;
    private ToggleButton? _star4;
    private ToggleButton? _star5;

    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();

        // 이전 이벤트 핸들러 제거
        // Remove previous event handlers
        UnsubscribeStarEvents();

        _star1 = GetTemplateChild("PART_Star1") as ToggleButton;
        _star2 = GetTemplateChild("PART_Star2") as ToggleButton;
        _star3 = GetTemplateChild("PART_Star3") as ToggleButton;
        _star4 = GetTemplateChild("PART_Star4") as ToggleButton;
        _star5 = GetTemplateChild("PART_Star5") as ToggleButton;

        // 이벤트 핸들러 등록
        // Subscribe event handlers
        SubscribeStarEvents();

        // 초기 상태 업데이트
        // Update initial state
        UpdateStarStates();
    }

    private void SubscribeStarEvents()
    {
        SubscribeStar(_star1, 1);
        SubscribeStar(_star2, 2);
        SubscribeStar(_star3, 3);
        SubscribeStar(_star4, 4);
        SubscribeStar(_star5, 5);
    }

    private void SubscribeStar(ToggleButton? star, int index)
    {
        if (star is null) return;

        star.Tag = index;
        star.Click += Star_Click;
        star.MouseEnter += Star_MouseEnter;
        star.MouseLeave += Star_MouseLeave;
    }

    private void UnsubscribeStarEvents()
    {
        UnsubscribeStar(_star1);
        UnsubscribeStar(_star2);
        UnsubscribeStar(_star3);
        UnsubscribeStar(_star4);
        UnsubscribeStar(_star5);
    }

    private void UnsubscribeStar(ToggleButton? star)
    {
        if (star is null) return;

        star.Click -= Star_Click;
        star.MouseEnter -= Star_MouseEnter;
        star.MouseLeave -= Star_MouseLeave;
    }

    private void Star_Click(object sender, RoutedEventArgs e)
    {
        if (IsReadOnly) return;

        if (sender is ToggleButton star && star.Tag is int index)
        {
            // 같은 별을 다시 클릭하면 선택 해제
            // Clicking the same star again deselects it
            Value = Value == index ? 0 : index;
            UpdateStarStates();
        }
    }

    private void Star_MouseEnter(object sender, MouseEventArgs e)
    {
        if (IsReadOnly) return;

        if (sender is ToggleButton star && star.Tag is int index)
        {
            HoverValue = index;
            UpdateStarStates();
        }
    }

    private void Star_MouseLeave(object sender, MouseEventArgs e)
    {
        HoverValue = 0;
        UpdateStarStates();
    }

    private void UpdateStarStates()
    {
        int displayValue = HoverValue > 0 ? HoverValue : Value;

        SetStarState(_star1, displayValue >= 1);
        SetStarState(_star2, displayValue >= 2);
        SetStarState(_star3, displayValue >= 3);
        SetStarState(_star4, displayValue >= 4);
        SetStarState(_star5, displayValue >= 5);
    }

    private static void SetStarState(ToggleButton? star, bool isChecked)
    {
        if (star is not null)
        {
            star.IsChecked = isChecked;
        }
    }
}
