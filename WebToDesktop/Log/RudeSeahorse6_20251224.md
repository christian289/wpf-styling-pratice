# RudeSeahorse6 변환 로그

## 변환 일시
2024-12-24

## 원본 정보
- 원작자: Javierrocadev
- 원본 링크: https://uiverse.io/Javierrocadev/rude-seahorse-6
- 분류: Tooltips

## 컴파일 결과
**빌드 성공** - 경고 0개, 오류 0개

## 에러 수정 내역
컴파일 에러 없음

## 런타임 오류 가능성

### 1. Style.Triggers의 EventTrigger 경고
- **위치**: `RudeSeahorse6.xaml` - Style.Triggers 섹션
- **문제**: Style.Triggers 내의 EventTrigger에서 ControlTemplate 내부 요소에 대한 애니메이션 적용 시도
- **증상**: `Storyboard.TargetProperty` 경로가 올바르지 않아 런타임에 애니메이션이 적용되지 않을 수 있음
- **권장 조치**: EventTrigger를 ControlTemplate.Triggers로 이동하거나, 코드 비하인드에서 애니메이션 처리

### 2. ::before/::after 요소 애니메이션 미구현
- **위치**: CSS의 `@keyframes tooltipAnimation`, `@keyframes tooltipBeforeAnimation`
- **문제**: CSS에서는 ::before 요소가 회전하고 ::after 요소가 scale 변화를 하지만, WPF 변환에서 이 무한 반복 애니메이션이 완전히 구현되지 않음
- **증상**: 툴팁 내부의 장식 요소들이 정적으로 표시됨
- **권장 조치**: ControlTemplate 내에서 Loaded EventTrigger를 추가하여 BeforeElement와 AfterElement에 대한 Storyboard 구현

### 3. CSS 그라데이션 방향 근사치
- **위치**: `RudeSeahorse6Resources.xaml`
- **문제**: CSS `linear-gradient(144deg, ...)` → WPF `StartPoint="0,0" EndPoint="0.83,0.83"`
- **증상**: 그라데이션 각도가 원본과 약간 다를 수 있음 (144° ≈ 대각선)
- **권장 조치**: 필요시 StartPoint/EndPoint 미세 조정

### 4. filter: blur 효과 차이
- **위치**: ::after 요소의 `filter: blur(8px)`
- **문제**: WPF의 BlurEffect와 CSS blur는 렌더링 방식이 다름
- **증상**: 블러 효과의 강도나 확산 범위가 원본과 다를 수 있음
- **권장 조치**: BlurEffect.Radius 값 조정

## CSS → WPF 변환 매핑

| CSS 속성 | 값 | WPF 속성 | 값 |
|----------|-----|----------|-----|
| `linear-gradient(144deg, ...)` | `#af40ff, #5b42f3 50%, #00ddeb` | `LinearGradientBrush` | `StartPoint="0,0" EndPoint="0.83,0.83"` |
| `box-shadow` | `0 2px 4px rgba(0,0,0,0.2)` | `DropShadowEffect` | `BlurRadius=4, ShadowDepth=2` |
| `filter: blur(8px)` | - | `BlurEffect` | `Radius=8` |
| `border-radius: 16px` | - | `CornerRadius` | `16` |
| `transition: all 0.3s` | - | `DoubleAnimation` | `Duration="0:0:0.3"` |
| `transform: scale(2)` | - | `ScaleTransform` | `ScaleX=2, ScaleY=2` |
| `opacity: 0` → `1` | - | `DoubleAnimation` | `To=1` |
| `padding: 0.7em 1.8em` | 12px 기준 | `Padding` | `21.6,8.4` |
| `font-weight: 700` | - | `FontWeight` | `Bold` |
| `font-weight: bolder` | - | `FontWeight` | `ExtraBold` |
