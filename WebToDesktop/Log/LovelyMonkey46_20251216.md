# LovelyMonkey46 변환 로그

## 변환 일시
2025-12-16

## 원본 정보
- 원작자: csemszepp
- 원본 링크: https://uiverse.io/csemszepp/lovely-monkey-46
- 카테고리: Patterns

## 컴파일 에러 및 수정 사항

### 에러 1: MC3028 - 콘텐츠 추가 불가
**에러 메시지:**
```
'LovelyMonkey46.Wpf.UI.Controls.LovelyMonkey46' 형식의 개체에 콘텐츠를 추가할 수 없습니다.
```

**원인:**
- `Control` 클래스는 자식 콘텐츠를 허용하지 않음
- MainWindow에서 컨트롤 내부에 Grid를 배치하려고 시도

**수정 방법:**
- `Control` 대신 `ContentControl`을 상속하도록 변경
```csharp
// 변경 전
// Before
public sealed class LovelyMonkey46 : Control

// 변경 후
// After
public sealed class LovelyMonkey46 : ContentControl
```

## 잠재적 런타임 오류

### 1. DrawingBrush TileMode 성능
- 여러 개의 DrawingBrush가 TileMode로 렌더링되므로 큰 화면에서 성능 저하 가능
- 해결: 필요시 캐싱 또는 비트맵 렌더링 고려

### 2. 음수 Viewport 오프셋
- Pattern4의 Viewport="-130,-170,610,610"과 같이 음수 오프셋 사용
- WPF에서는 정상 동작하나, 일부 렌더링 환경에서 예기치 않은 동작 가능
- 직접 실행하여 확인 필요

### 3. CSS와 WPF 그라데이션 차이
- CSS `radial-gradient` 퍼센트 스톱과 WPF `RadialGradientBrush` Offset 매핑에서 미세한 차이 가능
- 원본 CSS와 비교하여 시각적 확인 필요

## 최종 빌드 결과
- 빌드 성공 (경고 0개, 오류 0개)
