# GreatDragonfly65 변환 로그 (2025-12-28)

## 에러 수정 내역

### 1. MC3072: StackPanel에 'Spacing' 속성 없음

**에러 내용:**
```
MainWindow.xaml(11,77): error MC3072: XML 네임스페이스 'http://schemas.microsoft.com/winfx/2006/xaml/presentation'에 'Spacing' 속성이 없습니다.
```

**원인:**
- WPF의 `StackPanel`은 AvaloniaUI와 달리 `Spacing` 속성을 지원하지 않음
- WPF 제한사항 참조: `wpf-limitations.md#c009`

**수정 방법:**
- `Spacing="20"` 제거
- 각 자식 요소에 `Margin` 속성으로 간격 지정
- 예: `Margin="0,0,0,20"` (아래쪽 20px 여백)

```xml
<!-- Before -->
<StackPanel Spacing="20">

<!-- After -->
<StackPanel>
    <controls:GreatDragonfly65 Margin="0,0,0,20"/>
```

## 잠재적 런타임 에러 (직접 확인 필요)

### 1. PathGeometry Clip 좌표 범위

**위치:** `GreatDragonfly65.xaml` - BeforePseudo, AfterPseudo Border.Clip

**설명:**
- CSS `clip-path: polygon()` 좌표는 백분율(0-100)로 표현됨
- WPF PathGeometry는 실제 픽셀 좌표를 사용함
- 현재 0-100 범위로 설정되어 있어 버튼 크기에 따라 클리핑이 올바르게 동작하지 않을 수 있음

**권장 확인:**
- 런타임에서 클리핑 영역이 버튼 전체를 커버하는지 확인
- 필요시 `ViewBox` 또는 `LayoutTransform`으로 스케일링 적용

### 2. hover 시 텍스트 변경

**위치:** `GreatDragonfly65.xaml` - ControlTemplate.Triggers

**설명:**
- `Trigger.Setter`로 `TextBlock.Text`를 변경하지만, 애니메이션과 동시에 발생
- 애니메이션 중 텍스트 변경이 시각적으로 어색할 수 있음

**권장 확인:**
- hover 시 텍스트 전환이 자연스러운지 확인
- 필요시 Opacity 애니메이션으로 fade 효과 추가

### 3. TransformGroup 순서

**위치:** `GreatDragonfly65.xaml` - BeforePseudo, AfterPseudo RenderTransform

**설명:**
- CSS transform 순서: `translate` → `rotate` → `skew`
- WPF TransformGroup 순서가 CSS와 다를 경우 결과가 달라질 수 있음

**권장 확인:**
- hover 애니메이션 결과가 원본 CSS와 유사한지 확인
- 필요시 TransformGroup 내 순서 조정
