# GrumpyWombat18 AvaloniaUI 변환 로그

## 변환 정보
- **원본**: Uiverse.io by milegelu
- **변환일**: 2025-12-27
- **컨트롤명**: IconToggleButton
- **설명**: 체크/해제 상태에 따라 다른 아이콘과 텍스트를 표시하는 토글 버튼

## 프로젝트 구조
```
GrumpyWombat18/AvaloniaUI/
├── GrumpyWombat18.Avalonia.slnx
├── GrumpyWombat18.Avalonia.Lib/
│   ├── Controls/
│   │   └── IconToggleButton.cs
│   └── Themes/
│       ├── Generic.axaml
│       └── IconToggleButton.axaml
└── GrumpyWombat18.Avalonia.Gallery/
    ├── App.axaml / App.axaml.cs
    ├── MainWindow.axaml / MainWindow.axaml.cs
    └── Program.cs
```

## 컴파일 에러 및 수정

### 에러 1: AVLN2000 - ResourceDictionary vs IStyle 타입 불일치

**에러 메시지**:
```
Avalonia error AVLN2000: Resource "avares://GrumpyWombat18.Avalonia.Lib/Themes/Generic.axaml" 
is defined as "Avalonia.Controls.ResourceDictionary" type in the "GrumpyWombat18.Avalonia.Lib" 
assembly, but expected "Avalonia.Styling.IStyle".
```

**원인**:
- `Application.Styles`에서 `StyleInclude`로 ResourceDictionary를 포함하려고 시도
- AvaloniaUI에서 `StyleInclude`는 `IStyle` 타입만 허용

**수정 방법**:
App.axaml에서 `StyleInclude` 대신 `Application.Resources`에서 `ResourceInclude` 사용:

**수정 전**:
```xml
<Application.Styles>
    <FluentTheme/>
    <StyleInclude Source="avares://GrumpyWombat18.Avalonia.Lib/Themes/Generic.axaml"/>
</Application.Styles>
```

**수정 후**:
```xml
<Application.Styles>
    <FluentTheme/>
</Application.Styles>
<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceInclude Source="avares://GrumpyWombat18.Avalonia.Lib/Themes/Generic.axaml"/>
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

## CSS → AXAML 변환 상세

### 변환된 CSS 속성
| CSS 속성 | AXAML 속성 |
|----------|------------|
| `--UnChacked-color: hsl(0, 0%, 10%)` | `#1A1A1A` (SolidColorBrush) |
| `--chacked-color: hsl(216, 100%, 60%)` | `#3385FF` (SolidColorBrush) |
| `border-radius: 0.8em` | `CornerRadius="16"` |
| `padding: 0.5em` | `Padding="10"` |
| `transform: scale(1.1)` | `RenderTransform="scale(1.1)"` |
| `:hover` | `:pointerover` selector |
| `:active` | `:pressed` selector |
| `transition: all 0.2s` | `Transitions` (TransformOperationsTransition, BrushTransition) |

### SVG → StreamGeometry 변환
- Dribbble Ball 아이콘 (Unchecked 상태)
- Game Controller 아이콘 (Checked 상태)

## 잠재적 런타임 오류 (확인 필요)

### 1. Checked 상태에서 IconSize 바인딩
- **위치**: `IconToggleButton.axaml:191`
- **내용**: `Width="{Binding IconSize, RelativeSource={RelativeSource TemplatedParent}}"`
- **우려사항**: TemplatedParent 바인딩이 Selector 스타일에서 정상 동작하는지 확인 필요
- **확인 방법**: 앱 실행 후 체크 상태 토글 테스트

### 2. Opacity/Width 동시 애니메이션
- **위치**: Path 및 TextBlock 요소
- **내용**: Width와 Opacity를 동시에 전환
- **우려사항**: 0 Width에서 렌더링 이슈 가능성
- **확인 방법**: 체크/해제 토글 시 시각적 glitch 확인

### 3. Scale 애니메이션과 CornerRadius 변경
- **위치**: `:pressed` 상태
- **내용**: scale(0.95)와 CornerRadius="32" 동시 적용
- **우려사항**: 애니메이션 간 충돌 가능성
- **확인 방법**: 버튼 클릭 시 부드러운 애니메이션 확인

## 빌드 결과
- **빌드 성공**: 경고 0개, 오류 0개
- **빌드 시간**: 약 2.67초
