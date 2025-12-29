# NewDog56

Buttons 스타일 컨트롤 - 그라데이션 호버 효과가 있는 Primary Button

## 원본 정보

- **원작자**: ArturCodeCraft
- **원본 링크**: [https://uiverse.io/ArturCodeCraft/new-dog-56](https://uiverse.io/ArturCodeCraft/new-dog-56)

## 빌드 및 실행

### WPF

```bash
cd Wpf && dotnet run --project NewDog56.Wpf.Gallery
```

### AvaloniaUI

```bash
cd AvaloniaUI && dotnet run --project NewDog56.Avalonia.Gallery
```

## CSS → WPF 변환 매핑 테이블

| CSS | WPF |
|-----|-----|
| `border-radius: 40px` | `CornerRadius="40"` |
| `background: #000` | `Background="{StaticResource NewDog56.Background.Normal.Brush}"` |
| `color: #fff` | `Foreground="{StaticResource NewDog56.Foreground.Normal.Brush}"` |
| `min-width: 111px` | `MinWidth="111"` |
| `height: 56px` | `Height="56"` |
| `padding: 16px 40px` | `Padding="40,16"` |
| `transition: 0.2s ease-in-out` | `<ColorAnimation Duration="0:0:0.2" />` |
| `::before` pseudo-element | 별도 `Border` 요소 (Grid 내 첫 번째) |
| `opacity: 0/1` transition | `<DoubleAnimation>` for `Opacity` |
| `linear-gradient(69deg, ...)` | `LinearGradientBrush` + `RotateTransform` |
| `:hover` | `<Trigger Property="IsMouseOver" Value="True">` |
| `z-index: -1` | Grid 내 요소 선언 순서 (먼저 선언된 요소가 뒤에 배치) |

## 프로젝트 구조

```
NewDog56/
├── Readme.md
├── Wpf/
│   ├── NewDog56.Wpf.slnx
│   ├── NewDog56.Wpf.Gallery/     # 데모 앱
│   └── NewDog56.Wpf.UI/          # CustomControl 라이브러리
│       ├── Controls/
│       │   └── NewDog56.cs
│       └── Themes/
│           ├── Generic.xaml
│           ├── NewDog56.xaml
│           └── NewDog56Resources.xaml
└── AvaloniaUI/                   # (미구현)
```
