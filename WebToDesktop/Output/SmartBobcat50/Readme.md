# SmartBobcat50

Checkboxes 스타일 컨트롤 - 하트 모양의 Like/Unlike 체크박스

## 원본 정보
- **원작자**: KSAplay
- **원본 링크**: [https://uiverse.io/KSAplay/smart-bobcat-50](https://uiverse.io/KSAplay/smart-bobcat-50)

## 빌드 및 실행

### WPF
```bash
cd Wpf && dotnet run --project SmartBobcat50.Wpf.Gallery
```

### AvaloniaUI
```bash
cd AvaloniaUI && dotnet run --project SmartBobcat50.Avalonia.Gallery
```

## 기능
- 클릭 시 Like/Unlike 토글
- Hover 시 1.1배 확대 애니메이션
- 상태 변경 시 Bounce 애니메이션 (0 → 1.2 → 1)
- Checked 상태: 빨간색 하트 (fill)
- Unchecked 상태: 흰색 테두리 하트 (stroke only)

## CSS → WPF 변환 매핑

| CSS 속성 | WPF 구현 |
|---------|---------|
| `transform: scale()` | `ScaleTransform` + `DoubleAnimationUsingKeyFrames` |
| `animation: 400ms ease` | `Duration="0:0:0.4"` + `QuadraticEase` |
| `cursor: pointer` | `Cursor="Hand"` |
| SVG `viewBox="0 0 256 256"` | `Canvas Width="256" Height="256"` + `Viewbox` |
| SVG `path d=` | `Path Data=` (Geometry) |
| `fill: #FF5353` | `SolidColorBrush Color="#FF5353"` |
| `stroke: #FFF` | `Path.Stroke` |
| `stroke-width: 20px` | `Path.StrokeThickness="20"` |
| `:hover { scale(1.1) }` | `Trigger Property="IsMouseOver"` |
| `input:checked` | `Trigger Property="IsChecked"` |
| `@keyframes like_effect` | `Storyboard` + `EasingDoubleKeyFrame` |
| `font-size: 20px` + `height: 2em` | `Width="40"` `Height="40"` |

## 프로젝트 구조

```
SmartBobcat50/
├── Readme.md
├── Wpf/
│   ├── SmartBobcat50.Wpf.slnx
│   ├── SmartBobcat50.Wpf.Gallery/    # 데모 앱
│   │   ├── App.xaml
│   │   ├── MainWindow.xaml
│   │   └── ...
│   └── SmartBobcat50.Wpf.UI/         # 컨트롤 라이브러리
│       ├── Controls/
│       │   └── SmartBobcat50.cs
│       └── Themes/
│           ├── Generic.xaml
│           ├── SmartBobcat50.xaml
│           └── SmartBobcat50Resources.xaml
└── AvaloniaUI/                       # (미구현)
```
