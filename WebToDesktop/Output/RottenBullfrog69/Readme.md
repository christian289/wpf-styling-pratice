# RottenBullfrog69

ChatGPT 스타일의 채팅 UI 컨트롤 (Forms 스타일 컨트롤)

## 원본 정보

- **원작자**: shadowmurphy
- **원본 링크**: [https://uiverse.io/shadowmurphy/rotten-bullfrog-69](https://uiverse.io/shadowmurphy/rotten-bullfrog-69) (클릭 시 원본 CSS/HTML 확인 가능)
- **태그**: form, message, arrow, chat, chatgpt, close, colors

## 미리보기

다크 테마 기반의 채팅 UI로 다음 구성 요소를 포함합니다:
- 네비게이션 바 (제목 + 닫기 버튼)
- 메시지 영역 (줄무늬 배경)
- 입력 영역 (텍스트 입력 + 전송 버튼)

## 빌드 및 실행

### WPF
```bash
cd Wpf && dotnet run --project RottenBullfrog69.Wpf.Gallery
```

### AvaloniaUI
```bash
cd AvaloniaUI && dotnet run --project RottenBullfrog69.Avalonia.Gallery
```

## 사용 방법

```xml
<Window xmlns:controls="clr-namespace:RottenBullfrog69.Wpf.UI.Controls;assembly=RottenBullfrog69.Wpf.UI">
    <controls:RottenBullfrog69
        Title="Chat"
        PlaceholderText="Send a message."
        CloseClicked="OnCloseClicked"
        SendClicked="OnSendClicked"/>
</Window>
```

## 속성

| 속성 | 타입 | 기본값 | 설명 |
|------|------|--------|------|
| `Title` | `string` | "Chat" | 네비게이션 바 제목 |
| `PlaceholderText` | `string` | "Send a message." | 입력 필드 플레이스홀더 |
| `InputText` | `string` | "" | 입력된 텍스트 (양방향 바인딩) |
| `CloseCommand` | `ICommand` | null | 닫기 버튼 Command |
| `SendCommand` | `ICommand` | null | 전송 버튼 Command |

## 이벤트

| 이벤트 | 설명 |
|--------|------|
| `CloseClicked` | 닫기 버튼 클릭 시 발생 |
| `SendClicked` | 전송 버튼 클릭 시 발생 |

## CSS → WPF 변환 매핑 테이블

| CSS 속성/클래스 | WPF 구현 |
|-----------------|----------|
| `.container { background-color: #343541 }` | `SolidColorBrush` 리소스 |
| `.container { border-radius: 8px }` | `Border.CornerRadius="8"` + `Border.Clip` |
| `display: flex; flex-direction: column` | `Grid` with `RowDefinitions` |
| `display: flex; justify-content: space-between` | `Grid` with `ColumnDefinitions` |
| `.line { transform: rotate(45deg) }` | `Border.RenderTransform` + `RotateTransform` |
| `position: absolute` (X 버튼 라인) | 중첩된 `Border` 요소 |
| `.message.one, .three, .five { background }` | 교대로 배치된 `Border` 배경색 |
| `.send-input::placeholder` | `TextBlock` 오버레이 + `DataTrigger` |
| `gap: 5px` | 개별 `Margin` 속성 |
| `cursor: pointer` | `Cursor="Hand"` |
| SVG `<path>` | `Path.Data` + `Geometry` 리소스 |

## 프로젝트 구조

```
RottenBullfrog69/
├── Wpf/
│   ├── RottenBullfrog69.Wpf.slnx
│   ├── RottenBullfrog69.Wpf.UI/
│   │   ├── Controls/
│   │   │   ├── RottenBullfrog69.cs
│   │   │   └── Converters.cs
│   │   └── Themes/
│   │       ├── Generic.xaml
│   │       ├── RottenBullfrog69.xaml
│   │       └── RottenBullfrog69Resources.xaml
│   └── RottenBullfrog69.Wpf.Gallery/
│       ├── App.xaml
│       └── MainWindow.xaml
└── AvaloniaUI/
    └── (향후 추가 예정)
```
