# RareCobra61

Forms 스타일 컨트롤 - 로그인 폼 UI 컴포넌트

## 원본 정보

- **원작자**: akshat-patel28
- **원본 링크**: [https://uiverse.io/akshat-patel28/rare-cobra-61](https://uiverse.io/akshat-patel28/rare-cobra-61) (클릭 시 원본 CSS/HTML 확인 가능)

## 빌드 명령

### WPF

```bash
cd Wpf && dotnet run --project RareCobra61.Wpf.Gallery
```

### AvaloniaUI

```bash
cd AvaloniaUI && dotnet run --project RareCobra61.Avalonia.Gallery
```

## 주요 기능

- 이메일/비밀번호 입력 필드
- "Forgot Password?" 링크
- 로그인 버튼
- 회원가입 링크
- Apple/Google 소셜 로그인 버튼

## CSS → WPF 변환 매핑 테이블

| CSS 속성/값 | WPF 구현 |
|------------|----------|
| `width: 350px; height: 500px` | `Width="350" Height="500"` |
| `background-color: #fff` | `SolidColorBrush Color="#FFFFFF"` |
| `box-shadow: rgba(0,0,0,0.35) 0px 5px 15px` | `DropShadowEffect BlurRadius="15" ShadowDepth="5" Opacity="0.35"` |
| `border-radius: 10px` | `CornerRadius="10"` |
| `padding: 20px 30px` | `Padding="30,20,30,20"` |
| `font-family: "Lucida Sans"...` | `FontFamily="Lucida Sans, ..."` |
| `border-radius: 20px` (input) | `CornerRadius="20"` in Border Template |
| `border: 1px solid #c0c0c0` | `BorderThickness="1" BorderBrush="#C0C0C0"` |
| `background: teal` | `SolidColorBrush Color="#008080"` |
| `cursor: pointer` | `Cursor="Hand"` |
| `display: flex; flex-direction: column` | `StackPanel` |
| `gap: 18px` | `Margin="0,0,0,18"` on each item |
| SVG path (Apple icon) | `Geometry` resource + `Path` element |
| SVG multi-color (Google icon) | `Canvas` with multiple `Path` elements |

## 프로젝트 구조

```
RareCobra61/
├── Readme.md
├── Wpf/
│   ├── RareCobra61.Wpf.slnx
│   ├── RareCobra61.Wpf.Gallery/
│   │   ├── App.xaml
│   │   ├── MainWindow.xaml
│   │   └── ...
│   └── RareCobra61.Wpf.UI/
│       ├── Controls/
│       │   ├── RareCobra61.cs
│       │   └── PasswordBoxHelper.cs
│       └── Themes/
│           ├── Generic.xaml
│           ├── RareCobra61.xaml
│           └── RareCobra61Resources.xaml
└── AvaloniaUI/
    └── (추후 추가 예정)
```

## Dependency Properties

| 속성명 | 타입 | 기본값 | 설명 |
|--------|------|--------|------|
| `Title` | `string` | "Welcome back" | 제목 텍스트 |
| `Email` | `string` | "" | 이메일 입력값 (Two-way) |
| `Password` | `string` | "" | 비밀번호 입력값 (Two-way) |
| `EmailPlaceholder` | `string` | "Email" | 이메일 플레이스홀더 |
| `PasswordPlaceholder` | `string` | "Password" | 비밀번호 플레이스홀더 |
| `ForgotPasswordText` | `string` | "Forgot Password?" | 비밀번호 찾기 링크 텍스트 |
| `LoginButtonText` | `string` | "Log in" | 로그인 버튼 텍스트 |
| `SignUpLabelText` | `string` | "Don't have an account?" | 회원가입 안내 텍스트 |
| `SignUpLinkText` | `string` | "Sign up" | 회원가입 링크 텍스트 |
| `AppleLoginText` | `string` | "Log in with Apple" | Apple 로그인 버튼 텍스트 |
| `GoogleLoginText` | `string` | "Log in with Google" | Google 로그인 버튼 텍스트 |

## Commands

- `LoginCommand` - 로그인 버튼 클릭
- `ForgotPasswordCommand` - 비밀번호 찾기 클릭
- `SignUpCommand` - 회원가입 클릭
- `AppleLoginCommand` - Apple 로그인 클릭
- `GoogleLoginCommand` - Google 로그인 클릭

## Routed Events

- `LoginClick`
- `ForgotPasswordClick`
- `SignUpClick`
- `AppleLoginClick`
- `GoogleLoginClick`
