# UglyBear28

Patterns 스타일 컨트롤

## 원본 정보

- **원작자:** csemszepp
- **원본 링크:** [https://uiverse.io/csemszepp/ugly-bear-28](https://uiverse.io/csemszepp/ugly-bear-28) (클릭 시 원본 CSS/HTML 확인 가능)

## 빌드 명령

### WPF
```bash
cd Wpf && dotnet run --project UglyBear28.Wpf.Gallery
```

### AvaloniaUI
```bash
cd AvaloniaUI && dotnet run --project UglyBear28.Avalonia.Gallery
```

## CSS → WPF 변환 매핑 테이블

| CSS 속성 | CSS 값 | WPF 구현 | 비고 |
|---------|--------|----------|------|
| `width` | `100%` | `HorizontalAlignment="Stretch"` | 부모 요소에 맞춤 |
| `height` | `100%` | `VerticalAlignment="Stretch"` | 부모 요소에 맞춤 |
| `background` | `#fff` | `SolidColorBrush` | 리소스로 분리 |
| `filter` | `contrast(7)` | **미지원** | WPF에서 직접 지원하지 않음 |
| `radial-gradient` | `(#000, transparent)` | `RadialGradientBrush` | DrawingBrush 내 GeometryDrawing에서 사용 |
| 패턴 반복 | `0 0/1em 1em space` | `DrawingBrush TileMode="Tile"` | Viewport/Viewbox로 크기 지정 |
| `mask` | `linear-gradient(...)` | `Rectangle.OpacityMask` | LinearGradientBrush 사용 |
| `::before` | pseudo-element | `Rectangle` | Border 내부에 배치 |
| `position: absolute` | 전체 영역 덮기 | `Rectangle` fills `Border` | 기본 레이아웃 동작 |

## 제한 사항

1. **CSS `filter: contrast(7)` 미지원**
   - WPF에는 CSS filter와 동등한 기능이 없음
   - 원본은 높은 대비로 점 패턴이 더 선명하게 표시됨
   - 현재 구현은 대비 필터 없이 점 패턴만 표시

2. **마스크 동작 차이**
   - CSS mask는 색상 채널을 사용
   - WPF OpacityMask는 알파 채널만 사용
   - 시각적 결과가 다를 수 있음

3. **패턴 크기 고정**
   - CSS `1em`을 고정값 `16px`로 변환
   - 폰트 크기와 연동되지 않음

## 프로젝트 구조

```
UglyBear28/
├── Readme.md
├── Wpf/
│   ├── UglyBear28.Wpf.slnx
│   ├── UglyBear28.Wpf.UI/
│   │   ├── Controls/
│   │   │   └── UglyBear28.cs
│   │   ├── Themes/
│   │   │   ├── Generic.xaml
│   │   │   ├── UglyBear28.xaml
│   │   │   └── UglyBear28Resources.xaml
│   │   └── Properties/
│   │       └── AssemblyInfo.cs
│   └── UglyBear28.Wpf.Gallery/
│       ├── App.xaml
│       ├── MainWindow.xaml
│       └── ...
└── AvaloniaUI/
    └── (미구현)
```
