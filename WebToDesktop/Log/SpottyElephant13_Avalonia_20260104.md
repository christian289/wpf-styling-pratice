# SpottyElephant13 AvaloniaUI 변환 로그

## 변환 정보

- **원본**: Uiverse.io by bociKond (checkbox, pulse, color)
- **변환 일시**: 2026-01-04
- **프레임워크**: AvaloniaUI 11.2.2 / .NET 9.0

## 프로젝트 구조

```
WebToDesktop/Output/SpottyElephant13/AvaloniaUI/
├── SpottyElephant13.Avalonia.slnx
├── SpottyElephant13.Avalonia.Lib/
│   ├── Controls/
│   │   └── SpottyElephant13CheckBox.cs
│   └── Themes/
│       ├── Generic.axaml
│       └── SpottyElephant13CheckBox.axaml
└── SpottyElephant13.Avalonia.Gallery/
    ├── App.axaml / App.axaml.cs
    ├── MainWindow.axaml / MainWindow.axaml.cs
    └── Program.cs
```

## 컴파일 에러 수정 내용

### 에러 1: AVLN2000 - ResourceDictionary vs IStyle 타입 불일치

**에러 메시지**:
```
Avalonia error AVLN2000: Resource "avares://SpottyElephant13.Avalonia.Lib/Themes/Generic.axaml"
is defined as "Avalonia.Controls.ResourceDictionary" type in the "SpottyElephant13.Avalonia.Lib"
assembly, but expected "Avalonia.Styling.IStyle". Line 8, position 23.
```

**원인**:
`Application.Styles` 내부에서 `StyleInclude`를 사용하여 `ResourceDictionary`를 포함하려 했으나, `StyleInclude`는 `IStyle` 타입만 허용함.

**수정 전** (App.axaml):
```xml
<Application.Styles>
    <FluentTheme/>
    <StyleInclude Source="avares://SpottyElephant13.Avalonia.Lib/Themes/Generic.axaml"/>
</Application.Styles>
```

**수정 후** (App.axaml):
```xml
<Application.Styles>
    <FluentTheme/>
</Application.Styles>

<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceInclude Source="avares://SpottyElephant13.Avalonia.Lib/Themes/Generic.axaml"/>
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

**설명**:
- `StyleInclude`는 `Styles` 컬렉션용 (IStyle 타입 필요)
- `ResourceInclude`는 `ResourceDictionary` 병합용
- ControlTheme이 포함된 ResourceDictionary는 `Application.Resources`에 병합해야 함

## CSS → AXAML 변환 내용

### 색상 매핑

| CSS 변수/값 | AXAML 리소스 |
|-------------|--------------|
| `--clr: #0B6E4F` | `SpottyElephant13.CheckedColor` |
| `#ccc` | `SpottyElephant13.UncheckedColor` |
| `#E0E0E2` | `SpottyElephant13.CheckmarkColor` |

### 크기 변환

| CSS 값 | AXAML 값 | 설명 |
|--------|----------|------|
| `1.5rem` | 18px (폰트 크기 기준) | 기본 폰트 크기 |
| `1.3em` | 24px | 체크박스 크기 |
| `0.25em` / `0.5em` | 4.5px / 9px | 체크마크 크기 |

### 상태 매핑

| CSS 선택자 | AvaloniaUI Selector |
|------------|---------------------|
| `.container input:checked ~ .checkmark` | `^:checked` |
| `:hover` | `:pointerover` |
| `:active` | `:pressed` |

### 애니메이션 변환

**CSS @keyframes pulse**:
```css
@keyframes pulse {
  0% { box-shadow: 0 0 0 #0B6E4F90; rotate: 20deg; }
  50% { rotate: -20deg; }
  75% { box-shadow: 0 0 0 10px #0B6E4F60; }
  100% { box-shadow: 0 0 0 13px #0B6E4F30; rotate: 0; }
}
```

**AvaloniaUI Animation**:
```xml
<Animation Duration="0:0:0.5" Easing="CubicEaseInOut" FillMode="Forward">
    <KeyFrame Cue="0%">
        <Setter Property="BoxShadow" Value="0 0 0 0 #900B6E4F"/>
        <Setter Property="RenderTransform"><RotateTransform Angle="20"/></Setter>
    </KeyFrame>
    <!-- ... -->
</Animation>
```

## 잠재적 Runtime Error 가능성

### 1. 펄스 애니메이션 반복 동작

**문제**: CSS 애니메이션은 체크할 때마다 트리거되지만, AvaloniaUI의 Style Animation은 상태 진입 시 한 번만 실행됨.

**증상**: 체크박스를 해제했다가 다시 체크해도 펄스 애니메이션이 재생되지 않을 수 있음.

**확인 필요**: 실제 앱에서 체크/해제를 반복하여 애니메이션 동작 테스트 필요.

### 2. BoxShadow 알파 채널 표현

**문제**: CSS의 `#0B6E4F90` (RGBA 형식)과 AvaloniaUI의 `#900B6E4F` (ARGB 형식)은 바이트 순서가 다름.

**현재 처리**: ARGB 형식으로 변환 완료.

**확인 필요**: 그림자 색상이 원본과 동일하게 보이는지 시각적 비교 필요.

### 3. 체크마크 렌더링

**문제**: CSS의 `::after` pseudo-element로 구현된 체크마크를 Border의 BorderThickness로 구현함.

**확인 필요**: 체크마크의 시각적 모양이 원본과 일치하는지 확인 필요.

## 빌드 결과

```
빌드했습니다.
    경고 0개
    오류 0개
```

## 실행 방법

```bash
cd WebToDesktop/Output/SpottyElephant13/AvaloniaUI
dotnet run --project SpottyElephant13.Avalonia.Gallery
```
