# TidyVampirebat71 변환 로그

## 변환 정보
- 변환일: 2026-01-04
- 원본: HTML/CSS (uiverse.io)
- 타겟: WPF CustomControl

## 컴파일 에러 및 수정 내용

### 에러 1: StackPanel.Spacing 속성 없음
- **에러 내용**: `MC3072: XML 네임스페이스 'http://schemas.microsoft.com/winfx/2006/xaml/presentation'에 'Spacing' 속성이 없습니다.`
- **위치**: `MainWindow.xaml:11`
- **원인**: WPF StackPanel은 CSS의 `gap` 속성처럼 자식 요소 간격을 지정하는 `Spacing` 속성을 지원하지 않음 (Avalonia에서는 지원)
- **수정 방법**: 각 자식 요소에 `Margin` 속성을 개별적으로 적용
  ```xml
  <!-- Before -->
  <StackPanel Spacing="20">

  <!-- After -->
  <StackPanel>
      <TextBlock Margin="0,0,0,20" />
  ```

## 잠재적 런타임 에러 가능성

### 1. ColorAnimation 타겟 바인딩 문제
- **위험도**: 중간
- **내용**: `(Rectangle.Fill).(SolidColorBrush.Color)` 경로로 ColorAnimation을 적용할 때, Fill이 StaticResource로 바인딩된 경우 Freezable 객체 문제 발생 가능
- **확인 필요**: 실행 시 애니메이션이 제대로 동작하는지 확인

### 2. TransformGroup 내 TranslateTransform 애니메이션
- **위험도**: 낮음
- **내용**: TransformGroup 내부의 TranslateTransform에 애니메이션을 적용할 때 Property Path가 복잡해질 수 있음
- **현재 구현**: 직접 x:Name으로 지정하여 해결

### 3. RenderTransformOrigin 계산
- **위험도**: 낮음
- **내용**: CSS의 `transform-origin: 50% 500%`와 WPF의 `RenderTransformOrigin`은 계산 방식이 다름
- **현재 구현**: Nut 요소에 `RenderTransformOrigin="0.5,9"`로 근사 적용

## 변환 시 CSS → WPF 대응 매핑

| CSS 속성 | WPF 구현 |
|---------|---------|
| `rotate: 45deg` | `RotateTransform Angle="45"` |
| `translateY(-1rem)` | `TranslateTransform Y="-16"` |
| `transition-delay` | `Storyboard BeginTime` |
| `aspect-ratio: 1/1` | 명시적 Width/Height 동일값 |
| `border-radius: 50%` | `Ellipse` 또는 `CornerRadius` |
| `:checked` 상태 | `VisualState "Checked"` |
