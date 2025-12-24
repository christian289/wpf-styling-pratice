# YoungBulldog90 변환 로그

**날짜**: 2025-12-25

## 컴파일 에러

### 에러 1: StackPanel.Spacing 속성 없음

**에러 메시지**:
```
MC3072: XML 네임스페이스 'http://schemas.microsoft.com/winfx/2006/xaml/presentation'에 'Spacing' 속성이 없습니다.
```

**원인**:
- WPF의 `StackPanel`은 `Spacing` 속성을 지원하지 않음
- `Spacing`은 AvaloniaUI에서만 사용 가능한 속성

**수정 방법**:
- `StackPanel`에서 `Spacing` 속성 제거
- 각 자식 요소에 개별 `Margin` 속성 적용

**수정 전**:
```xml
<StackPanel Spacing="20">
    <TextBlock ... />
    <TextBlock ... />
    <controls:YoungBulldog90 Margin="0,20,0,0" />
</StackPanel>
```

**수정 후**:
```xml
<StackPanel>
    <TextBlock ... Margin="0,0,0,10" />
    <TextBlock ... Margin="0,0,0,20" />
    <controls:YoungBulldog90 />
</StackPanel>
```

## Runtime Error 가능성

### 잠재적 이슈 1: Arc Path 렌더링

**설명**:
- CSS `border-top` + `border-right`로 만든 90도 호를 WPF `Path`와 `ArcSegment`로 구현
- 시작점 (30, 2)에서 끝점 (58, 30)까지 시계 방향 90도 호

**확인 필요**:
- 호의 시작/끝 위치가 원본 CSS와 정확히 일치하는지 확인
- 회전 중심점 (`RenderTransformOrigin="0.5,0.5"`)이 올바르게 작동하는지 확인

### 잠재적 이슈 2: 애니메이션 성능

**설명**:
- `Storyboard`가 `Loaded` 이벤트에서 시작되어 `Forever` 반복
- 컨트롤이 화면에서 벗어나도 애니메이션이 계속 실행될 수 있음

**권장 사항**:
- 성능이 중요한 시나리오에서는 `IsVisible` 속성과 연동하여 애니메이션 일시 중지 고려

## 변환 완료 파일

- `YoungBulldog90.Wpf.UI/Controls/YoungBulldog90.cs`
- `YoungBulldog90.Wpf.UI/Themes/YoungBulldog90.xaml`
- `YoungBulldog90.Wpf.UI/Themes/YoungBulldog90Resources.xaml`
- `YoungBulldog90.Wpf.UI/Themes/Generic.xaml`
- `YoungBulldog90.Wpf.Gallery/App.xaml`
- `YoungBulldog90.Wpf.Gallery/MainWindow.xaml`
