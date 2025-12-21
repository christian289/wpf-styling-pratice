using System.Windows;
using System.Windows.Controls;

namespace SwiftChicken44.Wpf.UI.Controls;

/// <summary>
/// 유효성 검사 상태에 따라 시각적 피드백을 제공하는 입력 컨트롤입니다.
/// A text input control that provides visual feedback based on validation state.
/// </summary>
public sealed class SwiftChicken44 : TextBox
{
    /// <summary>
    /// 입력이 유효한지 여부를 나타냅니다.
    /// Indicates whether the input is valid.
    /// </summary>
    public static readonly DependencyProperty IsValidProperty =
        DependencyProperty.Register(
            nameof(IsValid),
            typeof(bool?),
            typeof(SwiftChicken44),
            new PropertyMetadata(null));

    /// <summary>
    /// 입력이 유효한지 여부를 가져오거나 설정합니다.
    /// Gets or sets whether the input is valid.
    /// </summary>
    public bool? IsValid
    {
        get => (bool?)GetValue(IsValidProperty);
        set => SetValue(IsValidProperty, value);
    }

    static SwiftChicken44()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(SwiftChicken44),
            new FrameworkPropertyMetadata(typeof(SwiftChicken44)));
    }
}
