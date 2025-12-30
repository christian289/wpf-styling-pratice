using Avalonia.Controls;
using Avalonia.Interactivity;
using BadSquid34.Avalonia.Lib.Controls;

namespace BadSquid34.Avalonia.Gallery;

public sealed partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void OnErrorAlertCloseClicked(object? sender, RoutedEventArgs e)
    {
        if (sender is ErrorAlert errorAlert)
        {
            errorAlert.IsVisible = false;
            StatusText.Text = $"Alert '{errorAlert.Message[..20]}...' has been closed";
        }
    }
}
