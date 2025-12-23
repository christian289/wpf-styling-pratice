# AngryGrasshopper50

Checkboxes 스타일 컨트롤 - 햄버거 메뉴 토글 버튼

## 원본 정보

- **원작자:** 3bdel3ziz-T
- **원본 링크:** [https://uiverse.io/3bdel3ziz-T/angry-grasshopper-50](https://uiverse.io/3bdel3ziz-T/angry-grasshopper-50)
- **태그:** material design, animation, checkbox, hamburger, menu, click effect, click animation, close

## 기능 설명

- 햄버거 메뉴 아이콘 (세 개의 수평 라인)
- 클릭 시 X 아이콘으로 부드럽게 변환
- 호버 시 원형 배경 및 라인 색상 변경
- 클릭 시 scale 애니메이션 효과

## 빌드 및 실행

### WPF

```bash
cd Wpf && dotnet run --project AngryGrasshopper50.Wpf.Gallery
```

### AvaloniaUI

```bash
cd AvaloniaUI && dotnet run --project AngryGrasshopper50.Avalonia.Gallery
```

## CSS → WPF 변환 매핑 테이블

| CSS 속성/선택자 | CSS 값 | WPF 구현 |
|----------------|--------|----------|
| `.burger` width/height | `40px` | `Width/Height="40"` |
| `.line` width | `25px` | `Border Width="25"` |
| `.line` height | `2.1px` | `Border Height="2.1"` |
| `border-radius` | `10px` | `CornerRadius="10"` |
| `border-radius` (hover) | `50%` | `CornerRadius="20"` |
| `transition: 300ms` | - | `Duration="0:0:0.3"` |
| `animation: 400ms` | - | `Duration="0:0:0.4"` |
| `transform: translateY(8px)` | - | `TranslateTransform Y="-8"` |
| `transform: rotate(45deg)` | - | `RotateTransform Angle="45"` |
| `::before`, `::after` | - | 추가 Border 요소 |
| `:checked` | - | `IsChecked` Trigger |
| `:hover` | - | `IsMouseOver` Trigger |
| `:active` | - | `IsPressed` Trigger |
| `scale: 0.95` | - | `ScaleTransform ScaleX/Y="0.95"` |
| `background: #aeaeae` | - | `SolidColorBrush Color="#aeaeae"` |
| `ease-out` | - | `CubicEase EasingMode="EaseOut"` |
| `@keyframes` | - | `DoubleAnimationUsingKeyFrames` |

## 프로젝트 구조

```
AngryGrasshopper50/
├── Wpf/
│   ├── AngryGrasshopper50.Wpf.slnx
│   ├── AngryGrasshopper50.Wpf.Gallery/     # 데모 앱
│   └── AngryGrasshopper50.Wpf.UI/          # 커스텀 컨트롤 라이브러리
│       ├── Controls/
│       │   └── AngryGrasshopper50.cs
│       └── Themes/
│           ├── Generic.xaml
│           ├── AngryGrasshopper50.xaml
│           └── AngryGrasshopper50Resources.xaml
└── AvaloniaUI/                              # (예정)
```
