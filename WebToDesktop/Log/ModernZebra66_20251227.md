# ModernZebra66 변환 로그

## 변환 정보

- **변환 일시**: 2025-12-27
- **원본**: HTML/CSS (uiverse.io by csemszepp)
- **대상**: WPF CustomControl

## 컴파일 에러 및 수정

### 에러 1: XML 주석 내 `--` 문자 오류

**에러 내용**:
```
ModernZebra66.xaml(134,73): error MC3000: 'An XML comment cannot contain '--',
and '-' cannot be the last character. Line 134, position 73.' XML이 잘못되었습니다.
```

**원인**:
- XML 주석 내에 CSS 변수 표기법 `--s`가 포함됨
- XML 규격상 주석 내에 `--` 연속 문자가 허용되지 않음

**수정 방법**:
- `var(--s)` → `var([s])` 형식으로 변경
- CLAUDE.md의 wpf-limitations 가이드에 따라 CSS 변수 주석 시 `--` 제거

**수정 전**:
```xml
<!-- CSS의 calc(0.5 * var(--s)) 오프셋 시뮬레이션 -->
```

**수정 후**:
```xml
<!-- CSS의 calc(0.5 * var([s])) 오프셋 시뮬레이션 -->
```

## 잠재적 런타임 오류

### 1. DrawingBrush 타일 패턴 정확도

**가능성**: 중간

**설명**:
- CSS `repeating-conic-gradient`는 WPF에서 직접 지원되지 않음
- `DrawingBrush` + `PathGeometry`로 구현했으나 원본 CSS와 시각적 차이가 있을 수 있음
- 특히 30도 회전과 오프셋 적용 시 경계선 정렬이 원본과 다를 수 있음

**확인 필요 사항**:
- 실제 실행 시 패턴이 올바르게 타일링되는지 확인
- 경계선에서 이음새가 보이는지 확인

### 2. Viewport/Viewbox 단위 호환성

**가능성**: 낮음

**설명**:
- `ViewportUnits="Absolute"`와 `ViewboxUnits="Absolute"` 사용
- 다양한 DPI 환경에서 스케일링 문제 발생 가능

**확인 필요 사항**:
- 고해상도 디스플레이에서 패턴 크기 확인

## CSS → WPF 변환 매핑

| CSS 속성 | WPF 구현 |
|---------|---------|
| `repeating-conic-gradient` | `DrawingBrush` + `GeometryDrawing` |
| `from 30deg` | `RotateTransform Angle="30"` |
| `calc(0.5 * var([s]))` offset | `TranslateTransform X="50" Y="43.3"` |
| CSS 변수 `--c1, --c2, --c3` | `SolidColorBrush` 리소스 |
| `background-size: var([s]) calc(var([s]) * 0.577)` | `Viewport="0,0,100,86.6"` |
