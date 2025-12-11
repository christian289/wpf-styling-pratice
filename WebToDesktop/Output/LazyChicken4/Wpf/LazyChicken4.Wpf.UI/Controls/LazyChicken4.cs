using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace LazyChicken4.Wpf.UI.Controls;

public sealed class LazyChicken4 : Control
{
    static LazyChicken4()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(LazyChicken4),
            new FrameworkPropertyMetadata(typeof(LazyChicken4)));
    }

    public static readonly DependencyProperty UsernameProperty =
        DependencyProperty.Register(
            nameof(Username),
            typeof(string),
            typeof(LazyChicken4),
            new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

    public string Username
    {
        get => (string)GetValue(UsernameProperty);
        set => SetValue(UsernameProperty, value);
    }

    public static readonly DependencyProperty PasswordProperty =
        DependencyProperty.Register(
            nameof(Password),
            typeof(string),
            typeof(LazyChicken4),
            new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

    public string Password
    {
        get => (string)GetValue(PasswordProperty);
        set => SetValue(PasswordProperty, value);
    }

    public static readonly DependencyProperty RememberMeProperty =
        DependencyProperty.Register(
            nameof(RememberMe),
            typeof(bool),
            typeof(LazyChicken4),
            new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

    public bool RememberMe
    {
        get => (bool)GetValue(RememberMeProperty);
        set => SetValue(RememberMeProperty, value);
    }

    public static readonly DependencyProperty TitleProperty =
        DependencyProperty.Register(
            nameof(Title),
            typeof(string),
            typeof(LazyChicken4),
            new PropertyMetadata("Login"));

    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public static readonly DependencyProperty SubtitleProperty =
        DependencyProperty.Register(
            nameof(Subtitle),
            typeof(string),
            typeof(LazyChicken4),
            new PropertyMetadata("Enter details below."));

    public string Subtitle
    {
        get => (string)GetValue(SubtitleProperty);
        set => SetValue(SubtitleProperty, value);
    }

    public static readonly DependencyProperty LoginCommandProperty =
        DependencyProperty.Register(
            nameof(LoginCommand),
            typeof(ICommand),
            typeof(LazyChicken4),
            new PropertyMetadata(null));

    public ICommand? LoginCommand
    {
        get => (ICommand?)GetValue(LoginCommandProperty);
        set => SetValue(LoginCommandProperty, value);
    }

    public static readonly DependencyProperty ForgotPasswordCommandProperty =
        DependencyProperty.Register(
            nameof(ForgotPasswordCommand),
            typeof(ICommand),
            typeof(LazyChicken4),
            new PropertyMetadata(null));

    public ICommand? ForgotPasswordCommand
    {
        get => (ICommand?)GetValue(ForgotPasswordCommandProperty);
        set => SetValue(ForgotPasswordCommandProperty, value);
    }

    public static readonly DependencyProperty SignUpCommandProperty =
        DependencyProperty.Register(
            nameof(SignUpCommand),
            typeof(ICommand),
            typeof(LazyChicken4),
            new PropertyMetadata(null));

    public ICommand? SignUpCommand
    {
        get => (ICommand?)GetValue(SignUpCommandProperty);
        set => SetValue(SignUpCommandProperty, value);
    }

    public static readonly RoutedEvent LoginClickedEvent =
        EventManager.RegisterRoutedEvent(
            nameof(LoginClicked),
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(LazyChicken4));

    public event RoutedEventHandler LoginClicked
    {
        add => AddHandler(LoginClickedEvent, value);
        remove => RemoveHandler(LoginClickedEvent, value);
    }

    public static readonly RoutedEvent ForgotPasswordClickedEvent =
        EventManager.RegisterRoutedEvent(
            nameof(ForgotPasswordClicked),
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(LazyChicken4));

    public event RoutedEventHandler ForgotPasswordClicked
    {
        add => AddHandler(ForgotPasswordClickedEvent, value);
        remove => RemoveHandler(ForgotPasswordClickedEvent, value);
    }

    public static readonly RoutedEvent SignUpClickedEvent =
        EventManager.RegisterRoutedEvent(
            nameof(SignUpClicked),
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(LazyChicken4));

    public event RoutedEventHandler SignUpClicked
    {
        add => AddHandler(SignUpClickedEvent, value);
        remove => RemoveHandler(SignUpClickedEvent, value);
    }

    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();

        if (GetTemplateChild("PART_LoginButton") is Button loginButton)
        {
            loginButton.Click += (s, e) =>
            {
                RaiseEvent(new RoutedEventArgs(LoginClickedEvent, this));
                LoginCommand?.Execute(null);
            };
        }

        if (GetTemplateChild("PART_ForgotPasswordLink") is Button forgotPasswordLink)
        {
            forgotPasswordLink.Click += (s, e) =>
            {
                RaiseEvent(new RoutedEventArgs(ForgotPasswordClickedEvent, this));
                ForgotPasswordCommand?.Execute(null);
            };
        }

        if (GetTemplateChild("PART_SignUpLink") is Button signUpLink)
        {
            signUpLink.Click += (s, e) =>
            {
                RaiseEvent(new RoutedEventArgs(SignUpClickedEvent, this));
                SignUpCommand?.Execute(null);
            };
        }
    }
}
