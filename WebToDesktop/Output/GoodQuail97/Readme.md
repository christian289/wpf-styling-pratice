# GoodQuail97

Radio-buttons 스타일 컨트롤 - 네온 글로우 애니메이션이 적용된 라디오 버튼

## 원본 정보
- **원작자**: radwakhalil22
- **원본 링크**: [https://uiverse.io/radwakhalil22/good-quail-97](https://uiverse.io/radwakhalil22/good-quail-97)

## 빌드 명령

### WPF
```bash
cd Wpf && dotnet run --project GoodQuail97.Wpf.Gallery
```

### AvaloniaUI
```bash
cd AvaloniaUI && dotnet run --project GoodQuail97.Avalonia.Gallery
```

## CSS → WPF 변환 매핑 테이블

| CSS 속성 | 값 | WPF 구현 | 비고 |
|---------|-----|---------|------|
| `width`, `height` | `30px` | `Width="30" Height="30"` | 크기 |
| `border-radius` | `50px` | `CornerRadius="15"` | 원형 모서리 |
| `background-color` | `rgba(5, 19, 16, 0.3)` | `SolidColorBrush Color="#4D051310"` | 반투명 배경 |
| `box-shadow` | `5px 5px 20px rgb(...)` | `DropShadowEffect BlurRadius="20"` | 글로우 효과 |
| `transform: scale()` | `0.9` | `ScaleTransform` | 호버 시 축소 |
| `@keyframes glow` | 무한 반복 | `ColorAnimationUsingKeyFrames` + `RepeatBehavior="Forever"` | 색상 애니메이션 |
| `transition` | `0.5s` | `Duration="0:0:0.5"` | 전환 시간 |
| `::after` (checked) | 흰색 원 | `Ellipse` + Opacity 애니메이션 | 체크 표시 |

## 주요 특징

1. **네온 글로우 애니메이션**: 보라색(#5D34A8)과 청록색(#51E0D2) 사이를 1초 주기로 반복
2. **호버 효과**: 마우스 오버 시 0.9배 축소 및 배경색 변경
3. **체크 상태**: 클릭 시 내부에 흰색 원 표시

## 프로젝트 구조

```
GoodQuail97/
├── Wpf/
│   ├── GoodQuail97.Wpf.slnx
│   ├── GoodQuail97.Wpf.UI/
│   │   ├── Controls/
│   │   │   └── GoodQuail97.cs
│   │   └── Themes/
│   │       ├── Generic.xaml
│   │       ├── GoodQuail97.xaml
│   │       └── GoodQuail97Resources.xaml
│   └── GoodQuail97.Wpf.Gallery/
│       ├── App.xaml
│       └── MainWindow.xaml
└── AvaloniaUI/
    └── (예정)
```
