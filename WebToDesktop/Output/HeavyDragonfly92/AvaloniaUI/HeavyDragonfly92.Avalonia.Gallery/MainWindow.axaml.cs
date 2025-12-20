using Avalonia.Controls;

namespace HeavyDragonfly92.Avalonia.Gallery;

public sealed partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        // 탭 추가
        // Add tabs
        TabControl.AddTab("Hello", 2);
        TabControl.AddTab("UI");
        TabControl.AddTab("World");
    }
}
