# NervousZebra0 변환 로그

## 변환 일자
2025-12-18

## 원본 정보
- **원작자**: WittyHydra
- **원본 링크**: https://uiverse.io/WittyHydra/nervous-zebra-0
- **태그**: notification

## 빌드 결과
**성공** - 경고 0개, 오류 0개

## 컴파일 에러
없음

## 잠재적 Runtime Error 가능성

### 1. CSS rotateX 애니메이션 → WPF ScaleY 대체
- **원본 CSS**: `transform: rotateX(90deg)` → `transform: rotateX(0deg)`
- **WPF 구현**: `ScaleY` 0 → 1 애니메이션으로 대체
- **이유**: WPF는 3D rotateX를 직접 지원하지 않음. ScaleY로 유사한 시각 효과 구현
- **확인 필요**: 애니메이션 효과가 원본과 다를 수 있음

### 2. CSS hover transition → WPF ColorAnimation
- **원본 CSS**: `.notification:hover` 배경색/전경색 전환
- **WPF 구현**: `EventTrigger` + `ColorAnimation`으로 구현
- **확인 필요**: 애니메이션 타이밍이 원본과 약간 다를 수 있음

### 3. Button hover scale transform
- **원본 CSS**: `transform: scale(1.1)` on `:hover`
- **WPF 구현**: `Trigger.EnterActions`/`ExitActions`로 `ScaleTransform` 애니메이션
- **확인 필요**: 버튼 호버 시 스케일 애니메이션 동작 확인 필요

### 4. DropShadowEffect 위치
- **원본 CSS**: `box-shadow: 0 8px 24px rgba(0, 0, 0, 0.2)`
- **WPF 구현**: `DropShadowEffect` (Direction=270, ShadowDepth=8, BlurRadius=24)
- **확인 필요**: 그림자가 잘리거나 잘못 표시될 수 있음 (ClipToBounds 영향)

## CSS → WPF 변환 매핑

| CSS 속성 | WPF 구현 |
|---------|---------|
| `--bg-color: #c3daf6` | `SolidColorBrush` StaticResource |
| `width: 300px` | `Width="300"` |
| `height: 100px` | `Height="100"` |
| `border-radius: 10px` | `CornerRadius="10"` |
| `box-shadow` | `DropShadowEffect` |
| `overflow: hidden` | `ClipToBounds="True"` |
| `position: absolute` (top/bottom sections) | `Grid.Row` 구분 |
| `transform: translateY(-100%)` | `TranslateTransform.Y="-50"` |
| `animation: slide-down 1s` | `DoubleAnimation` Duration="0:0:1" |
| `animation: rotate-text 1s` | `DoubleAnimation` (ScaleY) |
| `text-transform: uppercase` | TextBlock CharacterCasing (미구현, 수동 대문자 입력) |
| `letter-spacing: 2px` | TextBlock CharacterSpacing (미구현) |
| `display: flex; align-items: center` | `HorizontalAlignment/VerticalAlignment` |
| `justify-content: space-between` | `Grid` with `ColumnDefinitions` |
| `transition: all 0.3s` | `ColorAnimation`/`DoubleAnimation` Duration="0:0:0.3" |
| `transform: scale(1.1)` | `ScaleTransform` 애니메이션 |

## 생성된 파일 목록

```
NervousZebra0/Wpf/
├── NervousZebra0.Wpf.slnx
├── NervousZebra0.Wpf.Gallery/
│   ├── NervousZebra0.Wpf.Gallery.csproj
│   ├── App.xaml
│   ├── App.xaml.cs
│   ├── MainWindow.xaml
│   └── MainWindow.xaml.cs
└── NervousZebra0.Wpf.UI/
    ├── NervousZebra0.Wpf.UI.csproj
    ├── Controls/
    │   └── NervousZebra0.cs
    ├── Themes/
    │   ├── Generic.xaml
    │   ├── NervousZebra0.xaml
    │   └── NervousZebra0Resources.xaml
    └── Properties/
        └── AssemblyInfo.cs
```
