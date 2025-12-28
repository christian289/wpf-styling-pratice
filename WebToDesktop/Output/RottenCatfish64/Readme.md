# RottenCatfish64

Patterns 스타일 컨트롤 - 대각선 줄무늬 패턴 배경

## 원본 정보

- **원작자**: AmruthGowda91200
- **원본 링크**: [https://uiverse.io/AmruthGowda91200/rotten-catfish-64](https://uiverse.io/AmruthGowda91200/rotten-catfish-64)
- **태그**: simple, blue, minimalist, html, css, pattern

## 빌드 및 실행

### WPF
```bash
cd Wpf && dotnet run --project RottenCatfish64.Wpf.Gallery
```

### AvaloniaUI
```bash
cd AvaloniaUI && dotnet run --project RottenCatfish64.Avalonia.Gallery
```

## CSS → WPF 변환 매핑 테이블

| CSS | WPF | 설명 |
|-----|-----|------|
| `repeating-linear-gradient` | `DrawingBrush` + `TileMode="Tile"` | 반복 그라데이션을 타일 브러시로 구현 |
| `-45deg`, `45deg`, `-30deg`, `30deg` | `RotateTransform` | 대각선 각도 적용 |
| 다중 그라데이션 레이어 | `DrawingGroup` + `Opacity` | 여러 레이어를 Opacity로 블렌딩 |
| `#ff7e5f` | `SolidColorBrush` (Coral) | Primary 색상 |
| `#3f51b5` | `SolidColorBrush` (Indigo) | Secondary 색상 |
| `10px` stripe width | `RectangleGeometry` | 줄무늬 너비 |
| `width: 100%`, `height: 100%` | `Stretch` (기본값) | 부모 크기에 맞춤 |

## 프로젝트 구조

```
RottenCatfish64/
├── Wpf/
│   ├── RottenCatfish64.Wpf.slnx
│   ├── RottenCatfish64.Wpf.Gallery/     # 데모 앱
│   └── RottenCatfish64.Wpf.UI/          # 컨트롤 라이브러리
│       ├── Controls/
│       │   └── RottenCatfish64.cs
│       └── Themes/
│           ├── Generic.xaml
│           ├── RottenCatfish64.xaml
│           └── RottenCatfish64Resources.xaml
└── AvaloniaUI/                          # (미구현)
```

## 사용 방법

1. `RottenCatfish64.Wpf.UI` 프로젝트 참조 추가
2. App.xaml에 리소스 딕셔너리 병합:

```xml
<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceDictionary Source="pack://application:,,,/RottenCatfish64.Wpf.UI;component/Themes/Generic.xaml" />
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

3. XAML에서 컨트롤 사용:

```xml
<controls:RottenCatfish64 xmlns:controls="clr-namespace:RottenCatfish64.Wpf.UI.Controls;assembly=RottenCatfish64.Wpf.UI" />
```
