# SlipperyDragonfly42 AvaloniaUI 변환 로그

## 변환 정보
- **날짜**: 2025-12-19
- **원본**: uiverse.io by iZOXVL
- **유형**: 로그인 폼 (Login Form)
- **스타일**: Tailwind CSS 기반 다크 테마

## 프로젝트 구조

```
SlipperyDragonfly42/AvaloniaUI/
├── SlipperyDragonfly42.Avalonia.slnx
├── SlipperyDragonfly42.Avalonia.Lib/
│   ├── Controls/
│   │   └── SlipperyDragonfly42.cs
│   └── Themes/
│       ├── Generic.axaml
│       └── SlipperyDragonfly42.axaml
└── SlipperyDragonfly42.Avalonia.Gallery/
    ├── App.axaml
    ├── App.axaml.cs
    ├── MainWindow.axaml
    ├── MainWindow.axaml.cs
    └── Program.cs
```

## 컴파일 에러 및 수정

### 에러 1: ResourceDictionary를 Application.Styles에 포함할 수 없음

**에러 메시지**:
```
Avalonia error AVLN2000: Resource "avares://SlipperyDragonfly42.Avalonia.Lib/Themes/Generic.axaml"
is defined as "Avalonia.Controls.ResourceDictionary" type in the "SlipperyDragonfly42.Avalonia.Lib"
assembly, but expected "Avalonia.Styling.IStyle".
```

**원인**:
- AvaloniaUI에서 `Application.Styles`는 `IStyle` 인터페이스를 구현하는 객체만 포함 가능
- `ResourceDictionary`는 `IStyle`이 아니므로 `StyleInclude`로 포함 불가

**수정 방법**:
```xml
<!-- 변경 전 (오류) -->
<Application.Styles>
    <FluentTheme />
    <StyleInclude Source="avares://SlipperyDragonfly42.Avalonia.Lib/Themes/Generic.axaml" />
</Application.Styles>

<!-- 변경 후 (정상) -->
<Application.Styles>
    <FluentTheme />
</Application.Styles>

<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceInclude Source="avares://SlipperyDragonfly42.Avalonia.Lib/Themes/Generic.axaml" />
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

**요약**:
- `ControlTheme`은 `ResourceDictionary`에 정의됨
- `ResourceDictionary`는 `Application.Resources`에서 `ResourceInclude`로 병합해야 함

## 변환 노트

### CSS → AXAML 변환 매핑

| Tailwind CSS 클래스 | AvaloniaUI 속성 |
|---------------------|-----------------|
| `bg-gray-800` | `Background="#1F2937"` |
| `bg-gray-700` | `Background="#374151"` |
| `text-white` | `Foreground="White"` |
| `text-gray-400` | `Foreground="#9CA3AF"` |
| `text-indigo-500` | `Foreground="#6366F1"` |
| `rounded-md` | `CornerRadius="6"` |
| `rounded-lg` | `CornerRadius="8"` |
| `px-3 py-3` | `Padding="12,12"` |
| `p-8` | `Margin="32"` |
| `mt-4` | `Margin="0,16,0,0"` |
| `space-y-6` | `StackPanel Spacing="24"` |
| `font-extrabold` | `FontWeight="ExtraBold"` |
| `text-3xl` | `FontSize="30"` |
| `text-sm` | `FontSize="14"` |

### 컨트롤 속성

커스텀 컨트롤 `SlipperyDragonfly42`는 다음 속성을 제공:
- `Email` (string): 이메일 입력값
- `Password` (string): 비밀번호 입력값
- `RememberMe` (bool): 기억하기 체크 여부
- `Title` (string): 제목 텍스트 (기본값: "Welcome Back")
- `Subtitle` (string): 부제목 텍스트 (기본값: "Sign in to continue")

## 잠재적 런타임 오류

1. **TextBox Watermark 미표시 가능성**
   - 커스텀 TextBox 템플릿에서 `PART_Watermark` 로직이 복잡함
   - Text 바인딩과 Watermark 표시 간의 충돌 가능성 있음
   - **확인 필요**: 실제 실행 시 Watermark(placeholder) 텍스트 표시 확인

2. **CheckBox 체크마크 Path 데이터**
   - 수동으로 작성한 Path 데이터가 정확히 렌더링되지 않을 수 있음
   - **확인 필요**: 체크박스 선택 시 체크마크 모양 확인

3. **BoxShadow 투명도 값**
   - CSS `rgba(0,0,0,0.1)` → AXAML `#1A000000` 변환은 근사값
   - 미세한 시각적 차이가 있을 수 있음

## 빌드 결과

- **빌드 상태**: ✅ 성공
- **경고**: 0개
- **에러**: 0개 (수정 후)
