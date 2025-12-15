# YellowFalcon57 AvaloniaUI 변환 로그

## 변환 정보

- **날짜**: 2025-12-15
- **소스**: Uiverse.io by faxriddin20
- **태그**: purple, button, download, #button
- **대상 프레임워크**: .NET 9.0 + Avalonia 11.2.2

## 원본 분석

### HTML 구조
- `<button class="download-btn">` - 버튼 컨테이너
- `<svg>` - 다운로드 아이콘 (클라우드 + 화살표)

### CSS 스타일
- 크기: 50x50px
- 테두리: 2px solid rgb(168, 38, 255) (보라색)
- 배경: 흰색 → hover 시 보라색
- 아이콘: 검정 → hover 시 흰색
- 애니메이션: transition 0.2s ~ 0.3s ease

## 변환 결과

### 생성된 파일

```
YellowFalcon57/AvaloniaUI/
├── YellowFalcon57.Avalonia.slnx
├── YellowFalcon57.Avalonia.Lib/
│   ├── YellowFalcon57.Avalonia.Lib.csproj
│   ├── Controls/
│   │   └── DownloadButton.cs
│   └── Themes/
│       ├── Generic.axaml
│       └── DownloadButton.axaml
└── YellowFalcon57.Avalonia.Gallery/
    ├── YellowFalcon57.Avalonia.Gallery.csproj
    ├── App.axaml
    ├── App.axaml.cs
    ├── MainWindow.axaml
    ├── MainWindow.axaml.cs
    └── Program.cs
```

### CSS → AXAML 변환 매핑

| CSS | AXAML |
|-----|-------|
| `border: 2px solid rgb(168, 38, 255)` | `BorderBrush="#A826FF" BorderThickness="2"` |
| `background-color: white` | `Background="{StaticResource DownloadButton.BackgroundDefault}"` |
| `border-radius: 10px` | `CornerRadius="10"` |
| `cursor: pointer` | `Cursor="Hand"` |
| `:hover` | `:pointerover` |
| `transition: all 0.2s ease` | `<Animation Duration="0:0:0.2" Easing="CubicEaseOut">` |
| SVG path | `<StreamGeometry>` + `<Path>` |

## 컴파일 에러 수정 내역

### 에러 1: AVLN2000 - ResourceDictionary vs IStyle 타입 불일치

**에러 메시지**:
```
Avalonia error AVLN2000: Resource "avares://YellowFalcon57.Avalonia.Lib/Themes/Generic.axaml"
is defined as "Avalonia.Controls.ResourceDictionary" type in the "YellowFalcon57.Avalonia.Lib" assembly,
but expected "Avalonia.Styling.IStyle". Line 7, position 23.
```

**원인**:
`Application.Styles`에서 `StyleInclude`를 사용하여 ResourceDictionary를 로드하려고 함.
AvaloniaUI에서 `Application.Styles`는 `IStyle` 타입만 허용하고, `ResourceDictionary`는 `Application.Resources`에서 병합해야 함.

**수정 전 (App.axaml)**:
```xml
<Application.Styles>
    <FluentTheme />
    <StyleInclude Source="avares://YellowFalcon57.Avalonia.Lib/Themes/Generic.axaml" />
</Application.Styles>
```

**수정 후 (App.axaml)**:
```xml
<Application.Styles>
    <FluentTheme />
</Application.Styles>
<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceInclude Source="avares://YellowFalcon57.Avalonia.Lib/Themes/Generic.axaml" />
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

## 잠재적 런타임 오류 가능성

### 1. 애니메이션 FillMode 동작
- `FillMode="Forward"` 사용 시 애니메이션 종료 후 상태가 유지됨
- `:not(:pointerover)` 상태 애니메이션으로 원래 상태 복귀 처리했으나,
  마우스 빠르게 이동 시 애니메이션 충돌 가능성 있음
- **확인 필요**: 빠른 마우스 이동 시 시각적 결함 여부

### 2. StreamGeometry 렌더링
- SVG path를 StreamGeometry로 변환함
- 복잡한 경로는 렌더링 성능 영향 있을 수 있음
- **확인 필요**: 다양한 DPI 환경에서 아이콘 렌더링 품질

### 3. ControlTheme 적용
- `x:Key="{x:Type controls:DownloadButton}"` 패턴 사용
- 다른 ControlTheme과 충돌 가능성은 낮으나 확인 필요

## 빌드 결과

```
빌드했습니다.
    경고 0개
    오류 0개
```

## 실행 방법

```bash
cd WebToDesktop/Output/YellowFalcon57/AvaloniaUI
dotnet run --project YellowFalcon57.Avalonia.Gallery
```
