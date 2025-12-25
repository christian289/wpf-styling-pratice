using Avalonia.Controls;
using Avalonia.Interactivity;
using NastyMoth15.Avalonia.Lib.Controls;

namespace NastyMoth15.Avalonia.Gallery;

public sealed partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        // 토글 스위치 상태 변경 이벤트 연결
        // Connect toggle switch state change event
        Loaded += OnLoaded;
    }

    private void OnLoaded(object? sender, RoutedEventArgs e)
    {
        var toggle = this.FindControl<NastyMoth15ToggleSwitch>("NastyMoth15ToggleSwitch");
        var statusText = this.FindControl<TextBlock>("StatusText");

        if (toggle is not null && statusText is not null)
        {
            toggle.Click += (s, args) =>
            {
                statusText.Text = toggle.IsChecked == true ? "ON" : "OFF";
            };
        }
    }
}
