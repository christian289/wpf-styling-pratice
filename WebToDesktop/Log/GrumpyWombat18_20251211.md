# GrumpyWombat18 변환 로그

## 변환 일시
2025-12-11

## 원본 정보
- 원작자: milegelu
- 원본 링크: https://uiverse.io/milegelu/grumpy-wombat-18
- 태그: blue, black, button, active, checkbox, modern, click animation

## 빌드 결과
**성공** - 경고 0개, 오류 0개

## 컴파일 에러
없음

## 잠재적 런타임 에러

### 1. Path 아이콘 공유 문제
- **위치**: `GrumpyWombat18.xaml` - UncheckedIcon/CheckedIcon Setter
- **문제**: XAML에서 Setter.Value로 정의된 Path 요소는 컨트롤 인스턴스마다 공유되어 "이미 다른 부모가 있습니다" 오류가 발생할 수 있음
- **해결 방법**: `x:Shared="False"` 를 리소스에 적용하거나, Path를 ControlTemplate 내부로 이동
- **심각도**: 높음 (여러 컨트롤 인스턴스 사용 시)

### 2. DoubleAnimation To 값 StaticResource 바인딩
- **위치**: `GrumpyWombat18.xaml` - Storyboard 애니메이션
- **문제**: WPF의 Storyboard는 Freezable이므로 StaticResource 바인딩이 런타임에 문제를 일으킬 수 있음
- **해결 방법**: 필요시 하드코딩된 값으로 변경
- **심각도**: 중간

### 3. ScaleTransform 애니메이션 충돌
- **위치**: Hover와 Pressed 트리거의 애니메이션
- **문제**: IsMouseOver가 True인 상태에서 IsPressed가 True가 되면 두 애니메이션이 충돌할 수 있음
- **해결 방법**: MultiTrigger를 사용하거나 VisualStateManager로 전환
- **심각도**: 낮음

## CSS → WPF 변환 매핑

| CSS 속성 | 값 | WPF 구현 |
|---------|-----|---------|
| `--UnChacked-color` | `hsl(0, 0%, 10%)` | `SolidColorBrush #1A1A1A` |
| `--chacked-color` | `hsl(216, 100%, 60%)` | `SolidColorBrush #3385FF` |
| `--font-color` | `white` | `SolidColorBrush White` |
| `--icon-size` | `1.5em` | `sys:Double 30` (20px * 1.5) |
| `--anim-time` | `0.2s` | `Duration 0:0:0.2` |
| `--anim-scale` | `0.1` | `sys:Double 1.1` (hover), `0.95` (pressed) |
| `--base-radius` | `0.8em` | `CornerRadius 16` |
| `border-radius` | `var(--base-radius)` | `Border.CornerRadius` |
| `transform: scale()` | hover/active | `ScaleTransform` + `DoubleAnimation` |
| `transition: all 0.2s` | - | `Storyboard` with `Duration` |
| `display: none` / `width: 0` | - | `Visibility.Collapsed` / `Width="0"` |
| `input:checked +` | - | `Trigger Property="IsChecked" Value="True"` |

## 변환 특이사항

1. **HTML checkbox → WPF ToggleButton**: HTML의 `<input type="checkbox">`를 WPF의 `ToggleButton`으로 변환하여 IsChecked 속성으로 상태 관리

2. **SVG → Geometry**: SVG path 데이터를 WPF Geometry 리소스로 변환

3. **CSS 변수 → StaticResource**: CSS 커스텀 속성(--변수)을 XAML StaticResource로 변환

4. **Pseudo-element → Overlay Border**: CSS `::before`를 XAML Grid 내부의 투명 Border로 구현

5. **아이콘 전환 방식**: CSS의 `width: 0`과 `display: none` 조합을 WPF의 `Width="0"` + `Visibility` 조합으로 변환
