using System.Windows.Input;

namespace SillySheep7.Wpf.UI.Controls;

/// <summary>
/// SillySheep7 컨트롤의 커맨드를 정의합니다.
/// Defines commands for the SillySheep7 control.
/// </summary>
public static class SillySheep7Commands
{
    public static readonly RoutedCommand SelectIndex = new(nameof(SelectIndex), typeof(SillySheep7Commands));

    static SillySheep7Commands()
    {
        CommandManager.RegisterClassCommandBinding(
            typeof(SillySheep7),
            new CommandBinding(SelectIndex, OnSelectIndexExecuted, OnSelectIndexCanExecute));
    }

    private static void OnSelectIndexExecuted(object sender, ExecutedRoutedEventArgs e)
    {
        if (sender is SillySheep7 control && e.Parameter is string indexStr && int.TryParse(indexStr, out int index))
        {
            control.SelectedIndex = index;
        }
    }

    private static void OnSelectIndexCanExecute(object sender, CanExecuteRoutedEventArgs e)
    {
        e.CanExecute = true;
    }
}
