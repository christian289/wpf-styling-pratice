using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace PerfectCheetah72.Avalonia.Lib.Controls;

/// <summary>
/// 테마 선택 팝업 컨트롤
/// Theme selection popup control
/// </summary>
public sealed class ThemePopup : TemplatedControl
{
    /// <summary>
    /// 테마 옵션을 정의하는 열거형
    /// Enumeration defining theme options
    /// </summary>
    public enum ThemeOption
    {
        Default,
        Light,
        Dark
    }

    public static readonly StyledProperty<ThemeOption> SelectedThemeProperty =
        AvaloniaProperty.Register<ThemePopup, ThemeOption>(nameof(SelectedTheme), ThemeOption.Default);

    public static readonly StyledProperty<bool> IsOpenProperty =
        AvaloniaProperty.Register<ThemePopup, bool>(nameof(IsOpen), false);

    /// <summary>
    /// 선택된 테마
    /// Selected theme
    /// </summary>
    public ThemeOption SelectedTheme
    {
        get => GetValue(SelectedThemeProperty);
        set => SetValue(SelectedThemeProperty, value);
    }

    /// <summary>
    /// 팝업이 열려있는지 여부
    /// Whether the popup is open
    /// </summary>
    public bool IsOpen
    {
        get => GetValue(IsOpenProperty);
        set => SetValue(IsOpenProperty, value);
    }

    protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
    {
        base.OnApplyTemplate(e);

        var toggleButton = e.NameScope.Find<ToggleButton>("PART_ToggleButton");
        var defaultItem = e.NameScope.Find<Button>("PART_DefaultItem");
        var lightItem = e.NameScope.Find<Button>("PART_LightItem");
        var darkItem = e.NameScope.Find<Button>("PART_DarkItem");
        var popup = e.NameScope.Find<Popup>("PART_Popup");

        if (toggleButton is not null)
        {
            toggleButton.Click += (_, _) => IsOpen = !IsOpen;
        }

        if (popup is not null)
        {
            popup.Closed += (_, _) => IsOpen = false;
        }

        if (defaultItem is not null)
        {
            defaultItem.Click += (_, _) =>
            {
                SelectedTheme = ThemeOption.Default;
                IsOpen = false;
            };
        }

        if (lightItem is not null)
        {
            lightItem.Click += (_, _) =>
            {
                SelectedTheme = ThemeOption.Light;
                IsOpen = false;
            };
        }

        if (darkItem is not null)
        {
            darkItem.Click += (_, _) =>
            {
                SelectedTheme = ThemeOption.Dark;
                IsOpen = false;
            };
        }
    }
}
