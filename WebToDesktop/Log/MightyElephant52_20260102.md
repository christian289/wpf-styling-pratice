# MightyElephant52 변환 로그

## 변환 일시
2026-01-02

## 원본 정보
- 원작자: vinodjangid07
- 원본 링크: https://uiverse.io/vinodjangid07/mighty-elephant-52
- 카테고리: Tooltips

## 빌드 에러 수정

### 에러 1: StackPanel.Spacing 속성 미지원

**에러 내용:**
```
error MC3072: XML 네임스페이스 'http://schemas.microsoft.com/winfx/2006/xaml/presentation'에 'Spacing' 속성이 없습니다.
```

**원인:**
WPF의 StackPanel은 Avalonia와 달리 Spacing 속성을 지원하지 않습니다.

**수정 방법:**
각 자식 요소에 개별적으로 Margin 속성을 적용하여 간격을 설정합니다.

```xml
<!-- 수정 전 -->
<StackPanel Spacing="30">
    <controls:MightyElephant52/>
</StackPanel>

<!-- 수정 후 -->
<StackPanel>
    <controls:MightyElephant52 Margin="0,0,0,30"/>
</StackPanel>
```

## 잠재적 런타임 오류

### 1. Tooltip 위치 문제 (가능성: 중간)
- **설명:** Tooltip이 버튼 상단에 고정 Margin(30px)으로 배치되어 있어, 컨트롤 크기가 변경되면 위치가 맞지 않을 수 있습니다.
- **권장 조치:** 실제 실행하여 Tooltip 위치 확인 필요

### 2. SVG → XAML 변환 정확도 (가능성: 낮음)
- **설명:** 원본 SVG의 `<rect rx="28.5">`가 Ellipse로 변환되었습니다. 원본과 완전히 동일한 형태가 아닐 수 있습니다.
- **권장 조치:** 시각적으로 아이콘 형태 확인 필요

### 3. Tooltip Arrow 클리핑 (가능성: 낮음)
- **설명:** Tooltip 하단의 화살표(회전된 Border)가 부모 Border에 의해 클리핑될 수 있습니다.
- **권장 조치:** 실행 후 Tooltip 화살표 표시 확인 필요

## 생성된 파일

| 파일 | 설명 |
|------|------|
| `Controls/MightyElephant52.cs` | CustomControl 클래스 (TooltipText DependencyProperty 포함) |
| `Themes/MightyElephant52Resources.xaml` | 색상, 크기, Geometry 리소스 |
| `Themes/MightyElephant52.xaml` | Style 및 ControlTemplate |
| `Themes/Generic.xaml` | ResourceDictionary 병합 |

## CSS → WPF 변환 매핑

| CSS 속성 | WPF 속성 |
|----------|----------|
| `display: flex; align-items: center` | `StackPanel Orientation="Horizontal"` + `VerticalAlignment="Center"` |
| `gap: 10px` | `Margin="0,0,10,0"` (각 요소에 개별 적용) |
| `border-radius: 12px` | `CornerRadius="12"` |
| `transition: all 0.3s` | `Storyboard Duration="0:0:0.3"` |
| `opacity: 0` → `opacity: 1` | `DoubleAnimation Storyboard.TargetProperty="Opacity"` |
| `transform: translateX(-50%)` | `HorizontalAlignment="Center"` |
| `position: absolute; top: 0` | Grid 레이아웃 + `VerticalAlignment="Top"` |
| `::before` (회전 사각형) | 별도 Border + RotateTransform |
| `:hover` | `Trigger Property="IsMouseOver" Value="True"` |
