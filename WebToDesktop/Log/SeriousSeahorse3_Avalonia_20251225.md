# SeriousSeahorse3 AvaloniaUI 변환 로그

## 변환 정보

- **소스**: Uiverse.io by eduardojsc18
- **원본 유형**: Tailwind CSS 기반 툴팁 버튼
- **변환 일시**: 2025-12-25
- **컨트롤 이름**: TooltipButton

## 프로젝트 구조

```
SeriousSeahorse3/AvaloniaUI/
├── SeriousSeahorse3.Avalonia.slnx
├── SeriousSeahorse3.Avalonia.Lib/
│   ├── Controls/
│   │   └── TooltipButton.cs
│   └── Themes/
│       ├── Generic.axaml
│       └── TooltipButton.axaml
└── SeriousSeahorse3.Avalonia.Gallery/
    ├── App.axaml
    ├── App.axaml.cs
    ├── MainWindow.axaml
    ├── MainWindow.axaml.cs
    └── Program.cs
```

## 컴파일 에러 및 수정 내용

### 에러 1: ResourceDictionary를 StyleInclude로 참조

**에러 메시지**:
```
AVLN2000: Resource "avares://SeriousSeahorse3.Avalonia.Lib/Themes/Generic.axaml" is defined as "Avalonia.Controls.ResourceDictionary" type in the "SeriousSeahorse3.Avalonia.Lib" assembly, but expected "Avalonia.Styling.IStyle"
```

**원인**:
- `Generic.axaml`이 `ResourceDictionary`로 정의되어 있는데, `Application.Styles`에서 `StyleInclude`로 참조함
- AvaloniaUI에서 `StyleInclude`는 `IStyle` 타입만 허용

**수정 방법**:
`App.axaml`에서 `StyleInclude` 대신 `Application.Resources`에 `ResourceInclude`로 변경

**수정 전**:
```xml
<Application.Styles>
    <FluentTheme />
    <StyleInclude Source="avares://SeriousSeahorse3.Avalonia.Lib/Themes/Generic.axaml" />
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
            <ResourceInclude Source="avares://SeriousSeahorse3.Avalonia.Lib/Themes/Generic.axaml" />
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

## CSS → AXAML 변환 매핑

| Tailwind CSS 클래스 | AvaloniaUI 변환 |
|---------------------|-----------------|
| `px-3 py-2` | `Padding="12,8"` |
| `rounded-md` | `CornerRadius="6"` |
| `border border-neutral-300` | `BorderBrush="#D4D4D4" BorderThickness="1"` |
| `bg-neutral-200` | `Background="#E5E5E5"` |
| `hover:bg-neutral-300` | `:pointerover` 스타일 |
| `text-sm` | `FontSize="14"` |
| `font-medium` | `FontWeight="Medium"` |
| `text-neutral-600` | `Foreground="#525252"` |
| `data-[tooltip]:after:content-[attr(data-tooltip)]` | `TooltipText` 속성 바인딩 |
| `data-[tooltip]:after:scale-50` → `hover:scale-100` | `ScaleTransform` 애니메이션 |
| `transition-all` | `Animation Duration="0:0:0.2"` |
| `drop-shadow` | `BoxShadow="0 2 4 0 #40000000"` |

## 잠재적 런타임 오류 (직접 확인 필요)

### 1. 툴팁 위치 문제
- **가능성**: 중간
- **설명**: 툴팁이 버튼 위에 정확히 위치하지 않을 수 있음
- **원인**: `Margin="0,-30,0,0"` 고정값 사용
- **확인 방법**: 다양한 `TooltipText` 길이로 테스트

### 2. 애니메이션 타이밍 문제
- **가능성**: 낮음
- **설명**: 호버 진입/이탈 시 애니메이션이 부자연스러울 수 있음
- **원인**: `:not(:pointerover)` 셀렉터의 애니메이션 동작
- **확인 방법**: 빠르게 마우스를 올렸다 내리며 테스트

### 3. 툴팁 화살표 Path 렌더링
- **가능성**: 낮음
- **설명**: 삼각형 화살표가 정확히 렌더링되지 않을 수 있음
- **원인**: `Path.Data` 좌표값
- **확인 방법**: 실행 후 시각적 확인

## 빌드 결과

```
빌드 성공
경고 0개
오류 0개
```
