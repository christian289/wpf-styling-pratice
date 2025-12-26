using Avalonia.Controls;
using PerfectCheetah72.Avalonia.Lib.Controls;

namespace PerfectCheetah72.Avalonia.Gallery;

public sealed partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        var themePopup = this.FindControl<ThemePopup>("ThemePopupControl");
        var selectedText = this.FindControl<TextBlock>("SelectedThemeText");

        if (themePopup is not null && selectedText is not null)
        {
            themePopup.PropertyChanged += (_, e) =>
            {
                if (e.Property == ThemePopup.SelectedThemeProperty)
                {
                    selectedText.Text = $"Selected: {themePopup.SelectedTheme}";
                }
            };
        }
    }
}
