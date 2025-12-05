# CLAUDE.md

이 파일은 Claude Code (claude.ai/code)가 이 프로젝트에서 작업할 때 참고하는 가이드입니다.

## 테마 개요

낮/밤 테마 전환을 위한 토글 스위치입니다. 해, 달, 구름, 별 애니메이션이 포함된 스키모어픽 디자인입니다.

## 폴더 구조

```
ThemeSwitch/
├── CLAUDE.md
├── Wpf/
│   ├── ThemeSwitch.Wpf.slnx
│   ├── ThemeSwitch.Wpf.Lib/
│   │   ├── Controls/
│   │   │   └── ThemeSwitchToggle.cs
│   │   ├── Properties/
│   │   │   └── AssemblyInfo.cs
│   │   └── Themes/
│   │       ├── Generic.xaml
│   │       ├── ThemeSwitchToggle.xaml
│   │       └── PathData.xaml
│   └── ThemeSwitch.Wpf.Gallery/
│       ├── App.xaml / App.xaml.cs
│       └── MainWindow.xaml / MainWindow.xaml.cs
└── Avalonia/
    ├── ThemeSwitch.Avalonia.sln
    ├── ThemeSwitch.Avalonia.Lib/
    │   ├── Controls/
    │   │   └── ThemeSwitchToggle.cs
    │   └── Themes/
    │       ├── Generic.axaml
    │       └── ThemeSwitchToggle.axaml
    └── ThemeSwitch.Avalonia.Gallery/
        ├── App.axaml / App.axaml.cs
        ├── MainWindow.axaml / MainWindow.axaml.cs
        └── Program.cs
```

## 빌드 및 실행

```bash
# WPF
cd Wpf && dotnet run --project ThemeSwitch.Wpf.Gallery

# Avalonia
cd Avalonia && dotnet run --project ThemeSwitch.Avalonia.Gallery
```

## 컨트롤

### ThemeSwitchToggle

| 항목 | WPF | Avalonia |
|------|-----|----------|
| 네임스페이스 | `ThemeSwitch.Wpf.Lib.Controls` | `ThemeSwitch.Avalonia.Lib.Controls` |
| 상속 | `ToggleButton` | `ToggleButton` |
| 상태 | `IsChecked=False` (낮), `IsChecked=True` (밤) | 동일 |

## 스타일 파일 구조

### WPF (`Themes/`)

- **Generic.xaml**: `ThemeSwitchToggle.xaml` 병합만 담당
- **ThemeSwitchToggle.xaml**: 컨트롤 스타일 정의, `PathData.xaml` 참조
- **PathData.xaml**: 별 패턴 SVG Path Data (`StarsPathData`)

### Avalonia (`Themes/`)

- **Generic.axaml**: `ThemeSwitchToggle.axaml` 병합만 담당
- **ThemeSwitchToggle.axaml**: ControlTheme 정의, Path Data 인라인 포함

## 비주얼 레이어 구조 (ZIndex 순서)

| ZIndex | 레이어 | 설명 |
|--------|--------|------|
| 100-101 | Inset Shadow | 컨테이너 입체감 (내부 그림자) |
| 5 | SunMoonCanvas | 해/달 + 달 크레이터 |
| 4 | CircleCanvas | 글로우 링 3개 |
| 3 | StarsCanvas | 별 패턴 (밤에만 표시) |
| 2 | FrontCloudsCanvas | 전경 구름 (흰색) |
| 1 | BackCloudsCanvas | 배경 구름 (회색) |

## 컬러 팔레트

| 요소 | 컬러 |
|------|------|
| 낮 배경 | `#3D7EAE` |
| 밤 배경 | `#1D1F2C` |
| 해 | `#ECCA2F` |
| 달 | `#C4C9D1` |
| 달 크레이터 | `#959DB1` |
| 전경 구름 | `#F3FDFF` |
| 배경 구름 | `#AACADF` |
| 별 | `#FFFFFF` |
| 글로우 링 | `#19FFFFFF` (10% 불투명) |

## 애니메이션

| 요소 | 지속시간 | 이징 |
|------|----------|------|
| 배경색 전환 | 0.5초 | CubicEaseOut |
| 해/달 좌우 이동 | 0.3초 | CubicEaseOut |
| 달 슬라이드 (해 위로) | 0.5초 | CubicEaseOut |
| 구름 상하 이동 | 0.5초 | CubicEaseOut |
| 별 페이드 + 이동 | 0.5초 | CubicEaseOut |
| 마우스 오버 (WPF) | 0.2초 | CubicEaseOut |

## WPF 전용 기능

- **마우스 오버 효과**: 낮 모드에서 +5px, 밤 모드에서 -5px 수평 이동
- **3D 그라데이션**: `RadialGradientBrush`로 해/달에 입체감 표현
- **구름 그라데이션**: 구름 Ellipse에 `RadialGradientBrush` 적용
- **DropShadowEffect**: 해/달에 드롭 섀도우 효과
