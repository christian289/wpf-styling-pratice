# WickedLiger39 AvaloniaUI 변환 로그

## 변환 정보
- **원본**: uiverse.io - ayman-ashine (Tags: animation, form, radio, gender, multicolor, tailwind, selectgender)
- **변환 날짜**: 2025-12-19
- **대상 프레임워크**: AvaloniaUI 11.2.2 / .NET 9.0

## 변환된 컨트롤

### GenderSelector
성별 선택 컨트롤 (Male, Female, Non-Binary, None 옵션)

**기능**:
- 4가지 성별 옵션 (남성-파랑, 여성-분홍, 논바이너리-보라, 미정-회색)
- 선택 시 확대 애니메이션 (ScaleTransform 1.1)
- 리플 효과 배경 확산 애니메이션
- 호버 시 미세 확대 효과

### GenderOption
개별 성별 옵션 라디오 버튼 컨트롤

**속성**:
- `IconData`: SVG Path 데이터
- `IconFill`, `IconStroke`, `IconStrokeThickness`: 아이콘 스타일
- `CircleBackground`: 원형 배경색
- `RippleBackground`: 리플 효과 배경색
- `RingBrush`: 선택 시 표시되는 링 색상

## 컴파일 에러 수정

### 1. StrokeLineJoin 속성 오류
**에러**:
```
Unable to resolve suitable regular or attached property StrokeLineJoin on type Avalonia.Controls:Avalonia.Controls.Shapes.Path
```

**원인**: AvaloniaUI의 Path 컨트롤에서는 `StrokeLineJoin` 대신 `StrokeJoin`을 사용

**수정**:
```xml
<!-- 수정 전 (WPF 스타일) -->
<Path StrokeLineJoin="Round"/>

<!-- 수정 후 (AvaloniaUI) -->
<Path StrokeJoin="Round"/>
```

**파일**: `WickedLiger39.Avalonia.Lib/Themes/GenderOption.axaml:64`

### 2. StyleInclude 타입 불일치 오류
**에러**:
```
Resource "avares://WickedLiger39.Avalonia.Lib/Themes/Generic.axaml" is defined as "Avalonia.Controls.ResourceDictionary" type in the assembly, but expected "Avalonia.Styling.IStyle"
```

**원인**: `Application.Styles`에서 `StyleInclude`는 `IStyle` 타입을 기대하지만, `ResourceDictionary` 루트 요소를 사용함

**수정**:
```xml
<!-- 수정 전 -->
<ResourceDictionary xmlns="https://github.com/avaloniaui">
    <ResourceDictionary.MergedDictionaries>
        <ResourceInclude Source="..."/>
    </ResourceDictionary.MergedDictionaries>
</ResourceDictionary>

<!-- 수정 후 -->
<Styles xmlns="https://github.com/avaloniaui">
    <Styles.Resources>
        <ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>
                <ResourceInclude Source="..."/>
            </ResourceDictionary.MergedDictionaries>
        </ResourceDictionary>
    </Styles.Resources>
</Styles>
```

**파일**: `WickedLiger39.Avalonia.Lib/Themes/Generic.axaml`

## 잠재적 런타임 오류 (확인 필요)

### 1. ControlTheme 바인딩 경고 가능성
`ControlTheme` 내부에서 `{Binding RingBrush, RelativeSource={RelativeSource TemplatedParent}}` 사용 시 런타임 바인딩 경고가 발생할 수 있음. 실제 동작에는 영향 없을 가능성 높음.

### 2. 애니메이션 FillMode 동작
`FillMode="Forward"` 설정이 상태 전환 시 예상대로 유지되지 않을 수 있음. 체크/언체크 상태 전환 시 애니메이션 초기화 확인 필요.

### 3. Non-Binary 아이콘 좌표 스케일
원본 SVG의 viewBox가 512x512인데 24x24로 스케일 변환 적용. Viewbox 내부에서 자동 스케일링되지만 Path 좌표가 간소화됨. 정확한 렌더링 확인 필요.

## 빌드 결과
- **최종 상태**: 성공
- **경고**: 0개
- **오류**: 0개
