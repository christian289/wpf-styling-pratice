# NastyMoth15

Toggle-switches 스타일 컨트롤 - 스파클 애니메이션 효과가 있는 토글 스위치

## 원본 정보

- **원작자:** MuhammadHasann
- **원본 링크:** [https://uiverse.io/MuhammadHasann/nasty-moth-15](https://uiverse.io/MuhammadHasann/nasty-moth-15)

## 빌드 및 실행

### WPF
```bash
cd Wpf && dotnet run --project NastyMoth15.Wpf.Gallery
```

### AvaloniaUI
```bash
cd AvaloniaUI && dotnet run --project NastyMoth15.Avalonia.Gallery
```

## CSS → WPF 변환 매핑 테이블

| CSS | WPF |
|-----|-----|
| `--primary: #54a8fc` | `<Color x:Key="NastyMoth15.Color.Primary">#54A8FC</Color>` |
| `--light: #d9d9d9` | `<Color x:Key="NastyMoth15.Color.Light">#D9D9D9</Color>` |
| `--dark: #121212` | `<Color x:Key="NastyMoth15.Color.Dark">#121212</Color>` |
| `--gray: #414344` | `<Color x:Key="NastyMoth15.Color.Gray">#414344</Color>` |
| `border-radius: 9999px` | `CornerRadius="25"` |
| `radial-gradient(circle at 50% 0%, ...)` | `<RadialGradientBrush GradientOrigin="0.5,0" Center="0.5,0">` |
| `box-shadow: inset ...` | 별도의 Border 레이어로 구현 |
| `transition: all 0.3s ease-in-out` | `<DoubleAnimation Duration="0:0:0.3"><CubicEase EasingMode="EaseInOut"/></DoubleAnimation>` |
| `transform: translateX(...) rotate(-225deg)` | `<TransformGroup><TranslateTransform/><RotateTransform/></TransformGroup>` |
| `@keyframes sparkle` | `<Storyboard RepeatBehavior="Forever">` + `<DoubleAnimation>` |
| `overflow: clip` | `ClipToBounds="True"` |
| `::before`, `::after` pseudo-elements | 별도의 `Border` 요소로 구현 |
| SVG `<path>` | `<Geometry x:Key="...">` + `<Path Data="{StaticResource ...}">` |
| `aspect-ratio: 1` | Width와 Height 동일하게 설정 |
| CSS 변수 `var(--name)` | `{StaticResource NastyMoth15.Name}` |

## 프로젝트 구조

```
NastyMoth15/
├── Wpf/
│   ├── NastyMoth15.Wpf.slnx
│   ├── NastyMoth15.Wpf.Gallery/     # 데모 앱
│   └── NastyMoth15.Wpf.UI/          # 커스텀 컨트롤 라이브러리
│       ├── Controls/
│       │   └── NastyMoth15.cs
│       └── Themes/
│           ├── Generic.xaml
│           ├── NastyMoth15.xaml
│           └── NastyMoth15Resources.xaml
└── AvaloniaUI/                       # (미구현)
```

## 기능

- 클릭 시 토글 상태 전환
- 체크 시 노브가 오른쪽으로 이동하며 -225도 회전
- 스파클(반짝이) 애니메이션 효과
- RadialGradient 배경으로 글로우 효과 표현
- 깃발 아이콘 (SVG → Path 변환)
