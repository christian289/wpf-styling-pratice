using Avalonia;
using Avalonia.Collections;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace FreshLizard20.Avalonia.Lib.Controls;

/// <summary>
/// 순환하는 단어 목록을 표시하는 로딩 텍스트 컨트롤
/// A loading text control that displays cycling word list
/// </summary>
public sealed class FreshLizard20LoadingTextControl : TemplatedControl
{
    /// <summary>
    /// 접두사 텍스트 (예: "loading")
    /// Prefix text (e.g., "loading")
    /// </summary>
    public static readonly StyledProperty<string> PrefixTextProperty =
        AvaloniaProperty.Register<FreshLizard20LoadingTextControl, string>(nameof(PrefixText), "loading");

    /// <summary>
    /// 순환할 단어 목록
    /// List of words to cycle through
    /// </summary>
    public static readonly StyledProperty<AvaloniaList<string>> WordsProperty =
        AvaloniaProperty.Register<FreshLizard20LoadingTextControl, AvaloniaList<string>>(
            nameof(Words),
            new AvaloniaList<string> { "buttons", "forms", "switches", "cards", "buttons" });

    /// <summary>
    /// 애니메이션 지속 시간 (초)
    /// Animation duration in seconds
    /// </summary>
    public static readonly StyledProperty<double> AnimationDurationProperty =
        AvaloniaProperty.Register<FreshLizard20LoadingTextControl, double>(nameof(AnimationDuration), 4.0);

    public string PrefixText
    {
        get => GetValue(PrefixTextProperty);
        set => SetValue(PrefixTextProperty, value);
    }

    public AvaloniaList<string> Words
    {
        get => GetValue(WordsProperty);
        set => SetValue(WordsProperty, value);
    }

    public double AnimationDuration
    {
        get => GetValue(AnimationDurationProperty);
        set => SetValue(AnimationDurationProperty, value);
    }
}
