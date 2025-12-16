# LovelyMonkey46 AvaloniaUI 변환 로그

## 변환 정보

- **원본**: Uiverse.io by csemszepp (okke29)
- **변환일**: 2025-12-16
- **대상 프레임워크**: AvaloniaUI 11.2.2 / .NET 9.0

## 원본 CSS 분석

복잡한 다중 배경 패턴:
- 6개의 `radial-gradient` (링 형태의 반투명 원형 그라디언트)
- 1개의 `linear-gradient` (45도 무지개 색상)
- 각각 다른 `background-size`와 `background-position`으로 타일링

## 컴파일 에러 및 수정

### 에러 1: ResourceDictionary에 Style 직접 추가 불가

**에러 메시지**:
```
AVLN3000: Unable to find suitable setter or adder for property Content of type
Avalonia.Base:Avalonia.Controls.ResourceDictionary for argument Avalonia.Base:Avalonia.Styling.Style
```

**원인**: AvaloniaUI에서 `<ResourceDictionary>`는 스타일을 직접 자식으로 가질 수 없음

**수정 전**:
```xml
<ResourceDictionary xmlns="https://github.com/avaloniaui"
                    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">
    <Style Selector="...">...</Style>
</ResourceDictionary>
```

**수정 후**:
```xml
<Styles xmlns="https://github.com/avaloniaui"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">
    <Style Selector="...">...</Style>
</Styles>
```

**Generic.axaml도 동일하게 수정**:
```xml
<Styles xmlns="https://github.com/avaloniaui"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">
    <StyleInclude Source="avares://LovelyMonkey46.Avalonia.Lib/Themes/LovelyMonkey46.axaml"/>
</Styles>
```

## 변환 시 고려사항

### CSS → AvaloniaUI 제한사항

1. **다중 배경 미지원**: CSS의 `background: ..., ..., ...` 구문처럼 여러 배경을 하나의 속성에 지정 불가
2. **background-size / background-position**: AvaloniaUI에서 직접 지원하지 않음
3. **타일링 패턴**: `TileBrush`로 가능하나, 여러 다른 크기의 타일을 동시에 적용 불가

### 구현 방식

커스텀 `Control`을 만들고 `Render` 메서드에서 직접 그리는 방식 채택:
1. 배경색 먼저 채우기
2. LinearGradientBrush로 베이스 그라디언트 적용
3. 여러 RadialGradientBrush를 타일 패턴으로 반복 렌더링

### RadialGradientBrush 주의사항 (Issue #19888)

AvaloniaUI에서 RadialGradientBrush 사용 시:
- **GradientOrigin과 Center 값이 반드시 동일해야 함**
- 다르면 첫 번째 GradientStop이 투명일 때 정상 동작하지 않음

본 변환에서는 모두 `Center="0.5,0.5"`, `GradientOrigin="0.5,0.5"`로 통일

## 잠재적 런타임 오류 가능성

1. **성능 문제**: 많은 수의 RadialGradient를 매 프레임 렌더링하므로 큰 윈도우 크기에서 성능 저하 가능
   - 해결 방안: `RenderTargetBitmap`으로 캐싱하거나 크기 변경 시에만 다시 그리기

2. **색상 정확도**: CSS의 링 그라디언트(얇은 테두리 효과)와 AvaloniaUI의 RadialGradient 표현 방식 차이로 시각적 차이 발생 가능

3. **타일 정렬**: CSS의 정확한 `background-position` 오프셋을 완벽히 재현하지 않음
   - 대략적인 패턴 효과만 구현

## 빌드 결과

```
빌드했습니다.
    경고 0개
    오류 0개
```

## 파일 구조

```
LovelyMonkey46/AvaloniaUI/
├── LovelyMonkey46.Avalonia.slnx
├── LovelyMonkey46.Avalonia.Lib/
│   ├── LovelyMonkey46.Avalonia.Lib.csproj
│   ├── Controls/
│   │   └── LovelyMonkey46.cs
│   └── Themes/
│       ├── Generic.axaml
│       └── LovelyMonkey46.axaml
└── LovelyMonkey46.Avalonia.Gallery/
    ├── LovelyMonkey46.Avalonia.Gallery.csproj
    ├── App.axaml
    ├── App.axaml.cs
    ├── MainWindow.axaml
    ├── MainWindow.axaml.cs
    └── Program.cs
```
