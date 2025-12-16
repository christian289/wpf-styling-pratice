# SmoothDuck62

Checkboxes 스타일 컨트롤 - 체크 시 45도 회전하여 체크마크 형태로 변환되는 애니메이션 체크박스

## 원본 정보

- **원작자:** G4b413l
- **원본 링크:** [https://uiverse.io/G4b413l/smooth-duck-62](https://uiverse.io/G4b413l/smooth-duck-62)

## 빌드 명령

### WPF
```bash
cd Wpf && dotnet run --project SmoothDuck62.Wpf.Gallery
```

### AvaloniaUI
```bash
cd AvaloniaUI && dotnet run --project SmoothDuck62.Avalonia.Gallery
```

## CSS -> WPF 변환 매핑 테이블

| CSS | WPF | 설명 |
|-----|-----|------|
| `width: 20px; height: 20px` | `Width="20" Height="20"` | 컨트롤 크기 |
| `cursor: pointer` | `Cursor="Hand"` | 마우스 커서 |
| `border: solid 3px #2a2a2ab7` | `BorderBrush="#B72A2A2A" BorderThickness="3"` | 테두리 (ARGB 순서 주의) |
| `border-radius: 6px` | `CornerRadius="6"` | 둥근 모서리 |
| `transition: all 0.375s` | `Duration="0:0:0.375"` | 애니메이션 지속 시간 |
| `transform: rotate(45deg)` | `RotateTransform Angle="45"` | 회전 변환 |
| `width: 14px` (checked) | `DoubleAnimation To="14"` | 체크 시 너비 변경 |
| `margin-left: 5px` (checked) | `TranslateTransform X="2.5"` | 체크 시 위치 이동 |
| `border-color: #24c78e` | `BorderBrush="#24C78E"` | 체크 시 테두리 색상 |
| `border-width: 5px` | `BorderThickness="0,0,5,5"` | 체크 시 테두리 두께 |
| `border-top-color: transparent` | `BorderThickness Top=0` | 상단 테두리 숨김 |
| `border-left-color: transparent` | `BorderThickness Left=0` | 좌측 테두리 숨김 |
| `border-radius: 0` (checked) | `CornerRadius="0"` | 체크 시 둥근 모서리 제거 |

## 특이사항

### ARGB 색상 순서
CSS의 `#2a2a2ab7`은 RGB + Alpha 순서이지만, WPF는 ARGB 순서를 사용하므로 `#B72A2A2A`로 변환됨.

### 체크마크 효과 구현
CSS에서는 `border-top-color: transparent`와 `border-left-color: transparent`로 개별 테두리 색상을 투명하게 설정하지만, WPF에서는 `BorderBrush`가 단일 색상이므로 `BorderThickness="0,0,5,5"`로 상단/좌측 테두리 두께를 0으로 설정하여 동일한 효과를 구현함.

### CornerRadius 애니메이션
WPF의 `CornerRadius`는 애니메이션 가능한 타입이 아니므로 `ObjectAnimationUsingKeyFrames`와 `DiscreteObjectKeyFrame`을 사용하여 이산적으로 값을 변경함.
