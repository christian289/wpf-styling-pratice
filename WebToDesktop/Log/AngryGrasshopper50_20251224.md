# AngryGrasshopper50 변환 로그

## 변환 일시
2024-12-24

## 원본 정보
- 원작자: 3bdel3ziz-T
- 원본 링크: https://uiverse.io/3bdel3ziz-T/angry-grasshopper-50
- 카테고리: Checkboxes

## 컴파일 에러 및 수정 내역

### 에러 1: StackPanel.Spacing 속성 없음

**에러 메시지:**
```
MC3072: XML 네임스페이스 'http://schemas.microsoft.com/winfx/2006/xaml/presentation'에 'Spacing' 속성이 없습니다.
```

**원인:**
- WPF의 StackPanel에는 Spacing 속성이 없음
- Spacing은 AvaloniaUI나 WinUI에만 존재하는 속성

**수정 방법:**
- `Spacing="20"` 속성 제거
- 각 자식 요소에 개별 Margin 속성으로 간격 지정

**수정 전:**
```xml
<StackPanel HorizontalAlignment="Center" VerticalAlignment="Center" Spacing="20">
```

**수정 후:**
```xml
<StackPanel HorizontalAlignment="Center" VerticalAlignment="Center">
```

## 잠재적 런타임 오류

### 1. CornerRadius 애니메이션 불가
- **가능성:** 중간
- **설명:** WPF에서 CornerRadius는 직접 애니메이션할 수 없음
- **현재 구현:** Trigger의 Setter로 즉시 변경 (애니메이션 없음)
- **CSS 원본:** `transition: 300ms`로 부드럽게 변경
- **해결책:** 필요시 ObjectAnimationUsingKeyFrames 또는 DoubleAnimation으로 개별 속성 애니메이션

### 2. ColorAnimation 대상 Brush
- **가능성:** 낮음
- **설명:** ColorAnimation은 SolidColorBrush의 Color 속성을 대상으로 해야 함
- **현재 구현:** `(Border.Background).(SolidColorBrush.Color)` 경로 사용
- **확인 필요:** 런타임에 실제로 애니메이션이 동작하는지 확인 필요

## 빌드 결과
- **상태:** 성공
- **경고:** 0개
- **오류:** 0개 (수정 후)
