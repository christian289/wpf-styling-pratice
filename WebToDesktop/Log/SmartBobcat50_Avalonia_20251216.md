# SmartBobcat50 AvaloniaUI 변환 로그

## 프로젝트 정보

- **원본**: uiverse.io by KSAplay (checkbox, like, heart)
- **변환 대상**: HTML/CSS → AvaloniaUI CustomControl
- **컨트롤 이름**: HeartCheckBox
- **변환 일시**: 2025-12-16

## 컴파일 에러 및 수정 내역

### 에러 1: ScaleTransform에 x:Name 속성 사용 불가

**에러 메시지**:
```
Avalonia error AVLN2000: Unable to resolve suitable regular or attached property Name on type Avalonia.Base:Avalonia.Media.ScaleTransform Line 31, position 34.
```

**원인**:
- AvaloniaUI에서 ScaleTransform은 Name attached property를 지원하지 않음
- WPF와 달리 Transform 객체에 x:Name을 부여할 수 없음

**수정 방법**:
- `<ScaleTransform x:Name="PathScaleTransform" ScaleX="1" ScaleY="1" />`
- → `<ScaleTransform ScaleX="1" ScaleY="1" />`

**수정 파일**: `SmartBobcat50.Avalonia.Lib/Themes/HeartCheckBox.axaml:31`

---

### 에러 2: Application.Styles에 ResourceDictionary 직접 포함 불가

**에러 메시지**:
```
Avalonia error AVLN2000: Resource "avares://SmartBobcat50.Avalonia.Lib/Themes/Generic.axaml" is defined as "Avalonia.Controls.ResourceDictionary" type in the "SmartBobcat50.Avalonia.Lib" assembly, but expected "Avalonia.Styling.IStyle".
```

**원인**:
- `Application.Styles`에는 IStyle 인터페이스를 구현한 객체만 포함 가능
- ResourceDictionary는 IStyle이 아니므로 StyleInclude로 직접 포함 불가

**수정 방법**:
```xml
<!-- 수정 전 -->
<Application.Styles>
    <FluentTheme />
    <StyleInclude Source="avares://SmartBobcat50.Avalonia.Lib/Themes/Generic.axaml" />
</Application.Styles>

<!-- 수정 후 -->
<Application.Styles>
    <FluentTheme />
</Application.Styles>

<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceInclude Source="avares://SmartBobcat50.Avalonia.Lib/Themes/Generic.axaml" />
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

**수정 파일**: `SmartBobcat50.Avalonia.Gallery/App.axaml`

---

## Runtime Error 가능성 (직접 확인 필요)

### 1. 애니메이션 타이밍 이슈

CSS `transition: 100ms`와 AvaloniaUI `Animation Duration="0:0:0.1"`은 동일하지만, 상태 전환 시 애니메이션 중첩 동작이 다를 수 있음.

**확인 사항**:
- hover → unhover 빠른 전환 시 애니메이션 끊김 여부
- checked/unchecked 토글 시 애니메이션 자연스러움

### 2. Path.RenderTransform 애니메이션

CSS의 transform 애니메이션은 요소 자체에 적용되지만, AXAML에서는 Path의 RenderTransform에 적용됨.

**확인 사항**:
- Scale 애니메이션 중심점(RenderTransformOrigin)이 의도대로 작동하는지 확인
- Viewbox 내부의 Path 스케일링이 예상대로 동작하는지 확인

### 3. 초기 로드 시 애니메이션

`:unchecked` 스타일에 애니메이션이 정의되어 있어 앱 시작 시 불필요한 애니메이션이 재생될 수 있음.

**확인 사항**:
- 앱 시작 시 하트가 scale 0 → 1.2 → 1 애니메이션 실행 여부

---

## 빌드 결과

```
빌드했습니다.
    경고 0개
    오류 0개
```

## 생성된 파일 구조

```
SmartBobcat50/AvaloniaUI/
├── SmartBobcat50.Avalonia.slnx
├── SmartBobcat50.Avalonia.Lib/
│   ├── SmartBobcat50.Avalonia.Lib.csproj
│   ├── Controls/
│   │   └── HeartCheckBox.cs
│   └── Themes/
│       ├── Generic.axaml
│       └── HeartCheckBox.axaml
└── SmartBobcat50.Avalonia.Gallery/
    ├── SmartBobcat50.Avalonia.Gallery.csproj
    ├── App.axaml
    ├── App.axaml.cs
    ├── MainWindow.axaml
    ├── MainWindow.axaml.cs
    └── Program.cs
```
