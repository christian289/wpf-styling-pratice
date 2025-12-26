# PerfectCheetah72

Radio-buttons 스타일 테마 선택 드롭다운 컨트롤

## 원본 정보

- **원작자:** Galahhad
- **원본 링크:** [https://uiverse.io/Galahhad/perfect-cheetah-72](https://uiverse.io/Galahhad/perfect-cheetah-72)
- **태그:** theme, theme-switch, radio, dropdown

## 미리보기

테마 선택 팝업 드롭다운 컨트롤로, 세 가지 테마 옵션을 제공합니다:
- OS Default (반반 아이콘)
- Light (태양 아이콘)
- Night (달 아이콘)

## 빌드 명령

### WPF

```bash
cd Wpf && dotnet run --project PerfectCheetah72.Wpf.Gallery
```

### AvaloniaUI

```bash
cd AvaloniaUI && dotnet run --project PerfectCheetah72.Avalonia.Gallery
```

## 사용법

```xml
<Window xmlns:controls="clr-namespace:PerfectCheetah72.Wpf.UI.Controls;assembly=PerfectCheetah72.Wpf.UI">
    <controls:PerfectCheetah72
        ButtonText="Theme"
        SelectedTheme="Default"
        ThemeChanged="OnThemeChanged"/>
</Window>
```

## 속성 (Properties)

| 속성 | 타입 | 기본값 | 설명 |
|------|------|--------|------|
| `SelectedTheme` | `ThemeOption` | `Default` | 선택된 테마 (Default, Light, Dark) |
| `IsDropDownOpen` | `bool` | `false` | 드롭다운 팝업 열림 상태 |
| `ButtonText` | `string` | `"Theme"` | 버튼에 표시될 텍스트 |

## 이벤트 (Events)

| 이벤트 | 설명 |
|--------|------|
| `ThemeChanged` | 테마가 변경되었을 때 발생 |

## CSS → WPF 변환 매핑 테이블

| CSS 속성 | CSS 값 | WPF 속성 | WPF 값 |
|----------|--------|----------|--------|
| `--total_text_color` | `#e0e0e0` | `SolidColorBrush` | `#E0E0E0` |
| `--btn_bg` | `#3A3A3A` | `SolidColorBrush` | `#3A3A3A` |
| `--btn_padding` | `0.5em` | `Thickness` | `8,0` |
| `--btn_height` | `2em` | `Double` | `32` |
| `--btn_border_radius` | `0.3125em` | `CornerRadius` | `5` |
| `--btn_outline_width` | `0.0625em` | `Thickness` | `1` |
| `--btn_outline_color` | `#A0A0A0` | `SolidColorBrush` | `#A0A0A0` |
| `--btn_gap` | `0.3125em` | `Thickness (Margin)` | `0,0,5,0` |
| `--list_padding` | `0.5em` | `Thickness` | `8` |
| `--list_gap` | `0.1875em` | `Thickness (Margin)` | `0,3,0,0` |
| `--list_btn_hover_bg` | `#5A5656` | `SolidColorBrush` | `#5A5656` |
| `--list_btn_active` | `#b9b9b970` | `SolidColorBrush` | `#70B9B9B9` |
| `--list_btn_border_radius` | `0.25em` | `CornerRadius` | `4` |
| `--list_btn_padding` | `0.35em 1em` | `Thickness` | `16,5.6` |
| `--list_btn_gap` | `0.4375em` | `Thickness (Margin)` | `0,0,7,0` |
| `--list_btn_font_size` | `14px` | `Double` | `14` |
| `--list_offset` | `0.35em` | `Double` | `5.6` |
| `display: none` (checkbox) | - | `Visibility` | `Collapsed` |
| `position: relative` | - | `Grid` | 기본 레이아웃 |
| `position: absolute` | - | `Popup` | 드롭다운 팝업 |
| `user-select: none` | - | - | WPF 기본 동작 |
| SVG `<path>` | path data | `Geometry` | Path Data 리소스 |
| `:hover` pseudo-class | - | `Trigger.IsMouseOver` | 트리거 스타일 |
| `:checked` pseudo-class | - | `SelectedTheme` 바인딩 | DataTrigger |

## 프로젝트 구조

```
PerfectCheetah72/
├── Readme.md
├── Wpf/
│   ├── PerfectCheetah72.Wpf.slnx
│   ├── PerfectCheetah72.Wpf.Gallery/    # 데모 앱
│   └── PerfectCheetah72.Wpf.UI/         # 커스텀 컨트롤 라이브러리
│       ├── Controls/
│       │   ├── PerfectCheetah72.cs      # 메인 컨트롤
│       │   └── ThemeOption.cs           # 열거형 정의
│       └── Themes/
│           ├── Generic.xaml             # 리소스 딕셔너리 병합
│           ├── PerfectCheetah72.xaml    # 스타일 및 템플릿
│           └── PerfectCheetah72Resources.xaml  # 색상, 크기, 아이콘 리소스
└── AvaloniaUI/                          # (예정)
```
