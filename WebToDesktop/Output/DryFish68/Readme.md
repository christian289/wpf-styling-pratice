# DryFish68

Buttons 스타일 컨트롤 - hover 시 배경이 아래에서 위로 사라지는 Download CV 버튼

## 원본 정보

- **원작자**: Codecite
- **원본 링크**: [https://uiverse.io/Codecite/dry-fish-68](https://uiverse.io/Codecite/dry-fish-68) (클릭 시 원본 CSS/HTML 확인 가능)

## 빌드 명령

### WPF
```bash
cd Wpf && dotnet run --project DryFish68.Wpf.Gallery
```

### AvaloniaUI
```bash
cd AvaloniaUI && dotnet run --project DryFish68.Avalonia.Gallery
```

## CSS → WPF 변환 매핑

| CSS | WPF |
|-----|-----|
| `border-radius: 50px` | `CornerRadius="50"` |
| `border: 2px solid #ed553b` | `BorderThickness="2"`, `BorderBrush="{StaticResource ...}"` |
| `padding: 14px 40px 13px` | `Padding="40,14,40,13"` (WPF는 Left,Top,Right,Bottom 순서) |
| `overflow: hidden` | `ClipToBounds="True"` |
| `color: #fff` | `Foreground="{StaticResource ...}"` |
| `font-weight: 600` | `FontWeight="SemiBold"` |
| `::before` pseudo-element | `Rectangle` 요소로 구현 |
| `transition: all .3s ease` | `DoubleAnimation Duration="0:0:0.3"` + `CubicEase` |
| `height: 111% -> 11%` | `TranslateTransform Y` 애니메이션 |
| `z-index` | XAML 선언 순서 (먼저 선언된 요소가 뒤에 배치됨) |
| `:hover` | `Trigger Property="IsMouseOver"` |

## 프로젝트 구조

```
DryFish68/
├── Wpf/
│   ├── DryFish68.Wpf.slnx
│   ├── DryFish68.Wpf.Gallery/     # 데모 앱
│   └── DryFish68.Wpf.UI/          # CustomControl 라이브러리
│       ├── Controls/
│       │   └── DryFish68.cs
│       └── Themes/
│           ├── Generic.xaml
│           ├── DryFish68.xaml
│           └── DryFish68Resources.xaml
└── AvaloniaUI/                    # (미구현)
```
