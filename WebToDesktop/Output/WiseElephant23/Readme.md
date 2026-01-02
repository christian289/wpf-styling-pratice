# WiseElephant23

Checkboxes 스타일 컨트롤 - 원형 체크박스로, 체크 시 초록색 배경과 체크마크 애니메이션이 표시됩니다.

## 원본 정보

- **원작자**: martinval9
- **원본 링크**: [https://uiverse.io/martinval9/wise-elephant-23](https://uiverse.io/martinval9/wise-elephant-23)

## 빌드 및 실행

### WPF

```bash
cd Wpf && dotnet run --project WiseElephant23.Wpf.Gallery
```

### AvaloniaUI

```bash
cd AvaloniaUI && dotnet run --project WiseElephant23.Avalonia.Gallery
```

## CSS → WPF 변환 매핑 테이블

| CSS | WPF |
|-----|-----|
| `font-size: 20px` (기준) | 크기 계산 기준 (1em = 20px) |
| `height/width: 1.3em` | `Width/Height="26"` |
| `background-color: #ccc` | `SolidColorBrush Color="#CCCCCC"` |
| `background-color: limegreen` | `SolidColorBrush Color="LimeGreen"` |
| `border-radius: 25px` | `CornerRadius="13"` |
| `transition: 0.15s` | `ColorAnimation Duration="0:0:0.15"` |
| `cursor: pointer` | `Cursor="Hand"` |
| `::after` pseudo-element | `Path` 요소 |
| `transform: rotate(45deg)` | `RotateTransform Angle="45"` |
| `display: none/block` | `Opacity="0/1"` 애니메이션 |
| `input:checked ~ .checkmark` | `Trigger IsChecked="True"` |

## 프로젝트 구조

```
WiseElephant23/
├── Readme.md
├── Wpf/
│   ├── WiseElephant23.Wpf.slnx
│   ├── WiseElephant23.Wpf.UI/
│   │   ├── Controls/
│   │   │   └── WiseElephant23.cs
│   │   ├── Themes/
│   │   │   ├── Generic.xaml
│   │   │   ├── WiseElephant23.xaml
│   │   │   └── WiseElephant23Resources.xaml
│   │   └── Properties/
│   │       └── AssemblyInfo.cs
│   └── WiseElephant23.Wpf.Gallery/
│       ├── App.xaml
│       └── MainWindow.xaml
└── AvaloniaUI/
    └── (미구현)
```

## 사용 방법

```xml
<Window xmlns:controls="clr-namespace:WiseElephant23.Wpf.UI.Controls;assembly=WiseElephant23.Wpf.UI">
    <controls:WiseElephant23 />
    <controls:WiseElephant23 IsChecked="True" />
</Window>
```
