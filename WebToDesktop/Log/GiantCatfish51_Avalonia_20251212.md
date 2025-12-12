# GiantCatfish51 - AvaloniaUI 변환 로그

## 변환 정보

- **원본**: uiverse.io by Siyu1017 (tooltip)
- **변환일**: 2025-12-12
- **컨트롤명**: TooltipButton

## 컴포넌트 설명

호버 시 상단에 툴팁이 나타나는 버튼 컨트롤입니다. CSS transition/transform 애니메이션을 AvaloniaUI Animation으로 변환했습니다.

## 컴파일 에러 및 수정

### 에러 1: StyleInclude vs ResourceInclude

**에러 메시지:**
```
Avalonia error AVLN2000: Resource "avares://GiantCatfish51.Avalonia.Lib/Themes/Generic.axaml"
is defined as "Avalonia.Controls.ResourceDictionary" type in the "GiantCatfish51.Avalonia.Lib" assembly,
but expected "Avalonia.Styling.IStyle". Line 7, position 23.
```

**원인:**
- `Application.Styles`에 `StyleInclude`를 사용하여 `ResourceDictionary`를 포함하려고 함
- `StyleInclude`는 `IStyle` 타입만 허용

**수정 방법:**
- `Application.Resources`에 `ResourceDictionary.MergedDictionaries`로 변경

**수정 전:**
```xml
<Application.Styles>
    <FluentTheme/>
    <StyleInclude Source="avares://GiantCatfish51.Avalonia.Lib/Themes/Generic.axaml"/>
</Application.Styles>
```

**수정 후:**
```xml
<Application.Styles>
    <FluentTheme/>
</Application.Styles>
<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceInclude Source="avares://GiantCatfish51.Avalonia.Lib/Themes/Generic.axaml"/>
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

## CSS → AXAML 변환 요약

| CSS | AXAML |
|-----|-------|
| `linear-gradient(135deg, #a940fd, #5b46e8)` | `LinearGradientBrush StartPoint="0%,0%" EndPoint="100%,100%"` |
| `box-shadow: 0 4px 16px 4px rgba(0,0,0,0.15)` | `BoxShadow="0 4 16 4 #26000000"` |
| `border-radius: 0.75rem` | `CornerRadius="12"` |
| `transition: all 0.2s` | `Animation Duration="0:0:0.2"` |
| `transform: scale(0)` → `scale(1)` | `ScaleTransform ScaleX/ScaleY` |
| `transform: translateY(-100%)` | `TranslateTransform Y="-40"` |
| `:hover` | `:pointerover` |
| `::before` (화살표) | 별도 `Border` 요소 |

## 잠재적 Runtime 오류

### 1. 애니메이션 깜빡임 가능성

- **증상**: 첫 hover 시 애니메이션이 부드럽지 않을 수 있음
- **원인**: 초기 RenderTransform 상태와 애니메이션 시작 상태 불일치
- **확인 필요**: 직접 실행하여 애니메이션 동작 확인

### 2. 툴팁 위치 조정 필요성

- **증상**: 버튼 크기에 따라 툴팁 위치가 적절하지 않을 수 있음
- **원인**: 고정된 TranslateY 값(-40) 사용
- **확인 필요**: 다양한 텍스트 길이로 테스트

### 3. 화살표 정렬

- **증상**: 화살표가 툴팁 본체와 분리되어 보일 수 있음
- **원인**: Panel 내부 요소 배치 순서와 Margin 값
- **확인 필요**: 직접 실행하여 시각적 확인

## 파일 구조

```
GiantCatfish51/AvaloniaUI/
├── GiantCatfish51.Avalonia.slnx
├── GiantCatfish51.Avalonia.Lib/
│   ├── GiantCatfish51.Avalonia.Lib.csproj
│   ├── Controls/
│   │   └── TooltipButton.cs
│   └── Themes/
│       ├── Generic.axaml
│       └── TooltipButton.axaml
└── GiantCatfish51.Avalonia.Gallery/
    ├── GiantCatfish51.Avalonia.Gallery.csproj
    ├── App.axaml
    ├── App.axaml.cs
    ├── MainWindow.axaml
    ├── MainWindow.axaml.cs
    └── Program.cs
```

## 빌드 결과

```
빌드했습니다.
    경고 0개
    오류 0개
```
