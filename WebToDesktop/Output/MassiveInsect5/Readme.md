# MassiveInsect5

Cards 스타일 컨트롤 - 소셜 미디어 아이콘 카드

## 원본 정보

- **원작자**: Smit-Prajapati
- **원본 링크**: [https://uiverse.io/Smit-Prajapati/massive-insect-5](https://uiverse.io/Smit-Prajapati/massive-insect-5) (클릭 시 원본 CSS/HTML 확인 가능)

## 빌드 명령

### WPF

```bash
cd Wpf && dotnet run --project MassiveInsect5.Wpf.Gallery
```

### AvaloniaUI

```bash
cd AvaloniaUI && dotnet run --project MassiveInsect5.Avalonia.Gallery
```

## 기능 설명

마우스 호버 시:
- 카드가 1.1배 확대
- 중앙의 UI 로고가 우하단으로 이동
- Instagram, Twitter, Discord 아이콘이 좌하단에서 순차적으로 슬라이드

각 소셜 아이콘 호버 시:
- 해당 플랫폼의 그라데이션 배경 표시
- 아이콘에 glow 효과

## CSS → WPF 변환 매핑 테이블

| CSS | WPF | 비고 |
|-----|-----|------|
| `width: 200px; height: 200px` | `Width="200" Height="200"` | 고정 크기 |
| `border-radius: 30px` | `CornerRadius="30"` | |
| `overflow: hidden` | `ClipToBounds="True"` | |
| `box-shadow: rgba(100,100,111,0.2) 0 7px 29px` | `DropShadowEffect` | Direction, ShadowDepth 변환 |
| `transition: all 1s ease-in-out` | `Storyboard + DoubleAnimation` | Duration="0:0:1", QuadraticEase |
| `radial-gradient(circle at X% Y%, ...)` | `RadialGradientBrush` | GradientOrigin, Center 설정 |
| `position: absolute` + `inset: 0` | Grid 내 Border 배치 | 전체 영역 채움 |
| `transform: translate(50%, 50%)` | `TranslateTransform` | 애니메이션으로 제어 |
| `transition-delay: 0.2s` | `BeginTime="0:0:0.2"` | |
| `::before` pseudo-element | 추가 Border 요소 | Opacity 애니메이션으로 표시/숨김 |
| `:hover` | `IsMouseOver` Trigger | |
| `filter: drop-shadow(0 0 5px white)` | `DropShadowEffect` | BlurRadius=5, Color=White |
| `border-radius: 10% 13% 42% 0%/10% 12% 75% 0%` | `CornerRadius="14,18,105,0"` | 픽셀 값 근사 |
| `fill: rgba(255,255,255,0.797)` | `SolidColorBrush Color="#CBFFFFFF"` | Alpha 변환 |

## 프로젝트 구조

```
MassiveInsect5/
├── Readme.md
├── Wpf/
│   ├── MassiveInsect5.Wpf.slnx
│   ├── MassiveInsect5.Wpf.Gallery/
│   │   ├── App.xaml
│   │   └── MainWindow.xaml
│   └── MassiveInsect5.Wpf.UI/
│       ├── Controls/
│       │   └── MassiveInsect5.cs
│       └── Themes/
│           ├── Generic.xaml
│           ├── MassiveInsect5.xaml
│           └── MassiveInsect5Resources.xaml
└── AvaloniaUI/ (미구현)
```
