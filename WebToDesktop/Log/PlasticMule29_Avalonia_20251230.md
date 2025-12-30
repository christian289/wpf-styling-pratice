# PlasticMule29 AvaloniaUI 변환 로그

## 개요

- **원본 소스**: uiverse.io by cssbuttons-io
- **컴포넌트 타입**: Button
- **변환 일자**: 2025-12-30

## CSS 분석

### 원본 CSS 특징

1. **::before pseudo-element**: inset box-shadow로 상하좌우 경계면 3D 입체감
   - `box-shadow: 0 -4px rgb(21 108 0 / 50%) inset, 0 4px rgb(100 253 31 / 99%) inset, -4px 0 rgb(100 253 31 / 50%) inset, 4px 0 rgb(21 108 0 / 50%) inset`
2. **::after pseudo-element**: 외부 드롭 섀도우
   - `box-shadow: 0 4px 0 0 rgb(0 0 0 / 15%)`
3. **:hover 상태**: inset shadow 색상 변경
4. **:active 상태**: `translateY(4px)` + 드롭 섀도우 제거

## 변환 방식

### CSS → AvaloniaUI 매핑

| CSS | AvaloniaUI |
|-----|------------|
| `::before` inset shadow | 4개의 Border 레이어 (Top/Bottom/Left/Right) |
| `::after` drop shadow | 별도 Border (PART_DropShadow) |
| `:hover` | `:pointerover` 셀렉터 |
| `:active` | `:pressed` 셀렉터 |
| `transform: translateY(4px)` | `<TranslateTransform Y="4"/>` |

## 컴파일 에러 및 수정

### 에러 1: StyleInclude vs ResourceInclude

**에러 메시지**:
```
Avalonia error AVLN2000: Resource "avares://PlasticMule29.Avalonia.Lib/Themes/Generic.axaml"
is defined as "Avalonia.Controls.ResourceDictionary" type in the "PlasticMule29.Avalonia.Lib"
assembly, but expected "Avalonia.Styling.IStyle".
```

**원인**:
- `Application.Styles`에 `StyleInclude`로 `ResourceDictionary`를 포함하려고 함
- `StyleInclude`는 `IStyle` 타입만 허용

**수정 방법**:
- `Application.Styles`에서 제거
- `Application.Resources`에 `ResourceInclude`로 병합

**수정 전**:
```xml
<Application.Styles>
    <FluentTheme />
    <StyleInclude Source="avares://PlasticMule29.Avalonia.Lib/Themes/Generic.axaml" />
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
            <ResourceInclude Source="avares://PlasticMule29.Avalonia.Lib/Themes/Generic.axaml" />
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

## 잠재적 런타임 오류 (직접 확인 필요)

### 1. Inset Shadow 시각적 차이

- **문제**: CSS inset box-shadow는 경계면이 자연스럽게 블렌딩되지만, Border 레이어 방식은 경계가 명확함
- **영향**: 시각적으로 원본과 약간 다를 수 있음
- **확인 방법**: 앱 실행 후 버튼 시각적 비교

### 2. 애니메이션 트랜지션

- **문제**: 원본 CSS는 `transition: all 0.7s cubic-bezier(0,.8,.26,.99)` 사용
- **현재 구현**: 트랜지션 없이 즉시 변경
- **영향**: hover/pressed 상태 변경 시 애니메이션 효과 없음
- **개선 방안**: `Style.Animations` 추가 (선택적)

### 3. 드롭 섀도우 위치

- **문제**: CSS `box-shadow: 0 4px 0 0`은 버튼 바깥에 그려지지만, Border는 레이아웃 내부
- **현재 구현**: `Margin="0,4,0,-4"`로 위치 조정
- **확인 방법**: 버튼 클릭 시 드롭 섀도우가 자연스럽게 사라지는지 확인

## 프로젝트 구조

```
PlasticMule29/AvaloniaUI/
├── PlasticMule29.Avalonia.slnx
├── PlasticMule29.Avalonia.Lib/
│   ├── PlasticMule29.Avalonia.Lib.csproj
│   ├── Controls/
│   │   └── PlasticMule29Button.cs
│   └── Themes/
│       ├── Generic.axaml
│       └── PlasticMule29Button.axaml
└── PlasticMule29.Avalonia.Gallery/
    ├── PlasticMule29.Avalonia.Gallery.csproj
    ├── App.axaml
    ├── App.axaml.cs
    ├── MainWindow.axaml
    ├── MainWindow.axaml.cs
    └── Program.cs
```

## 빌드 결과

- **상태**: 성공
- **경고**: 0개
- **오류**: 0개
