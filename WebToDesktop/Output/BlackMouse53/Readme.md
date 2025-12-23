# BlackMouse53

Cards 스타일 컨트롤 - CSS Art로 구현된 Twitter(X) 새 로고

## 원본 정보

- **원작자**: vladaxinte
- **원본 링크**: [https://uiverse.io/vladaxinte/black-mouse-53](https://uiverse.io/vladaxinte/black-mouse-53)

## 빌드 명령

### WPF

```bash
cd Wpf && dotnet run --project BlackMouse53.Wpf.Gallery
```

### AvaloniaUI

```bash
cd AvaloniaUI && dotnet run --project BlackMouse53.Avalonia.Gallery
```

## CSS to WPF 변환 매핑 테이블

| CSS 속성 | WPF 구현 | 비고 |
|---------|---------|------|
| `radial-gradient(circle at X% Y%, transparent N%, #fff M%)` | `RadialGradientBrush` with `GradientOrigin`, `Center`, `RadiusX/Y` | GradientOrigin과 Center를 동일하게 설정 |
| `border-radius: 100%` | `Ellipse` 요소 | 완전 원형은 Ellipse 사용 |
| `position: absolute` + `left/top` | `Canvas.Left`, `Canvas.Top` | Canvas 레이아웃 사용 |
| `transform: rotate(Ndeg)` | `RotateTransform` with `RenderTransformOrigin="0.5,0.5"` | 중심점 기준 회전 |
| `transform: translate(-15%, 20%)` | `Canvas.Left`, `Canvas.Top` 계산값 | 컨테이너 크기 기준 계산 |
| `z-index` | `Panel.ZIndex` | Canvas 내 레이어 순서 제어 |
| `background: #fff` (solid) | `SolidColorBrush` | Fill 속성에 적용 |

## 컨트롤 구조

이 컨트롤은 CSS Art 기법을 사용하여 여러 개의 `Ellipse` 요소와 `RadialGradientBrush`를 조합하여 Twitter 새 모양을 구성합니다.

### 구성 요소

1. **Head** - 머리 (solid white circle)
2. **Beak Top/Bottom** - 부리 (radial gradient)
3. **Torso** - 몸통 (radial gradient)
4. **Tummy** - 배 (radial gradient, z-index: -1)
5. **Tail** - 꼬리 (radial gradient)
6. **Wing Top/Middle/Bottom** - 날개 3개 (radial gradient)

### RadialGradientBrush 변환 패턴

CSS의 `radial-gradient(circle at X% Y%, transparent N%, #fff M%)`는 다음과 같이 변환됩니다:

```xml
<RadialGradientBrush GradientOrigin="X,Y" Center="X,Y" RadiusX="N" RadiusY="N">
    <GradientStop Color="Transparent" Offset="0" />
    <GradientStop Color="Transparent" Offset="N" />
    <GradientStop Color="White" Offset="N" />
</RadialGradientBrush>
```

- CSS `at X% Y%` → WPF `GradientOrigin="X/100, Y/100"` 및 `Center="X/100, Y/100"`
- CSS `transparent N%` → WPF `RadiusX/Y="N/100"`, `Offset="N/100"`
