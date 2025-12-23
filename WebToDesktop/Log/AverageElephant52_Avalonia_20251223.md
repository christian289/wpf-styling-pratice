# AverageElephant52 - AvaloniaUI 변환 로그

## 변환 정보

- **변환 날짜**: 2025-12-23
- **소스**: Uiverse.io by seyed-mohsen-mousavi
- **컴포넌트**: SearchBar (검색바)
- **태그**: input, shadow, gradient

## 프로젝트 구조

```
WebToDesktop/Output/AverageElephant52/AvaloniaUI/
├── AverageElephant52.Avalonia.slnx
├── AverageElephant52.Avalonia.Lib/
│   ├── AverageElephant52.Avalonia.Lib.csproj
│   ├── Controls/
│   │   └── SearchBar.cs
│   └── Themes/
│       ├── Generic.axaml
│       └── SearchBar.axaml
└── AverageElephant52.Avalonia.Gallery/
    ├── AverageElephant52.Avalonia.Gallery.csproj
    ├── App.axaml
    ├── App.axaml.cs
    ├── MainWindow.axaml
    ├── MainWindow.axaml.cs
    └── Program.cs
```

## CSS → AXAML 변환 내용

### 1. Radial Gradient 변환

#### 외부 컨테이너 (search-bar)
```css
/* CSS */
background: radial-gradient(circle 80px at 80% -10%, #fff, #181b1b);
```

```xml
<!-- AXAML -->
<RadialGradientBrush GradientOrigin="80%,-10%" Center="80%,-10%" RadiusX="0.4" RadiusY="0.8">
    <GradientStop Color="#FFFFFFFF" Offset="0" />
    <GradientStop Color="#FF181B1B" Offset="1" />
</RadialGradientBrush>
```

#### Blob 장식 요소
```css
/* CSS */
background: radial-gradient(circle 60px at 0% 100%, #ff3fcb, rgba(255, 0, 216, 0.5), transparent);
```

```xml
<!-- AXAML -->
<RadialGradientBrush GradientOrigin="0%,100%" Center="0%,100%" RadiusX="0.9" RadiusY="1.2">
    <GradientStop Color="#FFFF3FCB" Offset="0" />
    <GradientStop Color="#80FF00D8" Offset="0.5" />
    <GradientStop Color="#00000000" Offset="1" />
</RadialGradientBrush>
```

#### 내부 텍스트박스 컨테이너 (inner)
```css
/* CSS */
background: radial-gradient(circle 80px at 80% -50%, #777, #0f1111);
```

```xml
<!-- AXAML -->
<RadialGradientBrush GradientOrigin="80%,-50%" Center="80%,-50%" RadiusX="0.4" RadiusY="0.8">
    <GradientStop Color="#FF777777" Offset="0" />
    <GradientStop Color="#FF0F1111" Offset="1" />
</RadialGradientBrush>
```

### 2. Box-Shadow 변환

```css
/* CSS */
box-shadow: 0 0 5px rgba(0, 0, 0, 0.66);
```

```xml
<!-- AXAML -->
BoxShadow="0 0 5 0 #A8000000"
```

### 3. Focus 애니메이션 변환

```css
/* CSS */
.search-bar:focus-within {
    transform: skew(10deg, 0deg);
    box-shadow: -13px 20px 20px rgba(0, 0, 0, 0.66);
    transition: all 0.3s linear;
}
```

```xml
<!-- AXAML -->
<Style Selector="^:focus-within /template/ Border#PART_OuterBorder">
    <Style.Animations>
        <Animation Duration="0:0:0.3" Easing="LinearEasing" FillMode="Forward">
            <KeyFrame Cue="100%">
                <Setter Property="BoxShadow" Value="-13 20 20 0 #A8000000" />
                <Setter Property="RenderTransform">
                    <SkewTransform AngleX="10" />
                </Setter>
            </KeyFrame>
        </Animation>
    </Style.Animations>
</Style>
```

### 4. Pseudo-element (::after) 변환

CSS의 `::after` pseudo-element를 Grid와 Border를 사용하여 구현:

```css
/* CSS */
.search-bar::after {
    width: 65%;
    height: 60%;
    border-radius: 120px;
    top: 0;
    right: 0;
    box-shadow: 0 0 20px rgba(255, 255, 255, 0.22);
}
```

```xml
<!-- AXAML: Grid를 사용하여 비율 처리 -->
<Grid ColumnDefinitions="*,1.857*" RowDefinitions="1.5*,*" IsHitTestVisible="False">
    <Border Grid.Column="1" Grid.Row="0" CornerRadius="120" BoxShadow="0 0 20 0 #38FFFFFF" />
</Grid>
```

## 컴파일 에러

**없음** - 빌드 성공 (경고 0개, 오류 0개)

## 잠재적 런타임 오류

### 1. RadialGradientBrush 렌더링 이슈

**이슈**: AvaloniaUI Issue #19888
- RadialGradientBrush에서 GradientOrigin과 Center 값이 다르고 첫 번째 GradientStop이 Transparent일 경우 정상 동작하지 않음
- **대응**: 모든 RadialGradientBrush에서 GradientOrigin과 Center 값을 동일하게 설정함
- **확인 필요**: 런타임에서 그라데이션이 올바르게 렌더링되는지 시각적 확인 필요

### 2. 음수 퍼센트 값 좌표

**이슈**: CSS의 `at 80% -10%`와 `at 80% -50%`를 AvaloniaUI에서 `80%,-10%` 및 `80%,-50%`로 변환
- **확인 필요**: AvaloniaUI에서 음수 퍼센트 좌표가 CSS와 동일하게 해석되는지 확인 필요
- 예상 동작이 다를 경우 RadiusX/RadiusY 조정 필요할 수 있음

### 3. SkewTransform 애니메이션

**이슈**: Focus 시 Skew 애니메이션이 적용됨
- **확인 필요**: 애니메이션 종료 후 원래 상태로 복귀하는지 확인 필요
- FillMode="Forward"로 설정되어 있어 focus 해제 시 원상복귀 애니메이션이 없음
- 필요시 `:not(:focus-within)` 상태에 대한 복귀 애니메이션 추가 필요

### 4. 텍스트 입력 스타일

**이슈**: CSS의 `-webkit-text-fill-color: transparent`는 AvaloniaUI에서 직접 지원하지 않음
- **대응**: 일반 Foreground 색상 사용
- **확인 필요**: 텍스트가 올바르게 표시되는지 확인 필요

## 변환 특이사항

1. **SearchBar 커스텀 컨트롤**: TemplatedControl 기반으로 구현
2. **속성**: Placeholder, Text 속성 지원
3. **검색 아이콘**: PathIcon을 사용하여 SVG 경로 데이터 직접 사용
4. **내부 TextBox**: 커스텀 ControlTemplate으로 기본 Fluent 스타일 재정의

## 빌드 결과

```
빌드했습니다.
    경고 0개
    오류 0개

경과 시간: 00:00:04.45
```
