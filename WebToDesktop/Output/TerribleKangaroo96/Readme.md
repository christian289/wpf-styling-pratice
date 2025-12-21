# TerribleKangaroo96

Checkboxes 스타일 컨트롤 - 원형 체크박스 with 체크마크 애니메이션

## 원본 정보

- **원작자**: Cornerstone-04
- **원본 링크**: [https://uiverse.io/Cornerstone-04/terrible-kangaroo-96](https://uiverse.io/Cornerstone-04/terrible-kangaroo-96)

## 빌드 및 실행

### WPF
```bash
cd Wpf && dotnet run --project TerribleKangaroo96.Wpf.Gallery
```

### AvaloniaUI
```bash
cd AvaloniaUI && dotnet run --project TerribleKangaroo96.Avalonia.Gallery
```

## CSS → WPF 변환 매핑 테이블

| CSS | WPF |
|-----|-----|
| `width: 30px; height: 30px` | `Width="30" Height="30"` |
| `border: 2px solid #212fab` | `BorderBrush="#212fab" BorderThickness="2"` |
| `border-radius: 50px` | `CornerRadius="15"` |
| `cursor: pointer` | `Cursor="Hand"` |
| `transition: all 0.3s linear` | `Storyboard Duration="0:0:0.3"` |
| `::after { opacity: 0 }` | `Opacity="0"` on checkmark element |
| `::after { transform: rotate(45deg) scale(0) }` | `RotateTransform Angle="45"`, `ScaleTransform ScaleX="0" ScaleY="0"` |
| `::after { border-right: 4px; border-bottom: 4px }` | 두 개의 Border 요소 (수직/수평) |
| `:checked ~ .checkbox { background: #212fab }` | `ColorAnimation To="#212fab"` |
| `:checked ~ .checkbox::after { opacity: 1; transform: rotate(50deg) scale(1) }` | `DoubleAnimation To="1"` (Opacity), `To="50"` (Angle), `To="1"` (Scale) |

## 프로젝트 구조

```
TerribleKangaroo96/
├── Wpf/
│   ├── TerribleKangaroo96.Wpf.slnx
│   ├── TerribleKangaroo96.Wpf.UI/
│   │   ├── Controls/
│   │   │   └── TerribleKangaroo96.cs
│   │   └── Themes/
│   │       ├── Generic.xaml
│   │       ├── TerribleKangaroo96.xaml
│   │       └── TerribleKangaroo96Resources.xaml
│   └── TerribleKangaroo96.Wpf.Gallery/
│       ├── App.xaml
│       └── MainWindow.xaml
└── AvaloniaUI/
    └── (미구현)
```

## 사용 방법

```xml
<controls:TerribleKangaroo96 />
<controls:TerribleKangaroo96 IsChecked="True" />
```
