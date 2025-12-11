# GrumpyOwl55

Patterns 스타일 컨트롤 - 기하학적 계단 패턴과 도트를 조합한 타일링 배경

## 원본 정보

- **원작자**: vikas7754
- **원본 링크**: [https://uiverse.io/vikas7754/grumpy-owl-55](https://uiverse.io/vikas7754/grumpy-owl-55) (클릭 시 원본 CSS/HTML 확인 가능)
- **태그**: simple, clean, pattern

## 빌드 및 실행

### WPF
```bash
cd Wpf && dotnet run --project GrumpyOwl55.Wpf.Gallery
```

### AvaloniaUI
```bash
cd AvaloniaUI && dotnet run --project GrumpyOwl55.Avalonia.Gallery
```

## CSS → WPF 변환 매핑

| CSS | WPF | 설명 |
|-----|-----|------|
| `repeating-linear-gradient(90deg, ...)` | 중첩 `DrawingBrush` + `TileMode="Tile"` | 수직 스트라이프 베이스 |
| `linear-gradient(-45deg, ...)` | `LinearGradientBrush` StartPoint="1,0" EndPoint="0,1" | 대각선 그라데이션 오버레이 |
| `conic-gradient(from -90deg at X% Y%, ...)` | `PathGeometry` (직사각형) | 90도 섹터를 직사각형으로 근사 |
| `radial-gradient(circle at X% Y%, ...)` | `EllipseGeometry` | 원형 도트 패턴 |
| `--sz: 15px` | `sys:Double` (15) | 기본 단위 크기 |
| `--c0: #000` | `SolidColorBrush` | Primary 색상 (검정) |
| `--c1: #c71175` | `SolidColorBrush` | Secondary 색상 (마젠타) |
| 타일 크기 `calc(sz*8) x calc(sz*16)` | `Viewport="0,0,120,240"` | 120x240px 타일 |

## 프로젝트 구조

```
GrumpyOwl55/
├── Readme.md
├── Wpf/
│   ├── GrumpyOwl55.Wpf.slnx
│   ├── GrumpyOwl55.Wpf.Gallery/    # 데모 앱
│   └── GrumpyOwl55.Wpf.UI/         # 커스텀 컨트롤 라이브러리
│       ├── Controls/
│       │   └── GrumpyOwl55.cs
│       └── Themes/
│           ├── Generic.xaml
│           ├── GrumpyOwl55.xaml
│           └── GrumpyOwl55Resources.xaml
└── AvaloniaUI/                     # (추후 생성)
```
