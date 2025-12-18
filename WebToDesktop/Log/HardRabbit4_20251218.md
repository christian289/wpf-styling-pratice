# HardRabbit4 변환 로그

## 변환 날짜
2025-12-18

## 원본 정보
- 원작자: escannord
- 원본 링크: https://uiverse.io/escannord/hard-rabbit-4
- 카테고리: Patterns

## 컴파일 에러
없음 - 빌드 성공

## 런타임 에러 가능성 (직접 확인 필요)
- 없음

## 변환 매핑 노트

### CSS 원본
```css
.container {
  width: 100%;
  height: 100%;
  background: rgba(29, 31, 32, 0.904)
    radial-gradient(rgba(255, 255, 255, 0.712) 10%, transparent 1%);
  background-size: 11px 11px;
}
```

### WPF 변환 방법
CSS의 `radial-gradient` 도트 패턴을 WPF의 `DrawingBrush`로 구현:

1. **배경색 레이어**: `SolidColorBrush`로 rgba(29, 31, 32, 0.904) 색상 적용
2. **도트 패턴 레이어**: `DrawingBrush` + `TileMode="Tile"`로 반복 패턴 생성
3. **도트**: `EllipseGeometry`로 원형 도트 그리기

### 색상 변환
| CSS | WPF |
|-----|-----|
| `rgba(29, 31, 32, 0.904)` | `#E71D1F20` |
| `rgba(255, 255, 255, 0.712)` | `#B5FFFFFF` |

### 크기 변환
| CSS | WPF |
|-----|-----|
| `background-size: 11px 11px` | `Viewport="0,0,11,11"` |
| 도트 크기 10% (약 1.1px) | `RadiusX="0.55" RadiusY="0.55"` |
