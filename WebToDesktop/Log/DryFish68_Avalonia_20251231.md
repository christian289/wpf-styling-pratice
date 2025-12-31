# DryFish68 Avalonia 변환 로그

## 변환 정보

- **소스**: `WebToDesktop/source/20251231_DryFish68/DryFish68.html`, `DryFish68.css`
- **출력**: `WebToDesktop/Output/DryFish68/AvaloniaUI/`
- **변환일**: 2025-12-31

## 원본 HTML/CSS 분석

### 컴포넌트 설명
- **유형**: Download CV 스타일 버튼 (uiverse.io by Codecite)
- **특징**:
  - 둥근 테두리 (border-radius: 50px)
  - 주황-빨강 테두리 색상 (#ed553b)
  - `::before` 의사 요소로 배경 채우기 효과
  - hover 시 배경이 아래로 내려가며 텍스트 색상 변경

### CSS 효과
```css
/* 기본 상태: ::before 요소가 버튼을 111% 채움 */
.button a::before {
    height: 111%;
    background-color: #ed553b;
}

/* hover 상태: ::before 요소가 11%로 줄어듦 (아래로 내려감) */
.button a:hover::before {
    height: 11%;
}
```

## 생성된 파일 구조

```
DryFish68/AvaloniaUI/
├── DryFish68.Avalonia.slnx
├── DryFish68.Avalonia.Lib/
│   ├── DryFish68.Avalonia.Lib.csproj
│   ├── Controls/
│   │   └── DryFish68Button.cs
│   └── Themes/
│       ├── Generic.axaml
│       └── DryFish68Button.axaml
└── DryFish68.Avalonia.Gallery/
    ├── DryFish68.Avalonia.Gallery.csproj
    ├── App.axaml / App.axaml.cs
    ├── MainWindow.axaml / MainWindow.axaml.cs
    ├── Program.cs
    └── app.manifest
```

## 컴파일 에러 및 수정

### 에러 1: AVLN2000 - ResourceDictionary 타입 불일치

**에러 메시지**:
```
Avalonia error AVLN2000: Resource "avares://DryFish68.Avalonia.Lib/Themes/Generic.axaml"
is defined as "Avalonia.Controls.ResourceDictionary" type in the "DryFish68.Avalonia.Lib" assembly,
but expected "Avalonia.Styling.IStyle". Line 8, position 23.
```

**원인**:
`Application.Styles`에는 `IStyle` 인터페이스를 구현한 타입만 포함할 수 있음. `ResourceDictionary`는 `IStyle`이 아님.

**수정 방법**:
`Generic.axaml`을 `ResourceDictionary` 대신 `Styles` 루트 요소로 변경하고, 리소스는 `Styles.Resources` 내에 배치.

**수정 전**:
```xml
<ResourceDictionary xmlns="https://github.com/avaloniaui"
                    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">
    <ResourceDictionary.MergedDictionaries>
        <ResourceInclude Source="avares://DryFish68.Avalonia.Lib/Themes/DryFish68Button.axaml" />
    </ResourceDictionary.MergedDictionaries>
</ResourceDictionary>
```

**수정 후**:
```xml
<Styles xmlns="https://github.com/avaloniaui"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">
    <Styles.Resources>
        <ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>
                <ResourceInclude Source="avares://DryFish68.Avalonia.Lib/Themes/DryFish68Button.axaml" />
            </ResourceDictionary.MergedDictionaries>
        </ResourceDictionary>
    </Styles.Resources>
</Styles>
```

## Runtime Error 가능성

### 1. 애니메이션 동작 차이 (확인 필요)

**문제 가능성**:
CSS의 `::before` 의사 요소 높이 애니메이션(111% → 11%)을 AvaloniaUI에서 `TranslateTransform.Y`로 구현했으나, 정확한 시각적 효과가 원본과 다를 수 있음.

**원본 CSS 동작**:
- 배경이 아래에서 위로 채워진 상태 (height: 111%)
- hover 시 배경이 아래로 내려감 (height: 11%)

**AvaloniaUI 구현**:
- `TranslateTransform Y="0"` → `Y="40"` 으로 이동
- 배경 Border가 아래로 슬라이드하는 효과

**확인 방법**:
실제 실행하여 hover 시 애니메이션 효과가 의도대로 작동하는지 확인 필요.

### 2. ClipToBounds 적용 범위 (확인 필요)

**문제 가능성**:
CSS의 `overflow: hidden`을 `ClipToBounds="True"`로 변환했으나, CornerRadius가 적용된 Border에서 클리핑이 원하는 대로 동작하지 않을 수 있음.

**확인 방법**:
애니메이션 중 배경 요소가 둥근 모서리 밖으로 보이는지 확인 필요.

### 3. 텍스트 색상 전환 (확인 필요)

**문제 가능성**:
hover 시 `Foreground` 색상 변경이 즉시 적용되지만, CSS에서는 `transition: all .3s ease`로 부드럽게 전환됨.

**개선 방안**:
필요시 `Foreground` 속성에도 애니메이션 추가 가능.

## 빌드 결과

```
빌드했습니다.
    경고 0개
    오류 0개
```

## CSS → AXAML 변환 매핑

| CSS 속성 | AXAML 속성 |
|---------|-----------|
| `border-radius: 50px` | `CornerRadius="50"` |
| `border: 2px solid #ed553b` | `BorderBrush`, `BorderThickness="2"` |
| `padding: 14px 40px 13px` | `Padding="40,14,40,13"` |
| `overflow: hidden` | `ClipToBounds="True"` |
| `transition: all .3s ease` | `<Animation Duration="0:0:0.3" Easing="CubicEaseOut">` |
| `:hover` | `:pointerover` |
| `::before` pseudo-element | 별도 Border 요소 |
