# BigSloth59

Inputs 스타일 컨트롤

## 원본 정보

- **원작자**: ozgeozkaraa01
- **원본 링크**: [https://uiverse.io/ozgeozkaraa01/big-sloth-59](https://uiverse.io/ozgeozkaraa01/big-sloth-59) (클릭 시 원본 CSS/HTML 확인 가능)

## 빌드 및 실행

### WPF
```bash
cd Wpf && dotnet run --project BigSloth59.Wpf.Gallery
```

### AvaloniaUI
```bash
cd AvaloniaUI && dotnet run --project BigSloth59.Avalonia.Gallery
```

## 컨트롤 특징

- 깔끔한 미니멀 디자인의 텍스트 입력 컨트롤
- 둥근 모서리 (border-radius: 10px)
- 하단 테두리만 표시되는 언더라인 스타일
- 포커스 시 부드러운 색상 전환 애니메이션 (0.5초)
- 포커스 색상: 보라색 (#6941c6)

## CSS → WPF 변환 매핑 테이블

| CSS 속성 | CSS 값 | WPF 속성 | WPF 값 |
|----------|--------|----------|--------|
| `height` | `40px` | `Height` | `40` |
| `border-radius` | `10px` | `CornerRadius` | `10` |
| `font-size` | `14px` | `FontSize` | `14` |
| `font-weight` | `500` | `FontWeight` | `Medium` |
| `padding-left` | `10px` | `Padding` | `10,0,10,0` |
| `border: none` | - | `BorderThickness` | `0,0,0,1` (하단만) |
| `border-bottom` | `1px solid #e5e5e5` | `BorderBrush` | `SolidColorBrush #e5e5e5` |
| `border-bottom:focus` | `1px solid #6941c6` | `ColorAnimation` | `To="#6941c6"` |
| `transition` | `0.5s` | `Duration` | `0:0:0.5` |
| `outline: none` | - | (기본값) | TextBox는 기본적으로 outline 없음 |

## 프로젝트 구조

```
BigSloth59/
├── Readme.md
├── Wpf/
│   ├── BigSloth59.Wpf.slnx
│   ├── BigSloth59.Wpf.Gallery/     # 데모 애플리케이션
│   └── BigSloth59.Wpf.UI/          # 커스텀 컨트롤 라이브러리
│       ├── Controls/
│       │   └── BigSloth59.cs
│       └── Themes/
│           ├── Generic.xaml
│           ├── BigSloth59.xaml
│           └── BigSloth59Resources.xaml
└── AvaloniaUI/                      # (미구현)
```
