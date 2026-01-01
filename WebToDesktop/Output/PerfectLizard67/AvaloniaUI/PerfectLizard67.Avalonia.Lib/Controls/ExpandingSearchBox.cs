using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace PerfectLizard67.Avalonia.Lib.Controls;

/// <summary>
/// 클릭 시 확장되는 검색창 컨트롤
/// Expanding search box control that expands on click
/// </summary>
public sealed class ExpandingSearchBox : TemplatedControl
{
    private const string ExpandedClassName = "expanded";

    public static readonly StyledProperty<string?> TextProperty =
        AvaloniaProperty.Register<ExpandingSearchBox, string?>(nameof(Text));

    public static readonly StyledProperty<string?> PlaceholderProperty =
        AvaloniaProperty.Register<ExpandingSearchBox, string?>(nameof(Placeholder), "search..");

    public static readonly StyledProperty<bool> IsExpandedProperty =
        AvaloniaProperty.Register<ExpandingSearchBox, bool>(nameof(IsExpanded));

    static ExpandingSearchBox()
    {
        IsExpandedProperty.Changed.AddClassHandler<ExpandingSearchBox>((control, args) =>
        {
            if (args.NewValue is true)
            {
                control.Classes.Add(ExpandedClassName);
            }
            else
            {
                control.Classes.Remove(ExpandedClassName);
            }
        });
    }

    public string? Text
    {
        get => GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public string? Placeholder
    {
        get => GetValue(PlaceholderProperty);
        set => SetValue(PlaceholderProperty, value);
    }

    public bool IsExpanded
    {
        get => GetValue(IsExpandedProperty);
        set => SetValue(IsExpandedProperty, value);
    }

    protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
    {
        base.OnApplyTemplate(e);

        var searchButton = e.NameScope.Find<Button>("PART_SearchButton");
        var textBox = e.NameScope.Find<TextBox>("PART_TextBox");

        if (searchButton is not null)
        {
            searchButton.Click += (_, _) =>
            {
                IsExpanded = true;
                textBox?.Focus();
            };
        }

        if (textBox is not null)
        {
            textBox.LostFocus += (_, _) =>
            {
                if (string.IsNullOrEmpty(Text))
                {
                    IsExpanded = false;
                }
            };
        }
    }
}
