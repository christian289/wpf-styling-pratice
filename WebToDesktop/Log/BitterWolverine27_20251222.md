# BitterWolverine27 변환 로그 (2025-12-22)

## 컴파일 에러 수정

### 에러 1: StackPanel.Spacing 속성 없음

**에러 내용:**
```
error MC3072: XML 네임스페이스 'http://schemas.microsoft.com/winfx/2006/xaml/presentation'에 'Spacing' 속성이 없습니다. 줄 12 위치 77.
```

**원인:**
- WPF의 `StackPanel`은 `Spacing` 속성을 지원하지 않음
- `Spacing`은 AvaloniaUI 또는 WinUI/UWP에서만 지원됨

**수정 방법:**
- 각 자식 요소에 `Margin` 속성을 적용하여 간격을 구현
- `Margin="0,0,0,40"`으로 하단 여백 40px 추가

```xml
<!-- 수정 전 -->
<StackPanel Spacing="40">

<!-- 수정 후 -->
<StackPanel>
    <controls:BitterWolverine27 Margin="0,0,0,40"/>
```

## 런타임 에러 가능성

### 잠재적 이슈 1: Tooltip 위치 계산

**설명:**
- CSS에서는 `position: absolute`와 `top` 속성으로 Tooltip 위치를 동적으로 조정
- WPF에서는 `Margin`과 `RenderTransform`으로 구현했으나, 컨트롤 크기에 따라 위치가 달라질 수 있음

**확인 필요:**
- 다양한 텍스트 길이로 테스트하여 Tooltip 위치 확인 필요

### 잠재적 이슈 2: cubic-bezier 애니메이션 근사값

**설명:**
- CSS `cubic-bezier(0.68, -0.55, 0.27, 1.55)`를 WPF `SplineKeyFrame`으로 변환
- WPF의 KeySpline은 0~1 범위 내 값만 지원하므로, 음수/1초과 값이 있는 cubic-bezier는 정확히 재현되지 않음
- 오버슈트(overshoot) 효과가 CSS와 다르게 나타날 수 있음

**확인 필요:**
- 실행하여 애니메이션 동작 확인 필요

### 잠재적 이슈 3: 화살표(Arrow) 위치

**설명:**
- CSS에서는 `::before` pseudo-element로 화살표를 구현하고 `left: 80%`로 위치 지정
- WPF에서는 `Polygon`으로 구현했으나, Tooltip 너비에 따라 화살표 위치 조정이 필요할 수 있음

**확인 필요:**
- 실행하여 화살표 위치 확인 필요
