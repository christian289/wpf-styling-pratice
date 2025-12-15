using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace NervousZebra0.Avalonia.Lib.Controls;

/// <summary>
/// Level Up 알림 컨트롤
/// Level Up notification control
/// </summary>
public sealed class LevelUpNotification : TemplatedControl
{
    /// <summary>
    /// 상단 텍스트 (예: "Level Up!")
    /// Top text (e.g., "Level Up!")
    /// </summary>
    public static readonly StyledProperty<string> TopTextProperty =
        AvaloniaProperty.Register<LevelUpNotification, string>(nameof(TopText), "Level Up!");

    public string TopText
    {
        get => GetValue(TopTextProperty);
        set => SetValue(TopTextProperty, value);
    }

    /// <summary>
    /// 레벨 텍스트 (예: "Level 5")
    /// Level text (e.g., "Level 5")
    /// </summary>
    public static readonly StyledProperty<string> LevelTextProperty =
        AvaloniaProperty.Register<LevelUpNotification, string>(nameof(LevelText), "Level 5");

    public string LevelText
    {
        get => GetValue(LevelTextProperty);
        set => SetValue(LevelTextProperty, value);
    }

    /// <summary>
    /// 버튼 텍스트 (예: "Next Level")
    /// Button text (e.g., "Next Level")
    /// </summary>
    public static readonly StyledProperty<string> ButtonTextProperty =
        AvaloniaProperty.Register<LevelUpNotification, string>(nameof(ButtonText), "Next Level");

    public string ButtonText
    {
        get => GetValue(ButtonTextProperty);
        set => SetValue(ButtonTextProperty, value);
    }
}
