# SpottyShrimp35

Patterns 스타일 컨트롤 - 45도 각도의 반복되는 줄무늬 패턴 배경

## 원본 정보

- **원작자**: lautyYT
- **원본 링크**: [https://uiverse.io/lautyYT/spotty-shrimp-35](https://uiverse.io/lautyYT/spotty-shrimp-35)

## 빌드 명령

### WPF

```bash
cd Wpf && dotnet run --project SpottyShrimp35.Wpf.Gallery
```

### AvaloniaUI

```bash
cd AvaloniaUI && dotnet run --project SpottyShrimp35.Avalonia.Gallery
```

## CSS to WPF 변환 매핑 테이블

| CSS 속성 | CSS 값 | WPF 구현 |
|---------|--------|---------|
| `width` | `100%` | `HorizontalAlignment="Stretch"` |
| `height` | `100%` | `VerticalAlignment="Stretch"` |
| `background` | `repeating-linear-gradient(45deg, ...)` | `DrawingBrush` + `TileMode="Tile"` + `RotateTransform` |
| 그라데이션 색상 #1 | `#0050fc` | `SolidColorBrush` (Primary Blue) |
| 그라데이션 색상 #2 | `#0684fade` | `SolidColorBrush` (Secondary Blue with Alpha) |
| 스트라이프 너비 | `20px` | `RectangleGeometry Rect="0,0,20,40"` |
| 패턴 반복 단위 | `40px` | `Viewport="0,0,40,40"` |
| 회전 각도 | `45deg` | `RotateTransform Angle="45"` |

## 프로젝트 구조

```
SpottyShrimp35/
├── Wpf/
│   ├── SpottyShrimp35.Wpf.slnx
│   ├── SpottyShrimp35.Wpf.Gallery/     # 데모 앱
│   └── SpottyShrimp35.Wpf.UI/          # 커스텀 컨트롤 라이브러리
│       ├── Controls/
│       │   └── SpottyShrimp35.cs
│       └── Themes/
│           ├── Generic.xaml
│           ├── SpottyShrimp35.xaml
│           └── SpottyShrimp35Resources.xaml
└── AvaloniaUI/                          # (추후 구현)
```

## 사용 예시

```xml
<Window xmlns:controls="clr-namespace:SpottyShrimp35.Wpf.UI.Controls;assembly=SpottyShrimp35.Wpf.UI">
    <Grid>
        <controls:SpottyShrimp35/>
    </Grid>
</Window>
```
