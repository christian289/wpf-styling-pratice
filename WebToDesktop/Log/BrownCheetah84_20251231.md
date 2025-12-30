# BrownCheetah84 변환 로그

## 변환 일시
2025-12-31

## 원본 정보
- 원작자: elijahgummer
- 원본 링크: https://uiverse.io/elijahgummer/brown-cheetah-84
- 카테고리: Patterns

## 빌드 결과
**성공** - 경고 0개, 오류 0개

## 컴파일 에러
없음

## 에러 수정 내용
해당 없음 (빌드 성공)

## 런타임 에러 가능성 (직접 확인 필요)

### 1. 패턴 렌더링 정확도
- **위치**: `BrownCheetah84.xaml` - DrawingBrush 패턴
- **가능성**: 낮음
- **설명**: CSS의 45도/-45도 linear-gradient 조합을 DrawingBrush의 PathGeometry로 변환했습니다.
  - CSS에서는 두 개의 대각선 그라데이션이 겹쳐져서 체크무늬 패턴을 생성
  - WPF에서는 4개의 삼각형 GeometryDrawing으로 동일한 효과를 재현
  - 패턴의 시각적 결과가 원본 CSS와 약간 다를 수 있음

### 2. Opacity 적용 방식
- **위치**: `BrownCheetah84.xaml` - 패턴 레이어 Border
- **가능성**: 낮음
- **설명**: CSS의 `opacity: 0.8`은 WPF Border의 Opacity 속성으로 변환했습니다.
  - 원본 CSS는 ::before pseudo-element에 opacity 적용
  - WPF에서는 패턴을 감싸는 Border에 동일한 opacity 적용
  - 렌더링 결과는 동일해야 하나, 성능 측면에서 차이가 있을 수 있음

### 3. 패턴 크기 고정
- **위치**: `BrownCheetah84.xaml` - DrawingBrush Viewport
- **가능성**: 없음
- **설명**: CSS의 `background-size: 20px 20px`을 WPF DrawingBrush의 Viewport="0,0,20,20"과 ViewportUnits="Absolute"로 구현했습니다.
  - 패턴 크기가 20px로 고정되어 원본과 동일하게 타일링됨

## CSS → WPF 변환 매핑

| CSS 속성 | CSS 값 | WPF 구현 |
|---------|--------|----------|
| `background` | `#f0f0f0` | `SolidColorBrush` (Border.Background) |
| `background` (pattern) | `linear-gradient(45deg, ...)` | `DrawingBrush` + `PathGeometry` |
| `background-size` | `20px 20px` | `Viewport="0,0,20,20"` + `ViewportUnits="Absolute"` |
| `opacity` | `0.8` | `Border Opacity="0.8"` |
| `::before` | pseudo-element | Grid 내 별도 Border 레이어 |
| `position: absolute` | 전체 영역 채움 | Grid 기본 동작 (Stretch) |

## 생성된 파일 목록

### UI 라이브러리 (BrownCheetah84.Wpf.UI)
- `Controls/BrownCheetah84.cs` - 커스텀 컨트롤 클래스
- `Themes/BrownCheetah84Resources.xaml` - 테마 리소스 (색상, 크기)
- `Themes/BrownCheetah84.xaml` - 컨트롤 스타일 및 템플릿
- `Themes/Generic.xaml` - ResourceDictionary 병합

### Gallery 애플리케이션 (BrownCheetah84.Wpf.Gallery)
- `App.xaml` - 리소스 딕셔너리 참조
- `MainWindow.xaml` - 컨트롤 데모
