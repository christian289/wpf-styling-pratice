# HappyRattlesnake25 변환 로그

## 변환 정보

- **변환 날짜**: 2025-12-29
- **원본 소스**: uiverse.io by csemszepp (Afif13)
- **카테고리**: Patterns

## 빌드 결과

**빌드 성공** - 경고 0개, 오류 0개

## 컴파일 에러

없음

## CSS → WPF 변환 주요 사항

### conic-gradient 변환

원본 CSS는 `conic-gradient`를 사용하여 기하학적 패턴을 생성합니다:

```css
--_g1: conic-gradient(from -116.36deg at 25% var(--_c));
--_g2: conic-gradient(from 63.43deg at 75% var(--_c));
background: var(--_g1), var(--_g1) calc(3 * var(--s)) calc(var(--s) / 2),
  var(--_g2), var(--_g2) calc(3 * var(--s)) calc(var(--s) / 2),
  conic-gradient(...);
```

WPF에서는 `conic-gradient`를 직접 지원하지 않으므로, `DrawingBrush` + `GeometryDrawing`으로 유사한 패턴을 구현했습니다:

- 삼각형과 마름모 형태의 `PathGeometry`를 조합
- `TileMode="Tile"`로 패턴 반복
- 타일 크기: 130px x 65px (원본 CSS의 2*s x s)

### CSS 변수 → DependencyProperty 매핑

| CSS 변수 | WPF DependencyProperty | 기본값 |
|----------|------------------------|--------|
| `--s` | `TileSize` | 65 |
| `--c1` | `Color1` | #dadee1 |
| `--c2` | `Color2` | #4a99b4 |
| `--c3` | `Color3` | #9cceb5 |

## 잠재적 런타임 오류

### 1. 패턴 정확도 (직접 확인 필요)

- **문제**: CSS `conic-gradient`와 WPF `DrawingBrush` 패턴의 시각적 차이
- **원인**: WPF에서는 conic-gradient를 직접 지원하지 않아 삼각형/마름모 기하학으로 근사화
- **확인 방법**: 원본 HTML과 WPF 결과물을 나란히 비교
- **조치**: 필요 시 PathGeometry 좌표 조정

### 2. 동적 TileSize 미지원

- **문제**: 현재 구현은 고정 크기(130x65) 타일 사용
- **원인**: DrawingBrush의 Viewport가 DependencyProperty 바인딩을 지원하지만, 현재 정적 값 사용
- **조치**: TileSize 속성 변경 시 패턴이 업데이트되도록 하려면 별도 Converter 필요

### 3. 색상 속성 미연결

- **문제**: Color1, Color2, Color3 DependencyProperty가 정의되어 있으나 ControlTemplate에서 사용하지 않음
- **원인**: StaticResource로 고정 색상 참조
- **조치**: 동적 색상 변경이 필요하면 TemplateBinding 또는 별도 로직 추가 필요
