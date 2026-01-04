using System.Windows;

namespace AverageShrimp57.Wpf.Gallery;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        Toggle1.Checked += (s, e) => StatusText.Text = "Current State: On";
        Toggle1.Unchecked += (s, e) => StatusText.Text = "Current State: Off";
    }
}
