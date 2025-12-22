# FreshLizard20 변환 로그

## 변환 일시
2025-12-23

## 빌드 결과
**성공** - 경고 0개, 오류 0개

## 컴파일 에러
없음

## 수정 내용
없음 (첫 빌드에서 성공)

## 잠재적 Runtime Error 가능성

### 1. 고정 크기 클리핑
- **위치**: `FreshLizard20.xaml` - Grid.Clip
- **내용**: `RectangleGeometry Rect="0,0,200,40"` 고정 크기 사용
- **가능성**: 단어가 200px보다 길 경우 잘릴 수 있음
- **확인 필요**: 긴 단어 테스트 필요

### 2. 애니메이션 키프레임 하드코딩
- **위치**: `FreshLizard20.xaml` - DoubleAnimationUsingKeyFrames
- **내용**: Words 컬렉션의 항목 수가 5개라고 가정하고 애니메이션 값이 하드코딩됨
- **가능성**: Words 컬렉션 항목 수가 변경되면 애니메이션이 정확하지 않을 수 있음
- **확인 필요**: 동적 단어 수 지원 시 코드 수정 필요

### 3. LinearGradient 페이드 효과
- **위치**: `FreshLizard20Resources.xaml` - FreshLizard20.FadeOverlay
- **내용**: CSS의 ::after pseudo-element를 Border로 구현
- **가능성**: 투명도 블렌딩이 CSS와 약간 다를 수 있음
- **확인 필요**: 시각적 비교 테스트 필요

## 변환 매핑

| CSS | WPF |
|-----|-----|
| `--bg-color: #212121` | `SolidColorBrush` 리소스 |
| `border-radius` | `CornerRadius` |
| `display: flex` | `StackPanel Orientation="Horizontal"` |
| `overflow: hidden` | `Grid.Clip` + `RectangleGeometry` |
| `::after` pseudo-element | 별도 `Border` 오버레이 |
| `@keyframes` animation | `Storyboard` + `DoubleAnimationUsingKeyFrames` |
| `animation: 4s infinite` | `Storyboard RepeatBehavior="Forever"` |
| `transform: translateY()` | `TranslateTransform.Y` |
