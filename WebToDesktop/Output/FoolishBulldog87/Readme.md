# FoolishBulldog87

Checkboxes 스타일 컨트롤 - Crimson 테마 체크박스

## 원본 정보

- **원작자**: elijahgummer
- **원본 링크**: [https://uiverse.io/elijahgummer/foolish-bulldog-87](https://uiverse.io/elijahgummer/foolish-bulldog-87)

## 빌드 명령

### WPF
```bash
cd Wpf && dotnet run --project FoolishBulldog87.Wpf.Gallery
```

### AvaloniaUI
```bash
cd AvaloniaUI && dotnet run --project FoolishBulldog87.Avalonia.Gallery
```

## CSS → WPF 변환 매핑 테이블

| CSS | WPF | 설명 |
|-----|-----|------|
| `display: flex; align-items: center; justify-content: center` | `HorizontalAlignment="Center"` `VerticalAlignment="Center"` | 중앙 정렬 |
| `cursor: pointer` | `Cursor="Hand"` | 마우스 커서 |
| `border: 0.2rem solid #dc143c` | `BorderBrush="#DC143C"` `BorderThickness="3.2"` | 테두리 |
| `border-radius: 0.2rem` | `CornerRadius="3.2"` | 모서리 둥글기 |
| `background: #ff475425` (hover) | `SolidColorBrush Color="#25FF4754"` | hover 배경 (25% opacity) |
| `background: #dc143c` (checked) | `SolidColorBrush Color="#DC143C"` | checked 배경 |
| `stroke: #f9f9f9` | `Path.Stroke="#F9F9F9"` | 체크마크 색상 |
| `stroke-dasharray: 25` | `StrokeDashArray="7.8125 7.8125"` | 대시 패턴 |
| `stroke-dashoffset: 25` / `0` | `StrokeDashOffset="7.8125"` / `0` | 대시 오프셋 |
| `stroke-linecap: round` | `StrokeStartLineCap="Round"` `StrokeEndLineCap="Round"` | 선 끝 모양 |
| `stroke-width: 0.2rem` | `StrokeThickness="3.2"` | 선 두께 |
| `transition: stroke-dashoffset 0.6s` | `DoubleAnimation Duration="0:0:0.6"` | 애니메이션 |
| `transition: background 0.4s` | `Trigger.EnterActions/ExitActions` | 배경 전환 |
| SVG `polyline points="20 6 9 17 4 12"` | `StreamGeometry "M 20,6 L 9,17 L 4,12"` | 체크마크 경로 |

## 프로젝트 구조

```
FoolishBulldog87/
├── Readme.md
├── Wpf/
│   ├── FoolishBulldog87.Wpf.slnx
│   ├── FoolishBulldog87.Wpf.UI/
│   │   ├── Controls/
│   │   │   └── FoolishBulldog87.cs
│   │   └── Themes/
│   │       ├── Generic.xaml
│   │       ├── FoolishBulldog87.xaml
│   │       └── FoolishBulldog87Resources.xaml
│   └── FoolishBulldog87.Wpf.Gallery/
│       ├── App.xaml
│       └── MainWindow.xaml
└── AvaloniaUI/
    └── (미구현)
```

## 사용 방법

```xml
<Window xmlns:controls="clr-namespace:FoolishBulldog87.Wpf.UI.Controls;assembly=FoolishBulldog87.Wpf.UI">
    <controls:FoolishBulldog87 />
    <controls:FoolishBulldog87 IsChecked="True" />
</Window>
```
