# WiseCrab44

Forms 스타일 컨트롤 - 업로드 버튼, 텍스트 입력, 전송 버튼이 있는 모던 폼 입력 컨트롤

## 원본 정보

- **원작자**: RashadGhzi
- **원본 링크**: [https://uiverse.io/RashadGhzi/wise-crab-44](https://uiverse.io/RashadGhzi/wise-crab-44)
- **태그**: simple, form, input, modern

## 빌드 명령

### WPF

```bash
cd Wpf && dotnet run --project WiseCrab44.Wpf.Gallery
```

### AvaloniaUI

```bash
cd AvaloniaUI && dotnet run --project WiseCrab44.Avalonia.Gallery
```

## 컨트롤 사용법

```xml
<controls:WiseCrab44 Placeholder="Enter your prompt..."
                     Text="{Binding InputText}"
                     UploadCommand="{Binding UploadCommand}"
                     SubmitCommand="{Binding SubmitCommand}"/>
```

### 속성

| 속성 | 타입 | 설명 |
|-----|------|------|
| `Text` | `string` | 텍스트 입력 값 (양방향 바인딩) |
| `Placeholder` | `string` | 플레이스홀더 텍스트 (기본값: "Enter your prompt...") |
| `UploadCommand` | `ICommand` | 업로드 버튼 클릭 커맨드 |
| `SubmitCommand` | `ICommand` | 전송 버튼 클릭 커맨드 |

## CSS → WPF 변환 매핑 테이블

| CSS / Tailwind | WPF 변환 |
|----------------|---------|
| `bg-white` | `SolidColorBrush Color="#FFFFFF"` |
| `border-gray-300` | `SolidColorBrush Color="#D1D5DB"` |
| `text-gray-600` | `SolidColorBrush Color="#4B5563"` |
| `hover:bg-gray-100` | `Trigger IsMouseOver` → `Background="#F3F4F6"` |
| `rounded-md` | `CornerRadius="6"` |
| `p-6` (1.5rem) | `Padding="24"` |
| `p-2` (0.5rem) | `Padding="8"` |
| `shadow-md` | `DropShadowEffect BlurRadius="8" ShadowDepth="2"` |
| `flex-grow` | `Grid ColumnDefinition Width="*"` |
| `h-6 w-6` | `Width="24" Height="24"` |
| `border` | `BorderThickness="1"` |
| `focus:outline-none` | WPF 기본 동작 |
| SVG `stroke` | `Path.Stroke` |
| SVG `stroke-width` | `Path.StrokeThickness` |
| SVG `stroke-linejoin="round"` | `Path.StrokeLineJoin="Round"` |
| SVG `stroke-linecap="round"` | `Path.StrokeStartLineCap/EndLineCap="Round"` |

## 프로젝트 구조

```
WiseCrab44/
├── Readme.md
├── Wpf/
│   ├── WiseCrab44.Wpf.slnx
│   ├── WiseCrab44.Wpf.Gallery/
│   │   ├── App.xaml
│   │   ├── MainWindow.xaml
│   │   └── ...
│   └── WiseCrab44.Wpf.UI/
│       ├── Controls/
│       │   └── WiseCrab44.cs
│       ├── Themes/
│       │   ├── Generic.xaml
│       │   ├── WiseCrab44.xaml
│       │   └── WiseCrab44Resources.xaml
│       └── Properties/
│           └── AssemblyInfo.cs
└── AvaloniaUI/
    └── (미구현)
```
