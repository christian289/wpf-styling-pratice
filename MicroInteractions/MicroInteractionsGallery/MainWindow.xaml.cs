using System.Windows;
using System.Windows.Controls;

namespace MicroInteractionsGallery;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        // InitializeComponent 완료 후 이벤트 핸들러 추가
        NavigationList.SelectionChanged += NavigationList_SelectionChanged;

        // 초기 선택 설정
        NavigationList.SelectedIndex = 0;
    }

    private void NavigationList_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (NavigationList.SelectedItem is not ListBoxItem selectedItem)
            return;

        // Hide all sections
        ButtonsSection.Visibility = Visibility.Collapsed;
        InputsSection.Visibility = Visibility.Collapsed;
        SelectionSection.Visibility = Visibility.Collapsed;
        NavigationSection.Visibility = Visibility.Collapsed;
        ProgressSection.Visibility = Visibility.Collapsed;
        AaronIkerSection.Visibility = Visibility.Collapsed;
        AllSection.Visibility = Visibility.Collapsed;

        // Show selected section based on Tag
        switch (selectedItem.Tag?.ToString())
        {
            case "Buttons":
                ButtonsSection.Visibility = Visibility.Visible;
                break;
            case "Inputs":
                InputsSection.Visibility = Visibility.Visible;
                break;
            case "Selection":
                SelectionSection.Visibility = Visibility.Visible;
                break;
            case "Navigation":
                NavigationSection.Visibility = Visibility.Visible;
                break;
            case "Progress":
                ProgressSection.Visibility = Visibility.Visible;
                break;
            case "AaronIker":
                AaronIkerSection.Visibility = Visibility.Visible;
                break;
            case "All":
                AllSection.Visibility = Visibility.Visible;
                break;
        }
    }
}
