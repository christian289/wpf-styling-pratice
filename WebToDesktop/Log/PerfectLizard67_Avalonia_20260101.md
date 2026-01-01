# PerfectLizard67 AvaloniaUI 변환 로그

## 원본 정보
- **출처**: Uiverse.io by boryanakrasteva
- **태그**: input, search
- **설명**: 클릭 시 확장되는 애니메이션 검색창

## 변환 결과

### 생성된 파일
```
WebToDesktop/Output/PerfectLizard67/AvaloniaUI/
├── PerfectLizard67.Avalonia.slnx
├── PerfectLizard67.Avalonia.Lib/
│   ├── PerfectLizard67.Avalonia.Lib.csproj
│   ├── Controls/
│   │   └── ExpandingSearchBox.cs
│   └── Themes/
│       ├── Generic.axaml
│       └── ExpandingSearchBox.axaml
└── PerfectLizard67.Avalonia.Gallery/
    ├── PerfectLizard67.Avalonia.Gallery.csproj
    ├── App.axaml
    ├── App.axaml.cs
    ├── MainWindow.axaml
    ├── MainWindow.axaml.cs
    └── Program.cs
```

### CSS to AXAML 변환 내용

| CSS 속성 | AvaloniaUI 속성 |
|---------|----------------|
| `border-radius: 50%` | `CornerRadius="25"` |
| `background-color: #7e4fd4` | `Background="{StaticResource ExpandingSearchBox.Primary.Brush}"` |
| `box-shadow: 0px 0px 3px #f3f3f3` | `BoxShadow="0 0 3 #f3f3f3"` (Border에 적용) |
| `transition: .5s ease-in-out` | `<DoubleTransition Duration="0:0:0.5" Easing="CubicEaseOut" />` |
| `:focus` pseudo-class | `.expanded` CSS class + PropertyChanged handler |

---

## 컴파일 에러 수정 내역

### 에러 1: TextBox에 BoxShadow 속성 없음
- **에러 메시지**: `Unable to resolve suitable regular or attached property BoxShadow on type Avalonia.Controls.TextBox`
- **원인**: AvaloniaUI의 TextBox에는 BoxShadow 속성이 없음. BoxShadow는 Border 컨트롤에만 존재
- **수정 방법**: TextBox를 Border로 감싸고, Border에 BoxShadow 적용
  ```xml
  <!-- 수정 전 -->
  <TextBox BoxShadow="0 0 3 #f3f3f3" ... />

  <!-- 수정 후 -->
  <Panel>
      <Border x:Name="PART_ShadowBorder" BoxShadow="0 0 3 #f3f3f3" ... />
      <TextBox Background="Transparent" ... />
  </Panel>
  ```

### 에러 2: ResourceDictionary를 StyleInclude로 로드 시도
- **에러 메시지**: `Resource is defined as "Avalonia.Controls.ResourceDictionary" type but expected "Avalonia.Styling.IStyle"`
- **원인**: App.axaml에서 StyleInclude를 사용했으나, Generic.axaml은 ResourceDictionary 타입
- **수정 방법**: Application.Resources에서 ResourceInclude로 병합
  ```xml
  <!-- 수정 전 -->
  <Application.Styles>
      <FluentTheme />
      <StyleInclude Source="avares://..." />
  </Application.Styles>

  <!-- 수정 후 -->
  <Application.Styles>
      <FluentTheme />
  </Application.Styles>
  <Application.Resources>
      <ResourceDictionary>
          <ResourceDictionary.MergedDictionaries>
              <ResourceInclude Source="avares://..." />
          </ResourceDictionary.MergedDictionaries>
      </ResourceDictionary>
  </Application.Resources>
  ```

---

## 잠재적 런타임 오류 가능성

### 1. Transition Easing 차이
- **설명**: CSS의 `cubic-bezier(0, 0.110, 0.35, 2)` 커브를 AvaloniaUI의 `CubicEaseOut`/`SpringEaseOut`으로 대체
- **영향**: 애니메이션 느낌이 원본과 약간 다를 수 있음
- **권장**: 실행 후 애니메이션 확인 필요

### 2. SVG Path 변환
- **설명**: 원본 SVG의 두 번째 path (`M22 22L20 20` - 검색 아이콘 손잡이)가 PathIcon에 포함되지 않음
- **영향**: 검색 아이콘이 원과 손잡이가 아닌 원만 표시될 수 있음
- **권장**: 실행 후 아이콘 모양 확인 필요, 필요시 DrawingGroup 사용

### 3. Font Family 가용성
- **설명**: `Trebuchet MS` 등 지정된 폰트가 시스템에 없을 경우 fallback 폰트 사용
- **영향**: 텍스트 스타일이 원본과 다를 수 있음
- **권장**: 크로스 플랫폼 테스트 시 확인 필요

---

## 빌드 결과
- **상태**: 성공
- **경고**: 0개
- **에러**: 0개
