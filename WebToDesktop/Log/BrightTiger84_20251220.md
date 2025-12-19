# BrightTiger84 변환 로그

## 변환 일시
2025-12-20

## 컴파일 에러 수정 내역

### Error 1: StackPanel.Spacing 속성 미지원

**에러 메시지:**
```
error MC3072: XML 네임스페이스 'http://schemas.microsoft.com/winfx/2006/xaml/presentation'에 'Spacing' 속성이 없습니다.
```

**원인:**
- WPF의 StackPanel은 `Spacing` 속성을 지원하지 않음
- AvaloniaUI에서는 지원하지만 WPF에서는 각 요소에 `Margin`을 적용해야 함

**수정 방법:**
- `Spacing="30"` 속성 제거
- 각 자식 요소에 `Margin` 속성으로 간격 조절

```xml
<!-- Before -->
<StackPanel Spacing="30">

<!-- After -->
<StackPanel>
    <TextBlock Margin="0,0,0,15" />
    <TextBlock Margin="0,0,0,30" />
    <StackPanel Margin="0,0,0,30" />
</StackPanel>
```

## Runtime Error 가능성

### 잠재적 이슈 1: Path Geometry 렌더링
- SVG Path 데이터가 복잡한 경우 WPF에서 렌더링 이슈가 발생할 수 있음
- 현재 Thumbs Up 아이콘의 Path 데이터는 표준적인 형태이므로 문제 없을 것으로 예상
- **확인 필요:** 직접 실행하여 아이콘 렌더링 상태 확인

### 잠재적 이슈 2: 애니메이션 성능
- `ScaleTransform`과 `RotateTransform`을 동시에 애니메이션하는 경우 성능 이슈 가능
- 현재 구현은 간단한 변환만 사용하므로 문제 없을 것으로 예상
- **확인 필요:** 다수의 컨트롤 인스턴스 사용 시 성능 테스트

## CSS → WPF 변환 매핑

| CSS | WPF |
|-----|-----|
| `fill: #666` | `SolidColorBrush` |
| `fill: #2196F3` | `SolidColorBrush` (Checked 상태) |
| `transition: all 0.3s` | `Storyboard` + `DoubleAnimation` Duration="0:0:0.3" |
| `transform: scale(1.1) rotate(-10deg)` | `ScaleTransform` + `RotateTransform` |
| `input:checked ~ svg` | `Trigger Property="IsChecked" Value="True"` |
| `svg:hover` | `Trigger Property="IsMouseOver" Value="True"` |
