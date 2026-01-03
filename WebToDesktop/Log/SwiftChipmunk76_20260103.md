# SwiftChipmunk76 변환 로그

## 변환 일시
2026-01-03

## 원본 정보
- **원작자**: PriyanshuGupta28
- **원본 링크**: https://uiverse.io/PriyanshuGupta28/swift-chipmunk-76
- **카테고리**: Inputs (Stars, Rating)

## 컴파일 에러 및 수정 내역

### 에러 1: StackPanel.Spacing 속성 미지원

**에러 메시지:**
```
error MC3072: XML 네임스페이스 'http://schemas.microsoft.com/winfx/2006/xaml/presentation'에 'Spacing' 속성이 없습니다.
```

**원인:**
- WPF의 StackPanel은 `Spacing` 속성을 지원하지 않음
- AvaloniaUI의 StackPanel과 혼동하여 사용

**수정 방법:**
- `Spacing` 속성을 제거하고 각 자식 요소에 `Margin` 속성으로 대체
- 예: `Spacing="30"` → 각 요소에 `Margin="0,0,0,30"` 적용

**수정 전:**
```xml
<StackPanel Spacing="30">
    <TextBlock Text="Title"/>
    <TextBlock Text="Content"/>
</StackPanel>
```

**수정 후:**
```xml
<StackPanel>
    <TextBlock Text="Title" Margin="0,0,0,30"/>
    <TextBlock Text="Content"/>
</StackPanel>
```

## 잠재적 런타임 오류

### 1. ColorAnimation 타겟 문제 (가능성: 낮음)
- **위치**: `SwiftChipmunk76.xaml` - StarButtonStyle의 Trigger EnterActions/ExitActions
- **설명**: ColorAnimation이 TextBlock의 Foreground 브러시 색상을 변경할 때, Foreground가 Frozen 상태면 애니메이션이 실패할 수 있음
- **확인 필요**: 실행 시 별의 색상 전환이 부드럽게 작동하는지 확인

### 2. HoverValue와 Value 상태 동기화 (가능성: 낮음)
- **위치**: `SwiftChipmunk76.cs` - UpdateStarStates 메서드
- **설명**: 마우스가 빠르게 움직일 때 MouseEnter/MouseLeave 이벤트가 순서대로 발생하지 않을 수 있음
- **확인 필요**: 빠른 마우스 이동 시 별 상태가 올바르게 표시되는지 확인

### 3. Template Part 누락 (가능성: 낮음)
- **위치**: `SwiftChipmunk76.cs` - OnApplyTemplate 메서드
- **설명**: PART_Star1~5가 템플릿에 정의되지 않으면 null이 됨
- **현재 상태**: 템플릿에 모든 PART가 정의되어 있으므로 문제 없음
- **확인 필요**: 커스텀 템플릿 적용 시 PART 이름 유지 필요

## CSS → WPF 변환 요약

| CSS 속성 | 값 | WPF 속성 | 값 |
|---------|-----|---------|-----|
| `display: inline-block` | - | `HorizontalAlignment` | `Left` |
| `float: right` | - | StackPanel + 순서 정렬 | 1→5 순서 배치 |
| `content: '\2605'` | ★ | TextBlock.Text | `&#x2605;` |
| `font-size: 30px` | 30px | FontSize | `30` |
| `color: #ccc` | 회색 | Foreground | `#CCCCCC` |
| `color: #6f00ff` | 보라색 | Foreground (선택/호버) | `#6F00FF` |
| `cursor: pointer` | - | Cursor | `Hand` |
| `transition: color 0.3s` | 0.3초 | ColorAnimation Duration | `0:0:0.3` |
