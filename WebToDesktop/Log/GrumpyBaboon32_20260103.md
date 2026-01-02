# GrumpyBaboon32 변환 로그

## 변환 일시

2026-01-03

## 컴파일 에러

없음 - 빌드 성공

## 수정 사항

해당 없음

## 잠재적 런타임 에러 가능성

### 1. 패턴 크기 바인딩 미적용

**상황**: `PatternSize` DependencyProperty를 정의했으나, XAML에서 `DrawingBrush`의 `Viewport`와 `Viewbox` 값이 고정값(50x50)으로 설정됨

**영향**: `PatternSize` 속성을 변경해도 실제 패턴 크기가 변경되지 않음

**해결 방안**: Converter를 사용하여 `PatternSize` 값을 `Viewport`/`Viewbox`에 바인딩하거나, 코드 비하인드에서 동적으로 업데이트 필요

### 2. CSS 그라데이션 정확도 차이

**상황**: CSS의 복잡한 multi-stop gradient 조합을 단순화된 `LineGeometry`와 `EllipseGeometry`로 변환

**영향**: 원본 CSS와 시각적 차이가 있을 수 있음. 특히:
- CSS의 `71%-79%` 구간 그라데이션이 WPF에서 단색 라인으로 표현됨
- `radial-gradient`의 35%-37% 경계가 명확한 원으로 표현됨

**해결 방안**: 더 정확한 재현이 필요할 경우 `RadialGradientBrush`와 `LinearGradientBrush`를 사용한 복잡한 구현 필요

### 3. 고해상도 디스플레이 대응

**상황**: 타일 크기가 절대 픽셀 단위(50x50)로 고정됨

**영향**: DPI가 다른 모니터에서 패턴 밀도가 다르게 보일 수 있음

**해결 방안**: DPI 인식 스케일링 적용 또는 상대적 단위 사용 고려

## CSS → WPF 변환 요약

| CSS | WPF | 비고 |
|-----|-----|------|
| `--s: 25px` | `PatternSize` DP | 현재 XAML에 미적용 |
| `--c1: #1eaaee` | `SolidColorBrush` 리소스 | 정상 적용 |
| `--c2: #171717` | `SolidColorBrush` 리소스 | 정상 적용 |
| `linear-gradient(45deg, ...)` | `LineGeometry` | 단순화됨 |
| `linear-gradient(135deg, ...)` | `LineGeometry` | 단순화됨 |
| `radial-gradient(...)` | `EllipseGeometry` | 단순화됨 |
| 타일링 배경 | `DrawingBrush` + `TileMode="Tile"` | 정상 적용 |
