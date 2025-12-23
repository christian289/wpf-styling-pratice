# WiseMule92

Buttons 스타일 컨트롤 - 鬼滅の刃 테마 버튼

## 원본 정보

- **원작자**: PriyanshuGupta28
- **원본 링크**: [https://uiverse.io/PriyanshuGupta28/wise-mule-92](https://uiverse.io/PriyanshuGupta28/wise-mule-92)

## 빌드 및 실행

### WPF
```bash
cd Wpf && dotnet run --project WiseMule92.Wpf.Gallery
```

### AvaloniaUI
```bash
cd AvaloniaUI && dotnet run --project WiseMule92.Avalonia.Gallery
```

## 기능

- 빨간색 배경의 버튼
- Hover 시 배경색 흰색으로 전환 + 텍스트 색상 빨간색으로 전환
- Hover 시 텍스트 회전(-10도) 및 스케일(1.1배) 애니메이션
- Hover 시 그림자 효과 추가
- 부드러운 300ms 트랜지션 애니메이션

## CSS → WPF 변환 매핑 테이블

| CSS 속성 | WPF 구현 |
|----------|----------|
| `background-color: #f44336` | `SolidColorBrush` |
| `color: #fff` | `Foreground` |
| `padding: 10px 20px` | `Padding="20,10,20,10"` |
| `font-size: 20px` | `FontSize="20"` |
| `font-weight: bold` | `FontWeight="Bold"` |
| `cursor: pointer` | `Cursor="Hand"` |
| `transition: all 0.3s ease-in-out` | `Storyboard` + `CubicEase` |
| `:hover` 배경색 변경 | `Trigger.EnterActions` + `ColorAnimation` |
| `:hover span transform: rotate(-10deg) scale(1.1)` | `RotateTransform` + `ScaleTransform` |
| `box-shadow` (복합) | `DropShadowEffect` |
| `letter-spacing` | 미지원 (WPF 제한) |
| `text-transform: uppercase` | Content에 직접 대문자 입력 |

## 프로젝트 구조

```
WiseMule92/
├── Readme.md
├── Wpf/
│   ├── WiseMule92.Wpf.slnx
│   ├── WiseMule92.Wpf.Gallery/     # 데모 애플리케이션
│   └── WiseMule92.Wpf.UI/          # CustomControl 라이브러리
│       ├── Controls/
│       │   └── WiseMule92.cs
│       └── Themes/
│           ├── Generic.xaml
│           ├── WiseMule92.xaml
│           └── WiseMule92Resources.xaml
└── AvaloniaUI/                      # (미구현)
```
