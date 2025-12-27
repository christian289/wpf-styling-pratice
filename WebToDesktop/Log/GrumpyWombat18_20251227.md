# GrumpyWombat18 변환 로그

## 변환 일자
2025-12-27

## 원본 정보
- **원작자**: milegelu
- **원본 링크**: https://uiverse.io/milegelu/grumpy-wombat-18
- **카테고리**: Checkboxes

## 빌드 결과
- **상태**: 성공
- **경고**: 0개
- **오류**: 0개

## 컴파일 에러 수정 내역
없음 - 첫 빌드에서 성공

## 잠재적 런타임 오류 (직접 확인 필요)

### 1. UncheckedIcon/CheckedIcon Setter에서 Path 객체 재사용 문제
- **위치**: `GrumpyWombat18.xaml` (16-33행)
- **설명**: Style의 Setter에서 Path 객체를 직접 정의하면, 여러 컨트롤 인스턴스에서 동일한 Path 객체가 공유되어 "already has a parent" 오류 발생 가능
- **증상**: 두 번째 GrumpyWombat18 컨트롤부터 아이콘이 표시되지 않거나 예외 발생
- **해결 방안**: `x:Shared="False"` 사용 또는 DataTemplate으로 래핑

### 2. Storyboard To 값의 StaticResource 바인딩
- **위치**: `GrumpyWombat18.xaml` (95-101, 109-115, 128-134행)
- **설명**: DoubleAnimation의 `To` 속성에 StaticResource 바인딩은 WPF에서 지원되지만, 일부 경우 동작하지 않을 수 있음
- **증상**: 스케일 애니메이션이 작동하지 않음
- **해결 방안**: To 값을 인라인으로 직접 지정 (예: `To="1.1"`)

### 3. Icon Width 전환 시 레이아웃 점프
- **위치**: `GrumpyWombat18.xaml` (146-151행)
- **설명**: IsChecked 상태 전환 시 Width가 0과 Auto 사이에서 급격히 변경되어 레이아웃 점프 발생 가능
- **증상**: 체크/언체크 시 컨트롤 크기가 순간적으로 변경됨
- **해결 방안**: DoubleAnimation으로 Width를 부드럽게 전환

## CSS → WPF 변환 매핑

| CSS 속성 | 값 | WPF 속성 | 값 |
|---------|-----|---------|-----|
| `--UnChacked-color` | `hsl(0, 0%, 10%)` | `SolidColorBrush` | `#1A1A1A` |
| `--chacked-color` | `hsl(216, 100%, 60%)` | `SolidColorBrush` | `#3385FF` |
| `--font-color` | `white` | `SolidColorBrush` | `White` |
| `--icon-size` | `1.5em` | `sys:Double` | `30` (FontSize 20 × 1.5) |
| `--anim-time` | `0.2s` | `Duration` | `0:0:0.2` |
| `--anim-scale` | `0.1` | `sys:Double` | `1.1` (Hover), `0.95` (Pressed) |
| `--base-radius` | `0.8em` | `CornerRadius` | `16` (FontSize 20 × 0.8) |
| `border-radius` (pressed) | `calc(var(--base-radius) * 2)` | `CornerRadius` | `32` |
| `padding` | `0.5em` | `Thickness` | `10` |
| `margin` (name) | `0 0.25em` | `Thickness` | `5,0` |
| `transform: scale()` | CSS transition | `ScaleTransform` | Storyboard 애니메이션 |
| `::before` (hover overlay) | pseudo-element | `Border` | PART_HoverOverlay |
| `display: none` | CSS visibility | `Visibility` | `Collapsed` |
| `width: 0` | CSS width | `Width` | `0` + `Hidden` |
