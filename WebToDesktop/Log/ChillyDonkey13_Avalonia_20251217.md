# ChillyDonkey13 - AvaloniaUI 변환 로그

## 날짜
2025-12-17

## 소스
- **원본**: uiverse.io by EcheverriaJesus
- **HTML**: `WebToDesktop/source/20251216_ChillyDonkey13/ChillyDonkey13.html`
- **CSS**: Tailwind CSS 클래스 (인라인)

## 변환 내용
Tailwind CSS 클래스를 사용한 그라디언트 버튼을 AvaloniaUI CustomControl로 변환

### Tailwind → AvaloniaUI 매핑

| Tailwind Class | AvaloniaUI Property |
|----------------|---------------------|
| `w-28` (7rem) | `Width="112"` |
| `h-12` (3rem) | `Height="48"` |
| `text-white` | `Foreground="White"` |
| `font-semibold` | `FontWeight="SemiBold"` |
| `bg-gradient-to-r from-indigo-500 via-purple-500 to-pink-500` | `LinearGradientBrush` (#6366f1 → #a855f7 → #ec4899) |
| `rounded-lg` | `CornerRadius="8"` |
| `shadow-lg` | `BoxShadow="0 10 15 -3 #33000000, 0 4 6 -4 #33000000"` |
| `hover:scale-105` | `ScaleTransform` Animation (1.0 → 1.05) |
| `duration-200` | `Animation Duration="0:0:0.2"` |
| `hover:shadow-[#7dd3fc]` | `BoxShadow="0 25 50 -12 #807dd3fc"` |
| `hover:cursor-pointer` | `Cursor="Hand"` |

## 컴파일 에러 및 수정

### 에러 1: AVLN2000 - ResourceDictionary와 IStyle 타입 불일치

**에러 메시지:**
```
Avalonia error AVLN2000: Resource "avares://ChillyDonkey13.Avalonia.Lib/Themes/Generic.axaml"
is defined as "Avalonia.Controls.ResourceDictionary" type in the "ChillyDonkey13.Avalonia.Lib"
assembly, but expected "Avalonia.Styling.IStyle". Line 8, position 23.
```

**원인:**
- `App.axaml`에서 `Application.Styles` 내에 `StyleInclude`를 사용하여 `ResourceDictionary`를 포함하려고 시도
- AvaloniaUI에서 `StyleInclude`는 `IStyle` 타입만 허용하며, `ResourceDictionary`는 `IStyle`이 아님

**수정 전:**
```xml
<Application.Styles>
    <FluentTheme />
    <StyleInclude Source="avares://ChillyDonkey13.Avalonia.Lib/Themes/Generic.axaml" />
</Application.Styles>
```

**수정 후:**
```xml
<Application.Styles>
    <FluentTheme />
</Application.Styles>

<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceInclude Source="avares://ChillyDonkey13.Avalonia.Lib/Themes/Generic.axaml" />
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

**수정 방법:**
- `StyleInclude` 대신 `ResourceInclude` 사용
- `Application.Styles`가 아닌 `Application.Resources`에서 `ResourceDictionary.MergedDictionaries`로 병합

## Runtime Error 가능성

### 잠재적 이슈 1: Animation FillMode 동작
- `:not(:pointerover)` 셀렉터의 애니메이션이 초기 로드 시 실행될 수 있음
- 심각도: 낮음 (시각적 영향만)
- 확인 필요: 앱 시작 시 버튼이 1초간 애니메이션되는지 확인

### 잠재적 이슈 2: BoxShadow 렌더링 성능
- 복잡한 BoxShadow (다중 그림자)가 저사양 시스템에서 렌더링 지연 발생 가능
- 심각도: 낮음
- 확인 필요: 다수의 버튼 동시 렌더링 시 성능 테스트

## 빌드 결과
- **최종 상태**: 성공
- **경고**: 0개
- **에러**: 0개

## 생성된 파일 목록

```
WebToDesktop/Output/ChillyDonkey13/AvaloniaUI/
├── ChillyDonkey13.Avalonia.slnx
├── ChillyDonkey13.Avalonia.Lib/
│   ├── ChillyDonkey13.Avalonia.Lib.csproj
│   ├── Controls/
│   │   └── GradientButton.cs
│   └── Themes/
│       ├── Generic.axaml
│       └── GradientButton.axaml
└── ChillyDonkey13.Avalonia.Gallery/
    ├── ChillyDonkey13.Avalonia.Gallery.csproj
    ├── App.axaml
    ├── App.axaml.cs
    ├── MainWindow.axaml
    ├── MainWindow.axaml.cs
    ├── Program.cs
    └── app.manifest
```
