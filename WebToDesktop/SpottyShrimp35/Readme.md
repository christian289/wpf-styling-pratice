# SpottyShrimp35

Patterns 스타일 컨트롤 - 45도 각도의 반복 스트라이프 패턴 배경

## 원본 정보
- **출처**: [uiverse.io](https://uiverse.io)
- **원작자**: lautyYT
- **태그**: simple, blue, pattern

## 빌드 및 실행

```bash
cd Wpf && dotnet run --project SpottyShrimp35.Wpf.Gallery
```

## 프로젝트 구조

```
SpottyShrimp35/
├── Wpf/
│   ├── SpottyShrimp35.Wpf.slnx
│   ├── SpottyShrimp35.Wpf.Gallery/      # 데모 앱
│   └── SpottyShrimp35.Wpf.UI/           # 커스텀 컨트롤 라이브러리
│       ├── Controls/
│       │   └── SpottyShrimp35.cs
│       └── Themes/
│           ├── Generic.xaml
│           ├── SpottyShrimp35.xaml
│           └── SpottyShrimp35Resources.xaml
└── Log/
    └── SpottyShrimp35_20251210.md
```

## CSS → WPF 변환 매핑

| CSS                                            | WPF                                       |
| ---------------------------------------------- | ----------------------------------------- |
| `repeating-linear-gradient`                    | `DrawingBrush` + `TileMode="Tile"`        |
| `45deg`                                        | `RotateTransform` (Angle="45")            |
| `#0050fc` (primary color)                      | `SolidColorBrush` in Resources            |
| `#0684fade` (secondary color with alpha)       | `SolidColorBrush` in Resources            |
| Color stops at 20px intervals                  | `GeometryDrawing` + `RectangleGeometry`   |
| `width: 100%; height: 100%`                    | Control fills parent container            |

## 사용 예시

```xml
<Window xmlns:controls="clr-namespace:SpottyShrimp35.Wpf.UI.Controls;assembly=SpottyShrimp35.Wpf.UI">
    <Grid>
        <controls:SpottyShrimp35/>
    </Grid>
</Window>
```
