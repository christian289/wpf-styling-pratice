using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace RareCobra61.Wpf.UI.Controls;

/// <summary>
/// 로그인 폼 컨트롤
/// Login form control
/// </summary>
public sealed class RareCobra61 : Control
{
    static RareCobra61()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(RareCobra61),
            new FrameworkPropertyMetadata(typeof(RareCobra61)));
    }

    #region Dependency Properties

    /// <summary>
    /// 제목 텍스트
    /// Title text
    /// </summary>
    public static readonly DependencyProperty TitleProperty =
        DependencyProperty.Register(
            nameof(Title),
            typeof(string),
            typeof(RareCobra61),
            new PropertyMetadata("Welcome back"));

    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    /// <summary>
    /// 이메일 입력값
    /// Email input value
    /// </summary>
    public static readonly DependencyProperty EmailProperty =
        DependencyProperty.Register(
            nameof(Email),
            typeof(string),
            typeof(RareCobra61),
            new FrameworkPropertyMetadata(
                string.Empty,
                FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

    public string Email
    {
        get => (string)GetValue(EmailProperty);
        set => SetValue(EmailProperty, value);
    }

    /// <summary>
    /// 비밀번호 입력값
    /// Password input value
    /// </summary>
    public static readonly DependencyProperty PasswordProperty =
        DependencyProperty.Register(
            nameof(Password),
            typeof(string),
            typeof(RareCobra61),
            new FrameworkPropertyMetadata(
                string.Empty,
                FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

    public string Password
    {
        get => (string)GetValue(PasswordProperty);
        set => SetValue(PasswordProperty, value);
    }

    /// <summary>
    /// 이메일 플레이스홀더
    /// Email placeholder
    /// </summary>
    public static readonly DependencyProperty EmailPlaceholderProperty =
        DependencyProperty.Register(
            nameof(EmailPlaceholder),
            typeof(string),
            typeof(RareCobra61),
            new PropertyMetadata("Email"));

    public string EmailPlaceholder
    {
        get => (string)GetValue(EmailPlaceholderProperty);
        set => SetValue(EmailPlaceholderProperty, value);
    }

    /// <summary>
    /// 비밀번호 플레이스홀더
    /// Password placeholder
    /// </summary>
    public static readonly DependencyProperty PasswordPlaceholderProperty =
        DependencyProperty.Register(
            nameof(PasswordPlaceholder),
            typeof(string),
            typeof(RareCobra61),
            new PropertyMetadata("Password"));

    public string PasswordPlaceholder
    {
        get => (string)GetValue(PasswordPlaceholderProperty);
        set => SetValue(PasswordPlaceholderProperty, value);
    }

    /// <summary>
    /// 비밀번호 찾기 텍스트
    /// Forgot password text
    /// </summary>
    public static readonly DependencyProperty ForgotPasswordTextProperty =
        DependencyProperty.Register(
            nameof(ForgotPasswordText),
            typeof(string),
            typeof(RareCobra61),
            new PropertyMetadata("Forgot Password?"));

    public string ForgotPasswordText
    {
        get => (string)GetValue(ForgotPasswordTextProperty);
        set => SetValue(ForgotPasswordTextProperty, value);
    }

    /// <summary>
    /// 로그인 버튼 텍스트
    /// Login button text
    /// </summary>
    public static readonly DependencyProperty LoginButtonTextProperty =
        DependencyProperty.Register(
            nameof(LoginButtonText),
            typeof(string),
            typeof(RareCobra61),
            new PropertyMetadata("Log in"));

    public string LoginButtonText
    {
        get => (string)GetValue(LoginButtonTextProperty);
        set => SetValue(LoginButtonTextProperty, value);
    }

    /// <summary>
    /// 회원가입 안내 텍스트
    /// Sign up label text
    /// </summary>
    public static readonly DependencyProperty SignUpLabelTextProperty =
        DependencyProperty.Register(
            nameof(SignUpLabelText),
            typeof(string),
            typeof(RareCobra61),
            new PropertyMetadata("Don't have an account?"));

    public string SignUpLabelText
    {
        get => (string)GetValue(SignUpLabelTextProperty);
        set => SetValue(SignUpLabelTextProperty, value);
    }

    /// <summary>
    /// 회원가입 링크 텍스트
    /// Sign up link text
    /// </summary>
    public static readonly DependencyProperty SignUpLinkTextProperty =
        DependencyProperty.Register(
            nameof(SignUpLinkText),
            typeof(string),
            typeof(RareCobra61),
            new PropertyMetadata("Sign up"));

    public string SignUpLinkText
    {
        get => (string)GetValue(SignUpLinkTextProperty);
        set => SetValue(SignUpLinkTextProperty, value);
    }

    /// <summary>
    /// Apple 로그인 텍스트
    /// Apple login text
    /// </summary>
    public static readonly DependencyProperty AppleLoginTextProperty =
        DependencyProperty.Register(
            nameof(AppleLoginText),
            typeof(string),
            typeof(RareCobra61),
            new PropertyMetadata("Log in with Apple"));

    public string AppleLoginText
    {
        get => (string)GetValue(AppleLoginTextProperty);
        set => SetValue(AppleLoginTextProperty, value);
    }

    /// <summary>
    /// Google 로그인 텍스트
    /// Google login text
    /// </summary>
    public static readonly DependencyProperty GoogleLoginTextProperty =
        DependencyProperty.Register(
            nameof(GoogleLoginText),
            typeof(string),
            typeof(RareCobra61),
            new PropertyMetadata("Log in with Google"));

    public string GoogleLoginText
    {
        get => (string)GetValue(GoogleLoginTextProperty);
        set => SetValue(GoogleLoginTextProperty, value);
    }

    #endregion

    #region Routed Events

    /// <summary>
    /// 로그인 버튼 클릭 이벤트
    /// Login button click event
    /// </summary>
    public static readonly RoutedEvent LoginClickEvent =
        EventManager.RegisterRoutedEvent(
            nameof(LoginClick),
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(RareCobra61));

    public event RoutedEventHandler LoginClick
    {
        add => AddHandler(LoginClickEvent, value);
        remove => RemoveHandler(LoginClickEvent, value);
    }

    /// <summary>
    /// 비밀번호 찾기 클릭 이벤트
    /// Forgot password click event
    /// </summary>
    public static readonly RoutedEvent ForgotPasswordClickEvent =
        EventManager.RegisterRoutedEvent(
            nameof(ForgotPasswordClick),
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(RareCobra61));

    public event RoutedEventHandler ForgotPasswordClick
    {
        add => AddHandler(ForgotPasswordClickEvent, value);
        remove => RemoveHandler(ForgotPasswordClickEvent, value);
    }

    /// <summary>
    /// 회원가입 클릭 이벤트
    /// Sign up click event
    /// </summary>
    public static readonly RoutedEvent SignUpClickEvent =
        EventManager.RegisterRoutedEvent(
            nameof(SignUpClick),
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(RareCobra61));

    public event RoutedEventHandler SignUpClick
    {
        add => AddHandler(SignUpClickEvent, value);
        remove => RemoveHandler(SignUpClickEvent, value);
    }

    /// <summary>
    /// Apple 로그인 클릭 이벤트
    /// Apple login click event
    /// </summary>
    public static readonly RoutedEvent AppleLoginClickEvent =
        EventManager.RegisterRoutedEvent(
            nameof(AppleLoginClick),
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(RareCobra61));

    public event RoutedEventHandler AppleLoginClick
    {
        add => AddHandler(AppleLoginClickEvent, value);
        remove => RemoveHandler(AppleLoginClickEvent, value);
    }

    /// <summary>
    /// Google 로그인 클릭 이벤트
    /// Google login click event
    /// </summary>
    public static readonly RoutedEvent GoogleLoginClickEvent =
        EventManager.RegisterRoutedEvent(
            nameof(GoogleLoginClick),
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(RareCobra61));

    public event RoutedEventHandler GoogleLoginClick
    {
        add => AddHandler(GoogleLoginClickEvent, value);
        remove => RemoveHandler(GoogleLoginClickEvent, value);
    }

    #endregion

    #region Commands

    public static readonly DependencyProperty LoginCommandProperty =
        DependencyProperty.Register(
            nameof(LoginCommand),
            typeof(ICommand),
            typeof(RareCobra61));

    public ICommand? LoginCommand
    {
        get => (ICommand?)GetValue(LoginCommandProperty);
        set => SetValue(LoginCommandProperty, value);
    }

    public static readonly DependencyProperty ForgotPasswordCommandProperty =
        DependencyProperty.Register(
            nameof(ForgotPasswordCommand),
            typeof(ICommand),
            typeof(RareCobra61));

    public ICommand? ForgotPasswordCommand
    {
        get => (ICommand?)GetValue(ForgotPasswordCommandProperty);
        set => SetValue(ForgotPasswordCommandProperty, value);
    }

    public static readonly DependencyProperty SignUpCommandProperty =
        DependencyProperty.Register(
            nameof(SignUpCommand),
            typeof(ICommand),
            typeof(RareCobra61));

    public ICommand? SignUpCommand
    {
        get => (ICommand?)GetValue(SignUpCommandProperty);
        set => SetValue(SignUpCommandProperty, value);
    }

    public static readonly DependencyProperty AppleLoginCommandProperty =
        DependencyProperty.Register(
            nameof(AppleLoginCommand),
            typeof(ICommand),
            typeof(RareCobra61));

    public ICommand? AppleLoginCommand
    {
        get => (ICommand?)GetValue(AppleLoginCommandProperty);
        set => SetValue(AppleLoginCommandProperty, value);
    }

    public static readonly DependencyProperty GoogleLoginCommandProperty =
        DependencyProperty.Register(
            nameof(GoogleLoginCommand),
            typeof(ICommand),
            typeof(RareCobra61));

    public ICommand? GoogleLoginCommand
    {
        get => (ICommand?)GetValue(GoogleLoginCommandProperty);
        set => SetValue(GoogleLoginCommandProperty, value);
    }

    #endregion
}
