# RareCobra61 AvaloniaUI Conversion Log

## 변환 정보
- **날짜**: 2025-12-25
- **소스**: uiverse.io by akshat-patel28
- **태그**: login, button, form, input, login form, apple login, google login
- **컨트롤**: LoginForm (로그인 폼)

## 프로젝트 구조

```
RareCobra61/AvaloniaUI/
├── RareCobra61.Avalonia.slnx
├── RareCobra61.Avalonia.Lib/
│   ├── Controls/
│   │   └── LoginForm.cs
│   └── Themes/
│       ├── Generic.axaml
│       └── LoginForm.axaml
└── RareCobra61.Avalonia.Gallery/
    ├── App.axaml
    ├── App.axaml.cs
    ├── MainWindow.axaml
    ├── MainWindow.axaml.cs
    └── Program.cs
```

## CSS → AvaloniaUI 변환 매핑

| CSS 속성 | AvaloniaUI 속성 |
|----------|-----------------|
| `box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px` | `BoxShadow="0 5 15 #59000000"` |
| `box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px` | `BoxShadow="0 3 8 #3D000000"` |
| `border-radius: 20px` | `CornerRadius="20"` |
| `cursor: pointer` | `Cursor="Hand"` |
| `:hover` pseudo-class | `:pointerover` selector |
| `:active` pseudo-class | `:pressed` selector |
| `display: flex; flex-direction: column` | `StackPanel Orientation="Vertical"` |

## 컴파일 에러 및 수정

### 에러 1: StyleInclude vs ResourceInclude

**에러 내용**:
```
AVLN2000: Resource "avares://RareCobra61.Avalonia.Lib/Themes/Generic.axaml"
is defined as "Avalonia.Controls.ResourceDictionary" type in the
"RareCobra61.Avalonia.Lib" assembly, but expected "Avalonia.Styling.IStyle"
```

**원인**:
- `Application.Styles`에서 `StyleInclude`를 사용했으나, Generic.axaml은 `ResourceDictionary` 타입임
- AvaloniaUI에서 `StyleInclude`는 `IStyle` 인터페이스를 구현한 타입만 허용

**수정 방법**:
```xml
<!-- 수정 전 -->
<Application.Styles>
    <FluentTheme />
    <StyleInclude Source="avares://RareCobra61.Avalonia.Lib/Themes/Generic.axaml" />
</Application.Styles>

<!-- 수정 후 -->
<Application.Styles>
    <FluentTheme />
</Application.Styles>

<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceInclude Source="avares://RareCobra61.Avalonia.Lib/Themes/Generic.axaml" />
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

## 잠재적 런타임 오류 (직접 확인 필요)

### 1. PathIcon Data 경로 스케일 문제
- **위치**: `LoginForm.axaml` - Apple/Google 아이콘
- **내용**: SVG path data가 원본 viewBox(1024x1024 / 48x48)에 맞춰져 있어 18x18 아이콘에 스케일 적용됨
- **가능한 문제**: 아이콘이 너무 작거나 크게 렌더링될 수 있음
- **해결 방안**: `RenderTransform`으로 `ScaleTransform` 적용 완료, 런타임에서 확인 필요

### 2. Font Family 가용성
- **위치**: 모든 텍스트 요소
- **내용**: `Lucida Sans` 폰트 패밀리 사용
- **가능한 문제**: Windows 이외 플랫폼(Linux, macOS)에서 해당 폰트가 없을 수 있음
- **해결 방안**: fallback 폰트 체인(`Lucida Sans, Lucida Sans Regular, Lucida Grande, Lucida Sans Unicode, Geneva, Verdana, sans-serif`) 적용됨

### 3. TextBox Watermark 표시
- **위치**: `LoginFormTextBoxTheme`의 `PART_Watermark`
- **내용**: 커스텀 TextBox 템플릿에서 Watermark 표시 로직
- **가능한 문제**: 포커스/언포커스 시 Watermark 표시 동작이 예상과 다를 수 있음
- **해결 방안**: `StringConverters.IsNullOrEmpty` 컨버터로 Text 바인딩 처리됨

### 4. TemplateBinding 범위
- **위치**: 소셜 로그인 버튼의 텍스트
- **내용**: `Button` 내부에서 `$parent[controls:LoginForm]` 바인딩 사용
- **가능한 문제**: 바인딩 경로가 복잡하여 런타임에서 null 참조 발생 가능
- **해결 방안**: `$parent` 바인딩 구문으로 부모 컨트롤 참조

## 빌드 결과

```
빌드했습니다.
    경고 0개
    오류 0개
```

## 실행 명령

```bash
cd WebToDesktop/Output/RareCobra61/AvaloniaUI
dotnet run --project RareCobra61.Avalonia.Gallery
```
