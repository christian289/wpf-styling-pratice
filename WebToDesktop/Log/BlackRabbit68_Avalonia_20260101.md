# BlackRabbit68 AvaloniaUI 변환 로그

## 프로젝트 정보

- **원본 출처**: Uiverse.io by JohnnyCSilva
- **태그**: card, crypto, bitcoin, rotating
- **변환 일자**: 2026-01-01
- **대상 프레임워크**: AvaloniaUI 11.2.3 / .NET 9.0

## 생성된 파일

```
BlackRabbit68/AvaloniaUI/
├── BlackRabbit68.Avalonia.slnx
├── BlackRabbit68.Avalonia.Lib/
│   ├── BlackRabbit68.Avalonia.Lib.csproj
│   ├── Controls/
│   │   └── BitcoinCoin.cs
│   └── Themes/
│       ├── Generic.axaml
│       └── BitcoinCoin.axaml
└── BlackRabbit68.Avalonia.Gallery/
    ├── BlackRabbit68.Avalonia.Gallery.csproj
    ├── App.axaml / App.axaml.cs
    ├── MainWindow.axaml / MainWindow.axaml.cs
    └── Program.cs
```

## 컴파일 에러 및 수정

### 에러 1: AVLN2000 - ResourceDictionary vs IStyle 타입 불일치

**에러 메시지**:
```
Avalonia error AVLN2000: Resource "avares://BlackRabbit68.Avalonia.Lib/Themes/Generic.axaml"
is defined as "Avalonia.Controls.ResourceDictionary" type in the "BlackRabbit68.Avalonia.Lib" assembly,
but expected "Avalonia.Styling.IStyle". Line 8, position 23.
```

**원인**:
- `Application.Styles`에 `StyleInclude`로 `ResourceDictionary`를 포함하려 했으나,
  `ResourceDictionary`는 `IStyle`이 아니므로 타입 불일치 발생

**수정 방법**:
```xml
<!-- 변경 전 (오류) -->
<Application.Styles>
    <FluentTheme />
    <StyleInclude Source="avares://BlackRabbit68.Avalonia.Lib/Themes/Generic.axaml"/>
</Application.Styles>

<!-- 변경 후 (정상) -->
<Application.Styles>
    <FluentTheme />
</Application.Styles>

<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceInclude Source="avares://BlackRabbit68.Avalonia.Lib/Themes/Generic.axaml"/>
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

## CSS → AvaloniaUI 변환 내역

### 3D 회전 → 2D ScaleX 시뮬레이션

**원본 CSS**:
```css
.coin {
    animation: rotate_4001510 7s infinite linear;
    transform-style: preserve-3d;
}

@keyframes rotate_4001510 {
    100% {
        transform: rotateY(360deg);
    }
}

.coin .side {
    transform: rotateY(-90deg);
    backface-visibility: hidden;
}
```

**AvaloniaUI 변환**:
- CSS의 `rotateY(360deg)` 3D 회전은 AvaloniaUI에서 직접 지원하지 않음
- `ScaleX`를 1 → 0 → -1 → 0 → 1로 애니메이션하여 동전 뒤집기 효과 시뮬레이션
- 앞면/뒷면 Opacity를 조합하여 backface-visibility 효과 구현

### LinearGradientBrush

**원본 CSS**:
```css
background: linear-gradient(#faa504, #141001);
```

**AvaloniaUI**:
```xml
<LinearGradientBrush StartPoint="0%,0%" EndPoint="0%,100%">
    <GradientStop Color="#FAA504" Offset="0"/>
    <GradientStop Color="#141001" Offset="1"/>
</LinearGradientBrush>
```

### SVG Path 변환

- SVG `<path>` 요소를 AvaloniaUI `<Path>` + `<PathGeometry>`로 직접 변환
- `fill` 속성 → `Fill` 속성

## 잠재적 런타임 오류 가능성

### 1. 애니메이션 타이밍 불일치
- **설명**: CSS 3D 회전과 2D ScaleX 시뮬레이션의 시각적 결과가 다를 수 있음
- **영향**: 동전 회전 애니메이션이 원본과 약간 다르게 보일 수 있음
- **확인 필요**: 실제 실행하여 애니메이션 품질 확인 필요

### 2. 뒷면 미러링 효과
- **설명**: CSS의 `transform: scaleX(-1)`이 SVG에 적용되어 뒷면이 좌우 반전됨
- **영향**: AvaloniaUI에서는 `ScaleTransform`으로 구현했으나 동일하게 동작해야 함
- **확인 필요**: 실제 실행하여 뒷면 미러링 확인 필요

### 3. CoinSize 바인딩
- **설명**: `CoinSize` 속성을 `Width`, `Height`에 바인딩하여 동적 크기 조절 지원
- **영향**: 바인딩이 정상 동작하지 않으면 기본값 200으로 고정됨
- **확인 필요**: 다양한 `CoinSize` 값으로 테스트 필요

## 빌드 결과

```
빌드했습니다.
    경고 0개
    오류 0개

경과 시간: 00:00:08.78
```

## 실행 방법

```bash
cd WebToDesktop/Output/BlackRabbit68/AvaloniaUI
dotnet run --project BlackRabbit68.Avalonia.Gallery
```
