using System.Windows;
using System.Windows.Controls;

namespace NervousZebra0.Wpf.UI.Controls;

/// <summary>
/// Level Up 알림 스타일의 Notification 컨트롤
/// 상단 영역이 슬라이드 다운 애니메이션으로 나타나고, 하단에 레벨 정보와 Next Level 버튼이 표시됩니다.
/// </summary>
public sealed class NervousZebra0 : Control
{
    /// <summary>
    /// 상단 영역에 표시될 제목 텍스트
    /// </summary>
    public static readonly DependencyProperty TitleProperty =
        DependencyProperty.Register(
            nameof(Title),
            typeof(string),
            typeof(NervousZebra0),
            new PropertyMetadata("Level Up!"));

    /// <summary>
    /// 하단 영역에 표시될 레벨 텍스트
    /// </summary>
    public static readonly DependencyProperty LevelTextProperty =
        DependencyProperty.Register(
            nameof(LevelText),
            typeof(string),
            typeof(NervousZebra0),
            new PropertyMetadata("Level 5"));

    /// <summary>
    /// Next Level 버튼 텍스트
    /// </summary>
    public static readonly DependencyProperty ButtonTextProperty =
        DependencyProperty.Register(
            nameof(ButtonText),
            typeof(string),
            typeof(NervousZebra0),
            new PropertyMetadata("Next Level"));

    /// <summary>
    /// Next Level 버튼 클릭 이벤트
    /// </summary>
    public static readonly RoutedEvent NextLevelClickEvent =
        EventManager.RegisterRoutedEvent(
            nameof(NextLevelClick),
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(NervousZebra0));

    static NervousZebra0()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(NervousZebra0),
            new FrameworkPropertyMetadata(typeof(NervousZebra0)));
    }

    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public string LevelText
    {
        get => (string)GetValue(LevelTextProperty);
        set => SetValue(LevelTextProperty, value);
    }

    public string ButtonText
    {
        get => (string)GetValue(ButtonTextProperty);
        set => SetValue(ButtonTextProperty, value);
    }

    public event RoutedEventHandler NextLevelClick
    {
        add => AddHandler(NextLevelClickEvent, value);
        remove => RemoveHandler(NextLevelClickEvent, value);
    }

    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();

        if (GetTemplateChild("PART_NextLevelButton") is Button button)
        {
            button.Click += (s, e) => RaiseEvent(new RoutedEventArgs(NextLevelClickEvent, this));
        }
    }
}
