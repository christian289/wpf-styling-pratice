using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace FreshLizard20.Wpf.UI.Controls;

/// <summary>
/// 로딩 텍스트와 함께 단어들이 세로로 순환 애니메이션되는 로더 컨트롤
/// A loader control with loading text and vertically cycling words animation
/// </summary>
public sealed class FreshLizard20 : Control
{
    static FreshLizard20()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(FreshLizard20),
            new FrameworkPropertyMetadata(typeof(FreshLizard20)));
    }

    /// <summary>
    /// 로딩 텍스트 (기본값: "loading")
    /// Loading text (default: "loading")
    /// </summary>
    public static readonly DependencyProperty LoadingTextProperty =
        DependencyProperty.Register(
            nameof(LoadingText),
            typeof(string),
            typeof(FreshLizard20),
            new PropertyMetadata("loading"));

    public string LoadingText
    {
        get => (string)GetValue(LoadingTextProperty);
        set => SetValue(LoadingTextProperty, value);
    }

    /// <summary>
    /// 순환할 단어 목록
    /// List of words to cycle through
    /// </summary>
    public static readonly DependencyProperty WordsProperty =
        DependencyProperty.Register(
            nameof(Words),
            typeof(ObservableCollection<string>),
            typeof(FreshLizard20),
            new PropertyMetadata(null));

    public ObservableCollection<string> Words
    {
        get => (ObservableCollection<string>)GetValue(WordsProperty);
        set => SetValue(WordsProperty, value);
    }

    /// <summary>
    /// 애니메이션 지속 시간 (초 단위, 기본값: 4)
    /// Animation duration in seconds (default: 4)
    /// </summary>
    public static readonly DependencyProperty AnimationDurationProperty =
        DependencyProperty.Register(
            nameof(AnimationDuration),
            typeof(double),
            typeof(FreshLizard20),
            new PropertyMetadata(4.0));

    public double AnimationDuration
    {
        get => (double)GetValue(AnimationDurationProperty);
        set => SetValue(AnimationDurationProperty, value);
    }

    public FreshLizard20()
    {
        Words =
        [
            "buttons",
            "forms",
            "switches",
            "cards",
            "buttons"
        ];
    }
}
