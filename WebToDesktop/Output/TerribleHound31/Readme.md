# TerribleHound31

Cards 스타일 컨트롤 - 과일(오렌지) 모양의 장식 컨트롤

## 원본 정보

- **원작자**: Hoseinnaqvi
- **원본 링크**: [https://uiverse.io/Hoseinnaqvi/terrible-hound-31](https://uiverse.io/Hoseinnaqvi/terrible-hound-31) (클릭 시 원본 CSS/HTML 확인 가능)
- **태그**: logo, one-div, fruit

## 미리보기

빨강→주황 그라데이션 배경의 둥근 사각형에 초록색 잎 장식과 깜빡이는 이모지 애니메이션이 적용된 과일 모양 컨트롤입니다.

## 빌드 명령

### WPF

```bash
cd Wpf && dotnet run --project TerribleHound31.Wpf.Gallery
```

### AvaloniaUI

```bash
cd AvaloniaUI && dotnet run --project TerribleHound31.Avalonia.Gallery
```

## CSS → WPF 변환 매핑 테이블

| CSS 속성 | WPF 구현 | 비고 |
|---------|---------|------|
| `linear-gradient(to right, red, orange)` | `LinearGradientBrush StartPoint="0,0.5" EndPoint="1,0.5"` | 수평 그라데이션 |
| `border-radius: 40%` | `CornerRadius="120"` | 300px * 40% = 120px |
| `box-shadow: 0px 0px 10px black` | `DropShadowEffect BlurRadius="10" ShadowDepth="0"` | 전방향 그림자 |
| `box-shadow: 0px -3px 6px rgba(...)` | `DropShadowEffect Direction="-90"` | 위쪽 방향 그림자 |
| `::before` (z-index: -1) | `Border` + `Panel.ZIndex="0"` | 요소 순서로 z-order 제어 |
| `::after` (content) | `TextBlock` + Storyboard | 이모지 텍스트 |
| `animation: 1s infinite alternate` | `RepeatBehavior="Forever" AutoReverse="True" Duration="0:0:1"` | 반복 + 역방향 애니메이션 |
| `opacity: 0.1 → 1` | `DoubleAnimation From="0.1" To="1"` | 투명도 애니메이션 |
| `filter: hue-rotate(130deg)` | 미구현 | WPF 기본 미지원 |

## 프로젝트 구조

```
TerribleHound31/
├── Readme.md
├── Wpf/
│   ├── TerribleHound31.Wpf.slnx
│   ├── TerribleHound31.Wpf.Gallery/    # 데모 앱
│   │   ├── App.xaml
│   │   └── MainWindow.xaml
│   └── TerribleHound31.Wpf.UI/         # 커스텀 컨트롤 라이브러리
│       ├── Controls/
│       │   └── TerribleHound31.cs
│       └── Themes/
│           ├── Generic.xaml
│           ├── TerribleHound31.xaml
│           └── TerribleHound31Resources.xaml
└── AvaloniaUI/                         # (예정)
```
