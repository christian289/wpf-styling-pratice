# GrumpyWombat18

Checkboxes 스타일 컨트롤 - 모던한 토글 버튼으로, 클릭 시 아이콘과 텍스트가 전환되며 스케일 애니메이션이 적용됩니다.

## 원본 정보

- **원작자**: milegelu
- **원본 링크**: [https://uiverse.io/milegelu/grumpy-wombat-18](https://uiverse.io/milegelu/grumpy-wombat-18) (클릭 시 원본 CSS/HTML 확인 가능)
- **태그**: blue, black, button, active, checkbox, modern, click animation

## 빌드 명령

### WPF
```bash
cd Wpf && dotnet run --project GrumpyWombat18.Wpf.Gallery
```

### AvaloniaUI
```bash
cd AvaloniaUI && dotnet run --project GrumpyWombat18.Avalonia.Gallery
```

## 기능

- Unchecked 상태: 검정 배경 + Dribbble 아이콘 + "ball" 텍스트
- Checked 상태: 파란색 배경 + 게임패드 아이콘 + "Game" 텍스트
- Hover: 1.1배 스케일 확대 애니메이션
- Pressed: 0.95배 스케일 축소 + 둥근 모서리 강화

## CSS → WPF 변환 매핑

| CSS 속성 | CSS 값 | WPF 구현 |
|---------|--------|---------|
| `--UnChacked-color` | `hsl(0, 0%, 10%)` | `SolidColorBrush #1A1A1A` |
| `--chacked-color` | `hsl(216, 100%, 60%)` | `SolidColorBrush #3385FF` |
| `--font-color` | `white` | `SolidColorBrush White` |
| `--icon-size` | `1.5em` | `sys:Double 30` |
| `--anim-time` | `0.2s` | `Duration 0:0:0.2` |
| `--base-radius` | `0.8em` | `CornerRadius 16` |
| `transform: scale(1.1)` | hover | `ScaleTransform` + `DoubleAnimation` |
| `transform: scale(0.95)` | active | `ScaleTransform` + `DoubleAnimation` |
| `transition: all 0.2s` | - | `Storyboard` |
| `input:checked +` | - | `Trigger Property="IsChecked"` |
| `width: 0` / `display: none` | - | `Width="0"` + `Visibility` |

## 프로젝트 구조

```
GrumpyWombat18/
├── Wpf/
│   ├── GrumpyWombat18.Wpf.slnx
│   ├── GrumpyWombat18.Wpf.UI/
│   │   ├── Controls/
│   │   │   └── GrumpyWombat18.cs
│   │   └── Themes/
│   │       ├── Generic.xaml
│   │       ├── GrumpyWombat18.xaml
│   │       └── GrumpyWombat18Resources.xaml
│   └── GrumpyWombat18.Wpf.Gallery/
│       ├── App.xaml
│       └── MainWindow.xaml
└── AvaloniaUI/
    └── (미구현)
```
