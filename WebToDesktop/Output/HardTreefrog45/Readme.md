# HardTreefrog45

Facebook 스타일 회원가입 폼 (Sign Up Form) 컨트롤

## 원본 정보

- **원작자**: themrsami
- **원본 링크**: [https://uiverse.io/themrsami/hard-treefrog-45](https://uiverse.io/themrsami/hard-treefrog-45) (클릭 시 원본 CSS/HTML 확인 가능)
- **카테고리**: Forms

## 빌드 명령

### WPF
```bash
cd Wpf && dotnet run --project HardTreefrog45.Wpf.Gallery
```

### AvaloniaUI
```bash
cd AvaloniaUI && dotnet run --project HardTreefrog45.Avalonia.Gallery
```

## 주요 기능

- 이름 입력 (First name, Surname)
- 이메일/전화번호 입력
- 비밀번호 입력
- 생년월일 선택 (Day, Month, Year)
- 성별 선택 (Female, Male, Custom)
- Sign Up 버튼
- 닫기 버튼

## 바인딩 가능한 속성

| 속성 | 타입 | 설명 |
|------|------|------|
| `Title` | `string` | 폼 제목 (기본값: "Sign Up") |
| `Subtitle` | `string` | 부제목 (기본값: "It's quick and easy.") |
| `FirstName` | `string` | 이름 |
| `Surname` | `string` | 성 |
| `EmailOrPhone` | `string` | 이메일 또는 전화번호 |
| `Password` | `string` | 비밀번호 |
| `SelectedDay` | `int` | 선택된 일 (1-31) |
| `SelectedMonth` | `int` | 선택된 월 (1-12) |
| `SelectedYear` | `int` | 선택된 연도 (1990-2023) |
| `SelectedGender` | `string` | 선택된 성별 |
| `SignUpCommand` | `ICommand` | Sign Up 버튼 클릭 커맨드 |
| `CloseCommand` | `ICommand` | 닫기 버튼 클릭 커맨드 |

## CSS → WPF 변환 매핑 테이블

| CSS / Tailwind | WPF 구현 |
|----------------|----------|
| `max-w-[432px]` | `MaxWidth="432"` |
| `bg-white` | `Background="#FFFFFF"` |
| `rounded-md` | `CornerRadius="6"` |
| `shadow-lg drop-shadow-md` | `DropShadowEffect BlurRadius="15"` |
| `px-4 py-3` | `Padding="16,12,16,12"` |
| `font-bold` | `FontWeight="Bold"` |
| `text-gray-500` | `Foreground="#6B7280"` (Tailwind gray-500) |
| `text-gray-600` | `Foreground="#4B5563"` (Tailwind gray-600) |
| `ring-1 ring-gray-400` | `BorderThickness="1" BorderBrush="#9CA3AF"` |
| `bg-gray-100` | `Background="#F3F4F6"` |
| `flex space-x-3` | `Grid` with `ColumnDefinitions` + `Gap=12` |
| `flex-1` | `ColumnDefinition Width="*"` |
| `text-center` | `HorizontalAlignment="Center"` |
| `hover:` pseudo-class | `Trigger Property="IsMouseOver"` |
| SVG `<path>` | WPF `Path Data="..."` |

## 프로젝트 구조

```
HardTreefrog45/
├── Wpf/
│   ├── HardTreefrog45.Wpf.slnx
│   ├── HardTreefrog45.Wpf.Gallery/    # 데모 애플리케이션
│   └── HardTreefrog45.Wpf.UI/         # 커스텀 컨트롤 라이브러리
│       ├── Controls/
│       │   ├── HardTreefrog45.cs      # 컨트롤 클래스
│       │   └── Converters.cs          # 날짜 인덱스 변환 Converter
│       └── Themes/
│           ├── Generic.xaml           # ResourceDictionary 병합
│           ├── HardTreefrog45.xaml    # 스타일 및 ControlTemplate
│           └── HardTreefrog45Resources.xaml  # 테마 리소스
└── AvaloniaUI/                        # (미구현)
```
