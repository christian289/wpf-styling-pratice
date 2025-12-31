# SpottyShrimp35 AvaloniaUI 변환 로그

## 프로젝트 정보

- **원본**: Uiverse.io by lautyYT
- **태그**: simple, blue, pattern
- **변환 일자**: 2025-12-31

## 원본 CSS 분석

```css
.container {
  width: 100%;
  height: 100%;
  background: repeating-linear-gradient(45deg, #0050fc,#0050fc 20px, #0684fade 20px,#0684fade 40px);
}
```

45도 각도의 대각선 스트라이프 패턴:
- 첫 번째 스트라이프: `#0050fc` (0-20px)
- 두 번째 스트라이프: `#0684fa` (20-40px, 투명도 0xDE)

## 변환 방식

AvaloniaUI에서는 `repeating-linear-gradient`를 직접 지원하지 않으므로 `DrawingBrush`와 `GeometryDrawing`을 사용하여 타일링 패턴으로 구현.

### 핵심 구현

```xml
<DrawingBrush TileMode="Tile" Stretch="None" DestinationRect="0,0,40,40">
    <DrawingBrush.Drawing>
        <DrawingGroup>
            <!-- 배경색 -->
            <GeometryDrawing>
                <GeometryDrawing.Brush>
                    <SolidColorBrush Color="{Binding Stripe1Color, RelativeSource={RelativeSource TemplatedParent}}"/>
                </GeometryDrawing.Brush>
                <GeometryDrawing.Geometry>
                    <RectangleGeometry Rect="0,0,40,40"/>
                </GeometryDrawing.Geometry>
            </GeometryDrawing>
            <!-- 대각선 스트라이프 -->
            <GeometryDrawing>
                <GeometryDrawing.Brush>
                    <SolidColorBrush Color="{Binding Stripe2Color, RelativeSource={RelativeSource TemplatedParent}}"/>
                </GeometryDrawing.Brush>
                <GeometryDrawing.Geometry>
                    <PathGeometry>
                        <PathGeometry.Figures>
                            <PathFigure StartPoint="20,0" IsClosed="True">
                                <LineSegment Point="40,0"/>
                                <LineSegment Point="40,20"/>
                                <LineSegment Point="20,40"/>
                                <LineSegment Point="0,40"/>
                                <LineSegment Point="0,20"/>
                            </PathFigure>
                        </PathGeometry.Figures>
                    </PathGeometry>
                </GeometryDrawing.Geometry>
            </GeometryDrawing>
        </DrawingGroup>
    </DrawingBrush.Drawing>
</DrawingBrush>
```

## 컴파일 에러 및 수정

### 에러 1: AVLN2000 - StyleInclude와 ResourceDictionary 타입 불일치

**에러 메시지**:
```
Avalonia error AVLN2000: Resource "avares://SpottyShrimp35.Avalonia.Lib/Themes/Generic.axaml"
is defined as "Avalonia.Controls.ResourceDictionary" type in the "SpottyShrimp35.Avalonia.Lib" assembly,
but expected "Avalonia.Styling.IStyle".
```

**원인**:
- `Application.Styles`에서 `StyleInclude`를 사용하여 `ResourceDictionary`를 참조하려고 함
- `StyleInclude`는 `IStyle` 타입만 참조 가능하고, `ResourceDictionary`는 `IStyle`이 아님

**수정 전**:
```xml
<Application.Styles>
    <FluentTheme />
    <StyleInclude Source="avares://SpottyShrimp35.Avalonia.Lib/Themes/Generic.axaml"/>
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
            <ResourceInclude Source="avares://SpottyShrimp35.Avalonia.Lib/Themes/Generic.axaml"/>
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

**설명**:
- `ResourceDictionary`는 `Application.Resources`에서 `ResourceInclude`를 통해 병합해야 함
- `Application.Styles`는 `FluentTheme`, `StyleInclude` 등 `IStyle` 구현체만 포함 가능

## 런타임 에러 가능성

### 1. DrawingBrush 타일링 이음매

**가능성**: 낮음

**설명**:
- `DrawingBrush`의 `TileMode="Tile"`과 `DestinationRect="0,0,40,40"` 설정으로 40x40 픽셀 단위로 타일링
- 대각선 스트라이프의 기하학적 계산이 정확하여 이음매 없이 연결되어야 함

**확인 필요 사항**:
- 실제 렌더링 시 타일 경계에서 미세한 간격이 보이는지 확인
- 고해상도 디스플레이에서 안티앨리어싱으로 인한 시각적 차이 확인

### 2. 투명도 처리

**가능성**: 중간

**설명**:
- 원본 CSS의 `#0684fade`는 투명도 0xDE(87%)를 포함
- 현재 구현에서는 `#0684fa` (불투명)로 처리됨

**확인 필요 사항**:
- 원본 디자인 의도에 따라 투명도가 필요한 경우 `Color` 속성에 Alpha 값 추가 필요:
  ```xml
  <Color x:Key="Stripe2.Color">#DE0684FA</Color>
  ```

### 3. StripeWidth 속성 미사용

**가능성**: 낮음 (기능 제한)

**설명**:
- `StripedPatternControl`에 `StripeWidth` 속성이 정의되어 있지만, 현재 XAML 템플릿에서는 고정값 40을 사용
- 동적으로 스트라이프 너비를 변경하려면 추가 구현 필요

## 생성된 파일 목록

```
SpottyShrimp35.Avalonia.slnx
SpottyShrimp35.Avalonia.Lib/
├── SpottyShrimp35.Avalonia.Lib.csproj
├── Controls/
│   └── StripedPatternControl.cs
└── Themes/
    ├── Generic.axaml
    └── StripedPatternControl.axaml
SpottyShrimp35.Avalonia.Gallery/
├── SpottyShrimp35.Avalonia.Gallery.csproj
├── App.axaml
├── App.axaml.cs
├── MainWindow.axaml
├── MainWindow.axaml.cs
└── Program.cs
```

## 빌드 결과

- **상태**: 성공
- **경고**: 0개
- **에러**: 0개 (수정 후)
