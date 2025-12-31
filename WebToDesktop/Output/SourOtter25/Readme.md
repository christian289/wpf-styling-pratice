# SourOtter25

CSS Clip-Path 폴리곤 애니메이션이 적용된 Cards 스타일 컨트롤

## 원본 정보

- **원작자**: ElektroRaks
- **원본 링크**: [https://uiverse.io/ElektroRaks/sour-otter-25](https://uiverse.io/ElektroRaks/sour-otter-25)
- **카테고리**: Cards
- **태그**: card, polygon, blur filter, text animation, rotate, clip-path

## 빌드 및 실행

### WPF

```bash
cd Wpf && dotnet run --project SourOtter25.Wpf.Gallery
```

### AvaloniaUI

```bash
cd AvaloniaUI && dotnet run --project SourOtter25.Avalonia.Gallery
```

## 컨트롤 사용법

```xml
<controls:SourOtter25
    Title="CSS Clip-Path"
    Author="ELEKTRO RAKS"
    Description="Custom card" />
```

### 속성

| 속성 | 타입 | 기본값 | 설명 |
|------|------|--------|------|
| `Title` | string | "CSS Clip-Path" | 카드 제목 |
| `Author` | string | "ELEKTRO RAKS" | 작성자 이름 |
| `Description` | string | "Custom card" | 설명 텍스트 |

## 효과 설명

- **초기 상태**: 다이아몬드 형태의 clip-path, 제목이 34도 회전된 상태
- **호버 상태**: 전체 직사각형으로 확장, 제목 회전 해제, 작성자/설명 텍스트 페이드인

## CSS → WPF 변환 매핑

| CSS | WPF |
|-----|-----|
| `clip-path: polygon(...)` | `Border.Clip` + `PathGeometry` |
| `linear-gradient(135deg, #1afbf0, #da00ff)` | `LinearGradientBrush` StartPoint="0,0" EndPoint="1,1" |
| `backdrop-filter: blur(20px)` | 미지원 (반투명 배경으로 대체) |
| `transform: rotate(34deg)` | `RotateTransform Angle="34"` |
| `transition: 0.5s` | `PointAnimation`, `DoubleAnimation` Duration="0:0:0.5" |
| `:hover` | `Trigger Property="IsMouseOver"` |
| `opacity: 0 → 1` | `DoubleAnimation` Opacity |
| `margin-left: 25%` | `Margin="47.5,0,0,0"` |
| `padding-top: 6.3em` | `Margin="0,100.8,0,0"` |

## 프로젝트 구조

```
SourOtter25/
├── Wpf/
│   ├── SourOtter25.Wpf.slnx
│   ├── SourOtter25.Wpf.Gallery/     # 데모 앱
│   └── SourOtter25.Wpf.UI/          # 커스텀 컨트롤 라이브러리
│       ├── Controls/
│       │   └── SourOtter25.cs
│       └── Themes/
│           ├── Generic.xaml
│           ├── SourOtter25.xaml
│           └── SourOtter25Resources.xaml
└── AvaloniaUI/                       # (예정)
```

## 제한사항

1. **clip-path 고정 크기**: 현재 190x254 픽셀 기준으로 좌표가 고정되어 있음
2. **backdrop-filter 미지원**: WPF에서 CSS backdrop-filter를 직접 지원하지 않아 블러 효과 생략
