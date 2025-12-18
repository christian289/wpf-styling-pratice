# FreshFrog39

loaders 스타일 컨트롤 - 3개의 원이 순차적으로 페이드 인/아웃되는 로딩 스피너

## 원본 정보

- **원작자**: satyamchaudharydev
- **원본 링크**: [https://uiverse.io/satyamchaudharydev/fresh-frog-39](https://uiverse.io/satyamchaudharydev/fresh-frog-39) (클릭 시 원본 CSS/HTML 확인 가능)

## 빌드 명령

### WPF
```bash
cd Wpf && dotnet run --project FreshFrog39.Wpf.Gallery
```

### AvaloniaUI
```bash
cd AvaloniaUI && dotnet run --project FreshFrog39.Avalonia.Gallery
```

## 사용 가능한 속성

| 속성 | 타입 | 기본값 | 설명 |
|-----|------|-------|------|
| `DotColor` | `Brush` | `#007180` | 점의 색상 |
| `DotSize` | `double` | `20` | 각 점의 크기 (픽셀) |
| `DotGap` | `double` | `6` | 점 사이의 간격 (픽셀) |
| `IsAnimating` | `bool` | `true` | 애니메이션 실행 여부 |

## 사용 예시

```xml
<!-- 기본 사용 -->
<controls:FreshFrog39 />

<!-- 색상 변경 -->
<controls:FreshFrog39>
    <controls:FreshFrog39.DotColor>
        <SolidColorBrush Color="#e94560"/>
    </controls:FreshFrog39.DotColor>
</controls:FreshFrog39>

<!-- 크기 변경 -->
<controls:FreshFrog39 DotSize="30" DotGap="10" Width="150" Height="60"/>
```

## CSS → WPF 변환 매핑 테이블

| CSS 속성 | CSS 값 | WPF 구현 |
|---------|--------|---------|
| `--clr` (CSS 변수) | `rgb(0, 113, 128)` | `SolidColorBrush` (`#007180`) |
| `--gap` (CSS 변수) | `6px` | `Thickness.Left` via Converter |
| `width/height` (container) | `100px` | `Width/Height` DependencyProperty |
| `width/height` (dot) | `20px` | `DotSize` DependencyProperty |
| `border-radius: 100%` | 원형 | `Ellipse` 요소 |
| `display: flex` | Flexbox 레이아웃 | `StackPanel Orientation="Horizontal"` |
| `justify-content: center` | 가운데 정렬 | `HorizontalAlignment="Center"` |
| `align-items: center` | 수직 가운데 정렬 | `VerticalAlignment="Center"` |
| `gap` | 요소 간격 | `Margin` (DoubleToLeftMarginConverter) |
| `animation-delay` | `0s, 0.33s, 0.66s` | `BeginTime` 속성 |
| `animation-duration: 1s` | 애니메이션 시간 | `Duration="0:0:1"` |
| `animation: infinite` | 무한 반복 | `RepeatBehavior="Forever"` |
| `ease-in-out` | 이징 함수 | 선형 (SplineKeyFrame으로 개선 가능) |
| `@keyframes fade` | 키프레임 정의 | `DoubleAnimationUsingKeyFrames` |
| `opacity: 0 → 1` | 투명도 변화 | `SplineDoubleKeyFrame` |

## 프로젝트 구조

```
FreshFrog39/
├── Readme.md
├── Wpf/
│   ├── FreshFrog39.Wpf.slnx
│   ├── FreshFrog39.Wpf.UI/
│   │   ├── Controls/
│   │   │   ├── FreshFrog39.cs
│   │   │   └── DoubleToLeftMarginConverter.cs
│   │   ├── Themes/
│   │   │   ├── Generic.xaml
│   │   │   ├── FreshFrog39.xaml
│   │   │   └── FreshFrog39Resources.xaml
│   │   └── Properties/
│   │       └── AssemblyInfo.cs
│   └── FreshFrog39.Wpf.Gallery/
│       ├── App.xaml
│       └── MainWindow.xaml
└── AvaloniaUI/
    └── (미구현)
```
