using Avalonia;
using Avalonia.Animation;
using Avalonia.Animation.Easings;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Media;
using Avalonia.Styling;

namespace SillySheep7.Avalonia.Lib.Controls;

/// <summary>
/// 스큐어모피즘 스타일의 회전 노브 라디오 버튼 컨트롤
/// Skeuomorphism style rotating knob radio button control
/// </summary>
public sealed class SillySheep7KnobRadio : TemplatedControl
{
    /// <summary>
    /// 현재 선택된 값 (1-5)
    /// Currently selected value (1-5)
    /// </summary>
    public static readonly StyledProperty<int> SelectedValueProperty =
        AvaloniaProperty.Register<SillySheep7KnobRadio, int>(nameof(SelectedValue), 3, coerce: CoerceSelectedValue);

    /// <summary>
    /// 노브 배경색
    /// Knob background color
    /// </summary>
    public static readonly StyledProperty<IBrush?> KnobBackgroundProperty =
        AvaloniaProperty.Register<SillySheep7KnobRadio, IBrush?>(nameof(KnobBackground));

    /// <summary>
    /// 노브 테두리 색상
    /// Knob border color
    /// </summary>
    public static readonly StyledProperty<IBrush?> KnobBorderBrushProperty =
        AvaloniaProperty.Register<SillySheep7KnobRadio, IBrush?>(nameof(KnobBorderBrush));

    /// <summary>
    /// 라벨 폰트 크기
    /// Label font size
    /// </summary>
    public static readonly StyledProperty<double> LabelFontSizeProperty =
        AvaloniaProperty.Register<SillySheep7KnobRadio, double>(nameof(LabelFontSize), 12);

    /// <summary>
    /// 노브 회전 각도 (읽기 전용, SelectedValue에 의해 계산됨)
    /// Knob rotation angle (readonly, calculated by SelectedValue)
    /// </summary>
    public static readonly DirectProperty<SillySheep7KnobRadio, double> KnobRotationAngleProperty =
        AvaloniaProperty.RegisterDirect<SillySheep7KnobRadio, double>(
            nameof(KnobRotationAngle),
            o => o.KnobRotationAngle);

    private double _knobRotationAngle;
    private Border? _knobBorder;
    private RotateTransform? _knobRotateTransform;

    static SillySheep7KnobRadio()
    {
        SelectedValueProperty.Changed.AddClassHandler<SillySheep7KnobRadio>((x, _) => x.UpdateKnobRotation());
    }

    public SillySheep7KnobRadio()
    {
        UpdateKnobRotation();
    }

    public int SelectedValue
    {
        get => GetValue(SelectedValueProperty);
        set => SetValue(SelectedValueProperty, value);
    }

    public IBrush? KnobBackground
    {
        get => GetValue(KnobBackgroundProperty);
        set => SetValue(KnobBackgroundProperty, value);
    }

    public IBrush? KnobBorderBrush
    {
        get => GetValue(KnobBorderBrushProperty);
        set => SetValue(KnobBorderBrushProperty, value);
    }

    public double LabelFontSize
    {
        get => GetValue(LabelFontSizeProperty);
        set => SetValue(LabelFontSizeProperty, value);
    }

    public double KnobRotationAngle
    {
        get => _knobRotationAngle;
        private set => SetAndRaise(KnobRotationAngleProperty, ref _knobRotationAngle, value);
    }

    private static int CoerceSelectedValue(AvaloniaObject sender, int value)
    {
        return Math.Clamp(value, 1, 5);
    }

    private void UpdateKnobRotation()
    {
        // CSS에서 정의된 각도:
        // Angles defined in CSS:
        // radio1: -60deg, radio2: -35deg, radio3: 0deg, radio4: 35deg, radio5: 60deg
        KnobRotationAngle = SelectedValue switch
        {
            1 => -60,
            2 => -35,
            3 => 0,
            4 => 35,
            5 => 60,
            _ => 0
        };

        // 노브 회전 적용
        // Apply knob rotation
        if (_knobRotateTransform != null)
        {
            _knobRotateTransform.Angle = KnobRotationAngle;
        }
    }

    protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
    {
        base.OnApplyTemplate(e);

        // 노브 Border 찾기 및 RotateTransform 설정
        // Find knob Border and setup RotateTransform
        _knobBorder = e.NameScope.Find<Border>("PART_Knob");
        if (_knobBorder != null)
        {
            _knobRotateTransform = new RotateTransform(KnobRotationAngle);
            _knobBorder.RenderTransform = _knobRotateTransform;

            // CSS transition: transform 350ms cubic-bezier(0.175, 0.885, 0.32, 1.275)
            // Avalonia에서는 Transitions로 애니메이션 효과 추가
            // Add animation effect with Transitions in Avalonia
            _knobBorder.Transitions =
            [
                new TransformOperationsTransition
                {
                    Property = Border.RenderTransformProperty,
                    Duration = TimeSpan.FromMilliseconds(350),
                    Easing = new SplineEasing(0.175, 0.885, 0.32, 1.275)
                }
            ];
        }

        // 라디오 버튼 이벤트 연결
        // Connect radio button events
        for (int i = 1; i <= 5; i++)
        {
            var radioButton = e.NameScope.Find<RadioButton>($"PART_Radio{i}");
            if (radioButton != null)
            {
                int value = i;
                radioButton.IsCheckedChanged += (_, _) =>
                {
                    if (radioButton.IsChecked == true)
                    {
                        SelectedValue = value;
                    }
                };

                // 초기 상태 설정
                // Set initial state
                if (i == SelectedValue)
                {
                    radioButton.IsChecked = true;
                }
            }
        }
    }
}
