# BitterSkunk14 변환 로그

## 변환 일시
2026-01-04

## 원본 정보
- 원작자: MohamedAboSeada
- 원본 링크: https://uiverse.io/MohamedAboSeada/bitter-skunk-14
- 카테고리: Tooltips

## 빌드 결과
**성공** - 경고 0개, 오류 0개

## 컴파일 에러
없음

## 수정 내용
없음 (첫 빌드에서 성공)

## 잠재적 런타임 오류 가능성

### 1. 툴팁 위치 오프셋 문제
- **위험도**: 낮음
- **설명**: CSS `top: -110px`를 WPF `Margin="0,-135,0,0"`으로 변환하였으나, 컨테이너 크기나 툴팁 크기에 따라 정확한 위치 조정이 필요할 수 있음
- **확인 필요**: 다양한 DPI 환경에서 툴팁 위치 확인

### 2. 애니메이션 타이밍
- **위험도**: 낮음
- **설명**: CSS `transition: 300ms ease`와 `animation: HeightUP 400ms ease`를 WPF Storyboard로 변환. CSS의 easing function과 WPF의 기본 easing이 약간 다를 수 있음
- **확인 필요**: 애니메이션이 원본과 동일하게 느껴지는지 시각적 확인

### 3. 연결선(Line)과 점(Dot) 동기화
- **위험도**: 낮음
- **설명**: CSS에서는 `::before` pseudo-element로 점을 구현하고 부모 요소의 bottom을 기준으로 배치. WPF에서는 별도 Ellipse로 구현하고 Margin으로 위치 조정
- **확인 필요**: 연결선 높이 애니메이션과 점 위치가 일치하는지 확인

### 4. 버튼 클릭 이벤트 미구현
- **위험도**: 중간
- **설명**: "Got It" 버튼이 시각적으로만 구현되어 있고, 실제 클릭 이벤트 핸들링이 없음. 필요시 Button 컨트롤로 교체하거나 Command 바인딩 추가 필요
- **확인 필요**: 버튼 기능이 필요한 경우 추가 구현

## CSS → WPF 변환 매핑

| CSS 속성 | 값 | WPF 속성 | 값 |
|---------|-----|---------|-----|
| `background-color: darkgray` | Container | `SolidColorBrush` | `DarkGray` |
| `border-radius: 5px` | Container/Tooltip/Button | `CornerRadius` | `5` |
| `box-shadow: 0 3px 0 rgb(0 0 0 / 80%)` | Container | `DropShadowEffect` | `BlurRadius=0, ShadowDepth=3, Opacity=0.8` |
| `box-shadow: 0 0 10px rgb(0 0 0 / 50%)` | Tooltip | `DropShadowEffect` | `BlurRadius=10, ShadowDepth=0, Opacity=0.5` |
| `transition: 300ms ease` | Fade | `DoubleAnimation` | `Duration="0:0:0.3"` |
| `animation: HeightUP 400ms ease` | Line | `DoubleAnimation` | `Duration="0:0:0.4"` |
| `opacity: 0` → `opacity: 1` | Hover | `DoubleAnimation` | `Opacity 0→1` |
| `::before` pseudo-element | Dot | `Ellipse` | 별도 요소 |
| `font-style: oblique` | Tooltip text | `FontStyle` | `Oblique` |
