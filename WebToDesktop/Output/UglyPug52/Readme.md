# UglyPug52

Tooltips 스타일 컨트롤 - 호버 시 텍스트가 아이콘으로 전환되고 툴팁이 애니메이션과 함께 표시되는 장바구니 버튼

## 원본 정보

- **원작자:** SouravBandyopadhyay
- **원본 링크:** [https://uiverse.io/SouravBandyopadhyay/ugly-pug-52](https://uiverse.io/SouravBandyopadhyay/ugly-pug-52)
- **카테고리:** Tooltips
- **태그:** simple, tooltip, black, clean, submit, transition, hover effect

## 빌드 및 실행

### WPF
```bash
cd Wpf && dotnet run --project UglyPug52.Wpf.Gallery
```

### AvaloniaUI
```bash
cd AvaloniaUI && dotnet run --project UglyPug52.Avalonia.Gallery
```

## 기능

- 호버 시 텍스트 → 아이콘 슬라이드 전환 애니메이션
- 툴팁이 위에서 페이드인되며 나타남
- 툴팁 화살표 표시
- `TooltipText` 속성으로 툴팁 텍스트 커스터마이징
- `Content` 속성으로 버튼 텍스트 커스터마이징

## 사용법

```xml
<controls:UglyPug52 />

<!-- 커스텀 툴팁 텍스트 -->
<controls:UglyPug52 TooltipText="SALE 50% OFF" />

<!-- 커스텀 버튼 텍스트 -->
<controls:UglyPug52 Content="Buy Now" TooltipText="FREE SHIPPING" />
```

## CSS → WPF 변환 매핑 테이블

| CSS | WPF | 설명 |
|-----|-----|------|
| `--width: 100px` | `sys:Double x:Key="UglyPug52.Width"` | CSS 변수 → StaticResource |
| `--height: 35px` | `sys:Double x:Key="UglyPug52.Height"` | CSS 변수 → StaticResource |
| `--button-color: #222` | `SolidColorBrush x:Key="UglyPug52.Button.Background"` | 색상 변수 → Brush 리소스 |
| `border-radius: 0.5em` | `CornerRadius x:Key="UglyPug52.Button.CornerRadius"` | 모서리 둥글기 |
| `transition: top 0.5s` | `DoubleAnimation Duration="0:0:0.5"` | 트랜지션 → Storyboard |
| `::before` (tooltip) | `Border x:Name="TooltipBorder"` | Pseudo-element → 별도 요소 |
| `::after` (arrow) | `Path x:Name="TooltipArrow"` | Pseudo-element → Path 요소 |
| `opacity: 0` → `1` | `DoubleAnimation Storyboard.TargetProperty="Opacity"` | 투명도 애니메이션 |
| `top: 0` → `top: -100%` | `TranslateTransform.Y` 애니메이션 | 슬라이드 애니메이션 |
| `content: attr(data-tooltip)` | `TemplateBinding TooltipText` | data 속성 → DependencyProperty |
| SVG `<path d="...">` | `Geometry x:Key="UglyPug52.CartIcon.Data"` | SVG Path → Geometry 리소스 |
| `transition: all 0.5s` | `CubicEase EasingMode="EaseOut"` | 이징 함수 적용 |
| `:hover` | `Trigger Property="IsMouseOver"` | 호버 상태 트리거 |
| `visibility: hidden/visible` | `Opacity` 애니메이션 (0/1) | 가시성 → 투명도 |

## 프로젝트 구조

```
UglyPug52/
├── Readme.md
├── Wpf/
│   ├── UglyPug52.Wpf.slnx
│   ├── UglyPug52.Wpf.Gallery/          # 데모 앱
│   │   ├── App.xaml
│   │   └── MainWindow.xaml
│   └── UglyPug52.Wpf.UI/               # 컨트롤 라이브러리
│       ├── Controls/
│       │   └── UglyPug52.cs            # CustomControl 클래스
│       └── Themes/
│           ├── Generic.xaml            # 리소스 병합
│           ├── UglyPug52.xaml          # 스타일 + ControlTemplate
│           └── UglyPug52Resources.xaml # 리소스 (색상, 크기, 아이콘)
└── AvaloniaUI/                         # (예정)
```
