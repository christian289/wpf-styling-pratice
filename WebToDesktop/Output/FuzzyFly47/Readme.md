# FuzzyFly47

Notifications 스타일 컨트롤 - 레벨업 알림 효과가 있는 게임 스타일 알림 배너

## 원본 정보

- **원작자**: ActiveIceDigital
- **원본 링크**: [https://uiverse.io/ActiveIceDigital/fuzzy-fly-47](https://uiverse.io/ActiveIceDigital/fuzzy-fly-47) (클릭 시 원본 CSS/HTML 확인 가능)

## 빌드 명령

### WPF
```bash
cd Wpf && dotnet run --project FuzzyFly47.Wpf.Gallery
```

### AvaloniaUI
```bash
cd AvaloniaUI && dotnet run --project FuzzyFly47.Avalonia.Gallery
```

## 컨트롤 사용법

```xml
<controls:FuzzyFly47 Message="Congratulations Champion!"
                     LevelText="Level 10"/>
```

### 속성

| 속성 | 타입 | 기본값 | 설명 |
|------|------|--------|------|
| `Message` | `string` | "Congratulations Champion!" | 알림 메시지 |
| `LevelText` | `string` | "Level 10" | 레벨 텍스트 |

## CSS → WPF 변환 매핑 테이블

| CSS | WPF | 비고 |
|-----|-----|------|
| `width: 250px` | `Width="250"` | |
| `height: 60px` | `Height="60"` | |
| `background: rgba(0, 0, 0, 0.5)` | `SolidColorBrush Color="#80000000"` | |
| `border-radius: 14px` | `CornerRadius="14"` | |
| `padding: 5px 15px` | `Padding="15,5,15,5"` | WPF는 Left,Top,Right,Bottom 순서 |
| `box-shadow: inset ...` | 중첩 `Border` + `BorderBrush` | WPF에 inset shadow 없음 |
| `box-shadow: 0px 2px 5px` | `DropShadowEffect` | |
| `text-transform: uppercase` | `Typography.Capitals="AllSmallCaps"` | |
| `font-weight: 700` | `FontWeight="Bold"` | |
| `display: flex` | `StackPanel Orientation="Horizontal"` | |
| `justify-content: center` | `HorizontalAlignment="Center"` | |
| `gap: 5px` | 각 요소에 `Margin` 적용 | WPF에 gap 없음 |
| `@keyframes ud` | `Storyboard` + `DoubleAnimationUsingKeyFrames` | |
| `animation: ud 1s ease-in-out infinite` | `RepeatBehavior="Forever"` + `SplineDoubleKeyFrame` | |
| `transform: translateY(-5px)` | `TranslateTransform Y="-5"` | |
| `opacity: 0/1` | `Opacity` 애니메이션 | |
| `ease-in-out` | `KeySpline="0.42,0,0.58,1"` | CSS cubic-bezier 등가 |

## 프로젝트 구조

```
FuzzyFly47/
├── Wpf/
│   ├── FuzzyFly47.Wpf.slnx
│   ├── FuzzyFly47.Wpf.Gallery/     # 데모 앱
│   └── FuzzyFly47.Wpf.UI/          # 커스텀 컨트롤 라이브러리
│       ├── Controls/
│       │   └── FuzzyFly47.cs
│       └── Themes/
│           ├── Generic.xaml
│           ├── FuzzyFly47.xaml
│           └── FuzzyFly47Resources.xaml
└── AvaloniaUI/                      # (예정)
```
