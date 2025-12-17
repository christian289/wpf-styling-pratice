# TastyApe73

Notifications 스타일 컨트롤 - "Level Up!" 알림에 컨페티(색종이) 애니메이션 효과가 포함된 게임 스타일 알림 컨트롤

## 원본 정보

- **원작자**: JkHuger
- **원본 링크**: [https://uiverse.io/JkHuger/tasty-ape-73](https://uiverse.io/JkHuger/tasty-ape-73) (클릭 시 원본 CSS/HTML 확인 가능)
- **카테고리**: Notifications

## 빌드 및 실행

### WPF
```bash
cd Wpf && dotnet run --project TastyApe73.Wpf.Gallery
```

### AvaloniaUI
```bash
cd AvaloniaUI && dotnet run --project TastyApe73.Avalonia.Gallery
```

## 기능

- **Scale-up 애니메이션**: 로드 시 컨트롤이 0에서 1로 스케일 업
- **컨페티 효과**: 다양한 색상과 모양의 컨페티 요소들
- **호버 애니메이션**: 마우스 오버 시 컨페티가 아래로 떨어지는 효과
- **커스텀 텍스트**: `NotificationText` 속성으로 알림 텍스트 변경 가능
- **컨페티 토글**: `ShowConfetti` 속성으로 컨페티 표시/숨김

## 속성

| 속성 | 타입 | 기본값 | 설명 |
|------|------|--------|------|
| `NotificationText` | `string` | "Level Up!" | 알림 텍스트 |
| `ShowConfetti` | `bool` | `true` | 컨페티 표시 여부 |

## CSS → WPF 변환 매핑 테이블

| CSS | WPF | 설명 |
|-----|-----|------|
| `background-color: #FDD835` | `SolidColorBrush Color="#FDD835"` | 배경색 |
| `border-radius: 10px` | `CornerRadius="10"` | 둥근 모서리 |
| `box-shadow: 0 0 10px rgba(0,0,0,0.5)` | `DropShadowEffect BlurRadius="10"` | 그림자 효과 |
| `text-shadow: 2px 2px #000` | `DropShadowEffect ShadowDepth="2"` | 텍스트 그림자 |
| `transform: scale(0)` → `scale(1)` | `ScaleTransform` + `DoubleAnimation` | 스케일 애니메이션 |
| `animation: ease-in-out` | `QuadraticEase EasingMode="EaseInOut"` | 이징 함수 |
| `transform: rotate(-140deg)` | `RotateTransform Angle="-140"` | 회전 변환 |
| `.dodecagram` (CSS border trick) | 3개 Rectangle + RotateTransform (30°, 60°) | 12각형 별 |
| `var(--bg)` (CSS 변수) | `StaticResource` | 동적 색상 참조 |
| `:hover` | `Trigger Property="IsMouseOver"` | 호버 상태 |
| `@keyframes confetti` | `Storyboard` + `DoubleAnimation` | 키프레임 애니메이션 |
| `overflow: hidden` | `Border.Clip` + `RectangleGeometry` | 클리핑 |

## 파일 구조

```
TastyApe73/
├── Readme.md
└── Wpf/
    ├── TastyApe73.Wpf.slnx
    ├── TastyApe73.Wpf.Gallery/          # 데모 앱
    │   ├── App.xaml
    │   ├── MainWindow.xaml
    │   └── ...
    └── TastyApe73.Wpf.UI/               # 컨트롤 라이브러리
        ├── Controls/
        │   └── TastyApe73.cs            # 컨트롤 클래스
        ├── Converters/
        │   ├── SizeToRectConverter.cs   # 클리핑용 컨버터
        │   └── BoolToVisibilityConverter.cs
        └── Themes/
            ├── Generic.xaml              # 리소스 딕셔너리 병합
            ├── TastyApe73.xaml           # 스타일 정의
            └── TastyApe73Resources.xaml  # 색상, 크기 등 리소스
```
