# WetQuail86 AvaloniaUI Conversion Log

## 변환 정보 / Conversion Info

- **원본 소스 / Source**: Uiverse.io by catraco
- **변환 일자 / Date**: 2026-01-03
- **컨트롤 타입 / Control Type**: TextBox with tooltip-style title
- **태그 / Tags**: input, dark, advanced, input effect

## 컴파일 에러 및 수정 내용 / Compile Errors and Fixes

### 에러 1: Avalonia.Sdk를 찾을 수 없음 / Avalonia.Sdk not found

**에러 내용 / Error**:
```
error MSB4236: 지정된 'Avalonia.Sdk/11.2.6' SDK를 찾을 수 없습니다.
```

**수정 방법 / Fix**:
- `Sdk="Avalonia.Sdk/11.2.6"` 대신 `Sdk="Microsoft.NET.Sdk"`를 사용
- `<PackageReference Include="Avalonia" Version="11.2.2"/>` NuGet 패키지 참조 추가

### 에러 2: ResourceDictionary를 IStyle로 사용 불가 / ResourceDictionary cannot be used as IStyle

**에러 내용 / Error**:
```
Avalonia error AVLN2000: Resource "avares://WetQuail86.Avalonia.Lib/Themes/Generic.axaml" is defined as "Avalonia.Controls.ResourceDictionary" type in the "WetQuail86.Avalonia.Lib" assembly, but expected "Avalonia.Styling.IStyle".
```

**수정 방법 / Fix**:
- Generic.axaml의 루트 요소를 `<ResourceDictionary>`에서 `<Styles>`로 변경
- 스타일 병합을 `<ResourceDictionary.MergedDictionaries>`에서 `<StyleInclude>`로 변경
- 컨트롤 스타일 파일도 `<Styles>` + `<Styles.Resources>` 구조로 변경

**변경 전 / Before**:
```xml
<ResourceDictionary xmlns="https://github.com/avaloniaui" ...>
    <ResourceDictionary.MergedDictionaries>
        <ResourceInclude Source="..."/>
    </ResourceDictionary.MergedDictionaries>
</ResourceDictionary>
```

**변경 후 / After**:
```xml
<Styles xmlns="https://github.com/avaloniaui" ...>
    <StyleInclude Source="..."/>
</Styles>
```

## CSS → Avalonia 변환 패턴 / CSS to Avalonia Conversion Patterns

| CSS | Avalonia |
|-----|----------|
| `:hover` | `:pointerover` |
| `:focus` | `:focus-within` |
| `opacity: 0` → `1` transition | `Animation` with `FillMode="Forward"` |
| `letter-spacing: 2px` | `LetterSpacing="2"` |
| `::before` pseudo-element | 별도 Border 요소 (45도 회전) |
| `border-radius: var(--br)` | `CornerRadius` (CornerRadius 타입 리소스 사용) |

## Runtime Error 가능성 / Potential Runtime Errors

1. **TemplateBinding 문제**: `TemplateBinding Title`이 정상 동작하지 않을 경우 `{Binding Title, RelativeSource={RelativeSource TemplatedParent}}`로 변경 필요
2. **Animation FillMode**: `FillMode="Forward"`가 지원되지 않는 버전에서는 애니메이션 후 상태가 초기화될 수 있음
3. **TextBox 내부 스타일 충돌**: 내부 PART_TextBox가 FluentTheme의 기본 스타일과 충돌할 수 있음 (Foreground, Background 색상 등)

## 프로젝트 구조 / Project Structure

```
WetQuail86/AvaloniaUI/
├── WetQuail86.Avalonia.slnx
├── WetQuail86.Avalonia.Lib/
│   ├── WetQuail86.Avalonia.Lib.csproj
│   ├── Controls/
│   │   └── WetQuail86TextBox.cs
│   └── Themes/
│       ├── Generic.axaml
│       ├── WetQuail86TextBox.axaml
│       └── WetQuail86TextBoxResources.axaml
└── WetQuail86.Avalonia.Gallery/
    ├── WetQuail86.Avalonia.Gallery.csproj
    ├── Program.cs
    ├── App.axaml / App.axaml.cs
    └── MainWindow.axaml / MainWindow.axaml.cs
```

## 빌드 결과 / Build Result

```
빌드했습니다.
    경고 0개
    오류 0개
```
