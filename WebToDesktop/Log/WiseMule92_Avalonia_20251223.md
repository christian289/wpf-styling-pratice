# WiseMule92 AvaloniaUI 변환 로그

## 변환 정보

- **원본**: uiverse.io by PriyanshuGupta28 (button)
- **변환일**: 2025-12-23
- **프레임워크**: AvaloniaUI 11.2.2 / .NET 9.0

## 컨트롤 설명

일본어 텍스트(鬼滅の刃)가 있는 애니메이션 버튼입니다.

### 기능

- 기본 상태: 빨간색 배경(#f44336), 흰색 텍스트
- Hover 상태: 흰색 배경, 빨간색 텍스트, 복잡한 box-shadow
- Hover 시 텍스트 애니메이션: 회전(-10deg) + 확대(1.1x)
- 0.3초 CubicEaseInOut 전환 애니메이션

## 컴파일 에러 및 수정

### 에러 1: Transform에 x:Name 사용 불가

**에러 메시지**:
```
Avalonia error AVLN2000: Unable to resolve suitable regular or attached property Name on type Avalonia.Base:Avalonia.Media.RotateTransform
Avalonia error AVLN2000: Unable to resolve suitable regular or attached property Name on type Avalonia.Base:Avalonia.Media.ScaleTransform
```

**원인**:
AvaloniaUI에서 `RotateTransform`, `ScaleTransform` 등 Transform 요소에는 `x:Name` 속성을 직접 사용할 수 없음.

**수정 방법**:
```xml
<!-- 수정 전 (에러 발생) -->
<RotateTransform x:Name="RotateTransform" Angle="0" />
<ScaleTransform x:Name="ScaleTransform" ScaleX="1" ScaleY="1" />

<!-- 수정 후 (정상 동작) -->
<RotateTransform Angle="0" />
<ScaleTransform ScaleX="1" ScaleY="1" />
```

### 에러 2: StyleInclude에 ResourceDictionary 타입 불일치

**에러 메시지**:
```
Avalonia error AVLN2000: Resource "avares://WiseMule92.Avalonia.Lib/Themes/Generic.axaml" is defined as "Avalonia.Controls.ResourceDictionary" type in the "WiseMule92.Avalonia.Lib" assembly, but expected "Avalonia.Styling.IStyle"
```

**원인**:
`Application.Styles`에 포함되는 리소스는 `IStyle` 타입이어야 함. `ResourceDictionary` 타입은 직접 Styles에 포함될 수 없음.

**수정 방법**:
```xml
<!-- 수정 전 (에러 발생) -->
<ResourceDictionary xmlns="https://github.com/avaloniaui"
                    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">
    <ResourceDictionary.MergedDictionaries>
        <ResourceInclude Source="avares://WiseMule92.Avalonia.Lib/Themes/WiseMule92Button.axaml" />
    </ResourceDictionary.MergedDictionaries>
</ResourceDictionary>

<!-- 수정 후 (정상 동작) -->
<Styles xmlns="https://github.com/avaloniaui"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">
    <Styles.Resources>
        <ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>
                <ResourceInclude Source="avares://WiseMule92.Avalonia.Lib/Themes/WiseMule92Button.axaml" />
            </ResourceDictionary.MergedDictionaries>
        </ResourceDictionary>
    </Styles.Resources>
</Styles>
```

## 런타임 오류 가능성

### 1. 애니메이션 RenderTransform 할당 문제

**잠재적 문제**:
Style.Animations에서 `RenderTransform`에 새로운 `TransformGroup`을 할당하는 방식은 런타임에서 예상대로 동작하지 않을 수 있음.

**현재 코드**:
```xml
<Style.Animations>
    <Animation Duration="0:0:0.3" Easing="CubicEaseInOut" FillMode="Forward">
        <KeyFrame Cue="100%">
            <Setter Property="RenderTransform">
                <TransformGroup>
                    <RotateTransform Angle="-10" />
                    <ScaleTransform ScaleX="1.1" ScaleY="1.1" />
                </TransformGroup>
            </Setter>
        </KeyFrame>
    </Animation>
</Style.Animations>
```

**확인 필요**:
- 직접 실행하여 회전/확대 애니메이션이 부드럽게 전환되는지 확인
- 전환이 끊기거나 깜빡임이 발생하면 코드비하인드에서 애니메이션 처리 필요

### 2. BoxShadow inset 렌더링

**잠재적 문제**:
CSS의 복잡한 inset box-shadow를 AvaloniaUI BoxShadow로 변환했으나, 일부 브라우저 렌더링과 차이가 있을 수 있음.

**현재 코드**:
```xml
BoxShadow="0 -23 25 0 #2B000000 inset, 0 -36 30 0 #26000000 inset, 0 -79 40 0 #1A000000 inset, 0 2 1 0 #0F000000, 0 4 2 0 #17000000, 0 8 4 0 #17000000, 0 16 8 0 #17000000, 0 32 16 0 #17000000"
```

**확인 필요**:
- 실행하여 그림자 효과가 CSS 원본과 유사한지 시각적으로 확인

## 프로젝트 구조

```
WiseMule92/AvaloniaUI/
├── WiseMule92.Avalonia.slnx
├── WiseMule92.Avalonia.Lib/
│   ├── Controls/
│   │   └── WiseMule92Button.cs
│   ├── Themes/
│   │   ├── Generic.axaml
│   │   └── WiseMule92Button.axaml
│   └── WiseMule92.Avalonia.Lib.csproj
└── WiseMule92.Avalonia.Gallery/
    ├── App.axaml
    ├── App.axaml.cs
    ├── MainWindow.axaml
    ├── MainWindow.axaml.cs
    ├── Program.cs
    ├── app.manifest
    └── WiseMule92.Avalonia.Gallery.csproj
```

## 빌드 결과

- **빌드 상태**: 성공
- **경고**: 0개
- **에러**: 0개
