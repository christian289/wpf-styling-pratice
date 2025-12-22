# BigSloth59 AvaloniaUI 변환 로그

## 변환 정보

- **날짜**: 2025-12-22
- **원본**: Uiverse.io by ozgeozkaraa01
- **컨트롤 유형**: Input (TextBox)
- **플랫폼**: AvaloniaUI 11.2.2 / .NET 9.0

## 원본 CSS 분석

```css
.input {
  font-weight: 500;
  font-size: 14px;
  height: 40px;
  border-radius: 10px;
  padding-left: 10px;
  border: none;
  border-bottom: 1px solid #e5e5e5;
  outline: none;
}

.input:focus {
  border-bottom: 1px solid #6941c6;
  transition: 0.5s;
}
```

## 변환 매핑

| CSS 속성 | AvaloniaUI 속성 |
|---------|----------------|
| `font-weight: 500` | `FontWeight="Medium"` |
| `font-size: 14px` | `FontSize="14"` |
| `height: 40px` | `MinHeight="40"` |
| `border-radius: 10px` | `CornerRadius="10"` |
| `padding-left: 10px` | `Padding="10,0,10,0"` |
| `border-bottom: 1px solid #e5e5e5` | `BorderThickness="0,0,0,1"` + `BorderBrush` |
| `:focus` | `:focus` pseudo-class selector |
| `transition: 0.5s` | `Animation Duration="0:0:0.5"` |

## 컴파일 에러 및 수정

### 에러 1: AVLN2000 - StyleInclude vs ResourceInclude

**에러 내용**:
```
Avalonia error AVLN2000: Resource "avares://BigSloth59.Avalonia.Lib/Themes/Generic.axaml"
is defined as "Avalonia.Controls.ResourceDictionary" type in the "BigSloth59.Avalonia.Lib" assembly,
but expected "Avalonia.Styling.IStyle".
```

**원인**:
- `Application.Styles`에서 `StyleInclude`를 사용하여 `ResourceDictionary`를 로드하려 함
- AvaloniaUI에서 `StyleInclude`는 `IStyle` 타입만 로드 가능
- `ResourceDictionary`는 `Application.Resources`에서 `ResourceInclude`로 로드해야 함

**수정 방법**:

변경 전:
```xml
<Application.Styles>
    <FluentTheme />
    <StyleInclude Source="avares://BigSloth59.Avalonia.Lib/Themes/Generic.axaml" />
</Application.Styles>
```

변경 후:
```xml
<Application.Styles>
    <FluentTheme />
</Application.Styles>

<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceInclude Source="avares://BigSloth59.Avalonia.Lib/Themes/Generic.axaml" />
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

## Runtime Error 가능성 (직접 확인 필요)

### 1. 애니메이션 미적용 가능성
- CSS `transition` 효과를 AvaloniaUI `Animation`으로 변환했으나, `BorderBrush` 속성의 애니메이션이 예상대로 동작하지 않을 수 있음
- AvaloniaUI에서 `SolidColorBrush`를 직접 애니메이션하는 것은 제한적임
- 필요시 `Color` 애니메이션으로 변경 검토

### 2. Watermark 표시 위치
- 기본 TextBox 템플릿을 커스터마이징했으므로 Watermark(placeholder) 텍스트의 위치나 스타일이 FluentTheme과 다를 수 있음

### 3. DataValidationErrors 표시
- 템플릿에 `DataValidationErrors`를 포함했으나, 실제 validation 시나리오에서 스타일이 의도와 다르게 표시될 수 있음

## 생성된 파일 구조

```
BigSloth59/AvaloniaUI/
├── BigSloth59.Avalonia.slnx
├── BigSloth59.Avalonia.Lib/
│   ├── BigSloth59.Avalonia.Lib.csproj
│   ├── Controls/
│   │   └── BigSloth59TextBox.cs
│   └── Themes/
│       ├── Generic.axaml
│       └── BigSloth59TextBox.axaml
└── BigSloth59.Avalonia.Gallery/
    ├── BigSloth59.Avalonia.Gallery.csproj
    ├── App.axaml
    ├── App.axaml.cs
    ├── MainWindow.axaml
    ├── MainWindow.axaml.cs
    └── Program.cs
```

## 빌드 결과

- **상태**: 성공
- **경고**: 0개
- **오류**: 0개 (수정 후)
