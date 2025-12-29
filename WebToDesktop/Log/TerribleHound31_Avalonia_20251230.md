# TerribleHound31 AvaloniaUI 변환 로그

- **변환일**: 2025-12-30
- **소스**: Uiverse.io by Hoseinnaqvi
- **태그**: logo, one-div, fruit

## 변환 요약

과일 모양 로고 UI를 HTML/CSS에서 AvaloniaUI CustomControl로 변환.

### 원본 구성 요소
- 빨강-주황 `linear-gradient` 배경의 둥근 원형 (border-radius: 40%)
- `::before` pseudo-element로 초록색 잎
- `::after` pseudo-element로 이모지 텍스트 + 깜빡임 애니메이션

### 변환된 파일
| 파일 | 설명 |
|------|------|
| `TerribleHound31.Avalonia.Lib/Controls/FruitLogo.cs` | 커스텀 컨트롤 클래스 |
| `TerribleHound31.Avalonia.Lib/Themes/FruitLogo.axaml` | 컨트롤 스타일 및 템플릿 |
| `TerribleHound31.Avalonia.Lib/Themes/Generic.axaml` | 리소스 병합 |
| `TerribleHound31.Avalonia.Gallery/*` | 데모 앱 |

## 컴파일 에러 및 수정

### 에러 1: AVLN2000 - ResourceDictionary vs IStyle 타입 불일치

**에러 메시지**:
```
Avalonia error AVLN2000: Resource "avares://TerribleHound31.Avalonia.Lib/Themes/Generic.axaml"
is defined as "Avalonia.Controls.ResourceDictionary" type in the "TerribleHound31.Avalonia.Lib"
assembly, but expected "Avalonia.Styling.IStyle". Line 8, position 23.
```

**원인**:
- `Application.Styles` 내에 `StyleInclude`로 `ResourceDictionary`를 포함하려 함
- AvaloniaUI에서 `Styles` 컬렉션은 `IStyle` 타입만 허용

**수정 방법**:
```xml
<!-- 수정 전 (에러) -->
<Application.Styles>
    <FluentTheme />
    <StyleInclude Source="avares://TerribleHound31.Avalonia.Lib/Themes/Generic.axaml" />
</Application.Styles>

<!-- 수정 후 (정상) -->
<Application.Styles>
    <FluentTheme />
</Application.Styles>
<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceInclude Source="avares://TerribleHound31.Avalonia.Lib/Themes/Generic.axaml" />
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

## 잠재적 런타임 오류

### 1. CSS `hue-rotate(130deg)` 미지원
- **위치**: `FruitLogo.axaml` 이모지 TextBlock
- **원인**: CSS의 `filter: hue-rotate(130deg)`는 AvaloniaUI에서 직접 지원하지 않음
- **현재 상태**: 원본 이모지 색상 그대로 사용
- **해결 방안**: 필요 시 ShaderEffect 또는 다른 이모지로 대체

### 2. `border-radius` 백분율 변환
- **위치**: 잎(leaf) Border의 CornerRadius
- **원인**: CSS `border-radius: 0 40% 0 60%`를 픽셀값 `0,36,0,54`로 변환
- **비고**: 90px 기준으로 계산 (90 * 0.4 = 36, 90 * 0.6 = 54)
- **잠재적 문제**: 크기 변경 시 비율이 유지되지 않음

### 3. 잎 위치 조정
- **위치**: 잎 Border의 Margin
- **원인**: CSS `position: absolute; top: 5%; left: 42%`를 Margin으로 변환
- **비고**: 컨트롤 크기 300px 기준으로 계산하여 고정값 사용
- **잠재적 문제**: 컨트롤 크기 변경 시 위치 재조정 필요

### 4. CSS `z-index: -1` 처리
- **위치**: 잎 Border
- **원인**: CSS에서 잎이 본체 뒤에 위치 (`z-index: -1`)
- **현재 상태**: Panel 내 순서와 `ZIndex` 속성으로 처리
- **비고**: Panel에서 ZIndex 0(잎), 1(본체) 순으로 설정

## 빌드 결과

```
빌드했습니다.
    경고 0개
    오류 0개
```
