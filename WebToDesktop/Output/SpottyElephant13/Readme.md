# SpottyElephant13

Checkboxes 스타일 컨트롤 - 펄스 애니메이션이 있는 커스텀 체크박스

## 원본 정보

- **원작자**: bociKond
- **원본 링크**: [https://uiverse.io/bociKond/spotty-elephant-13](https://uiverse.io/bociKond/spotty-elephant-13)
- **태그**: checkbox, pulse, color

## 빌드 명령

### WPF

```bash
cd Wpf && dotnet run --project SpottyElephant13.Wpf.Gallery
```

### AvaloniaUI

```bash
cd AvaloniaUI && dotnet run --project SpottyElephant13.Avalonia.Gallery
```

## CSS → WPF 변환 매핑

| CSS 속성 | WPF 구현 |
|---------|---------|
| `--clr: #0B6E4F` | `SolidColorBrush` 리소스 |
| `border-radius: 50%` | `CornerRadius="15.6"` |
| `border-radius: .5rem` | `CornerRadius="8"` |
| `background-color` | `Border.Background` |
| `box-shadow: 0 0 0 Xpx` | `DropShadowEffect.BlurRadius` |
| `transition: 300ms` | 부분 지원 (CornerRadius 애니메이션 미지원) |
| `@keyframes pulse` | `Storyboard` + `DoubleAnimationUsingKeyFrames` |
| `rotate: Xdeg` | `RotateTransform.Angle` |
| `::after` | `Grid` 내 `Border` 요소 |
| `border-right + border-bottom` | 두 개의 `Border` 조합 |
| `transform: rotate(45deg)` | `RenderTransform` > `RotateTransform` |

## 기능

- 체크 시 원형 → 둥근 사각형으로 모양 변경
- 체크 시 펄스 애니메이션 (회전 + 그림자 확산)
- 체크마크 표시/숨김 애니메이션

## 프로젝트 구조

```
SpottyElephant13/
├── Wpf/
│   ├── SpottyElephant13.Wpf.slnx
│   ├── SpottyElephant13.Wpf.Gallery/    # 데모 앱
│   └── SpottyElephant13.Wpf.UI/         # 커스텀 컨트롤 라이브러리
│       ├── Controls/
│       │   └── SpottyElephant13.cs
│       └── Themes/
│           ├── Generic.xaml
│           ├── SpottyElephant13.xaml
│           └── SpottyElephant13Resources.xaml
└── AvaloniaUI/                           # (미구현)
```
