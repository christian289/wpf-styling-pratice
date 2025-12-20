using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using Avalonia.Media;

namespace HeavyDragonfly92.Avalonia.Lib.Controls;

/// <summary>
/// 슬라이딩 글라이더 효과가 있는 탭 컨트롤
/// Tab control with sliding glider effect
/// </summary>
public sealed class SlidingTabControl : TemplatedControl
{
    private Border? _glider;
    private ItemsControl? _tabsContainer;
    private readonly List<SlidingTabItem> _tabs = [];

    public static readonly StyledProperty<int> SelectedIndexProperty =
        AvaloniaProperty.Register<SlidingTabControl, int>(nameof(SelectedIndex), defaultValue: 0);

    public static readonly DirectProperty<SlidingTabControl, IReadOnlyList<SlidingTabItem>> TabsProperty =
        AvaloniaProperty.RegisterDirect<SlidingTabControl, IReadOnlyList<SlidingTabItem>>(
            nameof(Tabs),
            o => o.Tabs);

    public int SelectedIndex
    {
        get => GetValue(SelectedIndexProperty);
        set => SetValue(SelectedIndexProperty, value);
    }

    public IReadOnlyList<SlidingTabItem> Tabs => _tabs;

    public void AddTab(string text, int notificationCount = 0)
    {
        var tab = new SlidingTabItem
        {
            Text = text,
            NotificationCount = notificationCount,
            IsSelected = _tabs.Count == SelectedIndex
        };
        _tabs.Add(tab);
        RaisePropertyChanged(TabsProperty, [], _tabs);
    }

    protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
    {
        base.OnApplyTemplate(e);

        _glider = e.NameScope.Find<Border>("PART_Glider");
        _tabsContainer = e.NameScope.Find<ItemsControl>("PART_TabsContainer");

        if (_tabsContainer is not null)
        {
            _tabsContainer.ItemsSource = _tabs;
        }

        UpdateGliderPosition(false);
    }

    protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
    {
        base.OnPropertyChanged(change);

        if (change.Property == SelectedIndexProperty)
        {
            var oldIndex = change.GetOldValue<int>();
            var newIndex = change.GetNewValue<int>();

            if (oldIndex >= 0 && oldIndex < _tabs.Count)
            {
                _tabs[oldIndex].IsSelected = false;
            }

            if (newIndex >= 0 && newIndex < _tabs.Count)
            {
                _tabs[newIndex].IsSelected = true;
            }

            UpdateGliderPosition(true);
        }
    }

    private void UpdateGliderPosition(bool animate)
    {
        if (_glider is null) return;

        const double tabWidth = 50;
        var translateX = SelectedIndex * tabWidth;

        if (animate)
        {
            _glider.RenderTransform = new TranslateTransform(translateX, 0);
        }
        else
        {
            _glider.RenderTransform = new TranslateTransform(translateX, 0);
        }
    }

    internal void SelectTab(SlidingTabItem tab)
    {
        var index = _tabs.IndexOf(tab);
        if (index >= 0)
        {
            SelectedIndex = index;
        }
    }
}
