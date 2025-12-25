# WiseCrab44 - AvaloniaUI 변환 로그

## 변환 정보

- **소스**: uiverse.io by RashadGhzi (Tags: simple, form, input, modern)
- **변환 일자**: 2025-12-25
- **대상 프레임워크**: .NET 9.0 / Avalonia 11.2.3

## 원본 HTML 분석

프롬프트 입력 폼 컴포넌트:
- 클라우드 업로드 버튼 (SVG 아이콘)
- 텍스트 입력 필드 (placeholder: "Enter your prompt...")
- 전송 버튼 (SVG 아이콘)
- Tailwind CSS 클래스 기반 스타일링

## 생성된 파일 구조

```
WiseCrab44/AvaloniaUI/
├── WiseCrab44.Avalonia.slnx
├── WiseCrab44.Avalonia.Lib/
│   ├── WiseCrab44.Avalonia.Lib.csproj
│   ├── Controls/
│   │   └── PromptInputBox.cs
│   └── Themes/
│       ├── Generic.axaml
│       └── PromptInputBox.axaml
└── WiseCrab44.Avalonia.Gallery/
    ├── WiseCrab44.Avalonia.Gallery.csproj
    ├── App.axaml
    ├── App.axaml.cs
    ├── MainWindow.axaml
    ├── MainWindow.axaml.cs
    └── Program.cs
```

## 컴파일 에러 및 수정 내역

### 에러 1: TextPresenter Padding 속성 미지원

**에러 메시지:**
```
AVLN2000: Unable to resolve suitable regular or attached property Padding on type Avalonia.Controls:Avalonia.Controls.Presenters.TextPresenter
```

**원인:**
- AvaloniaUI의 `TextPresenter`는 WPF와 달리 `Padding` 속성을 직접 지원하지 않음

**수정 방법:**
- `TextPresenter`에서 `Padding` 속성 제거
- 대신 부모 `ScrollViewer`에 `Padding` 속성 적용

**수정 전:**
```xml
<ScrollViewer x:Name="PART_ScrollViewer" ...>
    <TextPresenter x:Name="PART_TextPresenter"
                   Padding="{TemplateBinding Padding}"
                   .../>
</ScrollViewer>
```

**수정 후:**
```xml
<ScrollViewer x:Name="PART_ScrollViewer"
              Padding="{TemplateBinding Padding}"
              ...>
    <TextPresenter x:Name="PART_TextPresenter"
                   .../>
</ScrollViewer>
```

---

### 에러 2: ResourceDictionary를 Styles에 포함 시도

**에러 메시지:**
```
AVLN2000: Resource "avares://WiseCrab44.Avalonia.Lib/Themes/Generic.axaml" is defined as "Avalonia.Controls.ResourceDictionary" type in the "WiseCrab44.Avalonia.Lib" assembly, but expected "Avalonia.Styling.IStyle"
```

**원인:**
- `Application.Styles`에는 `IStyle` 타입만 포함 가능
- `ResourceDictionary`는 `Application.Resources`에 병합해야 함

**수정 방법:**
- `StyleInclude`를 `Application.Styles`에서 제거
- `ResourceInclude`를 `Application.Resources` 내 `MergedDictionaries`에 추가

**수정 전:**
```xml
<Application.Styles>
    <FluentTheme/>
    <StyleInclude Source="avares://WiseCrab44.Avalonia.Lib/Themes/Generic.axaml"/>
</Application.Styles>
```

**수정 후:**
```xml
<Application.Styles>
    <FluentTheme/>
</Application.Styles>
<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceInclude Source="avares://WiseCrab44.Avalonia.Lib/Themes/Generic.axaml"/>
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

## 잠재적 런타임 오류

### 1. SVG Path 데이터 렌더링 문제

**위험도:** 낮음

**설명:**
- HTML의 SVG path 데이터를 AvaloniaUI `StreamGeometry`로 직접 변환
- 일부 복잡한 SVG path 명령어가 AvaloniaUI에서 다르게 해석될 수 있음

**확인 필요 사항:**
- 클라우드 업로드 아이콘과 전송 아이콘이 정상적으로 표시되는지 확인

### 2. TextBox Watermark 표시 로직

**위험도:** 낮음

**설명:**
- 커스텀 `ControlTheme`에서 Watermark(placeholder) 표시를 위해 `:empty` 선택자 사용
- 텍스트 입력 후 지워도 Watermark가 다시 표시되지 않을 수 있음

**확인 필요 사항:**
- 텍스트 입력 → 삭제 → Watermark 재표시 시나리오 테스트

### 3. BoxShadow 렌더링

**위험도:** 매우 낮음

**설명:**
- CSS `box-shadow`를 AvaloniaUI `BoxShadow`로 변환
- 그림자 색상의 알파값이 미묘하게 다르게 보일 수 있음

## CSS → AXAML 변환 매핑

| CSS (Tailwind)       | AvaloniaUI                      |
| -------------------- | ------------------------------- |
| `p-6`                | `Padding="24"`                  |
| `rounded-md`         | `CornerRadius="6"`              |
| `shadow-md`          | `BoxShadow="0 4 6 #1A000000"`   |
| `border`             | `BorderThickness="1"`           |
| `border-gray-300`    | `BorderBrush="#D1D5DB"`         |
| `hover:bg-gray-100`  | `:pointerover` + `Background`   |
| `focus:outline-none` | (기본 동작)                     |
| `flex-grow`          | `Grid.Column="1"` (확장 열)     |
| `text-gray-600`      | `Foreground="#4B5563"`          |

## 빌드 결과

**최종 빌드 상태:** 성공 (경고 0, 오류 0)

```
dotnet build WiseCrab44.Avalonia.slnx
빌드했습니다.
    경고 0개
    오류 0개
```
