# MightyElephant52 AvaloniaUI 변환 로그

## 변환 정보

- **소스**: uiverse.io by vinodjangid07
- **컴포넌트 유형**: Tooltip이 있는 Follow 버튼
- **변환 일시**: 2026-01-02

## 프로젝트 구조

```
MightyElephant52/AvaloniaUI/
├── MightyElephant52.Avalonia.slnx
├── MightyElephant52.Avalonia.Lib/
│   ├── Controls/
│   │   └── MightyElephant52.cs
│   └── Themes/
│       ├── Generic.axaml
│       └── MightyElephant52.axaml
└── MightyElephant52.Avalonia.Gallery/
    ├── App.axaml / App.axaml.cs
    ├── MainWindow.axaml / MainWindow.axaml.cs
    └── Program.cs
```

## 컴파일 에러 및 수정 내용

### 에러 1: ResourceDictionary와 StyleInclude 타입 불일치

**에러 메시지**:
```
AVLN2000: Resource "avares://MightyElephant52.Avalonia.Lib/Themes/Generic.axaml"
is defined as "Avalonia.Controls.ResourceDictionary" type in the
"MightyElephant52.Avalonia.Lib" assembly, but expected "Avalonia.Styling.IStyle".
```

**원인**:
- `Generic.axaml`이 `ResourceDictionary`로 정의되어 있음
- `App.axaml`에서 `StyleInclude`로 포함하려고 시도
- AvaloniaUI에서 `StyleInclude`는 `IStyle` 타입만 허용

**수정 전** (`App.axaml`):
```xml
<Application.Styles>
    <FluentTheme />
    <StyleInclude Source="avares://MightyElephant52.Avalonia.Lib/Themes/Generic.axaml" />
</Application.Styles>
```

**수정 후** (`App.axaml`):
```xml
<Application.Styles>
    <FluentTheme />
</Application.Styles>
<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceInclude Source="avares://MightyElephant52.Avalonia.Lib/Themes/Generic.axaml" />
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

**해결 방법**:
- `ResourceDictionary`는 `Application.Resources`에서 `ResourceInclude`로 포함해야 함
- `StyleInclude`는 `Styles` 또는 `IStyle` 기반 리소스에만 사용

## CSS → AXAML 변환 매핑

| CSS 속성 | AXAML 속성 |
|---------|-----------|
| `display: flex; align-items: center; justify-content: center` | `StackPanel` + `HorizontalAlignment="Center"` |
| `position: absolute; top: 0` | `Panel` 내 요소 + `VerticalAlignment="Top"` |
| `transform: translateX(-50%)` | `HorizontalAlignment="Center"` |
| `opacity: 0` → `opacity: 1` | Animation KeyFrame으로 Opacity 변경 |
| `transition: all 0.3s` | `Animation Duration="0:0:0.3"` |
| `border-radius: 12px` | `CornerRadius="12"` |
| `padding: 11px 18px` | `Padding="18,11"` |
| `cursor: pointer` | `Cursor="Hand"` |
| `box-shadow` | 미구현 (BorderBrush로 대체 가능) |
| `::before` pseudo-element | 별도 `Border` 요소로 구현 (화살표) |
| `:hover` | `:pointerover` selector |

## 잠재적 런타임 오류 가능성

### 1. 애니메이션 초기 상태 문제
- **위치**: `MightyElephant52.axaml` - `:not(:pointerover)` 스타일
- **가능성**: 컨트롤 로드 시 초기 애니메이션이 재생될 수 있음
- **확인 필요**: 첫 로드 시 툴팁이 잠깐 보였다가 사라지는지 확인

### 2. 툴팁 위치 계산
- **위치**: `PART_Tooltip`의 `RenderTransform="translate(0px, -35px)"`
- **가능성**: 컨트롤 크기에 따라 툴팁 위치가 맞지 않을 수 있음
- **확인 필요**: 다양한 텍스트 길이에서 툴팁 위치 확인

### 3. 툴팁 화살표 렌더링
- **위치**: `PART_TooltipArrow` Border
- **가능성**: 회전된 Border가 CornerRadius 없이 정사각형으로 표시
- **확인 필요**: 화살표가 예상대로 삼각형으로 보이는지 확인

## 커스텀 컨트롤 속성

| 속성명 | 타입 | 기본값 | 설명 |
|-------|------|-------|------|
| `TooltipText` | `string` | "45k" | 툴팁에 표시될 텍스트 |
| `ButtonText` | `string` | "Follow" | 버튼에 표시될 텍스트 |

## 사용 예시

```xml
<!-- 기본 사용 -->
<controls:MightyElephant52 />

<!-- 커스텀 텍스트 -->
<controls:MightyElephant52 TooltipText="1.2M" ButtonText="Subscribe" />
```

## 빌드 결과

- **빌드 상태**: 성공
- **경고**: 0개
- **에러**: 0개
