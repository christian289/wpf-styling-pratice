# AverageElephant52 변환 로그 (2차 수정)

## 변환 일시
2025-12-23

## 원본 정보
- **원작자**: seyed-mohsen-mousavi
- **원본 링크**: https://uiverse.io/seyed-mohsen-mousavi/average-elephant-52
- **카테고리**: Inputs

## 빌드 결과
**성공** - 컴파일 에러 없음

## 수정 내용

### 타입 호환성 수정

| 파일 | 변경 전 | 변경 후 | 사유 |
|------|---------|---------|------|
| `AverageElephant52Resources.xaml` | `sys:Double` → `CornerRadius` 사용 | `CornerRadius` 타입 별도 정의 | WPF의 `CornerRadius` 속성은 `Double` 타입을 자동 변환하지 않음 |
| `AverageElephant52Resources.xaml` | `sys:Double` → `Thickness` 사용 | `Thickness` 타입 별도 정의 | WPF의 `Padding`, `Margin` 속성은 `Thickness` 타입 필요 |
| `AverageElephant52.xaml` | `AverageElephant52.CornerRadius` | `AverageElephant52.CornerRadiusValue` | `RectangleGeometry.RadiusX/Y`는 `Double` 타입 필요 |

### 리소스 키 변경 내역

| 기존 키 | 새 키 | 타입 |
|---------|-------|------|
| `AverageElephant52.CornerRadius` (Double) | `AverageElephant52.CornerRadiusValue` | `sys:Double` |
| `AverageElephant52.InnerCornerRadius` (Double) | `AverageElephant52.InnerCornerRadiusValue` | `sys:Double` |
| `AverageElephant52.BorderPadding` (Double) | `AverageElephant52.BorderPadding` | `Thickness` |
| `AverageElephant52.InnerMargin` (Double) | `AverageElephant52.InnerMargin` | `Thickness` |
| (신규) | `AverageElephant52.CornerRadius` | `CornerRadius` |
| (신규) | `AverageElephant52.InnerCornerRadius` | `CornerRadius` |

## 잠재적 Runtime Error 가능성

### 1. RadialGradientBrush 렌더링 차이
- **설명**: CSS의 `radial-gradient(circle 80px at 80% -10%, ...)` 에서 `-10%`는 요소 바깥 영역을 의미
- **WPF 동작**: RadialGradientBrush의 Center가 0~1 범위 밖이면 예상과 다르게 렌더링될 수 있음
- **현재 구현**: Center="0.8,0"으로 설정하여 근사 구현
- **확인 필요**: 실행 후 그라데이션 시각적 확인 필요

### 2. Skew Transform 방향
- **설명**: CSS `skew(10deg, 0deg)`는 X축 양의 방향으로 기울임
- **WPF 구현**: `SkewTransform AngleX="-10"`으로 반대 방향 설정 (CSS와 동일한 시각적 효과)
- **확인 필요**: 실행 후 기울기 방향 확인

### 3. TextBox 스타일 상속
- **설명**: ControlTemplate 내의 TextBox는 기본 시스템 스타일을 상속받음
- **현재 구현**: Background="Transparent", BorderThickness="0" 등 인라인 스타일 적용
- **확인 필요**: 포커스 시 텍스트박스 테두리가 나타나지 않는지 확인

### 4. Clip과 Effect 함께 사용
- **설명**: Border.Clip과 DropShadowEffect를 함께 사용 시 그림자가 잘릴 수 있음
- **현재 구현**: Effect는 OuterBorder에, Clip도 OuterBorder에 적용
- **확인 필요**: 그림자가 정상적으로 표시되는지 확인

## 권장 테스트 항목

1. [ ] 그라데이션 배경이 원본과 유사하게 표시되는지
2. [ ] 핑크색 Blob 장식이 좌측 하단에 표시되는지
3. [ ] 클릭/포커스 시 Skew 애니메이션이 작동하는지
4. [ ] 그림자가 포커스 시 더 강해지는지
5. [ ] 텍스트 입력 시 placeholder가 사라지는지
6. [ ] 검색 아이콘이 좌측에 표시되는지
