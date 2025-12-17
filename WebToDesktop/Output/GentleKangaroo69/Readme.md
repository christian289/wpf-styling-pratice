# GentleKangaroo69

Notifications 스타일 컨트롤 - "LEVEL UP!" 알림 배지

## 원본 정보

- **원작자:** tursynbek
- **원본 링크:** [https://uiverse.io/tursynbek/gentle-kangaroo-69](https://uiverse.io/tursynbek/gentle-kangaroo-69) (클릭 시 원본 CSS/HTML 확인 가능)

## 빌드 명령

### WPF

```bash
cd Wpf && dotnet run --project GentleKangaroo69.Wpf.Gallery
```

### AvaloniaUI

```bash
cd AvaloniaUI && dotnet run --project GentleKangaroo69.Avalonia.Gallery
```

## 기능

- 텍스트 bounce 애니메이션 (상하 이동)
- Hover 시 색상 반전 (배경: 오렌지 → 흰색, 텍스트: 흰색 → 오렌지)
- Hover 시 scale(1.1) 확대 애니메이션
- Hover 시 원형 점 표시 및 bounce 애니메이션
- 커스터마이징 가능한 `Text` 속성

## 사용법

```xml
<controls:GentleKangaroo69 />

<!-- 커스텀 텍스트 -->
<controls:GentleKangaroo69 Text="SUCCESS!" />
<controls:GentleKangaroo69 Text="NEW ACHIEVEMENT!" />
```

## CSS → WPF 변환 매핑 테이블

| CSS 속성 | CSS 값 | WPF 구현 |
|---------|--------|---------|
| `font-family` | `'Montserrat', sans-serif` | `FontFamily="Montserrat, Segoe UI, Arial"` |
| `font-size` | `25px` | `FontSize="25"` |
| `font-weight` | `bold` | `FontWeight="Bold"` |
| `color` | `#ffffff` | `Foreground="{StaticResource ...}"` |
| `background-color` | `#ff5733` | `Background="{StaticResource ...}"` |
| `padding` | `20px` | `Padding="20"` |
| `border-radius` | `10px` | `CornerRadius="10"` |
| `box-shadow` | `0px 5px 10px rgba(0,0,0,0.2)` | `DropShadowEffect` (ShadowDepth=5, BlurRadius=10, Opacity=0.2) |
| `transition` | `all 0.3s ease` | `DoubleAnimation Duration="0:0:0.3"` + `CubicEase` |
| `transform: scale(1.1)` | hover 시 확대 | `ScaleTransform` + `DoubleAnimation` |
| `animation: bounce` | `translateY(-10px)` | `TranslateTransform` + `DoubleAnimationUsingKeyFrames` |
| `::before` pseudo-element | 원형 점 | `Ellipse` (Opacity로 표시/숨김) |

## 프로젝트 구조

```
GentleKangaroo69/
├── Readme.md
├── Wpf/
│   ├── GentleKangaroo69.Wpf.slnx
│   ├── GentleKangaroo69.Wpf.Gallery/    # 데모 앱
│   │   ├── App.xaml
│   │   └── MainWindow.xaml
│   └── GentleKangaroo69.Wpf.UI/         # 커스텀 컨트롤 라이브러리
│       ├── Controls/
│       │   └── GentleKangaroo69.cs
│       └── Themes/
│           ├── Generic.xaml
│           ├── GentleKangaroo69.xaml
│           └── GentleKangaroo69Resources.xaml
└── AvaloniaUI/                          # (미구현)
```

## 스크린샷

실행 시 어두운 배경에 오렌지색 "LEVEL UP!" 배지가 표시되며, 텍스트가 위아래로 bounce 애니메이션됩니다. 마우스를 올리면 배경이 흰색으로, 텍스트가 오렌지색으로 변하며 전체가 살짝 커집니다.
