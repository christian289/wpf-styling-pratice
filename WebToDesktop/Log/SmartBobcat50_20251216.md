# SmartBobcat50 변환 로그

## 변환 일시
2025-12-16

## 원본 정보
- 원작자: KSAplay
- 원본: [uiverse.io/KSAplay/smart-bobcat-50](https://uiverse.io/KSAplay/smart-bobcat-50)
- 분류: Checkboxes (Heart Like)

## 컴파일 에러
**없음** - 빌드 성공 (경고 0개, 오류 0개)

## 런타임 오류 가능성 (직접 확인 필요)

### 1. 초기 로드 시 애니메이션 실행
- **위치**: `SmartBobcat50.xaml` - `IsChecked="False"` Trigger
- **증상**: 컨트롤이 처음 로드될 때 `IsChecked=False` 트리거가 실행되어 dislike_effect 애니메이션이 재생될 수 있음
- **원인**: WPF의 Trigger EnterActions는 초기 상태에서도 실행됨
- **해결방안**: EventTrigger와 Loaded 이벤트를 활용하거나, DataTrigger로 변경 필요

### 2. Path Geometry 렌더링
- **위치**: `SmartBobcat50Resources.xaml` - HeartPath
- **증상**: SVG 원본과 Path 모양이 약간 다를 수 있음
- **원인**: SVG path 데이터를 WPF Geometry로 변환하는 과정에서 미세한 차이 발생 가능
- **확인**: 실행하여 하트 모양이 정상적으로 표시되는지 확인 필요

### 3. ScaleTransform 애니메이션 충돌
- **위치**: `SmartBobcat50.xaml` - Hover/Checked 트리거
- **증상**: Hover 상태에서 클릭 시 두 애니메이션이 동시에 실행되어 예상치 못한 동작 가능
- **원인**: RootScaleTransform(Hover)과 HeartScaleTransform(Checked)이 별도로 동작
- **현재 설계**: 의도적으로 분리하여 병렬 실행 가능하게 구현

## CSS → WPF 변환 매핑

| CSS 속성 | WPF 구현 |
|---------|---------|
| `transform: scale()` | `ScaleTransform` + `DoubleAnimationUsingKeyFrames` |
| `animation: 400ms ease` | `Duration="0:0:0.4"` + `QuadraticEase` |
| `cursor: pointer` | `Cursor="Hand"` |
| SVG `viewBox` | `Canvas Width/Height` + `Viewbox Stretch="Uniform"` |
| SVG `path d=` | `Path Data=` (Geometry) |
| `fill: #FF5353` | `SolidColorBrush Color="#FF5353"` |
| `stroke: #FFF` | `Path.Stroke` |
| `stroke-width: 20px` | `Path.StrokeThickness="20"` |
| `:hover` | `Trigger Property="IsMouseOver"` |
| `input:checked` | `Trigger Property="IsChecked"` |
| `@keyframes` | `Storyboard` + `DoubleAnimationUsingKeyFrames` |
