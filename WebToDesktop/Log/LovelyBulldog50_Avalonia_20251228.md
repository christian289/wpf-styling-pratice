# LovelyBulldog50 AvaloniaUI 변환 로그

## 변환 정보

- **원본**: uiverse.io by sonusng (Tags: input)
- **변환 날짜**: 2025-12-28
- **컨트롤명**: ShakeTextBox

## 컴포넌트 설명

입력이 비어있을 때 흔들림 애니메이션을 표시하고, 입력이 유효할 때 테두리 색상이 변경되는 TextBox 컨트롤입니다.

### 기능

- 빈 입력 시 빨간색 테두리 (`#fe4567`) + 흔들림 애니메이션 (3회 반복)
- 유효한 입력 시 녹색 테두리 (`#45feaf`)
- 투명 배경, 흰색 텍스트

## 컴파일 에러 및 수정 내역

### 에러 1: CS1660 - 람다 식 변환 오류

**에러 내용**:
```
error CS1660: 람다 식은(는) 대리자 형식이 아니므로 'IObserver<string>' 형식으로 변환할 수 없습니다.
```

**원인**:
`IObservable<T>.Subscribe()` 메서드에 람다 식을 직접 전달하려면 System.Reactive 패키지가 필요하지만, 기본 Avalonia 패키지만으로는 불가능합니다.

**수정 방법**:
인스턴스 생성자 대신 정적 생성자에서 `AvaloniaProperty.Changed.AddClassHandler<T>()` 패턴을 사용하여 속성 변경을 감지하도록 수정했습니다.

```csharp
// 수정 전 (에러 발생)
public ShakeTextBox()
{
    this.GetObservable(TextProperty).Subscribe(text =>
    {
        IsValid = !string.IsNullOrEmpty(text);
    });
}

// 수정 후
static ShakeTextBox()
{
    TextProperty.Changed.AddClassHandler<ShakeTextBox>((textBox, e) =>
    {
        textBox.IsValid = !string.IsNullOrEmpty(e.NewValue as string);
    });
}
```

### 에러 2: AVLN2000 - ResourceDictionary 타입 불일치

**에러 내용**:
```
Avalonia error AVLN2000: Resource "avares://LovelyBulldog50.Avalonia.Lib/Themes/Generic.axaml" is defined as "Avalonia.Controls.ResourceDictionary" type in the "LovelyBulldog50.Avalonia.Lib" assembly, but expected "Avalonia.Styling.IStyle".
```

**원인**:
`Application.Styles`에서 `StyleInclude`를 사용하여 ResourceDictionary를 포함하려 했으나, IStyle 타입만 허용됩니다.

**수정 방법**:
`Application.Resources`에 `ResourceDictionary.MergedDictionaries`를 사용하여 ResourceDictionary를 병합하도록 수정했습니다.

```xml
<!-- 수정 전 (에러 발생) -->
<Application.Styles>
    <FluentTheme />
    <StyleInclude Source="avares://LovelyBulldog50.Avalonia.Lib/Themes/Generic.axaml" />
</Application.Styles>

<!-- 수정 후 -->
<Application.Styles>
    <FluentTheme />
</Application.Styles>
<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceInclude Source="avares://LovelyBulldog50.Avalonia.Lib/Themes/Generic.axaml" />
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

## 잠재적 런타임 오류

### 1. 흔들림 애니메이션 동작 확인 필요

**문제**: CSS `translate` 속성을 AvaloniaUI `TranslateTransform.X`로 변환했으나, 애니메이션이 초기 로드 시 트리거되는 방식이 다를 수 있습니다.

**확인 필요**:
- 컨트롤 로드 시 애니메이션이 정상적으로 3회 실행되는지
- `.valid` 클래스 추가 시 애니메이션이 멈추는지

### 2. Classes.valid 바인딩 동작 확인 필요

**문제**: `Classes.valid="{Binding IsValid, RelativeSource={RelativeSource Self}}"` 바인딩이 IsValid 속성 변경 시 정상적으로 CSS 클래스를 토글하는지 확인이 필요합니다.

**대안**: 바인딩이 작동하지 않을 경우 코드비하인드에서 직접 클래스를 토글해야 할 수 있습니다.

### 3. ControlTheme 적용 확인 필요

**문제**: `ControlTheme`이 ResourceDictionary를 통해 병합될 때 자동으로 ShakeTextBox에 적용되는지 확인이 필요합니다.

## 프로젝트 구조

```
LovelyBulldog50/AvaloniaUI/
├── LovelyBulldog50.Avalonia.slnx
├── LovelyBulldog50.Avalonia.Lib/
│   ├── LovelyBulldog50.Avalonia.Lib.csproj
│   ├── Controls/
│   │   └── ShakeTextBox.cs
│   └── Themes/
│       ├── Generic.axaml
│       └── ShakeTextBox.axaml
└── LovelyBulldog50.Avalonia.Gallery/
    ├── LovelyBulldog50.Avalonia.Gallery.csproj
    ├── Program.cs
    ├── App.axaml
    ├── App.axaml.cs
    ├── MainWindow.axaml
    └── MainWindow.axaml.cs
```

## 빌드 결과

```
빌드했습니다.
    경고 0개
    오류 0개
```
