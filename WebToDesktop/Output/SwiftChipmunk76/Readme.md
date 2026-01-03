# SwiftChipmunk76

Inputs 스타일 컨트롤 - 별점 평가 (Star Rating) 컴포넌트

## 원본 정보

- **원작자**: PriyanshuGupta28
- **원본 링크**: [https://uiverse.io/PriyanshuGupta28/swift-chipmunk-76](https://uiverse.io/PriyanshuGupta28/swift-chipmunk-76) (클릭 시 원본 CSS/HTML 확인 가능)

## 미리보기

5개의 별을 클릭하여 평점을 매기는 인터랙티브 컨트롤입니다.

- 기본 상태: 회색 별 (★)
- 호버/선택 상태: 보라색 별 (#6F00FF)
- 부드러운 색상 전환 애니메이션 (0.3초)

## 빌드 및 실행

### WPF

```bash
cd Wpf && dotnet run --project SwiftChipmunk76.Wpf.Gallery
```

### AvaloniaUI

```bash
cd AvaloniaUI && dotnet run --project SwiftChipmunk76.Avalonia.Gallery
```

## 사용법

```xml
<controls:SwiftChipmunk76 Value="3" />
```

### 속성

| 속성 | 타입 | 기본값 | 설명 |
|-----|------|-------|------|
| `Value` | `int` | `0` | 현재 선택된 평점 (0~5) |
| `MaxRating` | `int` | `5` | 최대 별 개수 |
| `HoverValue` | `int` | `0` | 현재 호버 중인 별 인덱스 |
| `IsReadOnly` | `bool` | `false` | 읽기 전용 모드 |

### 이벤트

| 이벤트 | 설명 |
|-------|------|
| `ValueChanged` | 평점 값이 변경될 때 발생 |

## CSS → WPF 변환 매핑 테이블

| CSS 속성 | CSS 값 | WPF 속성 | WPF 값 |
|---------|--------|---------|--------|
| `display` | `inline-block` | `HorizontalAlignment` | `Left` |
| `float` | `right` | StackPanel 순서 | 1→5 정순 배치 |
| `content` | `'\2605'` (★) | TextBlock.Text | `&#x2605;` |
| `font-size` | `30px` | FontSize | `30` |
| `color` (기본) | `#ccc` | Foreground | `#CCCCCC` |
| `color` (활성) | `#6f00ff` | Foreground | `#6F00FF` |
| `cursor` | `pointer` | Cursor | `Hand` |
| `transition` | `color 0.3s` | ColorAnimation.Duration | `0:0:0.3` |

## 프로젝트 구조

```
SwiftChipmunk76/
├── Readme.md
├── Wpf/
│   ├── SwiftChipmunk76.Wpf.slnx
│   ├── SwiftChipmunk76.Wpf.UI/
│   │   ├── Controls/
│   │   │   └── SwiftChipmunk76.cs
│   │   └── Themes/
│   │       ├── Generic.xaml
│   │       ├── SwiftChipmunk76.xaml
│   │       └── SwiftChipmunk76Resources.xaml
│   └── SwiftChipmunk76.Wpf.Gallery/
│       ├── App.xaml
│       ├── MainWindow.xaml
│       └── MainWindow.xaml.cs
└── AvaloniaUI/
    └── (미구현)
```
