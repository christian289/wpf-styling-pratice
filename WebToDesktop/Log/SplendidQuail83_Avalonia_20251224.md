# SplendidQuail83 Avalonia 변환 로그

## 원본 정보

- **출처**: Uiverse.io by artvelog
- **태그**: paper, light, modern, pattern
- **설명**: 공책 줄무늬 패턴 배경 (Notebook paper pattern background)

## 변환 내용

### CSS 패턴 분석

원본 CSS는 두 개의 linear-gradient를 겹쳐 공책 스타일 배경을 구현:

1. **수직 마진 라인**: 분홍색(#ffb4b8) 세로선 (50px 위치에 2px 두께)
2. **수평 줄**: 연회색(#e1e1e1) 가로선 (30px 간격)

```css
background-image: linear-gradient(
    90deg,
    transparent 50px,
    #ffb4b8 50px,
    #ffb4b8 52px,
    transparent 52px
  ),
  linear-gradient(#e1e1e1 0.1em, transparent 0.1em);
background-size: 100% 30px;
```

### AvaloniaUI 변환 방식

CSS의 복합 linear-gradient 패턴은 AvaloniaUI에서 직접 지원되지 않아 **CustomControl + DrawingContext**를 사용하여 직접 렌더링하는 방식으로 구현.

#### 생성된 파일

| 파일 | 설명 |
|------|------|
| `SplendidQuail83.Avalonia.Lib/Controls/NotebookPaperBackground.cs` | 커스텀 컨트롤 클래스 |
| `SplendidQuail83.Avalonia.Lib/Themes/NotebookPaperBackground.axaml` | 컨트롤 테마 |
| `SplendidQuail83.Avalonia.Lib/Themes/Generic.axaml` | 리소스 딕셔너리 병합 |

#### 속성 (Styled Properties)

| 속성명 | 타입 | 기본값 | 설명 |
|--------|------|--------|------|
| `BackgroundColor` | `IBrush?` | `#f1f1f1` | 배경색 |
| `MarginLineColor` | `Color` | `#ffb4b8` | 마진 라인 색상 |
| `HorizontalLineColor` | `Color` | `#e1e1e1` | 가로줄 색상 |
| `MarginLeft` | `double` | `50` | 마진 라인 위치 (px) |
| `MarginLineThickness` | `double` | `2` | 마진 라인 두께 |
| `LineSpacing` | `double` | `30` | 가로줄 간격 |
| `HorizontalLineThickness` | `double` | `1.2` | 가로줄 두께 |

---

## 컴파일 에러 및 수정

### 에러 1: StyleInclude 타입 불일치

**에러 메시지**:
```
AVLN2000: Resource "avares://SplendidQuail83.Avalonia.Lib/Themes/Generic.axaml" is defined as
"Avalonia.Controls.ResourceDictionary" type in the "SplendidQuail83.Avalonia.Lib" assembly,
but expected "Avalonia.Styling.IStyle".
```

**원인**:
`Application.Styles` 내에서 `StyleInclude`를 사용할 때, AvaloniaUI는 `IStyle` 인터페이스를 구현한 타입을 기대하지만 `ResourceDictionary`는 `IStyle`을 구현하지 않음.

**수정 방법**:
`Application.Styles`에서 `StyleInclude`를 제거하고, `Application.Resources`에서 `ResourceInclude`를 사용하여 `ResourceDictionary`를 병합.

**수정 전**:
```xml
<Application.Styles>
    <FluentTheme />
    <StyleInclude Source="avares://SplendidQuail83.Avalonia.Lib/Themes/Generic.axaml"/>
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
            <ResourceInclude Source="avares://SplendidQuail83.Avalonia.Lib/Themes/Generic.axaml"/>
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

---

## 잠재적 런타임 오류

### 1. 렌더링 성능 이슈

- **설명**: 컨트롤이 매우 큰 크기로 사용되거나 빈번하게 리사이즈될 경우, `Render()` 메서드에서 많은 수의 수평선을 그리게 되어 성능 저하 가능성 있음.
- **권장 조치**: 프로덕션 사용 시 가상화 또는 DrawingGroup 캐싱 고려.

### 2. DPI 스케일링

- **설명**: 고DPI 환경에서 라인 두께가 예상과 다르게 보일 수 있음.
- **권장 조치**: 실제 디스플레이에서 테스트 필요.

---

## 빌드 결과

- **빌드 성공**: 예
- **경고**: 0개
- **오류**: 0개

---

## 사용 예시

```xml
<controls:NotebookPaperBackground
    MarginLeft="60"
    MarginLineColor="#ff9999"
    LineSpacing="25" />
```
