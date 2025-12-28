# RottenCatfish64 AvaloniaUI 변환 로그

## 변환 정보

- **소스**: Uiverse.io by AmruthGowda91200
- **태그**: simple, blue, minimalist, html, css, pattern
- **변환일**: 2025-12-29
- **대상 프레임워크**: AvaloniaUI 11.2.2, .NET 9.0

## 원본 CSS 분석

```css
.container {
  width: 100%;
  height: 100%;
  background: repeating-linear-gradient(
      -45deg,
      #ff7e5f,
      #ff7e5f 10px,
      #3f51b5 10px,
      #3f51b5 20px
    ),
    repeating-linear-gradient(
      45deg,
      #3f51b5,
      #3f51b5 10px,
      #ff7e5f 10px,
      #ff7e5f 20px
    ),
    repeating-linear-gradient(
      -30deg,
      #3f51b5,
      #3f51b5 10px,
      #ff7e5f 10px,
      #ff7e5f 20px
    ),
    repeating-linear-gradient(
      30deg,
      #ff7e5f,
      #ff7e5f 10px,
      #3f51b5 10px,
      #3f51b5 20px
    );
}
```

## 변환 방식

CSS `repeating-linear-gradient`는 AvaloniaUI에서 직접 지원하지 않으므로, `Control.Render` 메서드를 오버라이드하여 `DrawingContext`로 직접 구현했습니다.

### 구현 상세

1. 4개의 repeating-linear-gradient 패턴을 각각 다른 각도로 렌더링
2. 각 패턴에 opacity를 적용하여 블렌딩 효과 구현
3. `Matrix.CreateRotation`을 사용하여 회전 변환 적용

## 컴파일 에러 및 수정

### 에러 1: AVLN2000 - Unable to resolve property Template

**에러 메시지**:
```
Avalonia error AVLN2000: Unable to resolve suitable regular or attached property Template on type RottenCatfish64.Avalonia.Lib:RottenCatfish64.Avalonia.Lib.Controls.RottenCatfish64
```

**원인**:
- `Control` 클래스는 `Template` 속성이 없음
- `ControlTheme`과 `Template` Setter는 `TemplatedControl`에서만 사용 가능

**수정 방법**:
- `ControlTheme` 대신 `Style`로 변경
- `Template` Setter 제거

### 에러 2: AVLN3000 - Unable to find suitable setter for Style in ResourceDictionary

**에러 메시지**:
```
Avalonia error AVLN3000: Unable to find suitable setter or adder for property Content of type Avalonia.Base:Avalonia.Controls.ResourceDictionary for argument Avalonia.Base:Avalonia.Styling.Style
```

**원인**:
- `ResourceDictionary`는 `Style` 요소를 직접 포함할 수 없음
- `Style`은 `Styles` 루트 요소 내에서 정의해야 함

**수정 방법**:
- `ResourceDictionary` 대신 `Styles`를 루트 요소로 사용
- `Generic.axaml`과 `RottenCatfish64.axaml` 모두 `Styles`로 변경

## 잠재적 런타임 에러 (직접 확인 필요)

1. **렌더링 성능 이슈**
   - 4개의 패턴을 매 프레임마다 렌더링하므로 창 크기가 클 경우 성능 저하 가능
   - `InvalidateVisual()` 호출 시 전체 다시 그리기 발생

2. **색상 블렌딩 차이**
   - CSS의 background 레이어 합성 방식과 DrawingContext의 Opacity 블렌딩이 다를 수 있음
   - 원본 CSS와 정확히 동일한 시각적 결과를 보장하지 않음

3. **클리핑 이슈**
   - `ClipToBounds="True"` 설정에도 불구하고 특정 상황에서 패턴이 경계 밖으로 나올 수 있음

## 생성된 파일

```
RottenCatfish64/AvaloniaUI/
├── RottenCatfish64.Avalonia.slnx
├── RottenCatfish64.Avalonia.Lib/
│   ├── RottenCatfish64.Avalonia.Lib.csproj
│   ├── Controls/
│   │   └── RottenCatfish64.cs
│   └── Themes/
│       ├── Generic.axaml
│       └── RottenCatfish64.axaml
└── RottenCatfish64.Avalonia.Gallery/
    ├── RottenCatfish64.Avalonia.Gallery.csproj
    ├── Program.cs
    ├── App.axaml
    ├── App.axaml.cs
    ├── MainWindow.axaml
    └── MainWindow.axaml.cs
```

## 빌드 결과

```
빌드했습니다.
    경고 0개
    오류 0개
```
