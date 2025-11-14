using System.Windows;
using System.Windows.Controls.Primitives;

namespace GlassmorphismLib;

public class GlassCheckBox : ToggleButton
{
    static GlassCheckBox()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(GlassCheckBox),
            new FrameworkPropertyMetadata(typeof(GlassCheckBox)));
    }
}
