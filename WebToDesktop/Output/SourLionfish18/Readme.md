# SourLionfish18

애니메이션 체크마크가 있는 둥근 체크박스 스타일 컨트롤

## 원본 정보

- **원작자:** mobinkakei
- **원본 링크:** [https://uiverse.io/mobinkakei/sour-lionfish-18](https://uiverse.io/mobinkakei/sour-lionfish-18)
- **카테고리:** Checkboxes

## 빌드 및 실행

### WPF
```bash
cd Wpf && dotnet run --project SourLionfish18.Wpf.Gallery
```

### AvaloniaUI
```bash
cd AvaloniaUI && dotnet run --project SourLionfish18.Avalonia.Gallery
```

## CSS → WPF 변환 매핑 테이블

| CSS 속성 | 값 | WPF 구현 |
|---------|-----|---------|
| `width`, `height` | `30px` | `Width="30"`, `Height="30"` |
| `background-color` | `#ddd` / `#08bb68` | `SolidColorBrush` + `ColorAnimation` |
| `border-radius` | `10px` | `CornerRadius="10"` |
| `transition` | `0.4s` | `Duration="0:0:0.4"` |
| `::after` (pseudo-element) | - | `Border` (L자 체크마크) |
| `border-right`, `border-bottom` | `3px solid #fff` | `BorderThickness="0,0,3,3"` |
| `transform: rotateZ(40deg)` | - | `RotateTransform Angle="40"` |
| `transform: scale(10)` / `scale(1)` | - | `ScaleTransform` + `DoubleAnimation` |
| `opacity` | `0` / `1` | `Opacity` + `DoubleAnimation` |
| `cursor: pointer` | - | `Cursor="Hand"` |

## 프로젝트 구조

```
SourLionfish18/
├── Wpf/
│   ├── SourLionfish18.Wpf.slnx
│   ├── SourLionfish18.Wpf.Gallery/     # 데모 앱
│   │   ├── App.xaml
│   │   └── MainWindow.xaml
│   └── SourLionfish18.Wpf.UI/          # 커스텀 컨트롤 라이브러리
│       ├── Controls/
│       │   └── SourLionfish18.cs
│       └── Themes/
│           ├── Generic.xaml
│           ├── SourLionfish18.xaml
│           └── SourLionfish18Resources.xaml
└── AvaloniaUI/                          # (미구현)
```

## 사용법

```xml
<!-- 네임스페이스 선언 -->
xmlns:controls="clr-namespace:SourLionfish18.Wpf.UI.Controls;assembly=SourLionfish18.Wpf.UI"

<!-- 체크박스 사용 -->
<controls:SourLionfish18 IsChecked="False"/>
<controls:SourLionfish18 IsChecked="True"/>
```
