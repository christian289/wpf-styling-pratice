# PopularCrab99 변환 로그

## 변환 일시
2025-12-18

## 빌드 결과
**성공** - 경고 0개, 오류 0개

## 컴파일 에러
없음

## CSS → WPF 변환 내용

### 1. 애니메이션 변환
- CSS `@keyframes move` → WPF `DoubleAnimationUsingKeyFrames`
- CSS `animation: move 4s infinite` → WPF `Storyboard RepeatBehavior="Forever"` + 4초 키프레임
- CSS `animation-delay: -1s, -2s, -3s, -4s` → 각 박스의 초기 위치와 키프레임 오프셋으로 변환

### 2. 레이아웃 변환
- CSS `position: absolute` + `transform: translate()` → WPF `TranslateTransform`
- CSS `display: flex; justify-content: center; align-items: center` → WPF `HorizontalAlignment="Center" VerticalAlignment="Center"`

### 3. 그림자 변환
- CSS `box-shadow: rgb(color) 0px 7px 29px 0px` → WPF `DropShadowEffect`
  - BlurRadius: 29
  - Direction: 270 (아래 방향)
  - ShadowDepth: 7
  - Opacity: 0.6

## 런타임 에러 가능성

### 잠재적 이슈 (직접 확인 필요)
1. **애니메이션 타이밍**: CSS의 `animation-delay`를 WPF 키프레임 오프셋으로 변환함. 각 박스가 시계방향으로 회전하도록 초기 위치와 애니메이션 순서를 조정했으나, 원본 CSS와 동일한 시각적 효과인지 확인 필요
2. **DropShadowEffect 성능**: 4개의 DropShadowEffect가 동시에 애니메이션되므로 저사양 PC에서 성능 저하 가능성

## 생성된 파일 목록
- `PopularCrab99.Wpf.UI/Controls/PopularCrab99.cs`
- `PopularCrab99.Wpf.UI/Themes/PopularCrab99Resources.xaml`
- `PopularCrab99.Wpf.UI/Themes/PopularCrab99.xaml`
- `PopularCrab99.Wpf.UI/Themes/Generic.xaml`
- `PopularCrab99.Wpf.Gallery/MainWindow.xaml`
- `PopularCrab99.Wpf.Gallery/App.xaml`
