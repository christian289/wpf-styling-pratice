# PerfectCheetah72 AvaloniaUI 변환 로그

## 변환 정보

- **원본**: HTML/CSS (uiverse.io by Galahhad)
- **대상**: AvaloniaUI 11.2.2
- **변환일**: 2025-12-26
- **컨트롤 유형**: Theme Popup (테마 선택 드롭다운)

## 프로젝트 구조

```
PerfectCheetah72/AvaloniaUI/
├── PerfectCheetah72.Avalonia.slnx
├── PerfectCheetah72.Avalonia.Lib/
│   ├── Controls/
│   │   └── ThemePopup.cs
│   └── Themes/
│       ├── Generic.axaml
│       └── ThemePopup.axaml
└── PerfectCheetah72.Avalonia.Gallery/
    ├── App.axaml
    ├── App.axaml.cs
    ├── MainWindow.axaml
    ├── MainWindow.axaml.cs
    └── Program.cs
```

## 컴파일 에러 및 수정

### 에러 1: StyleInclude vs ResourceInclude

**에러 내용**:
```
AVLN2000: Resource "avares://PerfectCheetah72.Avalonia.Lib/Themes/Generic.axaml" is defined as "Avalonia.Controls.ResourceDictionary" type in the "PerfectCheetah72.Avalonia.Lib" assembly, but expected "Avalonia.Styling.IStyle".
```

**원인**:
- App.axaml에서 `<StyleInclude>`를 사용하여 ResourceDictionary를 로드하려고 함
- `StyleInclude`는 `IStyle`을 구현하는 리소스만 로드 가능
- `ResourceDictionary`는 `IStyle`이 아니므로 `ResourceInclude`를 사용해야 함

**수정 방법**:
```xml
<!-- 수정 전 -->
<Application.Styles>
    <FluentTheme />
    <StyleInclude Source="avares://PerfectCheetah72.Avalonia.Lib/Themes/Generic.axaml" />
</Application.Styles>

<!-- 수정 후 -->
<Application.Styles>
    <FluentTheme />
</Application.Styles>

<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceInclude Source="avares://PerfectCheetah72.Avalonia.Lib/Themes/Generic.axaml" />
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

## 잠재적 런타임 에러 (확인 필요)

### 1. ToggleButton 중첩된 Content

- ToggleButton의 Template 내부에 아이콘 Panel이 있고, ToggleButton의 Content로도 Panel을 설정함
- 두 개의 아이콘 세트가 존재하여 의도한 동작이 아닐 수 있음
- **확인 필요**: 버튼 클릭 시 선택된 테마에 따른 아이콘 표시 확인

### 2. 선택된 테마에 따른 아이콘 토글

- CSS에서는 `:checked` 선택자로 라디오 버튼 상태에 따라 아이콘을 표시/숨김
- AvaloniaUI에서는 `SelectedTheme` 속성에 따라 아이콘 IsVisible을 바인딩해야 함
- 현재 구현에서는 Default 아이콘만 표시되고 테마 변경 시 아이콘이 변경되지 않음
- **확인 필요**: 테마 선택 시 버튼 아이콘 변경 확인

### 3. 팝업 라이트 디스미스

- `IsLightDismissEnabled="True"` 설정으로 외부 클릭 시 팝업 닫힘
- 단, AvaloniaUI 버전에 따라 동작이 다를 수 있음
- **확인 필요**: 팝업 외부 클릭 시 정상적으로 닫히는지 확인

### 4. 선택된 항목 하이라이트

- CSS에서는 선택된 라디오 버튼에 따라 해당 리스트 아이템에 배경색과 테두리 적용
- 현재 구현에서는 모든 리스트 아이템이 동일한 스타일 사용
- **확인 필요**: 선택된 테마에 해당하는 리스트 아이템 하이라이트 확인

## CSS → AvaloniaUI 변환 매핑

| CSS 속성 | AvaloniaUI 속성 |
|---------|----------------|
| `--total_text_color: #e0e0e0` | `<Color x:Key="ThemePopup.TextColor">#E0E0E0</Color>` |
| `--btn_bg: #3A3A3A` | `<Color x:Key="ThemePopup.ButtonBackground">#3A3A3A</Color>` |
| `border-radius: 0.3125em` | `CornerRadius="5"` |
| `display: flex; align-items: center` | `<StackPanel Orientation="Horizontal">` |
| `column-gap: 0.3125em` | `Spacing="5"` |
| `:hover` | `:pointerover` |
| `:checked` | `IsChecked` 또는 `SelectedTheme` 속성 |
| `display: none/block` | `IsVisible="True/False"` |

## 빌드 결과

- **최종 상태**: 성공
- **경고**: 0개
- **에러**: 0개
