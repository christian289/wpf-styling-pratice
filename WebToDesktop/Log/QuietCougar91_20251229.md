# QuietCougar91 변환 로그

## 변환 일시
2024-12-29

## 원본 정보
- 원작자: kyle1dev
- 원본 링크: https://uiverse.io/kyle1dev/quiet-cougar-91
- 분류: Tooltips

## 빌드 결과
- **상태**: 성공
- **경고**: 0개
- **오류**: 0개

## 컴파일 에러
없음

## 잠재적 Runtime Error 가능성

### 1. VisualStateManager 상태 전환
- **위치**: `QuietCougar91.xaml` (VisualStateGroup)
- **설명**: ContentControl은 기본적으로 VisualState 전환을 지원하지 않음. 현재 구현에서는 ControlTemplate.Triggers로 IsMouseOver를 처리하고 있으나, VisualStateManager의 CommonStates (Normal, MouseOver, Pressed, Disabled)가 자동으로 트리거되지 않을 수 있음.
- **해결 방안**: Control을 상속받고 OnMouseEnter/OnMouseLeave를 오버라이드하여 VisualStateManager.GoToState()를 호출하거나, Triggers만 사용하도록 변경

### 2. Tooltip 위치 계산
- **위치**: `QuietCougar91.xaml` (PART_TooltipBorder)
- **설명**: 현재 Grid 내에서 VerticalAlignment="Top"으로 툴팁을 배치하고 있음. 버튼 크기에 따라 툴팁이 버튼과 겹칠 수 있음.
- **해결 방안**: 필요시 Margin 또는 별도의 레이아웃 조정 필요

### 3. DropShadowEffect 성능
- **위치**: `QuietCougar91Resources.xaml` (DropShadowEffect)
- **설명**: DropShadowEffect는 GPU 가속을 사용하지 않아 많은 컨트롤 사용 시 성능 저하 가능
- **해결 방안**: 성능 이슈 발생 시 Effect를 제거하거나 간소화

## CSS → WPF 변환 매핑

| CSS | WPF |
|-----|-----|
| `linear-gradient(to right, #333, #000)` | `LinearGradientBrush StartPoint="0,0.5" EndPoint="1,0.5"` |
| `box-shadow: 0 4px 8px rgba(0,0,0,0.5)` | `DropShadowEffect ShadowDepth="4" BlurRadius="8" Opacity="0.5"` |
| `border-radius: 6px` | `CornerRadius="6"` |
| `padding: 15px 30px` | `Padding="30,15"` (WPF는 좌우,상하 순서) |
| `transition: 0.4s ease` | `Duration="0:0:0.4"` + `CubicEase EasingMode="EaseOut"` |
| `transform: translateY(-10px)` | `TranslateTransform Y="-10"` |
| `transform: scale(0.95)` | `ScaleTransform ScaleX="0.95" ScaleY="0.95"` |
| `opacity: 0` → `opacity: 1` | `DoubleAnimation` Opacity 0 → 1 |
| SVG `<path d="...">` | `Geometry x:Key="...">...` + `Path Data` |
