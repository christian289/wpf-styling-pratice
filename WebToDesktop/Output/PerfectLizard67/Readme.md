# PerfectLizard67

Inputs 스타일 컨트롤 - 확장형 검색 입력창

## 원본 정보

- **원작자:** boryanakrasteva
- **원본 링크:** [https://uiverse.io/boryanakrasteva/perfect-lizard-67](https://uiverse.io/boryanakrasteva/perfect-lizard-67) (클릭 시 원본 CSS/HTML 확인 가능)

## 기능

- 축소 상태: 원형 검색 아이콘 버튼
- 확장 상태: 밑줄이 있는 텍스트 입력창으로 확장
- 포커스 시 바운스 효과와 함께 확장 애니메이션
- 포커스 해제 시 (텍스트 없으면) 축소 애니메이션

## 빌드 명령

### WPF
```bash
cd Wpf && dotnet run --project PerfectLizard67.Wpf.Gallery
```

### AvaloniaUI
```bash
cd AvaloniaUI && dotnet run --project PerfectLizard67.Avalonia.Gallery
```

## CSS → WPF 변환 매핑 테이블

| CSS | WPF |
|-----|-----|
| `width: 50px; height: 50px` | `Width="50" Height="50"` |
| `border-radius: 50%` | `CornerRadius="25"` |
| `background-color: #7e4fd4` | `Background="#7e4fd4"` (SolidColorBrush) |
| `box-shadow: 0px 0px 3px #f3f3f3` | `DropShadowEffect BlurRadius="3" ShadowDepth="0" Color="#f3f3f3"` |
| `color: #fff` | `Foreground="#FFFFFF"` |
| `::placeholder { color: #8f8f8f }` | `TextBlock Foreground="#8f8f8f"` (PART_Placeholder) |
| `transition: .5s ease-in-out` | `Storyboard Duration="0:0:0.5" QuadraticEase` |
| `transition: 500ms cubic-bezier(0, 0.110, 0.35, 2)` | `Storyboard Duration="0:0:0.5" BackEase Amplitude="0.3"` |
| `:focus { width: 250px }` | `IsExpanded Trigger → DoubleAnimation To="250"` |
| `:focus { border-radius: 0 }` | `Setter CornerRadius="0"` |
| `:focus { border-bottom: 3px solid #7e4fd4 }` | `BorderThickness="0,0,0,3" BorderBrush="#7e4fd4"` |
| `:focus { background-color: transparent }` | `Background="Transparent"` |
| `:focus { box-shadow: none }` | `Effect="{x:Null}"` |
| `font-family: 'Trebuchet MS', ...` | `FontFamily="Trebuchet MS, ..."` |
| `font-size: 17px` | `FontSize="17"` |
| SVG `<path>` | `Geometry` + `Path` |

## 프로젝트 구조

```
PerfectLizard67/
├── Wpf/
│   ├── PerfectLizard67.Wpf.slnx
│   ├── PerfectLizard67.Wpf.Gallery/     # 데모 앱
│   └── PerfectLizard67.Wpf.UI/          # 커스텀 컨트롤 라이브러리
│       ├── Controls/
│       │   └── PerfectLizard67.cs
│       └── Themes/
│           ├── Generic.xaml
│           ├── PerfectLizard67.xaml
│           └── PerfectLizard67Resources.xaml
└── AvaloniaUI/                          # (미구현)
```

## 사용 방법

```xml
<!-- 1. 네임스페이스 추가 -->
xmlns:controls="clr-namespace:PerfectLizard67.Wpf.UI.Controls;assembly=PerfectLizard67.Wpf.UI"

<!-- 2. 리소스 딕셔너리 병합 (App.xaml) -->
<ResourceDictionary Source="pack://application:,,,/PerfectLizard67.Wpf.UI;component/Themes/Generic.xaml" />

<!-- 3. 컨트롤 사용 -->
<controls:PerfectLizard67 />
```

## 커스터마이징 가능한 속성

| 속성 | 타입 | 기본값 | 설명 |
|-----|------|-------|------|
| `CollapsedWidth` | `double` | 50 | 축소 상태 너비 |
| `ExpandedWidth` | `double` | 250 | 확장 상태 너비 |
| `IsExpanded` | `bool` | false | 확장 여부 (읽기 전용 권장) |
