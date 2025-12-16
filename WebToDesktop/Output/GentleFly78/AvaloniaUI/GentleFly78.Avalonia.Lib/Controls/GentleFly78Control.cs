using Avalonia;
using Avalonia.Controls.Primitives;

namespace GentleFly78.Avalonia.Lib.Controls;

/// <summary>
/// 이모지 슬라이딩 카드 컨트롤
/// Emoji sliding card control
/// </summary>
public sealed class GentleFly78Control : TemplatedControl
{
    /// <summary>
    /// 이모지 목록을 정의하는 속성
    /// Property that defines the emoji list
    /// </summary>
    public static readonly StyledProperty<string> EmojisProperty =
        AvaloniaProperty.Register<GentleFly78Control, string>(nameof(Emojis), "😄😁😆😂");

    /// <summary>
    /// 애니메이션 지속 시간 (초)
    /// Animation duration in seconds
    /// </summary>
    public static readonly StyledProperty<double> AnimationDurationProperty =
        AvaloniaProperty.Register<GentleFly78Control, double>(nameof(AnimationDuration), 5.0);

    /// <summary>
    /// 이모지 목록
    /// Emoji list
    /// </summary>
    public string Emojis
    {
        get => GetValue(EmojisProperty);
        set => SetValue(EmojisProperty, value);
    }

    /// <summary>
    /// 애니메이션 지속 시간 (초)
    /// Animation duration in seconds
    /// </summary>
    public double AnimationDuration
    {
        get => GetValue(AnimationDurationProperty);
        set => SetValue(AnimationDurationProperty, value);
    }
}
