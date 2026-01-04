using Avalonia.Controls;
using Avalonia.Interactivity;

namespace AverageShrimp57.Avalonia.Gallery;

public sealed partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        // 스위치 상태 변경 이벤트 연결
        // Connect switch state change event
        Switch1.IsCheckedChanged += OnSwitchCheckedChanged;
    }

    private void OnSwitchCheckedChanged(object? sender, RoutedEventArgs e)
    {
        var isChecked = Switch1.IsChecked ?? false;
        StatusText.Text = isChecked ? "Switch Status: On" : "Switch Status: Off";
    }
}
