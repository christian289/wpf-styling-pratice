# SeriousSeahorse3 변환 로그

## 변환 일자
2025-12-25

## 원본 정보
- 원작자: eduardojsc18
- 원본 링크: https://uiverse.io/eduardojsc18/serious-seahorse-3

## 컴파일 에러
없음 - 빌드 성공

## 수정 내용
해당 없음

## 잠재적 런타임 오류 가능성

### 1. Tooltip 위치 문제
- **증상**: Tooltip이 버튼 위가 아닌 다른 위치에 표시될 수 있음
- **원인**: Grid 내에서 TooltipContainer가 `VerticalAlignment="Top"`으로 설정되어 있어, 버튼 상단이 아닌 Grid 상단에 표시될 수 있음
- **확인 필요**: 실행 후 Tooltip 위치가 올바른지 확인 필요

### 2. Tooltip이 잘릴 수 있음
- **증상**: 버튼이 창 상단 가장자리에 있을 때 Tooltip이 잘려서 보일 수 있음
- **원인**: WPF는 CSS의 `overflow: visible`과 달리 기본적으로 부모 요소 경계를 벗어나는 콘텐츠를 클리핑함
- **해결 방안**: Popup 또는 Adorner 사용 고려

### 3. Scale 애니메이션 origin 문제
- **증상**: Tooltip이 스케일 애니메이션 시 중앙이 아닌 다른 지점에서 확대/축소될 수 있음
- **원인**: `RenderTransformOrigin="0.5,1"`이 설정되어 있지만 복합 Transform에서 예상과 다르게 동작할 수 있음
- **확인 필요**: 실행 후 애니메이션 동작 확인

## 변환 특이사항
- 원본 HTML은 Tailwind CSS 클래스를 사용하며, CSS 파일은 비어있음
- `data-tooltip` 속성의 `::after`, `::before` pseudo-element를 WPF의 StackPanel + Border + Polygon 구조로 변환
- Tailwind의 `transition-all` 애니메이션을 WPF Storyboard로 변환
