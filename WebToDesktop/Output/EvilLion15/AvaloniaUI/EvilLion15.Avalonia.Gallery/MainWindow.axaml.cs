using Avalonia.Controls;
using Avalonia.Interactivity;

namespace EvilLion15.Avalonia.Gallery;

public sealed partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        Switch1.Click += OnSwitchClicked;
        Switch2.Click += OnSwitchClicked;
    }

    private void OnSwitchClicked(object? sender, RoutedEventArgs e)
    {
        var switch1State = Switch1.IsChecked == true ? "ON" : "OFF";
        var switch2State = Switch2.IsChecked == true ? "ON" : "OFF";
        StatusText.Text = $"Switch 1: {switch1State} | Switch 2: {switch2State}";
    }
}
