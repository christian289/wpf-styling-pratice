# SilentOtter72 변환 로그

## 변환 일시
2025-12-20

## 원본 정보
- 원작자: alexruix
- 원본 링크: https://uiverse.io/alexruix/silent-otter-72
- 카테고리: Toggle-switches

## 컴파일 에러 수정 내역

### 에러 1: StackPanel.Spacing 속성 미지원

**에러 내용:**
```
MC3072: XML 네임스페이스 'http://schemas.microsoft.com/winfx/2006/xaml/presentation'에 'Spacing' 속성이 없습니다.
```

**원인:**
- WPF의 StackPanel은 `Spacing` 속성을 지원하지 않음
- `Spacing` 속성은 Avalonia UI에서만 지원되는 속성

**수정 방법:**
- `Spacing` 속성 제거
- 각 자식 요소에 `Margin` 속성으로 간격 지정

**수정 전:**
```xml
<StackPanel Spacing="30">
    <StackPanel Orientation="Horizontal" Spacing="20">
```

**수정 후:**
```xml
<StackPanel>
    <StackPanel Orientation="Horizontal" Margin="0,0,0,30">
        <controls:SilentOtter72 Margin="20,0,0,0"/>
```

## 잠재적 런타임 오류 (직접 확인 필요)

### 1. Canvas.Top 값 미지정
- `PART_ThumbContainer`의 `Canvas.Top`이 -1로 설정됨
- Thumb이 Track 바깥으로 약간 돌출될 수 있음
- 시각적으로 의도된 동작인지 런타임에서 확인 필요

### 2. Path Geometry 렌더링
- SVG viewBox="0 0 32 32"를 WPF StreamGeometry로 변환
- 체크마크 아이콘의 크기와 위치가 원본과 다를 수 있음
- 런타임에서 시각적 확인 필요

### 3. IsChecked=True 초기 상태 애니메이션
- Checked 상태로 초기화된 컨트롤의 시각적 상태
- Trigger.EnterActions가 로드 시 실행되지 않을 수 있음
- 초기 로드 시 시각적 상태 확인 필요

## CSS → WPF 변환 매핑

| CSS | WPF |
|-----|-----|
| `width: 3.5em` | `Width="59.5"` (17px * 3.5) |
| `height: 2em` | `Height="34"` (17px * 2) |
| `border-radius: 32px` | `CornerRadius="32"` |
| `background-color: #B0B0B0` | `SolidColorBrush Color="#B0B0B0"` |
| `transition: .4s` | `ColorAnimation Duration="0:0:0.4"` |
| `transition: transform .25s ease-in-out` | `DoubleAnimation Duration="0:0:0.25" + CubicEase` |
| `transform: translateX(1.5em)` | `Canvas.Left` 애니메이션 |
| `opacity: 0/1` | `Opacity` 속성 + DoubleAnimation |
| `::before` (pseudo-element) | Ellipse 요소 |
| SVG path | Path + StreamGeometry |
