# LovelyBulldog50 변환 로그

## 변환 일시
2025-12-28

## 원본 정보
- 원작자: sonusng
- 원본: [uiverse.io/sonusng/lovely-bulldog-50](https://uiverse.io/sonusng/lovely-bulldog-50)
- 카테고리: Inputs

## 컴파일 에러

### 에러 1: StackPanel.Spacing 속성 없음

**에러 메시지:**
```
error MC3072: XML 네임스페이스 'http://schemas.microsoft.com/winfx/2006/xaml/presentation'에 'Spacing' 속성이 없습니다.
```

**원인:**
WPF의 `StackPanel`은 `Spacing` 속성을 지원하지 않습니다. `Spacing`은 AvaloniaUI와 UWP/WinUI에서만 사용 가능합니다.

**수정 방법:**
`StackPanel`에서 `Spacing="20"` 속성을 제거하고, 각 자식 요소에 `Margin="0,0,0,20"`을 적용했습니다.

**수정 전:**
```xml
<StackPanel Spacing="20">
    <controls:LovelyBulldog50 PlaceholderText="Your Name" />
    <controls:LovelyBulldog50 PlaceholderText="Email Address" />
</StackPanel>
```

**수정 후:**
```xml
<StackPanel>
    <controls:LovelyBulldog50 PlaceholderText="Your Name" Margin="0,0,0,20" />
    <controls:LovelyBulldog50 PlaceholderText="Email Address" Margin="0,0,0,20" />
</StackPanel>
```

## 잠재적 Runtime Error

### 1. Shake 애니메이션 KeyTime 백분율 형식
- **위치:** `LovelyBulldog50.xaml` - `DoubleAnimationUsingKeyFrames`
- **설명:** CSS의 `@keyframes`에서 `0%`, `25%`, `75%`, `100%` 형식의 KeyTime을 사용했습니다. WPF에서 백분율 KeyTime이 정상적으로 작동하는지 런타임에서 확인이 필요합니다.
- **확인 필요:** 애니메이션이 로드 시 3회 실행되는지 테스트 필요

### 2. TranslateTransform 애니메이션 Property Path
- **위치:** `LovelyBulldog50.xaml`
- **설명:** `(UIElement.RenderTransform).(TranslateTransform.X)` Property Path를 사용했습니다. RenderTransform이 정확히 `TranslateTransform` 타입이 아니면 런타임 에러가 발생할 수 있습니다.
- **완화 조치:** Style에서 RenderTransform을 명시적으로 `TranslateTransform`으로 설정함

### 3. IsValid 상태 트리거
- **위치:** `LovelyBulldog50.xaml` - `ControlTemplate.Triggers`
- **설명:** 텍스트 입력 시 `IsValid` 속성이 `true`로 변경되어 border 색상이 빨간색에서 녹색으로 바뀌어야 합니다.
- **확인 필요:** `OnTextChanged` 이벤트에서 `IsValid` 속성 변경이 UI에 즉시 반영되는지 테스트 필요
