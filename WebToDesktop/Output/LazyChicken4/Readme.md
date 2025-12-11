# LazyChicken4

Forms 스타일 컨트롤 - 심플한 로그인 폼

## 원본 정보

- **원작자**: LeryLey
- **원본 링크**: [https://uiverse.io/LeryLey/lazy-chicken-4](https://uiverse.io/LeryLey/lazy-chicken-4) (클릭 시 원본 CSS/HTML 확인 가능)
- **카테고리**: Forms

## 빌드 명령

### WPF
```bash
cd Wpf && dotnet run --project LazyChicken4.Wpf.Gallery
```

### AvaloniaUI
```bash
cd AvaloniaUI && dotnet run --project LazyChicken4.Avalonia.Gallery
```

## 컨트롤 기능

- Username/Password 입력 필드
- Remember me 체크박스
- Login 버튼
- Forgot Password/Sign Up 링크
- ICommand 지원 (MVVM 패턴)
- RoutedEvent 지원

## DependencyProperty

| Property | Type | Description |
|----------|------|-------------|
| `Username` | `string` | 사용자 이름 (양방향 바인딩) |
| `Password` | `string` | 비밀번호 (양방향 바인딩) |
| `RememberMe` | `bool` | Remember me 체크 상태 |
| `Title` | `string` | 로그인 폼 제목 (기본값: "Login") |
| `Subtitle` | `string` | 부제목 (기본값: "Enter details below.") |
| `LoginCommand` | `ICommand` | 로그인 버튼 클릭 시 실행할 커맨드 |
| `ForgotPasswordCommand` | `ICommand` | Forgot Password 클릭 시 실행할 커맨드 |
| `SignUpCommand` | `ICommand` | Sign Up 클릭 시 실행할 커맨드 |

## RoutedEvent

| Event | Description |
|-------|-------------|
| `LoginClicked` | 로그인 버튼 클릭 시 발생 |
| `ForgotPasswordClicked` | Forgot Password 링크 클릭 시 발생 |
| `SignUpClicked` | Sign Up 링크 클릭 시 발생 |

## CSS -> WPF 변환 매핑 테이블

| Tailwind CSS | WPF 구현 | 설명 |
|--------------|----------|------|
| `w-80` | `Width="320"` | 20rem = 320px |
| `rounded-lg` | `CornerRadius="8"` | 0.5rem = 8px |
| `rounded-md` | `CornerRadius="6"` | 0.375rem = 6px |
| `shadow` | `DropShadowEffect` | 그림자 효과 |
| `p-6` | `Padding="24"` | 1.5rem = 24px |
| `space-y-2` | `Margin="0,0,0,8"` | 0.5rem = 8px |
| `space-y-3` | `Margin="0,0,0,12"` | 0.75rem = 12px |
| `mt-4` | `Margin="0,16,0,0"` | 1rem = 16px |
| `px-2 py-1` | `Padding="8,4,8,4"` | padding 변환 |
| `text-2xl` | `FontSize="24"` | 1.5rem = 24px |
| `text-slate-700` | `Color="#334155"` | 슬레이트 700 |
| `text-slate-500` | `Color="#64748B"` | 슬레이트 500 |
| `bg-white` | `Background="White"` | 흰색 배경 |
| `bg-blue-500` | `Color="#3B82F6"` | 블루 500 |
| `hover:bg-blue-600` | `Trigger IsMouseOver` | 블루 600 (#2563EB) |
| `active:bg-blue-700` | `Trigger IsPressed` | 블루 700 (#1D4ED8) |
| `focus:border-blue-300` | `Trigger IsFocused` | 블루 300 (#93C5FD) |
| `border-2` | `BorderThickness="2"` | 2px 테두리 |
| `ring-2` | `BorderBrush` | 링 효과를 테두리로 구현 |
| `font-medium` | `FontWeight="Medium"` | 중간 굵기 |
| `hover:underline` | `TextDecorations="Underline"` | 마우스오버 시 밑줄 |

## 파일 구조

```
LazyChicken4/
├── Readme.md
└── Wpf/
    ├── LazyChicken4.Wpf.slnx
    ├── LazyChicken4.Wpf.Gallery/
    │   ├── App.xaml
    │   ├── MainWindow.xaml
    │   └── ...
    └── LazyChicken4.Wpf.UI/
        ├── Controls/
        │   └── LazyChicken4.cs
        └── Themes/
            ├── Generic.xaml
            ├── LazyChicken4.xaml
            └── LazyChicken4Resources.xaml
```
