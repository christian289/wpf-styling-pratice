# WisePanda94 AvaloniaUI 변환 로그

## 변환 정보

- **변환 일시**: 2025-12-27
- **원본**: HTML/CSS (Tailwind CSS 기반)
- **타겟**: AvaloniaUI 11.2.3
- **컨트롤명**: SendMessageButton

## 원본 분석

Tailwind CSS 클래스 기반의 "Send Message" 버튼 컴포넌트:
- 흰색 배경, 둥근 모서리 (rounded-full)
- SVG 아이콘 (45도 회전된 전송 화살표)
- Hover 시 scale(1.1) 애니메이션
- box-shadow 적용

## 컴파일 에러 및 수정

### 에러 1: StrokeLineJoin 속성명 오류

**에러 메시지**:
```
Avalonia error AVLN2000: Unable to resolve suitable regular or attached property StrokeLineJoin on type Avalonia.Controls:Avalonia.Controls.Shapes.Path
```

**원인**: AvaloniaUI에서는 WPF의 `StrokeLineJoin` 대신 `StrokeJoin`을 사용

**수정 방법**:
```xml
<!-- Before -->
<Path StrokeLineJoin="Round" ... />

<!-- After -->
<Path StrokeJoin="Round" ... />
```

---

### 에러 2: ResourceDictionary를 Styles에 포함 시도

**에러 메시지**:
```
Avalonia error AVLN2000: Resource "avares://WisePanda94.Avalonia.Lib/Themes/Generic.axaml" is defined as "Avalonia.Controls.ResourceDictionary" type in the "WisePanda94.Avalonia.Lib" assembly, but expected "Avalonia.Styling.IStyle"
```

**원인**: `Application.Styles`에는 `IStyle` 타입만 포함 가능. `ResourceDictionary`는 `Application.Resources`에 병합해야 함

**수정 방법**:
```xml
<!-- Before -->
<Application.Styles>
    <FluentTheme />
    <StyleInclude Source="avares://WisePanda94.Avalonia.Lib/Themes/Generic.axaml" />
</Application.Styles>

<!-- After -->
<Application.Styles>
    <FluentTheme />
</Application.Styles>
<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceInclude Source="avares://WisePanda94.Avalonia.Lib/Themes/Generic.axaml" />
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

## 잠재적 런타임 에러 (직접 확인 필요)

### 1. Path Data 복합 경로 렌더링

SVG 원본의 `d="M12 19l9 2-9-18-9 18 9-2zm0 0v-8"` 경로를 단일 문자열로 변환:
```xml
Data="M12 19l9 2-9-18-9 18 9-2 M12 19v-8"
```

복합 경로(두 개의 서브패스)가 AvaloniaUI에서 정상 렌더링되는지 확인 필요

### 2. BoxShadow 다중 그림자

CSS의 복합 box-shadow를 AvaloniaUI BoxShadow로 변환:
```xml
BoxShadow="0 4 6 -1 #26000000, 0 2 4 -2 #1A000000"
```

음수 spread 값(-1, -2)이 AvaloniaUI에서 정상 동작하는지 확인 필요

### 3. CornerRadius="9999" 값

`rounded-full` 클래스를 `CornerRadius="9999"`로 변환. 버튼 크기에 따라 원형 모서리가 정상 적용되는지 확인 필요

## 변환 파일 목록

| 파일 | 설명 |
|------|------|
| `WisePanda94.Avalonia.Lib/Controls/SendMessageButton.cs` | 커스텀 컨트롤 클래스 |
| `WisePanda94.Avalonia.Lib/Themes/SendMessageButton.axaml` | 컨트롤 스타일 정의 |
| `WisePanda94.Avalonia.Lib/Themes/Generic.axaml` | ResourceDictionary 병합 |
| `WisePanda94.Avalonia.Gallery/MainWindow.axaml` | 데모 앱 UI |
| `WisePanda94.Avalonia.Gallery/App.axaml` | 애플리케이션 설정 |

## CSS → AvaloniaUI 변환 매핑 요약

| CSS (Tailwind) | AvaloniaUI |
|----------------|------------|
| `rounded-full` | `CornerRadius="9999"` |
| `bg-white` | `Background="#FFFFFF"` |
| `text-black` | `Foreground="#000000"` |
| `px-4 py-2` | `Padding="16,8"` |
| `shadow-md` | `BoxShadow="0 4 6 -1 #26000000, 0 2 4 -2 #1A000000"` |
| `hover:scale-110` | `^:pointerover { RenderTransform="scale(1.1)" }` |
| `transition duration-300` | `TransformOperationsTransition Duration="0:0:0.3"` |
| `rotate-45` | `RotateTransform Angle="45"` |
| `cursor-pointer` | `Cursor="Hand"` |
| `space-x-2` | `StackPanel Spacing="8"` |
| `stroke-linecap: round` | `StrokeLineCap="Round"` |
| `stroke-linejoin: round` | `StrokeJoin="Round"` (WPF와 다름!) |
