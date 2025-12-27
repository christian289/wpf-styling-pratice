# BitterMoth36

loaders 스타일 컨트롤

## 원본 정보

- **원작자**: Shoh2008
- **원본 링크**: [https://uiverse.io/Shoh2008/bitter-moth-36](https://uiverse.io/Shoh2008/bitter-moth-36) (클릭 시 원본 CSS/HTML 확인 가능)

## 빌드 명령

### WPF
```bash
cd Wpf && dotnet run --project BitterMoth36.Wpf.Gallery
```

### AvaloniaUI
```bash
cd AvaloniaUI && dotnet run --project BitterMoth36.Avalonia.Gallery
```

## CSS → WPF 변환 매핑 테이블

| CSS 속성/개념 | WPF 구현 |
|---------------|----------|
| `width: 48px; height: 48px` | `Width="48" Height="48"` |
| `border-radius: 50%` | `Ellipse` 요소 사용 |
| `position: absolute; top: 0` | `VerticalAlignment="Top"` in Grid |
| `position: absolute; bottom: 0` | `VerticalAlignment="Bottom"` in Grid |
| `background-color: #FFF` | `Fill="{StaticResource BitterMoth36.TopCircle.Background}"` |
| `background-color: #FF3D00` | `Fill="{StaticResource BitterMoth36.BottomCircle.Background}"` |
| `animation: rotation_19 1s linear infinite` | `DoubleAnimation Duration="0:0:1"` + `RepeatBehavior="Forever"` |
| `animation: scale50 1s infinite ease-in-out` | `DoubleAnimationUsingKeyFrames` + `SineEase EasingMode="EaseInOut"` |
| `animation-delay: 0.5s` | `BeginTime="0:0:0.5"` |
| `transform: rotate(360deg)` | `RotateTransform Angle="360"` |
| `transform: scale(0)` / `scale(1)` | `ScaleTransform ScaleX/ScaleY` |
| `::before`, `::after` | Grid 내 개별 Ellipse 요소로 분리 |

## 프로젝트 구조

```
BitterMoth36/
├── Readme.md
├── Wpf/
│   ├── BitterMoth36.Wpf.slnx
│   ├── BitterMoth36.Wpf.Gallery/     # 데모 애플리케이션
│   │   ├── App.xaml
│   │   ├── MainWindow.xaml
│   │   └── ...
│   └── BitterMoth36.Wpf.UI/          # 커스텀 컨트롤 라이브러리
│       ├── Controls/
│       │   └── BitterMoth36.cs
│       └── Themes/
│           ├── Generic.xaml
│           ├── BitterMoth36.xaml
│           └── BitterMoth36Resources.xaml
└── AvaloniaUI/                       # (미구현)
```

## 애니메이션 설명

이 로더는 두 개의 원이 반대 위치에서 번갈아 나타나며 회전하는 효과를 구현합니다:

1. **컨테이너 회전**: 전체 48x48 컨테이너가 1초에 360도 회전
2. **상단 원 (흰색)**: scale 0→1→0 애니메이션 (1초 주기)
3. **하단 원 (오렌지)**: 상단 원과 동일하나 0.5초 딜레이로 시작

두 원이 서로 반대 타이밍에 나타나면서 회전하는 컨테이너와 함께 시각적인 리듬감을 만들어냅니다.
