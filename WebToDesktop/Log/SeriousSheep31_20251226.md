# SeriousSheep31 변환 로그

## 변환 일시
2025-12-26

## 원본 정보
- 원작자: neerajbaniwal
- 원본 링크: https://uiverse.io/neerajbaniwal/serious-sheep-31
- 태그: radio, submit, switcher, html, css, 3d button

## 컴파일 에러
없음 - 첫 빌드에서 성공

## 수정 내용
해당 없음

## Runtime Error 가능성 (직접 확인 필요)

### 1. Neumorphism Inset Shadow 시뮬레이션
- **위치**: `NeumorphicRadioButton.xaml`, `NeumorphicRadioButtonGroup` 스타일
- **설명**: CSS의 `box-shadow: inset` 효과를 WPF에서 직접 구현할 수 없어 `DropShadowEffect`와 `LinearGradientBrush` BorderBrush를 조합하여 시뮬레이션
- **잠재적 문제**: 원본 CSS와 시각적 차이가 있을 수 있음

### 2. Animation 상태 충돌
- **위치**: `NeumorphicRadioButton.xaml`, Trigger 정의부
- **설명**: `IsMouseOver`, `IsFocused`, `IsChecked` 트리거가 동시에 활성화될 경우 Opacity 애니메이션이 충돌할 가능성
- **잠재적 문제**: 여러 상태가 동시에 활성화될 때 예상치 못한 시각적 동작

### 3. Inner Circle Transform Origin
- **위치**: `NeumorphicRadioButton.xaml`, `InnerCircle` 정의부
- **설명**: CSS의 `translate3d(0, 10%, 0)`를 고정값 `Y="2.4"`로 변환 (24px 높이의 10%)
- **잠재적 문제**: 인디케이터 크기가 변경될 경우 비율이 맞지 않을 수 있음

## CSS → WPF 변환 매핑

| CSS 속성 | WPF 구현 |
|----------|----------|
| `box-shadow: inset` | `DropShadowEffect` + `LinearGradientBrush` BorderBrush |
| `border-radius: 50%` | `Ellipse` 또는 `Border` with `CornerRadius` |
| `transition: opacity 0.2s` | `DoubleAnimation Duration="0:0:0.2"` |
| `transform: scale3d()` | `ScaleTransform` |
| `transform: translate3d()` | `TranslateTransform` |
| `::before`, `::after` | 추가 `Ellipse`/`Border` 요소 |
| `opacity: 0.6` | `Opacity="0.6"` 속성 |
