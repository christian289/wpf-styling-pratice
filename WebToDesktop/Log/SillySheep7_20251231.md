# SillySheep7 변환 로그

## 변환 일시
2025-12-31

## 원본 정보
- 원작자: Subaashbala
- 원본 링크: https://uiverse.io/Subaashbala/silly-sheep-7
- 태그: skeuomorphism, realistic, radio, rotate, click effect

## 빌드 결과
**성공** - 경고 0개, 오류 0개

## 컴파일 에러
없음

## 잠재적 Runtime Error

### 1. SelectedIndex 초기화 문제
- **위치**: `SillySheep7.cs` - `UpdateKnobAngle()` 메서드
- **설명**: `SelectedIndex`가 0~4 범위를 벗어나면 기본값 0도로 설정됨
- **권장 조치**: 런타임에서 `SelectedIndex` 바인딩 시 범위 검증 필요

### 2. CSS box-shadow의 WPF 변환 한계
- **원본 CSS**: 다중 box-shadow (15px 0px 35px, -15px 0px 40px, inset 0px 0px 4px)
- **WPF 구현**: 단일 `DropShadowEffect`로 간소화됨
- **영향**: 원본과 시각적 차이 발생 가능
- **권장 조치**: 더 정밀한 그림자 효과가 필요하면 다중 Border/Rectangle 레이어 사용

### 3. CSS transition 애니메이션 미구현
- **원본 CSS**: `transition: transform 350ms cubic-bezier(0.175, 0.885, 0.32, 1.275)`
- **WPF 상태**: `KnobAngle` 프로퍼티 변경 시 즉시 반영 (애니메이션 없음)
- **권장 조치**: `Storyboard`와 `DoubleAnimation` 추가로 부드러운 회전 구현 가능

### 4. 동적 그림자 효과 미구현
- **원본 CSS**: 선택된 라디오 버튼에 따라 center의 box-shadow 방향이 변경됨
- **WPF 상태**: 고정된 단일 그림자 효과 사용
- **권장 조치**: `DataTrigger` 또는 `VisualStateManager`로 동적 효과 구현 가능

## CSS → WPF 변환 매핑

| CSS 속성 | WPF 구현 |
|---------|---------|
| `position: absolute` | `Canvas` + `Canvas.Left/Top` |
| `border-radius: 50%` | `CornerRadius="104"` (절반 값) |
| `transform: rotateZ()` | `RotateTransform` |
| `box-shadow` | `DropShadowEffect` (단순화) |
| `aspect-ratio: 1` | 동일한 Width/Height 설정 |
| `::after pseudo-element` | 내부 `Rectangle` 요소 |
| `:has(:checked)` selector | `Command` + `SelectedIndex` 바인딩 |
| `transition` | 미구현 (Storyboard 필요) |

## 생성된 파일 목록

### SillySheep7.Wpf.UI
- `Controls/SillySheep7.cs` - 메인 커스텀 컨트롤
- `Controls/SillySheep7Commands.cs` - RoutedCommand 정의
- `Controls/IndexToBoolConverter.cs` - 인덱스↔Boolean 변환기
- `Themes/SillySheep7Resources.xaml` - 색상, 크기 등 테마 리소스
- `Themes/SillySheep7.xaml` - Style 및 ControlTemplate
- `Themes/Generic.xaml` - ResourceDictionary 병합

### SillySheep7.Wpf.Gallery
- `App.xaml` - 리소스 딕셔너리 참조 추가
- `MainWindow.xaml` - 컨트롤 데모 UI
