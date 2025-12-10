using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Gallery.OpenSilver.Controls
{
    /// <summary>
    /// 테마 전환 토글 버튼 컨트롤
    /// Theme switch toggle button control
    /// </summary>
    public class ThemeSwitchToggle : ToggleButton
    {
        public ThemeSwitchToggle()
        {
            DefaultStyleKey = typeof(ThemeSwitchToggle);
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            UpdateVisualState(false);
        }

        protected override void OnChecked(RoutedEventArgs e)
        {
            base.OnChecked(e);
            UpdateVisualState(true);
        }

        protected override void OnUnchecked(RoutedEventArgs e)
        {
            base.OnUnchecked(e);
            UpdateVisualState(true);
        }

        private void UpdateVisualState(bool useTransitions)
        {
            if (IsChecked == true)
            {
                VisualStateManager.GoToState(this, "Checked", useTransitions);
            }
            else
            {
                VisualStateManager.GoToState(this, "Unchecked", useTransitions);
            }
        }
    }
}
