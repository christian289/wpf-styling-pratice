# SmoothChipmunk60 변환 로그

## 변환 일시
2025-12-22

## 빌드 결과
**성공** - 경고 0개, 오류 0개

## 컴파일 에러
없음

## 잠재적 런타임 에러

### 1. 애니메이션 타이밍 불일치 가능성
- **위치**: `SmoothChipmunk60.xaml` - TransformGroup 애니메이션
- **설명**: CSS에서는 `transition: transform 0.5s, width 0.5s`로 transform과 width가 동시에 애니메이션되지만, WPF에서는 TranslateTransform과 RotateTransform을 개별적으로 애니메이션. 시각적 결과가 원본과 약간 다를 수 있음.
- **권장 확인**: 실행하여 애니메이션 동작 확인 필요

### 2. TransformOrigin 해석 차이
- **위치**: Line1, Line3의 `RenderTransformOrigin`
- **설명**: CSS `transform-origin: 0 0`과 `transform-origin: 100% 0`을 WPF의 `RenderTransformOrigin="0,0.5"`와 `RenderTransformOrigin="1,0.5"`로 변환. Y축 기준점 해석이 다를 수 있음.
- **권장 확인**: X 모양이 정확히 형성되는지 확인 필요

### 3. 라인 위치 계산
- **위치**: Line1, Line2, Line3의 위치 및 크기
- **설명**: CSS에서 `width: 80%; margin: 10%`로 컨테이너를 설정하고 내부 라인의 상대 위치를 계산하지만, WPF에서는 고정 Margin(4px)과 고정 너비(16px)로 변환. 다양한 크기에서 비율이 맞지 않을 수 있음.
- **권장 확인**: 크기 변경 시 비율 유지 확인 필요

## CSS → WPF 변환 매핑

| CSS 속성 | WPF 구현 |
|---------|---------|
| `linear-gradient(45deg, ...)` | `LinearGradientBrush StartPoint="0,1" EndPoint="1,0"` |
| `box-shadow` | `DropShadowEffect` |
| `border-radius: 5px` | `CornerRadius="5"` |
| `transition: transform 0.5s` | `DoubleAnimation Duration="0:0:0.5"` |
| `transform: translate() rotate()` | `TransformGroup` (TranslateTransform + RotateTransform) |
| `input:checked + div span` | `Trigger Property="IsChecked" Value="True"` |
| `:checked` pseudo-class | `ToggleButton.IsChecked` |

## 생성된 파일 목록
- `SmoothChipmunk60.Wpf.UI/Controls/SmoothChipmunk60.cs`
- `SmoothChipmunk60.Wpf.UI/Themes/SmoothChipmunk60Resources.xaml`
- `SmoothChipmunk60.Wpf.UI/Themes/SmoothChipmunk60.xaml`
- `SmoothChipmunk60.Wpf.UI/Themes/Generic.xaml`
- `SmoothChipmunk60.Wpf.Gallery/App.xaml`
- `SmoothChipmunk60.Wpf.Gallery/MainWindow.xaml`
