# SwiftChipmunk76 AvaloniaUI 변환 로그

## 변환 정보

- **원본**: uiverse.io by PriyanshuGupta28
- **컨트롤 종류**: Star Rating (별점 평가)
- **변환일**: 2026-01-03

## 원본 CSS 분석

```css
/* 주요 스타일 */
.rating label:before {
  content: '\2605';  /* ★ 유니코드 */
  font-size: 30px;
}

.rating label {
  float: right;       /* 오른쪽에서 왼쪽으로 배치 */
  color: #ccc;        /* 기본 회색 */
  transition: color 0.3s;
}

.rating input:checked ~ label,
.rating label:hover,
.rating label:hover ~ label {
  color: #6f00ff;     /* 보라색 활성화 */
}
```

## 컴파일 에러 및 수정

### 에러 1: CS1061 - FindAncestorOfType 확장 메서드 없음

**에러 메시지:**
```
error CS1061: 'StarItem'에는 'FindAncestorOfType'에 대한 정의가 포함되어 있지 않고,
'StarItem' 형식의 첫 번째 인수를 허용하는 액세스 가능한 확장 메서드 'FindAncestorOfType'이(가) 없습니다.
```

**원인:**
`FindAncestorOfType<T>()` 확장 메서드는 `Avalonia.VisualTree` 네임스페이스에 정의되어 있으나, 해당 using 지시문이 누락됨.

**수정:**
```csharp
// StarItem.cs에 추가
using Avalonia.VisualTree;
```

### 에러 2: AVLN2000 - ResourceDictionary를 StyleInclude로 포함

**에러 메시지:**
```
Avalonia error AVLN2000: Resource "avares://SwiftChipmunk76.Avalonia.Lib/Themes/Generic.axaml"
is defined as "Avalonia.Controls.ResourceDictionary" type in the "SwiftChipmunk76.Avalonia.Lib" assembly,
but expected "Avalonia.Styling.IStyle".
```

**원인:**
`Application.Styles` 내에서 `StyleInclude`는 `IStyle` 타입을 기대하지만, Generic.axaml은 `ResourceDictionary` 타입.

**수정:**
```xml
<!-- 변경 전 (잘못된 방식) -->
<Application.Styles>
    <FluentTheme />
    <StyleInclude Source="avares://..." />
</Application.Styles>

<!-- 변경 후 (올바른 방식) -->
<Application.Styles>
    <FluentTheme />
</Application.Styles>
<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceInclude Source="avares://..." />
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

## 잠재적 런타임 오류 (직접 확인 필요)

### 1. CSS `float: right` 동작 차이

- **CSS 원본**: `float: right`로 별이 오른쪽에서 왼쪽으로 역순 배치됨
- **AvaloniaUI 변환**: `StackPanel Orientation="Horizontal"`로 왼쪽에서 오른쪽으로 순차 배치
- **영향**: 별점 선택 시 시각적 동작은 동일하게 구현됨 (hover/click 시 해당 별과 이전 별들이 활성화)
- **확인 필요**: 원본과 동일한 UX인지 실행하여 확인 필요

### 2. CSS `:checked ~ label` 선택자 변환

- **CSS 원본**: 형제 선택자(`~`)로 checked 이후의 모든 label에 스타일 적용
- **AvaloniaUI 변환**: `IValueConverter`를 사용하여 `Value` 속성 기반으로 IsActive/IsHovered 상태 계산
- **확인 필요**: 호버 시 모든 이전 별이 정확히 활성화되는지 확인

### 3. Transition 애니메이션

- **CSS 원본**: `transition: color 0.3s`
- **AvaloniaUI 변환**: `<BrushTransition Property="Foreground" Duration="0:0:0.3" />`
- **확인 필요**: 전환 효과가 부드럽게 적용되는지 확인

## 생성된 파일 목록

```
SwiftChipmunk76/AvaloniaUI/
├── SwiftChipmunk76.Avalonia.slnx
├── SwiftChipmunk76.Avalonia.Lib/
│   ├── SwiftChipmunk76.Avalonia.Lib.csproj
│   ├── Controls/
│   │   ├── StarRating.cs
│   │   ├── StarItem.cs
│   │   └── StarRatingConverters.cs
│   └── Themes/
│       ├── Generic.axaml
│       └── StarRating.axaml
└── SwiftChipmunk76.Avalonia.Gallery/
    ├── SwiftChipmunk76.Avalonia.Gallery.csproj
    ├── app.manifest
    ├── App.axaml
    ├── App.axaml.cs
    ├── Program.cs
    ├── MainWindow.axaml
    └── MainWindow.axaml.cs
```

## 빌드 결과

```
빌드했습니다.
    경고 0개
    오류 0개
```
