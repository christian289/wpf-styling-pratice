# BreezyGoose71

Toggle-switches 스타일 컨트롤 - 북마크 토글 버튼

## 원본 정보

- **원작자**: vinodjangid07
- **원본 링크**: [https://uiverse.io/vinodjangid07/breezy-goose-71](https://uiverse.io/vinodjangid07/breezy-goose-71) (클릭 시 원본 CSS/HTML 확인 가능)

## 빌드 명령

### WPF

```bash
cd Wpf && dotnet run --project BreezyGoose71.Wpf.Gallery
```

### AvaloniaUI

```bash
cd AvaloniaUI && dotnet run --project BreezyGoose71.Avalonia.Gallery
```

## CSS to WPF 변환 매핑 테이블

| CSS                              | WPF                                      | 설명                         |
| -------------------------------- | ---------------------------------------- | ---------------------------- |
| `background-color: teal`         | `SolidColorBrush` (Teal)                 | 배경색                       |
| `width: 45px; height: 45px`      | `Width="45"`, `Height="45"`              | 컨트롤 크기                  |
| `border-radius: 10px`            | `CornerRadius="10"`                      | 모서리 둥글기                |
| `display: flex; align-items`     | `HorizontalAlignment`, `VerticalAlignment` | 정렬                         |
| `cursor: pointer`                | `Cursor="Hand"`                          | 커서 스타일                  |
| `input:checkbox`                 | `ToggleButton`                           | 토글 기능 베이스 컨트롤      |
| `stroke: white`                  | `Path.Stroke`                            | SVG 테두리 색상              |
| `fill: white` (checked)          | `Path.Fill` + Trigger                    | 체크 시 채우기 색상          |
| `stroke-dasharray` animation     | `ScaleTransform` animation               | 스케일 애니메이션으로 대체   |
| `transition-duration: 0.5s`      | `Duration="0:0:0.5"`                     | 애니메이션 지속 시간         |
| SVG `path d="..."`               | `Geometry` resource                      | 북마크 아이콘 경로 데이터    |

## 프로젝트 구조

```
BreezyGoose71/
├── Wpf/
│   ├── BreezyGoose71.Wpf.slnx
│   ├── BreezyGoose71.Wpf.Gallery/     # 데모 앱
│   └── BreezyGoose71.Wpf.UI/          # 커스텀 컨트롤 라이브러리
│       ├── Controls/
│       │   └── BreezyGoose71.cs
│       └── Themes/
│           ├── Generic.xaml
│           ├── BreezyGoose71.xaml
│           └── BreezyGoose71Resources.xaml
└── AvaloniaUI/                        # (미구현)
```

## 변환 특이사항

### CSS stroke-dasharray 애니메이션 대체

원본 CSS에서는 `stroke-dasharray`와 `stroke-dashoffset`을 이용한 선 그리기 애니메이션을 사용하지만, WPF에서는 이 기능을 직접 지원하지 않습니다. 대신 `ScaleTransform`을 사용한 펄스 애니메이션으로 체크 시각 효과를 구현했습니다.

### 컨트롤 베이스 클래스

`input type="checkbox"`는 WPF의 `ToggleButton`으로 변환되었습니다. `ToggleButton`은 `IsChecked` 속성을 통해 체크/언체크 상태를 관리합니다.
