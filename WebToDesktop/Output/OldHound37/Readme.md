# OldHound37

Patterns 스타일의 기하학적 패턴 배경 컨트롤입니다.

## 원본 정보

- **출처:** [uiverse.io](https://uiverse.io)
- **원작자:** csemszepp
- **태그:** simple, minimalist, pattern

## 빌드 및 실행

```bash
cd Wpf && dotnet run --project OldHound37.Wpf.Gallery
```

## 프로젝트 구조

```
Wpf/
├── OldHound37.Wpf.slnx
├── OldHound37.Wpf.UI/           # 커스텀 컨트롤 라이브러리
│   ├── Controls/
│   │   └── OldHound37.cs
│   └── Themes/
│       ├── Generic.xaml
│       ├── OldHound37.xaml
│       └── OldHound37Resources.xaml
└── OldHound37.Wpf.Gallery/      # 데모 애플리케이션
    ├── App.xaml
    └── MainWindow.xaml
```

## 사용 방법

```xml
<Window xmlns:controls="clr-namespace:OldHound37.Wpf.UI.Controls;assembly=OldHound37.Wpf.UI">
    <controls:OldHound37 TileSize="200"/>
</Window>
```

## CSS → WPF 변환 매핑 테이블

| CSS 속성 | WPF 구현 | 비고 |
|---------|---------|------|
| `conic-gradient` | `DrawingBrush` + `GeometryDrawing` | 직접 지원 안됨, 근사 구현 |
| `repeating-linear-gradient` | `LineGeometry` + `Pen` | 대각선/수직/수평 라인 |
| `repeating-conic-gradient` | `RectangleGeometry` | 체커보드 패턴 |
| `background-size: var(--s)` | `DrawingBrush.Viewport` | 타일 크기 제어 |
| CSS 변수 `--s` | `DependencyProperty` | TileSize 속성 |
| `#dc9d37` | `OldHound37.Color.Gold.Dark` | 진한 골드 |
| `#fed450` | `OldHound37.Color.Gold.Light` | 밝은 골드 |
| `#125c65` | `OldHound37.Color.Teal` | 틸 (청록색) |
| `#bc4a33` | `OldHound37.Color.Red` | 레드 |
| `#fff` | `OldHound37.Color.Line` | 그리드 라인 |

## 색상 팔레트

| 색상명 | HEX | 용도 |
|-------|-----|------|
| Gold Dark | `#dc9d37` | 골드 그라데이션 (진함) |
| Gold Light | `#fed450` | 골드 그라데이션 (밝음) |
| Teal | `#125c65` | 체커보드 배경 (청록) |
| Red | `#bc4a33` | 체커보드 배경 (적갈) |
| White | `#FFFFFF` | 그리드 라인 |

## 기술 스택

- .NET 9.0+
- WPF (Windows Presentation Foundation)
- C# 13
