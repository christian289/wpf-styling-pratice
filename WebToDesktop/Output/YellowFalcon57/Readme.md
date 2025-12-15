# YellowFalcon57

Buttons 스타일 컨트롤 - 다운로드 버튼

## 원본 정보
- 원작자: faxriddin20
- 원본 링크: [https://uiverse.io/faxriddin20/yellow-falcon-57](https://uiverse.io/faxriddin20/yellow-falcon-57) (클릭 시 원본 CSS/HTML 확인 가능)

## 빌드 명령

### WPF
```bash
cd Wpf && dotnet run --project YellowFalcon57.Wpf.Gallery
```

### AvaloniaUI
```bash
cd AvaloniaUI && dotnet run --project YellowFalcon57.Avalonia.Gallery
```

## CSS → WPF 변환 매핑 테이블

| CSS 속성 | CSS 값 | WPF 속성 | WPF 값 |
|---------|--------|---------|--------|
| `border` | `2px solid rgb(168, 38, 255)` | `BorderThickness` + `BorderBrush` | `2` + `#A826FF` |
| `background-color` | `white` | `Background` | `#FFFFFF` |
| `width` | `50px` | `Width` | `50` |
| `height` | `50px` | `Height` | `50` |
| `border-radius` | `10px` | `CornerRadius` | `10` |
| `cursor` | `pointer` | `Cursor` | `Hand` |
| `transition: all 0.2s` | - | `ColorAnimation Duration` | `0:0:0.2` |
| `transition: all 0.3s` (svg) | - | `ColorAnimation Duration` | `0:0:0.3` |
| `:hover background-color` | `rgb(168, 38, 255)` | `Trigger.EnterActions` | `#A826FF` |
| `:hover svg fill` | `white` | `Trigger.EnterActions` | `#FFFFFF` |

## 특징
- 보라색 테두리 다운로드 버튼
- Hover 시 배경색이 보라색으로 변경
- Hover 시 아이콘 색상이 흰색으로 변경
- 부드러운 애니메이션 전환 효과 (배경: 0.2s, 아이콘: 0.3s)
