# TidyVampirebat71

Checkboxes 스타일 컨트롤 - 무지개색 막대가 회전하며 나타나는 애니메이션 체크박스

## 원본 정보

- **원작자**: Uncannypotato69
- **원본 링크**: [https://uiverse.io/Uncannypotato69/tidy-vampirebat-71](https://uiverse.io/Uncannypotato69/tidy-vampirebat-71) (클릭 시 원본 CSS/HTML 확인 가능)
- **태그**: animation, checkbox, neon, rotate, css, cool checkbox, multicolor, pride-month-special

## 빌드 명령

### WPF
```bash
cd Wpf && dotnet run --project TidyVampirebat71.Wpf.Gallery
```

### AvaloniaUI
```bash
cd AvaloniaUI && dotnet run --project TidyVampirebat71.Avalonia.Gallery
```

## 컨트롤 설명

8개의 막대가 45도 간격으로 배치되어 회전 중심을 형성합니다. 체크 시:
1. 전체 컨트롤이 -360도 회전
2. 각 막대가 순차적으로 (250ms 간격) 나타남
3. 각 막대가 무지개색으로 변경
4. 마지막에 자물쇠 아이콘이 페이드 인

## CSS → WPF 변환 매핑 테이블

| CSS | WPF | 설명 |
|-----|-----|------|
| `--rotate-offset: 45deg` | `RotateTransform Angle="45"` | 8개 막대 45도씩 회전 |
| `--time-offset: 200ms` | `Duration="0:0:0.2"` | 애니메이션 지속 시간 |
| `--delay: 250ms` | `BeginTime="0:0:0.25"` | 막대 간 딜레이 |
| `transform: translateY(-1rem)` | `TranslateTransform Y="-16"` | 막대 숨김 위치 |
| `rotate(-360deg)` | `RotateTransform Angle="-360"` | 전체 회전 |
| `transition` | `DoubleAnimation` | 속성 애니메이션 |
| `transition-delay` | `BeginTime` | 시작 지연 |
| `background-color: #ffadad` | `SolidColorBrush Color="#FFADAD"` | 무지개색 |
| `border-radius: 50%` | `Ellipse` | 원형 요소 |
| `aspect-ratio: 1/1` | `Width=Height` | 정사각형 |
| `:has(:checked)` | `VisualState "Checked"` | 체크 상태 |
| `opacity: 0/1` | `Opacity="0/1"` | 자물쇠 표시 |
| `z-index` | XAML 선언 순서 | 레이어 순서 |

## 프로젝트 구조

```
TidyVampirebat71/
├── Wpf/
│   ├── TidyVampirebat71.Wpf.slnx
│   ├── TidyVampirebat71.Wpf.UI/
│   │   ├── Controls/
│   │   │   └── TidyVampirebat71.cs
│   │   └── Themes/
│   │       ├── Generic.xaml
│   │       ├── TidyVampirebat71.xaml
│   │       └── TidyVampirebat71Resources.xaml
│   └── TidyVampirebat71.Wpf.Gallery/
│       ├── App.xaml
│       └── MainWindow.xaml
└── AvaloniaUI/
    └── (미구현)
```

## 무지개 색상 팔레트

| 순서 | 색상 | HEX |
|------|------|-----|
| 1 | 연분홍 | #FFADAD |
| 2 | 살구색 | #FFD6A5 |
| 3 | 연노랑 | #FDFFB6 |
| 4 | 연두색 | #CAFFBF |
| 5 | 하늘색 | #9BF6FF |
| 6 | 연파랑 | #A0C4FF |
| 7 | 연보라 | #BDB2FF |
| 8 | 분홍색 | #FFC6FF |
