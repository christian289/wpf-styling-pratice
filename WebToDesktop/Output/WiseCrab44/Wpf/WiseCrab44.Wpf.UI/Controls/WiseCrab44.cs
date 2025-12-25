using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WiseCrab44.Wpf.UI.Controls;

/// <summary>
/// 업로드 버튼, 텍스트 입력, 전송 버튼이 있는 모던 폼 입력 컨트롤
/// A modern form input control with upload button, text input, and submit button
/// </summary>
public sealed class WiseCrab44 : Control
{
    static WiseCrab44()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(WiseCrab44),
            new FrameworkPropertyMetadata(typeof(WiseCrab44)));
    }

    #region Dependency Properties

    /// <summary>
    /// 텍스트 입력 값
    /// Text input value
    /// </summary>
    public static readonly DependencyProperty TextProperty =
        DependencyProperty.Register(
            nameof(Text),
            typeof(string),
            typeof(WiseCrab44),
            new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    /// <summary>
    /// 플레이스홀더 텍스트
    /// Placeholder text
    /// </summary>
    public static readonly DependencyProperty PlaceholderProperty =
        DependencyProperty.Register(
            nameof(Placeholder),
            typeof(string),
            typeof(WiseCrab44),
            new PropertyMetadata("Enter your prompt..."));

    public string Placeholder
    {
        get => (string)GetValue(PlaceholderProperty);
        set => SetValue(PlaceholderProperty, value);
    }

    /// <summary>
    /// 업로드 버튼 클릭 커맨드
    /// Upload button click command
    /// </summary>
    public static readonly DependencyProperty UploadCommandProperty =
        DependencyProperty.Register(
            nameof(UploadCommand),
            typeof(ICommand),
            typeof(WiseCrab44),
            new PropertyMetadata(null));

    public ICommand? UploadCommand
    {
        get => (ICommand?)GetValue(UploadCommandProperty);
        set => SetValue(UploadCommandProperty, value);
    }

    /// <summary>
    /// 전송 버튼 클릭 커맨드
    /// Submit button click command
    /// </summary>
    public static readonly DependencyProperty SubmitCommandProperty =
        DependencyProperty.Register(
            nameof(SubmitCommand),
            typeof(ICommand),
            typeof(WiseCrab44),
            new PropertyMetadata(null));

    public ICommand? SubmitCommand
    {
        get => (ICommand?)GetValue(SubmitCommandProperty);
        set => SetValue(SubmitCommandProperty, value);
    }

    #endregion
}
