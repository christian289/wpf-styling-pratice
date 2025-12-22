using System.Windows;
using System.Windows.Controls;

namespace BigSloth59.Wpf.UI.Controls;

public sealed class BigSloth59 : TextBox
{
    static BigSloth59()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(BigSloth59),
            new FrameworkPropertyMetadata(typeof(BigSloth59)));
    }
}
