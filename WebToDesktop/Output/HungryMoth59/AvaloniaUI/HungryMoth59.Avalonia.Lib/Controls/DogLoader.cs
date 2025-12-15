using Avalonia;
using Avalonia.Controls.Primitives;

namespace HungryMoth59.Avalonia.Lib.Controls;

/// <summary>
/// 귀여운 강아지 로딩 애니메이션 컨트롤
/// A cute animated dog loader control
/// </summary>
public sealed class DogLoader : TemplatedControl
{
    /// <summary>
    /// 컨트롤 크기 조절을 위한 스케일 속성
    /// Scale property for resizing the control
    /// </summary>
    public static readonly StyledProperty<double> ScaleProperty =
        AvaloniaProperty.Register<DogLoader, double>(nameof(Scale), 1.0);

    public double Scale
    {
        get => GetValue(ScaleProperty);
        set => SetValue(ScaleProperty, value);
    }
}
