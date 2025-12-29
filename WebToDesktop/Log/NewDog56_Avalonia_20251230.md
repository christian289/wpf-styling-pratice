# NewDog56 AvaloniaUI 변환 로그

## 변환 정보

- **변환 일시**: 2025-12-30
- **원본 소스**: uiverse.io by ArturCodeCraft
- **컨트롤 유형**: Primary Button with Gradient Hover Effect

## 원본 CSS 분석

```css
.primary-button {
  min-width: 111px;
  height: 56px;
  border-radius: 40px;
  background: #000;
  padding: 16px 40px;
  color: #fff;
  transition: background .2s ease-in-out, color .2s ease-in-out;
  position: relative;
}

.primary-button::before {
  /* 그라데이션 오버레이 */
  background: linear-gradient(69deg, #c3aab2 -4.77%, #9ec 46.72%, #80c0c8 90.23%, #4B8bfa 134.46%);
  opacity: 0;
  z-index: -1;
}

.primary-button:hover {
  background: transparent;
  color: #000;
}

.primary-button:hover::before {
  opacity: 1;
}
```

## CSS → AvaloniaUI 변환 매핑

| CSS 속성 | AvaloniaUI 속성 |
|----------|-----------------|
| `min-width: 111px` | `MinWidth="111"` |
| `height: 56px` | `Height="56"` |
| `border-radius: 40px` | `CornerRadius="40"` |
| `background: #000` | `Background="#000000"` |
| `padding: 16px 40px` | `Padding="40,16"` |
| `color: #fff` | `Foreground="White"` |
| `cursor: pointer` | `Cursor="Hand"` |
| `::before` pseudo-element | Panel 내 별도 Border로 구현 |
| `:hover` | `:pointerover` selector |
| `transition: 0.2s ease-in-out` | `BrushTransition Duration="0:0:0.2"` |

## 컴파일 에러 및 수정

### 에러 1: AVLN2000 - ResourceDictionary를 IStyle로 사용 시도

**에러 메시지**:
```
Avalonia error AVLN2000: Resource "avares://NewDog56.Avalonia.Lib/Themes/Generic.axaml"
is defined as "Avalonia.Controls.ResourceDictionary" type in the "NewDog56.Avalonia.Lib"
assembly, but expected "Avalonia.Styling.IStyle".
```

**원인**:
- `Application.Styles`에 `StyleInclude`로 ResourceDictionary를 포함하려 함
- AvaloniaUI에서 ResourceDictionary는 IStyle 인터페이스를 구현하지 않음

**수정 전** (App.axaml):
```xml
<Application.Styles>
    <FluentTheme />
    <StyleInclude Source="avares://NewDog56.Avalonia.Lib/Themes/Generic.axaml" />
</Application.Styles>
```

**수정 후** (App.axaml):
```xml
<Application.Styles>
    <FluentTheme />
</Application.Styles>

<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceInclude Source="avares://NewDog56.Avalonia.Lib/Themes/Generic.axaml" />
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

**해결 방법**:
- ResourceDictionary는 `Application.Resources`에서 `ResourceInclude`로 포함해야 함
- `Application.Styles`는 Styles/ControlTheme만 포함 가능

## 잠재적 런타임 오류 가능성

### 1. LinearGradientBrush 각도 근사

**위험도**: 낮음

**설명**:
- CSS `linear-gradient(69deg, ...)` 를 AvaloniaUI `LinearGradientBrush`로 변환
- CSS 각도와 AvaloniaUI StartPoint/EndPoint 시스템이 다름
- 69도를 `StartPoint="0%,50%" EndPoint="100%,50%"`로 근사 변환함 (실제로는 수평 그라데이션)

**확인 필요**:
- 실행 시 그라데이션 방향이 원본과 다를 수 있음
- 정확한 69도 각도가 필요하면 StartPoint/EndPoint 계산 필요

### 2. Transition 애니메이션

**위험도**: 낮음

**설명**:
- CSS의 `transition: background .2s ease-in-out`을 `BrushTransition`으로 변환
- AvaloniaUI에서 Template 내부 요소의 Background 변경은 직접 Transition이 적용되지 않을 수 있음

**확인 필요**:
- hover 시 배경색 전환이 부드럽게 작동하는지 확인

### 3. RenderTransform Scale

**위험도**: 낮음

**설명**:
- Pressed 상태에서 `RenderTransform="scale(0.98)"` 적용
- 원본 CSS에는 없는 추가 효과

**확인 필요**:
- 사용자 경험에 따라 제거 가능

## 생성된 파일 구조

```
NewDog56/AvaloniaUI/
├── NewDog56.Avalonia.slnx
├── NewDog56.Avalonia.Lib/
│   ├── NewDog56.Avalonia.Lib.csproj
│   ├── Controls/
│   │   └── NewDog56Button.cs
│   └── Themes/
│       ├── Generic.axaml
│       └── NewDog56Button.axaml
└── NewDog56.Avalonia.Gallery/
    ├── NewDog56.Avalonia.Gallery.csproj
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

## 실행 방법

```bash
cd WebToDesktop/Output/NewDog56/AvaloniaUI
dotnet run --project NewDog56.Avalonia.Gallery
```
