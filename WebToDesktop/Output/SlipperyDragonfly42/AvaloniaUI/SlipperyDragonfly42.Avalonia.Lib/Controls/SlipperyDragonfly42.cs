using Avalonia;
using Avalonia.Controls.Primitives;

namespace SlipperyDragonfly42.Avalonia.Lib.Controls;

/// <summary>
/// 로그인 폼 커스텀 컨트롤 - Tailwind CSS 스타일 기반
/// Login form custom control - Based on Tailwind CSS style
/// </summary>
public sealed class SlipperyDragonfly42 : TemplatedControl
{
    /// <summary>
    /// 이메일 입력값
    /// Email input value
    /// </summary>
    public static readonly StyledProperty<string> EmailProperty =
        AvaloniaProperty.Register<SlipperyDragonfly42, string>(nameof(Email), string.Empty);

    public string Email
    {
        get => GetValue(EmailProperty);
        set => SetValue(EmailProperty, value);
    }

    /// <summary>
    /// 비밀번호 입력값
    /// Password input value
    /// </summary>
    public static readonly StyledProperty<string> PasswordProperty =
        AvaloniaProperty.Register<SlipperyDragonfly42, string>(nameof(Password), string.Empty);

    public string Password
    {
        get => GetValue(PasswordProperty);
        set => SetValue(PasswordProperty, value);
    }

    /// <summary>
    /// Remember Me 체크 여부
    /// Whether Remember Me is checked
    /// </summary>
    public static readonly StyledProperty<bool> RememberMeProperty =
        AvaloniaProperty.Register<SlipperyDragonfly42, bool>(nameof(RememberMe), false);

    public bool RememberMe
    {
        get => GetValue(RememberMeProperty);
        set => SetValue(RememberMeProperty, value);
    }

    /// <summary>
    /// 제목 텍스트
    /// Title text
    /// </summary>
    public static readonly StyledProperty<string> TitleProperty =
        AvaloniaProperty.Register<SlipperyDragonfly42, string>(nameof(Title), "Welcome Back");

    public string Title
    {
        get => GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    /// <summary>
    /// 부제목 텍스트
    /// Subtitle text
    /// </summary>
    public static readonly StyledProperty<string> SubtitleProperty =
        AvaloniaProperty.Register<SlipperyDragonfly42, string>(nameof(Subtitle), "Sign in to continue");

    public string Subtitle
    {
        get => GetValue(SubtitleProperty);
        set => SetValue(SubtitleProperty, value);
    }
}
