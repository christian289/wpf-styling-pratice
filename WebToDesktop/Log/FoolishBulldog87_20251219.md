# FoolishBulldog87 변환 로그

## 날짜
2025-12-19

## 변환 정보
- **원본**: HTML/CSS Checkbox (uiverse.io)
- **원작자**: elijahgummer
- **대상**: WPF CustomControl

## 빌드 결과
- **상태**: 성공
- **경고**: 0개
- **오류**: 0개

## 컴파일 에러
없음

## 변환 시 주요 매핑

### CSS → WPF 변환

| CSS | WPF |
|-----|-----|
| `stroke-dashoffset` 애니메이션 | `Path.StrokeDashOffset` + `DoubleAnimation` |
| `stroke-dasharray: 25` | `StrokeDashArray="7.8125 7.8125"` (Path 길이 비율 조정) |
| `transition: 0.6s` | `Duration="0:0:0.6"` |
| `border-radius: 0.2rem` | `CornerRadius="3.2"` |
| `border: 0.2rem solid` | `BorderThickness="3.2"` |
| SVG `polyline` | WPF `Path` + `StreamGeometry` |

### stroke-dasharray 계산
- CSS: `stroke-dasharray: 25`, `stroke-dashoffset: 25` (path 전체 길이)
- WPF Path: M 20,6 L 9,17 L 4,12
  - 세그먼트 1: (20,6) → (9,17) = √((20-9)² + (6-17)²) ≈ 15.56
  - 세그먼트 2: (9,17) → (4,12) = √((9-4)² + (17-12)²) ≈ 7.07
  - 총 길이: ≈ 22.63
- WPF에서 StrokeDashArray는 StrokeThickness 단위로 정규화됨
- `StrokeDashArray="7.8125 7.8125"` (길이/StrokeThickness ≈ 25/3.2)

## 잠재적 런타임 오류 (직접 확인 필요)

1. **체크마크 Path 정렬 문제**
   - Path의 HorizontalAlignment/VerticalAlignment가 Border 내에서 정확히 중앙에 위치하지 않을 수 있음
   - Path의 viewBox가 CSS SVG와 다를 수 있어 체크마크 위치가 미세하게 다를 수 있음

2. **StrokeDashOffset 애니메이션 시각 효과**
   - CSS의 stroke-dashoffset 애니메이션과 WPF의 StrokeDashOffset 애니메이션이 동일한 시각 효과를 내지 않을 수 있음
   - Path 길이 계산이 정확하지 않으면 체크마크가 완전히 나타나지 않거나 과도하게 나타날 수 있음

3. **hover 상태 배경색 투명도**
   - CSS `#ff475425` (25% opacity) → WPF `#25FF4754` 변환이 정확한지 확인 필요
   - ARGB 순서 차이로 인한 색상 불일치 가능성

## 생성된 파일

### UI 라이브러리 (FoolishBulldog87.Wpf.UI)
- `Controls/FoolishBulldog87.cs` - CustomControl 클래스
- `Themes/FoolishBulldog87Resources.xaml` - 색상, 크기 리소스
- `Themes/FoolishBulldog87.xaml` - 스타일 및 ControlTemplate
- `Themes/Generic.xaml` - ResourceDictionary 병합

### Gallery (FoolishBulldog87.Wpf.Gallery)
- `App.xaml` - 리소스 병합
- `MainWindow.xaml` - 컨트롤 데모
