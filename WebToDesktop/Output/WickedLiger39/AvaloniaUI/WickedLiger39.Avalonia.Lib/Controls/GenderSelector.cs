using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace WickedLiger39.Avalonia.Lib.Controls;

/// <summary>
/// 성별 선택 컨트롤 (Male, Female, Non-Binary, None)
/// Gender selection control with animated radio buttons
/// </summary>
public sealed class GenderSelector : TemplatedControl
{
    public static readonly StyledProperty<string?> HeaderTextProperty =
        AvaloniaProperty.Register<GenderSelector, string?>(nameof(HeaderText), "Please select your gender");

    public static readonly StyledProperty<string?> SelectedGenderProperty =
        AvaloniaProperty.Register<GenderSelector, string?>(nameof(SelectedGender));

    /// <summary>
    /// 헤더 텍스트
    /// Header text
    /// </summary>
    public string? HeaderText
    {
        get => GetValue(HeaderTextProperty);
        set => SetValue(HeaderTextProperty, value);
    }

    /// <summary>
    /// 선택된 성별 값 (male, female, non-binary, none)
    /// Selected gender value
    /// </summary>
    public string? SelectedGender
    {
        get => GetValue(SelectedGenderProperty);
        set => SetValue(SelectedGenderProperty, value);
    }

    protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
    {
        base.OnApplyTemplate(e);

        var maleOption = e.NameScope.Find<GenderOption>("PART_MaleOption");
        var femaleOption = e.NameScope.Find<GenderOption>("PART_FemaleOption");
        var nonBinaryOption = e.NameScope.Find<GenderOption>("PART_NonBinaryOption");
        var noneOption = e.NameScope.Find<GenderOption>("PART_NoneOption");

        if (maleOption != null)
            maleOption.IsCheckedChanged += (_, _) => { if (maleOption.IsChecked == true) SelectedGender = "male"; };
        if (femaleOption != null)
            femaleOption.IsCheckedChanged += (_, _) => { if (femaleOption.IsChecked == true) SelectedGender = "female"; };
        if (nonBinaryOption != null)
            nonBinaryOption.IsCheckedChanged += (_, _) => { if (nonBinaryOption.IsChecked == true) SelectedGender = "non-binary"; };
        if (noneOption != null)
            noneOption.IsCheckedChanged += (_, _) => { if (noneOption.IsChecked == true) SelectedGender = "none"; };
    }
}
