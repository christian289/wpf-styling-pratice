# SwiftChicken44 AvaloniaUI 변환 로그

## 변환 정보
- **변환일**: 2025-12-21
- **원본**: HTML/CSS (uiverse.io by SARAN2004)
- **컨트롤 유형**: 유효성 검사 입력 컨트롤 (Inputs)

## 원본 CSS 분석
```css
.input {
  max-width: 190px;
  height: 45px;
  border-radius: 5px;
  padding-left: 15px;
  border: 1px solid #ccc;
  border-bottom-width: 2px;
  transition: all 0.3s ease;
}

.input:valid {
  border-color: #00ff2a;
  color: #00ff2a;
  box-shadow: 2px 2px 8px 1px #00ff2a;
}

.input:invalid {
  border-color: #ff0000;
  color: #ff0000;
  box-shadow: 2px 2px 8px 1px #ff0000;
}
```

## 컴파일 에러 및 수정

### 에러 1: BoxShadowsTransition 위치 오류
**에러 메시지**:
```
AVLN2000: Unable to resolve suitable regular or attached property BoxShadow
on type SwiftChicken44.Avalonia.Lib.Controls.ValidationTextBox
```

**원인**:
- `BoxShadowsTransition`을 `ValidationTextBox` 컨트롤의 `Transitions` 속성에 직접 설정
- `ValidationTextBox`는 `TemplatedControl`을 상속하며, 이 클래스에는 `BoxShadow` 속성이 없음

**수정 방법**:
- `BoxShadowsTransition`을 템플릿 내부의 `Border#PART_Border`에 대한 스타일로 이동
- `Border` 클래스에는 `BoxShadow` 속성이 존재함

**수정 전**:
```xml
<Setter Property="Transitions">
    <Transitions>
        <BrushTransition Property="BorderBrush" Duration="0:0:0.3" />
        <BrushTransition Property="Foreground" Duration="0:0:0.3" />
        <BoxShadowsTransition Property="BoxShadow" Duration="0:0:0.3" />
    </Transitions>
</Setter>
```

**수정 후**:
```xml
<Setter Property="Transitions">
    <Transitions>
        <BrushTransition Property="BorderBrush" Duration="0:0:0.3" />
        <BrushTransition Property="Foreground" Duration="0:0:0.3" />
    </Transitions>
</Setter>

<Style Selector="^ /template/ Border#PART_Border">
    <Setter Property="Transitions">
        <Transitions>
            <BoxShadowsTransition Property="BoxShadow" Duration="0:0:0.3" />
        </Transitions>
    </Setter>
</Style>
```

---

### 에러 2: StyleInclude로 ResourceDictionary 로드 불가
**에러 메시지**:
```
AVLN2000: Resource "avares://SwiftChicken44.Avalonia.Lib/Themes/Generic.axaml"
is defined as "Avalonia.Controls.ResourceDictionary" type in the assembly,
but expected "Avalonia.Styling.IStyle"
```

**원인**:
- `Application.Styles` 내에서 `StyleInclude`는 `IStyle` 타입만 로드 가능
- `Generic.axaml`은 `ResourceDictionary` 타입으로 정의됨

**수정 방법**:
- `Application.Resources`로 `ResourceDictionary`를 병합

**수정 전**:
```xml
<Application.Styles>
    <FluentTheme />
    <StyleInclude Source="avares://SwiftChicken44.Avalonia.Lib/Themes/Generic.axaml" />
</Application.Styles>
```

**수정 후**:
```xml
<Application.Styles>
    <FluentTheme />
</Application.Styles>

<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceInclude Source="avares://SwiftChicken44.Avalonia.Lib/Themes/Generic.axaml" />
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

---

## 잠재적 런타임 오류

### 1. TextBox 바인딩 동기화 문제
- **위치**: `ValidationTextBox.axaml` 내 `TextBox#PART_TextBox`
- **설명**: 템플릿 내부 `TextBox`의 `Text` 속성이 `ValidationTextBox.Text`에 바인딩됨
- **잠재적 문제**: 사용자가 입력 시 바인딩 업데이트 타이밍에 따라 유효성 검사가 지연될 수 있음
- **확인 필요**: 실제 입력 시 `:valid`/`:invalid` 상태 변경이 즉시 반영되는지 테스트

### 2. Placeholder와 Watermark 중복
- **위치**: `ValidationTextBox.axaml`
- **설명**: `TextBlock#PART_Placeholder`와 `TextBox`의 `Watermark` 속성이 동시에 설정됨
- **잠재적 문제**: 두 플레이스홀더가 겹쳐 보일 수 있음
- **확인 필요**: 실행 시 플레이스홀더 표시 정상 동작 테스트

### 3. 빈 상태 스타일 우선순위
- **위치**: `:empty`, `:valid`, `:invalid` 스타일
- **설명**: 빈 상태에서 `IsRequired=True`일 때 `:empty`와 `:invalid`가 모두 적용될 수 있음
- **잠재적 문제**: 스타일 우선순위에 따라 예상과 다른 스타일이 적용될 수 있음
- **확인 필요**: 빈 상태 + 필수 필드일 때 적용되는 스타일 확인

---

## 빌드 결과
- **상태**: 성공
- **경고**: 0개
- **오류**: 0개 (수정 후)

## 파일 구조
```
SwiftChicken44/AvaloniaUI/
├── SwiftChicken44.Avalonia.slnx
├── SwiftChicken44.Avalonia.Lib/
│   ├── SwiftChicken44.Avalonia.Lib.csproj
│   ├── Controls/
│   │   └── ValidationTextBox.cs
│   └── Themes/
│       ├── Generic.axaml
│       └── ValidationTextBox.axaml
└── SwiftChicken44.Avalonia.Gallery/
    ├── SwiftChicken44.Avalonia.Gallery.csproj
    ├── App.axaml
    ├── App.axaml.cs
    ├── MainWindow.axaml
    ├── MainWindow.axaml.cs
    └── Program.cs
```
