using Avalonia;
using Avalonia.Controls;

namespace LovelyBulldog50.Avalonia.Lib.Controls;

/// <summary>
/// 입력이 비어있을 때 흔들림 애니메이션을 표시하는 TextBox 컨트롤.
/// A TextBox control that shows a shake animation when input is empty.
/// </summary>
public sealed class ShakeTextBox : TextBox
{
    /// <summary>
    /// IsValid 속성 정의 - 입력이 유효한지 여부를 나타냄.
    /// IsValid property definition - indicates whether the input is valid.
    /// </summary>
    public static readonly StyledProperty<bool> IsValidProperty =
        AvaloniaProperty.Register<ShakeTextBox, bool>(nameof(IsValid), defaultValue: false);

    /// <summary>
    /// 입력이 유효한지 여부를 가져오거나 설정합니다.
    /// Gets or sets whether the input is valid.
    /// </summary>
    public bool IsValid
    {
        get => GetValue(IsValidProperty);
        set => SetValue(IsValidProperty, value);
    }

    static ShakeTextBox()
    {
        // Text 속성 변경 시 IsValid 속성 업데이트
        // Update IsValid property when Text property changes
        TextProperty.Changed.AddClassHandler<ShakeTextBox>((textBox, e) =>
        {
            textBox.IsValid = !string.IsNullOrEmpty(e.NewValue as string);
        });
    }
}
