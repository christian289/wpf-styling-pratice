# ShaggyEarwig15

Checkboxes 스타일 컨트롤 - 햄버거 메뉴 토글 버튼

## 원본 정보

- **원작자**: Jack17432
- **원본 링크**: [https://uiverse.io/Jack17432/shaggy-earwig-15](https://uiverse.io/Jack17432/shaggy-earwig-15) (클릭 시 원본 CSS/HTML 확인 가능)
- **태그**: glassmorphism, checkbox, hamburger, shadow

## 빌드 및 실행

### WPF
```bash
cd Wpf && dotnet run --project ShaggyEarwig15.Wpf.Gallery
```

### AvaloniaUI
```bash
cd AvaloniaUI && dotnet run --project ShaggyEarwig15.Avalonia.Gallery
```

## CSS → WPF 변환 매핑 테이블

| CSS 속성 | CSS 값 | WPF 속성 | WPF 값 |
|---------|--------|---------|--------|
| `width` / `height` | `3.5em` | `Width` / `Height` | `56` |
| `border-radius` | `0.5em` | `CornerRadius` | `8` |
| `background` | `#e8e8e8` | `Background` | `SolidColorBrush #E8E8E8` |
| `box-shadow` (outer) | `6px 6px 12px #c5c5c5, -6px -6px 12px #ffffff` | `DropShadowEffect` | 두 개의 Border + DropShadowEffect |
| `box-shadow` (inset) | `inset 4px 4px 12px` | N/A | BlurEffect + Border 조합 |
| `transition` | `0.3s ease` | `Storyboard` | `Duration="0:0:0.3"` |
| `.menuButton span` width | `30px` | `Width` | `30` |
| `.menuButton span` height | `4px` | `Height` | `4` |
| `border-radius` (bar) | `100px` | `CornerRadius` | `100` |
| `transform: translateY(290%)` | Y축 이동 | `TranslateTransform.Y` | `0` (center 기준) |
| `transform: rotate(45deg)` | 회전 | `RotateTransform.Angle` | `45` |
| `opacity: 0` | 투명도 | `Opacity` | `0` |
| `box-shadow` (bar glow) | `0 0 10px #495057` | `DropShadowEffect` | `BlurRadius="10"` |

## 컨트롤 특징

1. **Neumorphism 디자인**: 듀얼 그림자 시스템으로 입체적인 효과
2. **토글 상태**: ToggleButton 상속, IsChecked 상태에 따른 X 변환
3. **애니메이션**: 클릭 시 부드러운 0.3초 전환 효과
   - 상단 바: 중앙으로 이동 + 45도 회전
   - 중앙 바: 왼쪽으로 사라짐
   - 하단 바: 중앙으로 이동 + -45도 회전 + 글로우 효과
4. **호버 효과**: 테두리 색상 변경
5. **프레스 효과**: 눌림 상태에서 그림자 제거

## 프로젝트 구조

```
ShaggyEarwig15/
├── Readme.md
├── Wpf/
│   ├── ShaggyEarwig15.Wpf.slnx
│   ├── ShaggyEarwig15.Wpf.Gallery/     # 데모 앱
│   └── ShaggyEarwig15.Wpf.UI/          # 커스텀 컨트롤 라이브러리
│       ├── Controls/
│       │   └── ShaggyEarwig15.cs
│       └── Themes/
│           ├── Generic.xaml
│           ├── ShaggyEarwig15.xaml
│           └── ShaggyEarwig15Resources.xaml
└── AvaloniaUI/                          # (미구현)
```
