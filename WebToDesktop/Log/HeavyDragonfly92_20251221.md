# HeavyDragonfly92 변환 로그

## 변환 일시
2025-12-21

## 원본 정보
- 원작자: Pradeepsaranbishnoi
- 원본 링크: https://uiverse.io/Pradeepsaranbishnoi/heavy-dragonfly-92
- 카테고리: Radio-buttons

## 컴파일 에러 및 수정 내용

### 에러 1: StackPanel.Spacing 속성 미지원
- **에러 메시지**: `error MC3072: XML 네임스페이스 'http://schemas.microsoft.com/winfx/2006/xaml/presentation'에 'Spacing' 속성이 없습니다.`
- **원인**: WPF의 StackPanel은 Spacing 속성을 지원하지 않음 (AvaloniaUI와 다름)
- **수정 방법**: StackPanel의 Spacing="30" 속성을 제거하고, 개별 요소에 Margin="0,0,0,30" 적용
- **수정 파일**: `HeavyDragonfly92.Wpf.Gallery/MainWindow.xaml`

```xml
<!-- 수정 전 -->
<StackPanel HorizontalAlignment="Center" VerticalAlignment="Center" Spacing="30">

<!-- 수정 후 -->
<StackPanel HorizontalAlignment="Center" VerticalAlignment="Center">
    <controls:HeavyDragonfly92 Margin="0,0,0,30">
```

## Runtime Error 가능성 (직접 확인 필요)

### 1. Glider 애니메이션 미구현
- **설명**: CSS에서는 `transform: translateX(100%)`로 글라이더가 선택된 탭 위치로 이동하나, 현재 WPF 구현에서는 글라이더 애니메이션이 구현되지 않음
- **영향**: 시각적 효과만 영향 받음, 기능적 문제 없음
- **해결 방안**: SelectedIndex 변경 시 TranslateTransform의 X 값을 애니메이션으로 변경하는 코드 추가 필요

### 2. 탭 클릭 이벤트 미연결
- **설명**: HeavyDragonfly92Item 클릭 시 IsSelected 상태 변경 및 Selector의 SelectedIndex 업데이트 로직 미구현
- **영향**: 탭 클릭이 작동하지 않을 수 있음
- **해결 방안**: PreviewMouseLeftButtonDown 이벤트 핸들러 또는 ItemContainerGenerator 로직 추가 필요

### 3. Color 투명도 변환
- **설명**: CSS `rgba(24, 94, 224, 0.15)` → WPF `#26185EE0` (alpha=0x26, 약 15%)로 변환
- **영향**: 미세한 시각적 차이 가능

## 생성된 파일 목록

### UI 라이브러리 (HeavyDragonfly92.Wpf.UI)
- `Controls/HeavyDragonfly92.cs` - 메인 컨트롤 클래스 (Selector 상속)
- `Controls/HeavyDragonfly92Item.cs` - 탭 아이템 클래스 (ContentControl 상속)
- `Themes/HeavyDragonfly92Resources.xaml` - 색상, 크기, 애니메이션 리소스
- `Themes/HeavyDragonfly92.xaml` - 스타일 및 ControlTemplate 정의
- `Themes/Generic.xaml` - ResourceDictionary 병합

### Gallery 프로젝트 (HeavyDragonfly92.Wpf.Gallery)
- `App.xaml` - 리소스 딕셔너리 병합
- `MainWindow.xaml` - 컨트롤 데모

## CSS → WPF 변환 매핑

| CSS 속성 | CSS 값 | WPF 구현 |
|----------|--------|----------|
| `background-color` | `#fff` | `SolidColorBrush Color="#FFFFFF"` |
| `box-shadow` | `0 0 1px 0 rgba(24,94,224,0.15), 0 6px 12px 0 rgba(24,94,224,0.15)` | `DropShadowEffect BlurRadius="12" ShadowDepth="3"` |
| `padding` | `0.75rem` | `Thickness 12` |
| `border-radius` | `99px` | `CornerRadius 99` |
| `transition` | `0.15s ease-in` | `Duration="0:0:0.15"` (리소스 정의) |
| `font-weight: 500` | Medium | `FontWeight="Medium"` |
| `color` (selected) | `#185ee0` | `SolidColorBrush Color="#185EE0"` |
