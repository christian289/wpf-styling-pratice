# GiantCatfish51 변환 로그

## 변환 일시
2025-12-12

## 원본 정보
- 원작자: Siyu1017
- 원본 링크: https://uiverse.io/Siyu1017/giant-catfish-51
- 카테고리: Tooltips

## 컴파일 에러 및 수정 내역

### 에러 1: StackPanel Spacing 속성 미지원

**에러 메시지:**
```
error MC3072: XML 네임스페이스 'http://schemas.microsoft.com/winfx/2006/xaml/presentation'에 'Spacing' 속성이 없습니다. 줄 12 위치 77.
```

**원인:**
WPF의 StackPanel은 `Spacing` 속성을 지원하지 않음. 이 속성은 AvaloniaUI에서만 사용 가능.

**수정 방법:**
`Spacing="30"` 대신 각 컨트롤에 `Margin="0,0,0,30"` 적용

**수정 전:**
```xml
<StackPanel HorizontalAlignment="Center" VerticalAlignment="Center" Spacing="30">
```

**수정 후:**
```xml
<StackPanel HorizontalAlignment="Center" VerticalAlignment="Center">
    <controls:GiantCatfish51 TooltipText="Uiverse.io" Content="Tooltip" Margin="0,0,0,30"/>
    ...
</StackPanel>
```

## 잠재적 런타임 에러 (직접 확인 필요)

1. **툴팁 위치 계산**: CSS의 `transform: translateX(-50%) translateY(-100%)` 동작을 WPF에서 RenderTransformOrigin과 TranslateTransform으로 근사하였으나, 정확한 위치가 다를 수 있음

2. **화살표 위치**: `::before` pseudo-element의 정확한 위치 재현이 어려울 수 있음. 현재 `Margin="0,0,0,-5"`로 설정되어 있으나 조정 필요할 수 있음

3. **애니메이션 타이밍**: CSS `transition: all 0.2s`를 WPF Storyboard Duration="0:0:0.2"로 변환했으나, 이징 함수가 다를 수 있음

## 생성된 파일 목록

- `GiantCatfish51.Wpf.UI/Controls/GiantCatfish51.cs`
- `GiantCatfish51.Wpf.UI/Themes/GiantCatfish51Resources.xaml`
- `GiantCatfish51.Wpf.UI/Themes/GiantCatfish51.xaml`
- `GiantCatfish51.Wpf.UI/Themes/Generic.xaml` (수정됨)
- `GiantCatfish51.Wpf.Gallery/App.xaml` (수정됨)
- `GiantCatfish51.Wpf.Gallery/MainWindow.xaml` (수정됨)
