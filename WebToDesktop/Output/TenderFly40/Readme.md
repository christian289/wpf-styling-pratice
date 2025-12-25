# TenderFly40

Cards 스타일 컨트롤 - 명언을 표시하는 Quote Card

## 원본 정보
- **원작자**: alexmaracinaru
- **원본 링크**: [https://uiverse.io/alexmaracinaru/tender-fly-40](https://uiverse.io/alexmaracinaru/tender-fly-40)
- **태그**: simple, green, card, quote, monochromatic

## 빌드 명령

### WPF
```bash
cd Wpf && dotnet run --project TenderFly40.Wpf.Gallery
```

### AvaloniaUI
```bash
cd AvaloniaUI && dotnet run --project TenderFly40.Avalonia.Gallery
```

## 기능
- 명언(Quote) 텍스트 표시
- 마우스 호버 시 작가 정보 페이드 인 애니메이션
- DependencyProperty를 통한 커스터마이징:
  - `CardTitle`: 카드 상단 타이틀
  - `QuoteText`: 명언 텍스트
  - `Author`: 작가 이름
  - `AuthorDescription`: 작가 설명

## CSS → WPF 변환 매핑 테이블

| CSS 속성 | CSS 값 | WPF 속성 | WPF 값 |
|----------|--------|----------|--------|
| `width` | 190px | `Width` | 190 |
| `height` | 264px | `Height` | 264 |
| `background` | rgb(183, 226, 25) | `Background` | #B7E219 |
| `border-radius` | 8px | `CornerRadius` | 8 |
| `color` (title) | rgb(127, 155, 29) | `Foreground` | #7F9B1D |
| `color` (quote icon) | rgb(223, 248, 134) | `Fill` | #DFF886 |
| `color` (body) | #465512 | `Foreground` | #465512 |
| `font-weight: 700` | bold | `FontWeight` | Bold |
| `font-weight: 900` | black | `FontWeight` | Black |
| `text-transform` | uppercase | `Typography.Capitals` | AllSmallCaps |
| `opacity` | 0 → 1 | `Opacity` | 0 → 1 |
| `transition` | 0.5s | `Duration` | 0:0:0.5 |
| `:hover` | - | `Trigger.IsMouseOver` | True |
| SVG `<path>` | d="..." | `Path.Data` | Geometry |

## 프로젝트 구조

```
TenderFly40/
├── Readme.md
├── Wpf/
│   ├── TenderFly40.Wpf.slnx
│   ├── TenderFly40.Wpf.UI/
│   │   ├── Controls/
│   │   │   └── TenderFly40.cs
│   │   └── Themes/
│   │       ├── Generic.xaml
│   │       ├── TenderFly40.xaml
│   │       └── TenderFly40Resources.xaml
│   └── TenderFly40.Wpf.Gallery/
│       ├── App.xaml
│       └── MainWindow.xaml
└── AvaloniaUI/
    └── (미구현)
```
