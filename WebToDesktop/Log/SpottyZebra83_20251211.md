# SpottyZebra83 변환 로그

## 변환 일시
2025-12-11

## 원본 정보
- 원작자: gharsh11032000
- 원본 링크: https://uiverse.io/gharsh11032000/spotty-zebra-83
- 컨트롤 유형: Tooltips

## 컴파일 에러

### 에러 1: StackPanel.Spacing 속성 미지원

**에러 내용:**
```
MC3072: XML 네임스페이스 'http://schemas.microsoft.com/winfx/2006/xaml/presentation'에 'Spacing' 속성이 없습니다.
```

**원인:**
- WPF의 StackPanel은 Spacing 속성을 지원하지 않음
- Avalonia UI에서는 지원하지만 WPF에서는 미지원

**수정 방법:**
- `Spacing="40"` 대신 각 자식 요소에 `Margin="0,0,0,40"` 적용

**수정 전:**
```xml
<StackPanel Spacing="40">
    <controls:SpottyZebra83 ... />
    <controls:SpottyZebra83 ... />
</StackPanel>
```

**수정 후:**
```xml
<StackPanel>
    <controls:SpottyZebra83 ... Margin="0,0,0,40" />
    <controls:SpottyZebra83 ... Margin="0,0,0,40" />
    <controls:SpottyZebra83 ... />
</StackPanel>
```

## Runtime Error 가능성 (직접 확인 필요)

### 1. 툴팁 클리핑 가능성
- 툴팁이 컨트롤 상단에 표시되므로, 부모 컨테이너에 `ClipToBounds="True"`가 설정되어 있으면 툴팁이 잘릴 수 있음
- 해결: 부모 컨테이너의 ClipToBounds를 False로 설정하거나 충분한 Margin 확보

### 2. 애니메이션 타이밍 차이
- CSS의 `cubic-bezier(0.23, 1, 0.32, 1)` 이징을 WPF의 `CubicEase EaseOut`으로 대체
- 정확한 베지어 곡선이 아니므로 미세한 애니메이션 느낌 차이 가능

### 3. transform-origin 차이
- CSS의 `transform-origin: -100%` 같은 값은 WPF에서 정확히 구현하기 어려움
- `RenderTransformOrigin="0,0.5"` 등으로 유사하게 구현했으나 완벽히 동일하지 않을 수 있음

## 생성된 파일 목록

### UI 라이브러리 (SpottyZebra83.Wpf.UI)
- `Controls/SpottyZebra83.cs` - CustomControl 클래스
- `Themes/SpottyZebra83Resources.xaml` - 테마 리소스 (색상, 크기, 이징)
- `Themes/SpottyZebra83.xaml` - 스타일 및 ControlTemplate
- `Themes/Generic.xaml` - 리소스 딕셔너리 병합

### Gallery 애플리케이션 (SpottyZebra83.Wpf.Gallery)
- `MainWindow.xaml` - 컨트롤 데모 화면
- `App.xaml` - 리소스 딕셔너리 참조

## CSS → WPF 변환 매핑

| CSS 속성 | WPF 구현 |
|---------|---------|
| `transition: all 0.4s cubic-bezier(...)` | `DoubleAnimation Duration="0:0:0.4"` + `CubicEase EaseOut` |
| `transform: scale(0)` | `ScaleTransform ScaleX="0" ScaleY="0"` |
| `transform: translateX(-50%)` | `TranslateTransform X="-90"` (하드코딩) |
| `opacity: 0` → `opacity: 1` | `DoubleAnimation Opacity` |
| `box-shadow` | `DropShadowEffect` |
| `border-radius: 8px` | `CornerRadius="8"` |
| `@keyframes shake` | `DoubleAnimationUsingKeyFrames` |
| `position: absolute` | `Grid` 내 요소 배치 |
| `z-index` | XAML 선언 순서 또는 `Panel.ZIndex` |
| `::before` (화살표) | `Polygon` 요소 |
