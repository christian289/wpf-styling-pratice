# SillyGrasshopper43 변환 로그

## 변환 일시
2025-12-12

## 원본 정보
- 원작자: JulioCodesSM
- 원본 링크: https://uiverse.io/JulioCodesSM/silly-grasshopper-43
- 카테고리: loaders

## 빌드 결과
**성공** - 컴파일 에러 없음

## 에러 내용
없음

## 수정 방법
해당 없음

## Runtime Error 가능성

### 1. mix-blend-mode 미지원
- **CSS**: `mix-blend-mode: multiply`
- **WPF**: WPF에서는 CSS의 `mix-blend-mode`를 직접 지원하지 않음
- **현재 구현**: 블렌드 모드 없이 단순 겹침으로 구현
- **잠재적 차이**: 원본에서는 두 원이 겹칠 때 색상이 혼합되어 보이지만, WPF에서는 앞쪽 원이 뒤쪽 원을 완전히 가림
- **해결 방안**:
  - `OpacityMask` 또는 커스텀 `Effect` 구현 필요
  - ShaderEffect를 사용하여 multiply 블렌드 구현 가능

### 2. cubic-bezier 근사값
- **CSS**: `cubic-bezier(0.77, 0, 0.175, 1)`
- **WPF**: `KeySpline="0.77,0,0.175,1"`
- **잠재적 차이**: WPF의 KeySpline은 CSS의 cubic-bezier와 동일한 방식으로 동작하므로 큰 차이 없음

### 3. 애니메이션 동기화
- **CSS**: 개별 요소가 독립적으로 애니메이션
- **WPF**: Storyboard 내에서 동시에 시작
- **잠재적 차이**: BeginTime을 사용하여 delay를 구현했으나, 정확한 타이밍이 미세하게 다를 수 있음

## 생성된 파일
```
SillyGrasshopper43.Wpf.slnx
SillyGrasshopper43.Wpf.Gallery/
├── SillyGrasshopper43.Wpf.Gallery.csproj
├── App.xaml
├── App.xaml.cs
├── MainWindow.xaml
└── MainWindow.xaml.cs
SillyGrasshopper43.Wpf.UI/
├── SillyGrasshopper43.Wpf.UI.csproj
├── Controls/
│   └── SillyGrasshopper43.cs
├── Themes/
│   ├── Generic.xaml
│   ├── SillyGrasshopper43.xaml
│   └── SillyGrasshopper43Resources.xaml
└── Properties/
    └── AssemblyInfo.cs
```

## CSS → WPF 변환 매핑

| CSS 속성 | 값 | WPF 구현 |
|---------|-----|---------|
| `width`, `height` | `50px` | `Width="50"`, `Height="50"` |
| `border-radius` | `50%` | `Ellipse` 요소 사용 |
| `position: absolute` | - | `Canvas` + `Canvas.Left/Top` |
| `background-color` | `#fc3f9e`, `#50e8f3` | `SolidColorBrush` |
| `animation-duration` | `1s` | `Duration="0:0:1"` |
| `animation-delay` | `.5s` | `BeginTime="0:0:0.5"` |
| `animation-iteration-count` | `infinite` | `RepeatBehavior="Forever"` |
| `animation-timing-function` | `cubic-bezier(0.77, 0, 0.175, 1)` | `KeySpline="0.77,0,0.175,1"` |
| `transform: scale()` | `.3` ~ `1` | `ScaleTransform` + `DoubleAnimationUsingKeyFrames` |
| `left` | `0` ~ `50px` | `Canvas.Left` + `DoubleAnimationUsingKeyFrames` |
| `mix-blend-mode` | `multiply` | 미구현 (WPF 미지원) |
