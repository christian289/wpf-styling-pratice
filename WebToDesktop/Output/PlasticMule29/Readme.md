# PlasticMule29

Buttons 스타일 컨트롤 - 3D 입체감을 주는 그린 버튼

## 원본 정보

- **원작자:** cssbuttons-io
- **원본 링크:** [https://uiverse.io/cssbuttons-io/plastic-mule-29](https://uiverse.io/cssbuttons-io/plastic-mule-29) (클릭 시 원본 CSS/HTML 확인 가능)

## 특징

- 4방향 inset shadow로 입체감 있는 3D 버튼 효과
- Hover 시 inset shadow 색상 변경 애니메이션
- 클릭(Pressed) 시 아래로 눌리는 효과 + drop shadow 제거
- 텍스트에 subtle한 drop shadow 적용

## 빌드 명령

### WPF

```bash
cd Wpf && dotnet run --project PlasticMule29.Wpf.Gallery
```

### AvaloniaUI

```bash
cd AvaloniaUI && dotnet run --project PlasticMule29.Avalonia.Gallery
```

## CSS → WPF 변환 매핑 테이블

| CSS 속성 | CSS 값 | WPF 구현 |
|---------|--------|----------|
| `background-color` | `#008542` | `SolidColorBrush` |
| `color` | `#fff` | `Foreground` 속성 |
| `font-size` | `18px` | `FontSize="18"` |
| `font-weight` | `900` | `FontWeight="Black"` |
| `padding` | `.8rem 1.5rem` | `Padding="24,12.8,24,12.8"` |
| `text-shadow` | `0 2px 0 rgb(0 0 0 / 25%)` | `DropShadowEffect` on ContentPresenter |
| `box-shadow` (inset) | 4방향 inset shadow | 4개의 `Border` 요소로 시뮬레이션 |
| `box-shadow` (외부) | `0 4px 0 0 rgb(0 0 0 / 15%)` | `DropShadowEffect` |
| `transition` | `0.7s cubic-bezier(0,.8,.26,.99)` | `Storyboard` with `Duration="0:0:0.3"` |
| `transform: translateY(4px)` | pressed 상태 | `ThicknessAnimation` on Margin |
| `::before`, `::after` | pseudo-elements | Grid 내 별도 Border 요소 |
| `cursor: pointer` | pointer cursor | `Cursor="Hand"` |
| `text-transform: uppercase` | uppercase | 콘텐츠에서 직접 대문자 사용 |

## 프로젝트 구조

```
PlasticMule29/
├── Wpf/
│   ├── PlasticMule29.Wpf.slnx
│   ├── PlasticMule29.Wpf.Gallery/    # 데모 애플리케이션
│   └── PlasticMule29.Wpf.UI/         # 커스텀 컨트롤 라이브러리
│       ├── Controls/
│       │   └── PlasticMule29.cs
│       └── Themes/
│           ├── Generic.xaml
│           ├── PlasticMule29.xaml
│           └── PlasticMule29Resources.xaml
└── AvaloniaUI/                       # (미구현)
```
