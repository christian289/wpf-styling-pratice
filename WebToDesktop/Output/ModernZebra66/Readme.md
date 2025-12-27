# ModernZebra66

Patterns 스타일 컨트롤

## 원본 정보

- **원작자**: csemszepp
- **원본 링크**: [https://uiverse.io/csemszepp/modern-zebra-66](https://uiverse.io/csemszepp/modern-zebra-66) (클릭 시 원본 CSS/HTML 확인 가능)

## 빌드 및 실행

### WPF

```bash
cd Wpf && dotnet run --project ModernZebra66.Wpf.Gallery
```

### AvaloniaUI

```bash
cd AvaloniaUI && dotnet run --project ModernZebra66.Avalonia.Gallery
```

## CSS → WPF 변환 매핑 테이블

| CSS | WPF | 설명 |
|-----|-----|------|
| `repeating-conic-gradient` | `DrawingBrush` + `GeometryDrawing` | WPF는 conic-gradient 미지원, Path 기반 구현 |
| `from 30deg` | `RotateTransform Angle="30"` | 그라데이션 시작 각도 |
| `calc(0.5 * var([s]))` offset | `TranslateTransform` | 패턴 오프셋 |
| `--c1: #1d1d1d` | `SolidColorBrush` 리소스 | 가장 어두운 색상 |
| `--c2: #4e4f51` | `SolidColorBrush` 리소스 | 중간 색상 |
| `--c3: #3c3c3c` | `SolidColorBrush` 리소스 | 어두운 중간 색상 |
| `background-size` | `Viewport` / `Viewbox` | 타일 크기 설정 |
| `width: 100%; height: 100%` | `HorizontalAlignment="Stretch"` | 부모 크기에 맞춤 |

## 기술적 특징

- CSS `repeating-conic-gradient`를 WPF `DrawingBrush` + `PathGeometry`로 구현
- 육각형 패턴을 6개의 삼각형 섹터로 분할하여 시뮬레이션
- `TileMode="Tile"`을 사용하여 무한 반복 패턴 생성

## 프로젝트 구조

```
ModernZebra66/
├── Wpf/
│   ├── ModernZebra66.Wpf.slnx
│   ├── ModernZebra66.Wpf.Gallery/     # 데모 앱
│   └── ModernZebra66.Wpf.UI/          # 커스텀 컨트롤 라이브러리
│       ├── Controls/
│       │   └── ModernZebra66.cs
│       └── Themes/
│           ├── Generic.xaml
│           ├── ModernZebra66.xaml
│           └── ModernZebra66Resources.xaml
└── AvaloniaUI/                         # (미구현)
```
