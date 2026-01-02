# WhiteKangaroo0 변환 로그

## 변환 정보

- **변환 일시**: 2026-01-02
- **원본**: uiverse.io/Shoh2008/white-kangaroo-0
- **카테고리**: loaders

## 컴파일 결과

**빌드 성공**: 경고 0개, 오류 0개

## 변환 내용

### CSS → WPF 변환 매핑

| CSS 속성 | WPF 구현 |
|---------|----------|
| `radial-gradient` (다중 배경) | `DrawingBrush` + `DrawingGroup` (여러 `EllipseGeometry`) |
| `background-image` (톱니바퀴 패턴) | `GeometryDrawing`으로 각 원형 요소 표현 |
| `::before`, `::after` | Canvas 내 별도 Ellipse 요소로 구현 |
| `animation: rotationBack 3s linear infinite` | `DoubleAnimation` (Duration="0:0:3", RepeatBehavior="Forever") |
| `animation-direction: reverse` | To/From 값 반전 (0→360 대신 0→-360 또는 역방향) |
| `position: absolute` + `left/bottom` | `Canvas.Left`, `Canvas.Top` 계산 |
| `border-radius: 50%` | `Ellipse` 요소 사용 |
| `transform: rotate()` | `RotateTransform` + `RenderTransformOrigin="0.5,0.5"` |

### 특이 사항

1. **CSS radial-gradient 다중 배경**: 원본 CSS는 10개의 radial-gradient를 중첩하여 톱니바퀴 모양을 만듦. WPF에서는 `DrawingBrush` 내 `DrawingGroup`을 사용하여 여러 `EllipseGeometry`로 구현함.

2. **bottom 속성 계산**: CSS의 `bottom` 값을 WPF `Canvas.Top`으로 변환 시 `top = height - bottom - element_height` 공식 사용.

3. **애니메이션 방향**: CSS `animation: ... reverse`는 WPF에서 To 값을 반대 방향으로 설정하여 구현.

## 잠재적 런타임 오류

1. **DrawingBrush 렌더링**: `DrawingBrush`의 복잡한 `DrawingGroup`이 특정 그래픽 카드에서 성능 저하 가능성 있음. (확인 필요)

2. **Storyboard 메모리 누수**: `EventTrigger`로 시작된 `BeginStoryboard`가 컨트롤 언로드 시 자동으로 정리되지 않을 수 있음. 대규모 사용 시 메모리 모니터링 권장.

## 생성된 파일

```
WhiteKangaroo0.Wpf.slnx
WhiteKangaroo0.Wpf.Gallery/
├── App.xaml
├── App.xaml.cs
├── MainWindow.xaml
├── MainWindow.xaml.cs
└── WhiteKangaroo0.Wpf.Gallery.csproj
WhiteKangaroo0.Wpf.UI/
├── Controls/
│   └── WhiteKangaroo0.cs
├── Themes/
│   ├── Generic.xaml
│   ├── WhiteKangaroo0.xaml
│   └── WhiteKangaroo0Resources.xaml
├── Properties/
│   └── AssemblyInfo.cs
└── WhiteKangaroo0.Wpf.UI.csproj
```
