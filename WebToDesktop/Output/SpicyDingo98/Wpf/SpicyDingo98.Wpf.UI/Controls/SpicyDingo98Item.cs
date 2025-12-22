using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace SpicyDingo98.Wpf.UI.Controls;

/// <summary>
/// 라디오 버튼 그룹의 개별 아이템입니다.
/// An individual item in the radio button group.
/// </summary>
public sealed class SpicyDingo98Item : ContentControl
{
    public static readonly DependencyProperty IsSelectedProperty =
        Selector.IsSelectedProperty.AddOwner(
            typeof(SpicyDingo98Item),
            new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnIsSelectedChanged));

    public bool IsSelected
    {
        get => (bool)GetValue(IsSelectedProperty);
        set => SetValue(IsSelectedProperty, value);
    }

    static SpicyDingo98Item()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(SpicyDingo98Item),
            new FrameworkPropertyMetadata(typeof(SpicyDingo98Item)));
    }

    protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
    {
        base.OnMouseLeftButtonDown(e);

        if (!IsSelected)
        {
            IsSelected = true;
        }

        e.Handled = true;
    }

    private static void OnIsSelectedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is SpicyDingo98Item item && (bool)e.NewValue)
        {
            // 부모 Selector에서 다른 아이템들의 선택을 해제합니다.
            // Deselect other items in the parent Selector.
            if (ItemsControl.ItemsControlFromItemContainer(item) is SpicyDingo98 parent)
            {
                parent.SelectedItem = item.DataContext ?? item.Content ?? item;

                foreach (var obj in parent.Items)
                {
                    if (parent.ItemContainerGenerator.ContainerFromItem(obj) is SpicyDingo98Item sibling && sibling != item)
                    {
                        sibling.IsSelected = false;
                    }
                }
            }
        }
    }
}
