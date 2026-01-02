# GrumpyBaboon32

Patterns 스타일 컨트롤 - 기하학적 패턴 배경을 제공하는 커스텀 컨트롤

## 원본 정보

- **원작자**: mobinkakei
- **원본 링크**: [https://uiverse.io/mobinkakei/grumpy-baboon-32](https://uiverse.io/mobinkakei/grumpy-baboon-32)

## 빌드 및 실행

### WPF

```bash
cd Wpf && dotnet run --project GrumpyBaboon32.Wpf.Gallery
```

### AvaloniaUI

```bash
cd AvaloniaUI && dotnet run --project GrumpyBaboon32.Avalonia.Gallery
```

## CSS → WPF 변환 매핑 테이블

| CSS 속성 | 값 | WPF 구현 |
|---------|-----|---------|
| `--s` (패턴 크기) | `25px` | `PatternSize` DependencyProperty (기본값: 25) |
| `--c1` (주요 색상) | `#1eaaee` | `SolidColorBrush` 리소스 |
| `--c2` (배경 색상) | `#171717` | `SolidColorBrush` 리소스 |
| `linear-gradient(45deg, ...)` | 대각선 라인 | `DrawingBrush` 내 `LineGeometry` |
| `linear-gradient(135deg, ...)` | 대각선 라인 | `DrawingBrush` 내 `LineGeometry` |
| `radial-gradient(...)` | 원형 점 | `DrawingBrush` 내 `EllipseGeometry` |
| `background` (다중 레이어) | 3개 그라데이션 조합 | `DrawingBrush` + `DrawingGroup` 타일링 |

## 패턴 구조 설명

원본 CSS는 세 가지 그라데이션을 조합하여 패턴을 생성합니다:

1. **45도 linear-gradient**: 대각선 라인 (왼쪽 위 → 오른쪽 아래)
2. **135도 linear-gradient**: 대각선 라인 (오른쪽 위 → 왼쪽 아래)
3. **radial-gradient**: 원형 점 패턴

WPF에서는 `DrawingBrush`의 타일링 기능을 사용하여 50x50 픽셀 단위로 패턴을 반복합니다.

## 프로젝트 구조

```
GrumpyBaboon32/
├── Wpf/
│   ├── GrumpyBaboon32.Wpf.slnx
│   ├── GrumpyBaboon32.Wpf.UI/
│   │   ├── Controls/
│   │   │   └── GrumpyBaboon32.cs
│   │   └── Themes/
│   │       ├── Generic.xaml
│   │       ├── GrumpyBaboon32.xaml
│   │       └── GrumpyBaboon32Resources.xaml
│   └── GrumpyBaboon32.Wpf.Gallery/
│       ├── App.xaml
│       └── MainWindow.xaml
└── AvaloniaUI/
    └── (미구현)
```
