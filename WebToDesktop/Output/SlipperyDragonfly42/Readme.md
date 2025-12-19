# SlipperyDragonfly42

Forms 스타일 컨트롤 - 다크 테마 로그인 폼

## 원본 정보

- **원작자**: iZOXVL
- **원본 링크**: [https://uiverse.io/iZOXVL/slippery-dragonfly-42](https://uiverse.io/iZOXVL/slippery-dragonfly-42)

## 미리보기

![Preview](https://uiverse.io/api/html/render/iZOXVL/slippery-dragonfly-42)

## 빌드 명령

### WPF

```bash
cd Wpf && dotnet run --project SlipperyDragonfly42.Wpf.Gallery
```

### AvaloniaUI

```bash
cd AvaloniaUI && dotnet run --project SlipperyDragonfly42.Avalonia.Gallery
```

## 기능

- 다크 테마 로그인 폼
- Email 입력 필드
- Password 입력 필드
- Remember me 체크박스
- Forgot password 링크
- Sign In 버튼
- Sign up 링크

## 사용법

### XAML

```xml
<controls:SlipperyDragonfly42
    Title="Welcome Back"
    Subtitle="Sign in to continue"
    EmailPlaceholder="Email address"
    PasswordPlaceholder="Password"
    SignInButtonText="Sign In"
    SignInCommand="{Binding SignInCommand}"
    ForgotPasswordCommand="{Binding ForgotPasswordCommand}"
    SignUpCommand="{Binding SignUpCommand}"
    Email="{Binding Email, Mode=TwoWay}"
    RememberMe="{Binding RememberMe, Mode=TwoWay}"/>
```

### 속성 (Properties)

| 속성 | 타입 | 기본값 | 설명 |
|------|------|--------|------|
| `Title` | string | "Welcome Back" | 제목 |
| `Subtitle` | string | "Sign in to continue" | 부제목 |
| `Email` | string | "" | 이메일 (양방향 바인딩) |
| `Password` | string | "" | 비밀번호 (양방향 바인딩) |
| `RememberMe` | bool | false | 로그인 유지 (양방향 바인딩) |
| `EmailPlaceholder` | string | "Email address" | 이메일 플레이스홀더 |
| `PasswordPlaceholder` | string | "Password" | 비밀번호 플레이스홀더 |
| `SignInButtonText` | string | "Sign In" | 로그인 버튼 텍스트 |
| `SignInCommand` | ICommand | null | 로그인 버튼 클릭 커맨드 |
| `ForgotPasswordCommand` | ICommand | null | 비밀번호 찾기 클릭 커맨드 |
| `SignUpCommand` | ICommand | null | 회원가입 클릭 커맨드 |

## CSS → WPF 변환 매핑

| CSS (Tailwind) | 값 | WPF |
|----------------|-----|-----|
| `bg-gray-800` | `#1f2937` | `SolidColorBrush` (Card Background) |
| `bg-gray-700` | `#374151` | `SolidColorBrush` (Input Background) |
| `text-white` | `#ffffff` | `SolidColorBrush` (Title) |
| `text-gray-400` | `#9ca3af` | `SolidColorBrush` (Subtitle, Labels) |
| `bg-indigo-500` | `#6366f1` | `SolidColorBrush` (Button Background) |
| `hover:bg-indigo-600` | `#4f46e5` | `Trigger` (Button Hover) |
| `text-indigo-500` | `#6366f1` | `SolidColorBrush` (Links) |
| `hover:text-indigo-400` | `#818cf8` | `Trigger` (Link Hover) |
| `rounded-lg` | `8px` | `CornerRadius` |
| `rounded-md` | `6px` | `CornerRadius` |
| `box-shadow` | 복합 | `DropShadowEffect` |
| `focus:ring-indigo-500` | `#6366f1` | `Trigger` (Input Focus Border) |
| `p-8` | `32px` | `Padding/Margin` |
| `py-3 px-4` | `12px, 16px` | `Padding` |
