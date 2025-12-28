# ThinCrab36 AvaloniaUI 변환 로그

## 변환 정보

- **소스**: uiverse.io by 0xnihilism
- **컨트롤 이름**: BrutalistCard
- **변환 일시**: 2025-12-29
- **설명**: Brutalist 스타일의 경고/알림 카드 컨트롤

## 프로젝트 구조

```
ThinCrab36/AvaloniaUI/
├── ThinCrab36.Avalonia.slnx
├── ThinCrab36.Avalonia.Lib/
│   ├── ThinCrab36.Avalonia.Lib.csproj
│   ├── Controls/
│   │   └── BrutalistCard.cs
│   └── Themes/
│       ├── Generic.axaml
│       └── BrutalistCard.axaml
└── ThinCrab36.Avalonia.Gallery/
    ├── ThinCrab36.Avalonia.Gallery.csproj
    ├── app.manifest
    ├── Program.cs
    ├── App.axaml
    ├── App.axaml.cs
    ├── MainWindow.axaml
    └── MainWindow.axaml.cs
```

## 컴파일 에러 및 수정

### 에러 1: SDK 이름 오류

**에러 내용**:
```
지정된 'Sdk' SDK를 찾을 수 없습니다.
```

**원인**: csproj 파일에서 `<Project Sdk="Sdk">` 형태로 잘못 지정됨

**수정 방법**: `<Project Sdk="Microsoft.NET.Sdk">`로 변경

### 에러 2: ResourceDictionary vs IStyle 타입 불일치

**에러 내용**:
```
Avalonia error AVLN2000: Resource "avares://ThinCrab36.Avalonia.Lib/Themes/Generic.axaml"
is defined as "Avalonia.Controls.ResourceDictionary" type in the "ThinCrab36.Avalonia.Lib"
assembly, but expected "Avalonia.Styling.IStyle".
```

**원인**: App.axaml에서 `<StyleInclude>`를 사용하여 ResourceDictionary를 로드하려 함

**수정 방법**: `Application.Styles`의 `StyleInclude` 대신 `Application.Resources`에서 `ResourceInclude`를 사용

**수정 전**:
```xml
<Application.Styles>
    <FluentTheme />
    <StyleInclude Source="avares://ThinCrab36.Avalonia.Lib/Themes/Generic.axaml" />
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
            <ResourceInclude Source="avares://ThinCrab36.Avalonia.Lib/Themes/Generic.axaml" />
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

## 잠재적 Runtime 오류

### 1. 버튼 호버 시 그림자 동기화 문제

**설명**: CSS에서는 버튼 호버 시 `box-shadow: 7px 7px 0 #000`으로 그림자가 커지지만, 현재 AXAML 구현에서는 그림자 Border가 고정된 Margin으로 설정되어 있어 호버 효과와 그림자가 동기화되지 않을 수 있음.

**확인 필요**: 런타임에서 호버 시 버튼과 그림자의 시각적 일관성 확인 필요

### 2. 버튼 Pressed 상태의 그림자 처리

**설명**: CSS에서 `:active` 상태에서는 `box-shadow: none`이 적용되지만, 현재 구현에서는 그림자 Border가 항상 표시됨. Pressed 상태에서 그림자가 사라지지 않을 수 있음.

**확인 필요**: 버튼 클릭 시 그림자 동작 확인 필요

### 3. CSS ::before 효과 미구현

**설명**: 원본 CSS의 `::before` pseudo-element를 통한 빛 반사 애니메이션 효과는 미구현됨.

```css
.brutalist-card__button::before {
  content: "";
  position: absolute;
  top: 0;
  left: -100%;
  width: 100%;
  height: 100%;
  background: linear-gradient(120deg, transparent, rgba(255, 255, 255, 0.3), transparent);
  transition: all 0.6s;
}
.brutalist-card__button:hover::before {
  left: 100%;
}
```

**영향**: 호버 시 버튼 위를 스와이프하는 빛 반사 효과가 없음

## CSS → AvaloniaUI 변환 상세

| CSS 속성 | AvaloniaUI 변환 |
|----------|-----------------|
| `box-shadow: 10px 10px 0 #000` | Panel 내부에 별도 Border로 그림자 구현 |
| `font-weight: 900` | `FontWeight="Black"` |
| `font-weight: 700` | `FontWeight="Bold"` |
| `font-weight: 600` | `FontWeight="SemiBold"` |
| `text-transform: uppercase` | 컨트롤에서 직접 대문자 텍스트 입력 (자동 변환 미지원) |
| `transition: all 0.2s ease` | Style Selector + RenderTransform 조합 |
| `cursor: pointer` | `Cursor="Hand"` |
| `line-height: 1.4` | `LineHeight="15.4"` (FontSize 11 * 1.4) |

## 빌드 결과

- **최종 빌드 상태**: 성공
- **경고**: 0개
- **에러**: 0개
