# NervousZebra0

Notifications 스타일 컨트롤 - Level Up 알림 UI

## 원본 정보

- **원작자:** WittyHydra
- **원본 링크:** [https://uiverse.io/WittyHydra/nervous-zebra-0](https://uiverse.io/WittyHydra/nervous-zebra-0) (클릭 시 원본 CSS/HTML 확인 가능)

## 빌드 명령

### WPF
```bash
cd Wpf && dotnet run --project NervousZebra0.Wpf.Gallery
```

### AvaloniaUI
```bash
cd AvaloniaUI && dotnet run --project NervousZebra0.Avalonia.Gallery
```

## 기능

- 상단 영역이 슬라이드 다운 애니메이션으로 나타남
- "Level Up!" 텍스트에 스케일 애니메이션 적용
- 마우스 호버 시 배경색/텍스트색 전환 애니메이션
- Next Level 버튼 호버 시 스케일 확대 효과
- 커스터마이징 가능한 속성: Title, LevelText, ButtonText
- NextLevelClick 이벤트 제공

## 사용 예시

```xml
<controls:NervousZebra0 />

<controls:NervousZebra0
    Title="Achievement Unlocked!"
    LevelText="Level 10"
    ButtonText="Continue"
    NextLevelClick="OnNextLevelClick"/>
```

## CSS → WPF 변환 매핑 테이블

| CSS 속성 | WPF 구현 |
|----------|----------|
| `width: 300px` | `Width="300"` |
| `height: 100px` | `Height="100"` |
| `border-radius: 10px` | `CornerRadius="10"` |
| `box-shadow: 0 8px 24px rgba(0,0,0,0.2)` | `DropShadowEffect` (BlurRadius=24, ShadowDepth=8) |
| `background-color: #c3daf6` | `Background="{StaticResource NervousZebra0.Background}"` |
| `transform: translateY(-100%)` | `TranslateTransform Y="-50"` |
| `animation: slide-down 1s ease-out` | `DoubleAnimation` (Duration=0:0:1, EasingFunction=QuadraticEase) |
| `animation: rotate-text 1s ease-in-out` | `DoubleAnimation` on ScaleY (0→1) |
| `transform: rotateX(90deg)` | `ScaleTransform ScaleY="0"` (2D 근사) |
| `transition: all 0.3s ease-in-out` | `ColorAnimation Duration="0:0:0.3"` |
| `:hover` 효과 | `EventTrigger RoutedEvent="MouseEnter/MouseLeave"` |
| `transform: scale(1.1)` | `ScaleTransform` with animation |
| `position: absolute; top: 0; height: 50%` | `Grid.Row="0"` in 2-row Grid |
| `display: flex; align-items: center` | `HorizontalAlignment="Center" VerticalAlignment="Center"` |
| `justify-content: space-between` | `Grid` with `ColumnDefinition Width="*"` and `Width="Auto"` |
| `font-size: 24px` | `FontSize="24"` |
| `font-weight: bold` | `FontWeight="Bold"` |
| `letter-spacing: 2px` | (WPF에서 직접 지원 안됨, TextBlock에 CharacterSpacing 없음) |
| `text-transform: uppercase` | (코드에서 Text.ToUpper() 처리 또는 수동 입력) |
| `cursor: pointer` | `Cursor="Hand"` |

## 프로젝트 구조

```
NervousZebra0/
├── Wpf/
│   ├── NervousZebra0.Wpf.slnx
│   ├── NervousZebra0.Wpf.Gallery/     # 데모 앱
│   │   ├── App.xaml
│   │   └── MainWindow.xaml
│   └── NervousZebra0.Wpf.UI/          # 커스텀 컨트롤 라이브러리
│       ├── Controls/
│       │   └── NervousZebra0.cs
│       └── Themes/
│           ├── Generic.xaml
│           ├── NervousZebra0.xaml
│           └── NervousZebra0Resources.xaml
└── AvaloniaUI/                        # (미구현)
```
