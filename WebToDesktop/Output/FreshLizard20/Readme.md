# FreshLizard20

loaders 스타일 컨트롤 - 로딩 텍스트와 함께 단어들이 세로로 순환 애니메이션되는 로더

## 원본 정보

- **원작자**: kennyotsu
- **원본 링크**: [https://uiverse.io/kennyotsu/fresh-lizard-20](https://uiverse.io/kennyotsu/fresh-lizard-20) (클릭 시 원본 CSS/HTML 확인 가능)

## 빌드 명령

### WPF

```bash
cd Wpf && dotnet run --project FreshLizard20.Wpf.Gallery
```

### AvaloniaUI

```bash
cd AvaloniaUI && dotnet run --project FreshLizard20.Avalonia.Gallery
```

## CSS → WPF 변환 매핑 테이블

| CSS | WPF |
|-----|-----|
| `--bg-color: #212121` | `SolidColorBrush` 리소스 |
| `background-color` | `Border.Background` |
| `border-radius: 1.25rem` | `CornerRadius="20"` |
| `padding: 1rem 2rem` | `Padding="32,16,32,16"` |
| `display: flex` | `StackPanel Orientation="Horizontal"` |
| `font-family: "Poppins"` | `FontFamily="Segoe UI, Poppins"` |
| `font-size: 25px` | `FontSize="25"` |
| `font-weight: 500` | `FontWeight="Medium"` |
| `color: rgb(124,124,124)` | `Foreground="#7C7C7C"` |
| `color: #956afa` | `Foreground="#956AFA"` |
| `overflow: hidden` | `Grid.Clip` + `RectangleGeometry` |
| `position: relative` | `Grid` 컨테이너 |
| `::after` pseudo-element | 별도 `Border` 오버레이 |
| `linear-gradient` (fade) | `LinearGradientBrush` |
| `z-index: 20` | XAML 선언 순서 (나중에 선언 = 위에 표시) |
| `@keyframes spin_4991` | `Storyboard` + `DoubleAnimationUsingKeyFrames` |
| `animation: 4s infinite` | `Storyboard RepeatBehavior="Forever"` |
| `transform: translateY(-100%)` | `TranslateTransform.Y="-40"` |

## 프로젝트 구조

```
FreshLizard20/
├── Readme.md
├── Wpf/
│   ├── FreshLizard20.Wpf.slnx
│   ├── FreshLizard20.Wpf.Gallery/     # 데모 앱
│   │   ├── App.xaml
│   │   └── MainWindow.xaml
│   └── FreshLizard20.Wpf.UI/          # 커스텀 컨트롤 라이브러리
│       ├── Controls/
│       │   └── FreshLizard20.cs
│       └── Themes/
│           ├── Generic.xaml
│           ├── FreshLizard20.xaml
│           └── FreshLizard20Resources.xaml
└── AvaloniaUI/                        # (미구현)
```

## 사용 예시

```xml
<Window xmlns:controls="clr-namespace:FreshLizard20.Wpf.UI.Controls;assembly=FreshLizard20.Wpf.UI">
    <controls:FreshLizard20 />
</Window>
```

### 커스텀 단어 설정

```xml
<controls:FreshLizard20 LoadingText="fetching">
    <controls:FreshLizard20.Words>
        <collections:ObservableCollection x:TypeArguments="sys:String">
            <sys:String>data</sys:String>
            <sys:String>users</sys:String>
            <sys:String>settings</sys:String>
            <sys:String>data</sys:String>
        </collections:ObservableCollection>
    </controls:FreshLizard20.Words>
</controls:FreshLizard20>
```
