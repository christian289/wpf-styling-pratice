# TerribleKangaroo96 변환 로그

## 변환 일시
2025-12-21

## 원본 정보
- 원작자: Cornerstone-04
- 원본 링크: https://uiverse.io/Cornerstone-04/terrible-kangaroo-96
- 컨트롤 유형: Checkbox (원형 체크박스)

## 컴파일 에러
**없음** - 빌드 성공 (경고 0개, 오류 0개)

## 런타임 에러 가능성

### 1. ColorAnimation 초기값 문제
- **위치**: `TerribleKangaroo96.xaml` - IsChecked 트리거 ExitActions
- **설명**: `ColorAnimation`의 `To="Transparent"`는 정상 동작하지만, Background가 처음에 `Transparent`로 설정되어 있어야 함
- **현재 상태**: `UncheckedBackground` 브러시가 `Transparent`로 설정되어 있어 정상 동작 예상
- **확인 필요**: 컨트롤 로드 시 초기 배경색 확인

### 2. TransformGroup 애니메이션 타겟팅
- **위치**: `TerribleKangaroo96.xaml` - CheckmarkScale, CheckmarkRotate
- **설명**: TransformGroup 내부의 개별 Transform에 x:Name을 부여하여 직접 타겟팅
- **현재 상태**: WPF에서 지원되는 패턴이므로 정상 동작 예상
- **확인 필요**: 체크/언체크 시 애니메이션 스무스함 확인

### 3. 체크마크 위치 미세 조정
- **위치**: `TerribleKangaroo96.xaml` - 체크마크 Grid의 Margin
- **설명**: CSS의 `transform: translate(20%, -25%)`를 WPF Margin으로 근사 변환
- **현재 상태**: `Margin="-1,0,0,-2"`로 설정
- **확인 필요**: 체크마크가 원 중앙에 정확히 위치하는지 시각적 확인 필요

## CSS → WPF 변환 상세

| CSS 속성 | WPF 구현 |
|---------|---------|
| `border-radius: 50px` | `CornerRadius="15"` (30px 원의 절반) |
| `transition: all 0.3s linear` | `Duration="0:0:0.3"` Storyboard |
| `::after` pseudo-element | Grid 내부 Border 요소 |
| `transform: rotate(45deg)` | `RotateTransform Angle="45"` |
| `transform: scale(0)` | `ScaleTransform ScaleX="0" ScaleY="0"` |
| `opacity: 0` | `Opacity="0"` |
| `border-right + border-bottom` | 두 개의 Border (수직/수평) |

## 생성된 파일
- `TerribleKangaroo96.Wpf.UI/Controls/TerribleKangaroo96.cs`
- `TerribleKangaroo96.Wpf.UI/Themes/TerribleKangaroo96Resources.xaml`
- `TerribleKangaroo96.Wpf.UI/Themes/TerribleKangaroo96.xaml`
- `TerribleKangaroo96.Wpf.UI/Themes/Generic.xaml`
- `TerribleKangaroo96.Wpf.Gallery/App.xaml`
- `TerribleKangaroo96.Wpf.Gallery/MainWindow.xaml`
