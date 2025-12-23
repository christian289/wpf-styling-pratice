# SplendidQuail83

Patterns 스타일 컨트롤 - 노트 패드/종이 스타일의 배경 패턴

## 원본 정보
- **원작자**: artvelog
- **원본 링크**: [https://uiverse.io/artvelog/splendid-quail-83](https://uiverse.io/artvelog/splendid-quail-83)
- **태그**: paper, light, modern, pattern

## 빌드 명령

### WPF
```bash
cd Wpf && dotnet run --project SplendidQuail83.Wpf.Gallery
```

### AvaloniaUI
```bash
cd AvaloniaUI && dotnet run --project SplendidQuail83.Avalonia.Gallery
```

## CSS → WPF 변환 매핑 테이블

| CSS 속성 | CSS 값 | WPF 구현 |
|---------|--------|----------|
| `background` | `#f1f1f1` | `Rectangle.Fill` (SolidColorBrush) |
| `linear-gradient(90deg, ...)` | 수직 마진 라인 | `Rectangle` (Width=2, Margin=50,0,0,0) |
| `linear-gradient(#e1e1e1 ...)` | 수평 줄무늬 | `DrawingBrush` + `TileMode="Tile"` |
| `background-size: 100% 30px` | 타일 반복 | `Viewport="0,0,1,30"` (Absolute) |

## 프로젝트 구조

```
SplendidQuail83/
├── Readme.md
├── Wpf/
│   ├── SplendidQuail83.Wpf.slnx
│   ├── SplendidQuail83.Wpf.UI/           # 커스텀 컨트롤 라이브러리
│   │   ├── Controls/
│   │   │   └── SplendidQuail83.cs
│   │   └── Themes/
│   │       ├── Generic.xaml
│   │       ├── SplendidQuail83.xaml
│   │       └── SplendidQuail83Resources.xaml
│   └── SplendidQuail83.Wpf.Gallery/      # 데모 앱
└── AvaloniaUI/                           # (미구현)
```

## 사용 예시

```xml
<controls:SplendidQuail83 Padding="70,15,15,15">
    <TextBlock Text="노트 패드 스타일 배경" FontSize="18"/>
</controls:SplendidQuail83>
```
