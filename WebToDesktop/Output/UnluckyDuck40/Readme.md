# UnluckyDuck40

Buttons 스타일 컨트롤 - 소셜 공유 버튼

호버 시 소셜 미디어 아이콘(Twitter, Instagram, Facebook)이 위로 슬라이드되어 나타나는 Share 버튼입니다.

## 원본 정보

- **원작자**: boryanakrasteva
- **원본 링크**: [https://uiverse.io/boryanakrasteva/unlucky-duck-40](https://uiverse.io/boryanakrasteva/unlucky-duck-40)
- **태그**: social, button, share

## 빌드 명령

### WPF

```bash
cd Wpf && dotnet run --project UnluckyDuck40.Wpf.Gallery
```

### AvaloniaUI

```bash
cd AvaloniaUI && dotnet run --project UnluckyDuck40.Avalonia.Gallery
```

## 사용 방법

```xml
<controls:UnluckyDuck40 />

<!-- 커스텀 텍스트 -->
<controls:UnluckyDuck40 Text="SHARE IT" />
```

## CSS → WPF 변환 매핑

| CSS 속성 | WPF 속성 | 비고 |
|---------|---------|------|
| `width: 130px` | `Width="130"` | |
| `height: 40px` | `Height="40"` | |
| `border-radius: 20px` | `CornerRadius="20"` | |
| `border: 1px solid black` | `BorderThickness="1" BorderBrush="Black"` | |
| `background-color: transparent` | `Background="Transparent"` | |
| `filter: drop-shadow(...)` | `DropShadowEffect` | |
| `opacity: 0` → `1` | `Opacity` + Storyboard | 호버 시 애니메이션 |
| `visibility: hidden` → `visible` | Opacity로 처리 | |
| `transition: .2s linear` | `Duration="0:0:0.2"` | |
| `top: 0` → `-120%` | `TranslateTransform Y` | -48px 이동 |
| `radial-gradient` | `RadialGradientBrush` | Instagram 아이콘 |
| `linear-gradient` | `LinearGradientBrush` | Facebook 아이콘 |
| `letter-spacing` | (미지원) | WPF에서 지원 안 함 |
| `text-transform: uppercase` | 직접 대문자 입력 | |

## 프로젝트 구조

```
UnluckyDuck40/
├── Wpf/
│   ├── UnluckyDuck40.Wpf.slnx
│   ├── UnluckyDuck40.Wpf.UI/
│   │   ├── Controls/
│   │   │   └── UnluckyDuck40.cs
│   │   └── Themes/
│   │       ├── Generic.xaml
│   │       ├── UnluckyDuck40.xaml
│   │       └── UnluckyDuck40Resources.xaml
│   └── UnluckyDuck40.Wpf.Gallery/
└── AvaloniaUI/
    └── (미구현)
```
