using Avalonia.Controls;

namespace FreshMoth58.Avalonia.Gallery;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        // 토글 스위치 상태 변경 이벤트 처리
        // Handle toggle switch state change event
        ToggleSwitch.IsCheckedChanged += (s, e) =>
        {
            var isChecked = ToggleSwitch.IsChecked == true;
            StatusText.Text = isChecked
                ? "상태: On / Status: On"
                : "상태: Off / Status: Off";
        };
    }
}
