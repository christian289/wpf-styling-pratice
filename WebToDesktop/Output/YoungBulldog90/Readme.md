# YoungBulldog90

loaders 스타일 컨트롤 - 회전하는 원형 로딩 스피너

## 원본 정보

- **원작자**: Clemix37
- **원본 링크**: [https://uiverse.io/Clemix37/young-bulldog-90](https://uiverse.io/Clemix37/young-bulldog-90)

## 빌드 및 실행

### WPF

```bash
cd Wpf && dotnet run --project YoungBulldog90.Wpf.Gallery
```

### AvaloniaUI

```bash
cd AvaloniaUI && dotnet run --project YoungBulldog90.Avalonia.Gallery
```

## CSS → WPF 변환 매핑

| CSS | WPF | 설명 |
|-----|-----|------|
| `width: 60px; height: 60px` | `Width="60" Height="60"` | 컨트롤 크기 |
| `border-radius: 50%` | `Path` (Arc) | 원형 호 |
| `border-top: 2px solid #8900FF` | `Path.Stroke`, `StrokeThickness="2"` | 호 테두리 |
| `border-right: 2px solid transparent` | Arc endpoint | 투명 영역은 호 범위로 처리 |
| `::before` pseudo-element | `Path` in `ControlTemplate` | Grid 내 Path 요소로 대체 |
| `animation: spinner8217 0.8s linear infinite` | `Storyboard` + `DoubleAnimation` | 회전 애니메이션 |
| `transform: rotate(360deg)` | `RotateTransform.Angle` | 360도 회전 |
| `position: absolute` | Grid 레이아웃 | Grid가 기본적으로 중첩 배치 지원 |

## 프로젝트 구조

```
YoungBulldog90/
├── Readme.md
├── Wpf/
│   ├── YoungBulldog90.Wpf.slnx
│   ├── YoungBulldog90.Wpf.Gallery/     # 데모 앱
│   └── YoungBulldog90.Wpf.UI/          # 커스텀 컨트롤 라이브러리
│       ├── Controls/
│       │   └── YoungBulldog90.cs
│       └── Themes/
│           ├── Generic.xaml
│           ├── YoungBulldog90.xaml
│           └── YoungBulldog90Resources.xaml
└── AvaloniaUI/                          # (추후 추가)
```
