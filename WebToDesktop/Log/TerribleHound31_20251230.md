# TerribleHound31 변환 로그

## 변환 일시
2025-12-30

## 원본 정보
- 원작자: Hoseinnaqvi
- 원본 링크: https://uiverse.io/Hoseinnaqvi/terrible-hound-31
- 태그: logo, one-div, fruit

## 빌드 결과
**성공** - 경고 0개, 오류 0개

## 컴파일 에러
없음

## 런타임 에러 가능성 (직접 확인 필요)

### 1. hue-rotate 필터 미구현
- **원본 CSS**: `filter: hue-rotate(130deg);`
- **WPF 상태**: WPF에는 CSS의 hue-rotate에 해당하는 기능이 기본 제공되지 않음
- **현재 구현**: 필터 없이 원본 이모지 그대로 표시
- **영향**: 이모지 색상이 원본과 다를 수 있음

### 2. border-radius 백분율 변환
- **원본 CSS**: `border-radius: 40%` (부모 요소의 40%)
- **WPF 상태**: WPF CornerRadius는 픽셀 단위만 지원
- **현재 구현**: 300 * 0.4 = 120px로 고정값 적용
- **영향**: 컨트롤 크기 변경 시 비율이 맞지 않을 수 있음

### 3. 잎 모양 border-radius
- **원본 CSS**: `border-radius: 0 40% 0 60%`
- **WPF 상태**: 백분율 → 픽셀 변환 (90 * 0.4 = 36, 90 * 0.6 = 54)
- **영향**: 잎 크기 변경 시 비율이 맞지 않음

### 4. 잎 위치 계산
- **원본 CSS**: `top: 5%; left: 42%` (상대 위치)
- **WPF 상태**: 고정 Margin 값으로 변환 (Margin="126,-15,0,0")
- **영향**: 컨트롤 크기 변경 시 잎 위치가 부정확해질 수 있음

## CSS → WPF 변환 매핑

| CSS 속성 | WPF 속성 | 비고 |
|---------|---------|------|
| `linear-gradient(to right, red, orange)` | `LinearGradientBrush StartPoint="0,0.5" EndPoint="1,0.5"` | - |
| `border-radius: 40%` | `CornerRadius="120"` | 백분율→픽셀 변환 |
| `box-shadow: 0px 0px 10px black` | `DropShadowEffect BlurRadius="10" ShadowDepth="0"` | - |
| `::before` (z-index: -1) | `Panel.ZIndex="0"`, 먼저 선언 | - |
| `::after` | `Panel.ZIndex="1"`, 나중 선언 | - |
| `animation: txt 1s infinite alternate` | `Storyboard RepeatBehavior="Forever" AutoReverse="True"` | - |
| `opacity: 0.1 → 1` | `DoubleAnimation From="0.1" To="1"` | - |
| `filter: hue-rotate(130deg)` | 미구현 | WPF 기본 미지원 |
