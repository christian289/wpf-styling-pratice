# CurlyBullfrog98 변환 로그

## 변환 일시
2025-12-19

## 원본 정보
- 원작자: Bodyhc
- 원본 링크: https://uiverse.io/Bodyhc/curly-bullfrog-98
- 카테고리: loaders (3D cube loading animation)

## 컴파일 에러
없음 - 첫 빌드에서 성공

## 변환 특이사항

### CSS 3D → WPF Viewport3D 변환
원본 CSS는 `transform-style: preserve-3d`와 `perspective`를 사용한 CSS 3D 변환이지만, WPF는 CSS처럼 2D 요소에 3D perspective를 적용하는 것을 지원하지 않습니다.

따라서 WPF `Viewport3D`를 사용하여 실제 3D 큐브를 렌더링하는 방식으로 구현했습니다.

| CSS 원본 | WPF 구현 |
|---------|---------|
| `perspective: 1000px` | `PerspectiveCamera` (FieldOfView=45) |
| `transform-style: preserve-3d` | `Viewport3D` + `ModelVisual3D` |
| `rotateX/rotateY` | `AxisAngleRotation3D` |
| 6개 `div.side` + transform | 6개 `GeometryModel3D` (MeshGeometry3D) |
| `border: 3px solid #fff` | 흰색 `GeometryModel3D` edge 라인 |
| `@keyframes animate` | `Storyboard` + `DoubleAnimation` |

## 잠재적 런타임 오류

### 1. 3D 렌더링 성능
- **가능성**: 낮음
- **설명**: Viewport3D는 기본적으로 소프트웨어 렌더링을 사용할 수 있음. 고성능 요구 시 `RenderOptions.ProcessRenderMode` 설정 필요할 수 있음.

### 2. 애니메이션 Duration 하드코딩
- **가능성**: 낮음
- **설명**: Duration은 WPF에서 `StaticResource` 바인딩이 불가능하므로 `"0:0:4"`로 하드코딩됨. `Duration` DependencyProperty는 정의되어 있지만 ControlTemplate에서 직접 사용되지 않음.

### 3. Edge 라인 Z-fighting
- **가능성**: 중간
- **설명**: 흰색 border 라인이 메인 면과 매우 가까운 Z 위치에 있어 특정 각도에서 깜빡임이 발생할 수 있음. 현재 0.01 오프셋 적용.

## 생성된 파일
- `CurlyBullfrog98.Wpf.UI/Controls/CurlyBullfrog98.cs`
- `CurlyBullfrog98.Wpf.UI/Themes/CurlyBullfrog98Resources.xaml`
- `CurlyBullfrog98.Wpf.UI/Themes/CurlyBullfrog98.xaml`
- `CurlyBullfrog98.Wpf.UI/Themes/Generic.xaml` (수정)
- `CurlyBullfrog98.Wpf.Gallery/App.xaml` (수정)
- `CurlyBullfrog98.Wpf.Gallery/MainWindow.xaml` (수정)
