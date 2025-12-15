# HungryMoth59

귀여운 강아지 로딩 애니메이션 컨트롤 (loaders 스타일)

## 원본 정보

- **원작자**: elijahgummer
- **원본 링크**: [https://uiverse.io/elijahgummer/hungry-moth-59](https://uiverse.io/elijahgummer/hungry-moth-59)

## 빌드 및 실행

### WPF

```bash
cd Wpf && dotnet run --project HungryMoth59.Wpf.Gallery
```

### AvaloniaUI

```bash
cd AvaloniaUI && dotnet run --project HungryMoth59.Avalonia.Gallery
```

## CSS → WPF 변환 매핑 테이블

| CSS 속성/패턴 | WPF 구현 방법 |
|--------------|--------------|
| `vmax` 단위 | 고정 픽셀값 (1vmax ≈ 10px) |
| `position: absolute` | `Canvas` + `Canvas.Left/Top` |
| `border-radius` | `Border.CornerRadius` |
| `background-color` | `SolidColorBrush` |
| `linear-gradient` | `LinearGradientBrush` |
| `transform: rotateZ()` | `RotateTransform` |
| `transform-origin` | `RenderTransformOrigin` |
| `z-index` | `Panel.ZIndex` + XAML 선언 순서 |
| `::before`, `::after` | 별도의 Border/Ellipse 요소 |
| `@keyframes` | `Storyboard` + `DoubleAnimationUsingKeyFrames` |
| `animation: 10s` | `Duration="0:0:10"` |
| `animation: infinite` | `RepeatBehavior="Forever"` |
| `cubic-bezier()` | `LinearDoubleKeyFrame` (근사 변환) |
| `overflow: hidden` + `border-radius` | Ellipse 직접 사용 |

## 애니메이션 구성

10초 주기의 복합 애니메이션:
- **그림자**: 너비 변화 (99% → 101% → 96%)
- **머리**: Y축 이동 + 회전 (0° → 10°)
- **몸통**: 높이 변화 (호흡 효과)
- **왼쪽 귀**: 회전 (-50° → -30° → -60°)
- **오른쪽 귀**: 회전 (20° → 10° → 25°)
- **주둥이**: 높이 변화
- **입**: 너비 변화 (열림/닫힘)
- **눈**: 크기 + Y축 이동 (깜빡임 + 눈동자 움직임)

## 프로젝트 구조

```
HungryMoth59/
├── Readme.md
├── Wpf/
│   ├── HungryMoth59.Wpf.slnx
│   ├── HungryMoth59.Wpf.Gallery/     # 데모 앱
│   └── HungryMoth59.Wpf.UI/          # 커스텀 컨트롤 라이브러리
│       ├── Controls/
│       │   └── HungryMoth59.cs
│       └── Themes/
│           ├── Generic.xaml
│           ├── HungryMoth59.xaml
│           └── HungryMoth59Resources.xaml
└── AvaloniaUI/                        # (미구현)
```

## 사용 방법

```xml
<!-- 네임스페이스 추가 -->
xmlns:controls="clr-namespace:HungryMoth59.Wpf.UI.Controls;assembly=HungryMoth59.Wpf.UI"

<!-- 컨트롤 사용 -->
<controls:HungryMoth59 />
```
