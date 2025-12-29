# OrangeNewt83 AvaloniaUI 변환 로그

**변환 일자**: 2025-12-29
**원본 소스**: uiverse.io by ElSombrero2 (Tags: card)
**컨트롤 명**: FoodCard

## 프로젝트 구조

```
OrangeNewt83/AvaloniaUI/
├── OrangeNewt83.Avalonia.slnx
├── OrangeNewt83.Avalonia.Lib/
│   ├── Controls/
│   │   └── FoodCard.cs
│   └── Themes/
│       ├── Generic.axaml
│       └── FoodCard.axaml
└── OrangeNewt83.Avalonia.Gallery/
    ├── App.axaml / App.axaml.cs
    ├── MainWindow.axaml / MainWindow.axaml.cs
    └── Program.cs
```

## 변환된 기능

- 기울어진 카드 효과 (배경 5도, 콘텐츠 -5도 회전)
- hover 시 회전이 0도로 돌아가는 애니메이션
- pressed 시 그림자 제거 효과
- 햄버거 SVG 아이콘을 Path로 변환
- 제품명, 정보, 가격 표시 (통화 기호 접두사 포함)

## 컴파일 에러 및 수정 내역

### 에러 1: MSB4236 - SDK를 찾을 수 없음

**에러 메시지**:
```
error MSB4236: 지정된 'Sdk' SDK를 찾을 수 없습니다.
```

**원인**: csproj 파일에서 `Sdk="Sdk"`로 잘못 작성됨

**수정 방법**: `Sdk="Microsoft.NET.Sdk"`로 수정
```xml
<!-- 수정 전 -->
<Project Sdk="Sdk">

<!-- 수정 후 -->
<Project Sdk="Microsoft.NET.Sdk">
```

---

### 에러 2: AVLN2000 - TemplateBinding에서 StringFormat 미지원

**에러 메시지**:
```
Avalonia error AVLN2000: Unable to resolve suitable regular or attached property StringFormat on type Avalonia.Base:Avalonia.Data.TemplateBinding Line 81, position 48.
```

**원인**: AvaloniaUI에서 TemplateBinding은 StringFormat을 지원하지 않음

**수정 방법**: TemplateBinding 대신 Binding + RelativeSource 사용
```xml
<!-- 수정 전 -->
<TextBlock Text="{TemplateBinding Price, StringFormat={}{0:F2}}" />

<!-- 수정 후 -->
<TextBlock Text="{Binding Price, RelativeSource={RelativeSource TemplatedParent}, StringFormat={}{0:F2}}" />
```

---

### 에러 3: AVLN2000 - StyleInclude에서 ResourceDictionary 타입 불일치

**에러 메시지**:
```
Avalonia error AVLN2000: Resource "avares://OrangeNewt83.Avalonia.Lib/Themes/Generic.axaml" is defined as "Avalonia.Controls.ResourceDictionary" type in the "OrangeNewt83.Avalonia.Lib" assembly, but expected "Avalonia.Styling.IStyle".
```

**원인**: `Application.Styles`에서 `StyleInclude`는 IStyle 타입을 요구하지만, ResourceDictionary를 포함하려고 시도함

**수정 방법**: ResourceDictionary는 `Application.Resources`에서 병합
```xml
<!-- 수정 전 -->
<Application.Styles>
    <FluentTheme />
    <StyleInclude Source="avares://OrangeNewt83.Avalonia.Lib/Themes/Generic.axaml" />
</Application.Styles>

<!-- 수정 후 -->
<Application.Styles>
    <FluentTheme />
</Application.Styles>
<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceInclude Source="avares://OrangeNewt83.Avalonia.Lib/Themes/Generic.axaml" />
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

## Runtime Error 가능성 (직접 확인 필요)

1. **애니메이션 복귀 문제**: AvaloniaUI에서 `:pointerover` 애니메이션은 `FillMode="Forward"`로 설정되어 있어, 마우스가 떠난 후에도 0도 회전 상태가 유지될 수 있음. 마우스 떠남 시 원래 각도로 복귀하는 역방향 애니메이션이 필요할 수 있음.

2. **BoxShadow 렌더링**: `BoxShadow="0 0 5 1 #22000000"` 형식이 모든 AvaloniaUI 버전에서 동일하게 렌더링되는지 확인 필요.

3. **SVG Path 복잡도**: 햄버거 아이콘의 복잡한 Path 데이터가 성능에 영향을 줄 수 있음. 많은 카드를 동시에 렌더링할 경우 최적화가 필요할 수 있음.

4. **Price 포맷팅**: `StringFormat={}{0:F2}` 형식은 문화권 설정에 따라 소수점 구분자가 다르게 표시될 수 있음 (예: 유럽에서는 2.50 대신 2,50).

## 빌드 결과

```
빌드했습니다.
    경고 0개
    오류 0개
```

## 실행 방법

```bash
cd WebToDesktop/Output/OrangeNewt83/AvaloniaUI
dotnet run --project OrangeNewt83.Avalonia.Gallery
```
