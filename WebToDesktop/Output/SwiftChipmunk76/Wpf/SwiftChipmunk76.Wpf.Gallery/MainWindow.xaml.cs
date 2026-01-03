using System.Windows;
using SwiftChipmunk76.Wpf.UI.Controls;

namespace SwiftChipmunk76.Wpf.Gallery;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        RatingControl.ValueChanged += RatingControl_ValueChanged;
        UpdateRatingText(RatingControl.Value);
    }

    private void RatingControl_ValueChanged(object sender, RoutedPropertyChangedEventArgs<int> e)
    {
        UpdateRatingText(e.NewValue);
    }

    private void UpdateRatingText(int value)
    {
        RatingText.Text = value switch
        {
            0 => "No rating selected",
            1 => "1 Star - Poor",
            2 => "2 Stars - Fair",
            3 => "3 Stars - Good",
            4 => "4 Stars - Very Good",
            5 => "5 Stars - Excellent",
            _ => $"{value} Stars"
        };
    }
}
