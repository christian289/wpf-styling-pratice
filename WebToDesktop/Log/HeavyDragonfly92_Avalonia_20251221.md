# HeavyDragonfly92 AvaloniaUI 변환 로그

## 변환 정보

- **소스**: uiverse.io (Pradeepsaranbishnoi)
- **원본 HTML/CSS**: 슬라이딩 글라이더 효과가 있는 탭 컨트롤
- **변환 일시**: 2025-12-21
- **대상 프레임워크**: AvaloniaUI 11.2.2 / .NET 9.0

## 프로젝트 구조

```
HeavyDragonfly92/AvaloniaUI/
├── HeavyDragonfly92.Avalonia.slnx
├── HeavyDragonfly92.Avalonia.Lib/
│   ├── Controls/
│   │   ├── SlidingTabControl.cs
│   │   └── SlidingTabItem.cs
│   └── Themes/
│       ├── Generic.axaml
│       ├── SlidingTabControl.axaml
│       └── SlidingTabItem.axaml
└── HeavyDragonfly92.Avalonia.Gallery/
    ├── App.axaml / App.axaml.cs
    ├── MainWindow.axaml / MainWindow.axaml.cs
    └── Program.cs
```

## 컴파일 에러 및 수정 내용

### 에러 1: IPseudoClasses.Set 메서드 없음

**에러 내용**:
```
error CS1061: 'IPseudoClasses'에는 'Set'에 대한 정의가 포함되어 있지 않습니다
```

**원인**: Avalonia 11.x에서 `PseudoClasses.Set()` 메서드가 제거됨

**수정 방법**:
```csharp
// 수정 전
PseudoClasses.Set(":selected", isSelected);

// 수정 후
if (isSelected)
{
    Classes.Add(":selected");
}
else
{
    Classes.Remove(":selected");
}
```

### 에러 2: StyleInclude vs ResourceInclude 혼동

**에러 내용**:
```
Avalonia error AVLN2000: Resource "...Generic.axaml" is defined as "Avalonia.Controls.ResourceDictionary" type, but expected "Avalonia.Styling.IStyle"
```

**원인**: `ResourceDictionary`를 `StyleInclude`로 포함하려고 시도함

**수정 방법**:
```xml
<!-- 수정 전 -->
<Application.Styles>
    <FluentTheme/>
    <StyleInclude Source="avares://HeavyDragonfly92.Avalonia.Lib/Themes/Generic.axaml"/>
</Application.Styles>

<!-- 수정 후 -->
<Application.Styles>
    <FluentTheme/>
</Application.Styles>
<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceInclude Source="avares://HeavyDragonfly92.Avalonia.Lib/Themes/Generic.axaml"/>
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

## 잠재적 런타임 에러 (직접 확인 필요)

### 1. 탭 클릭 이벤트 미연결

현재 `SlidingTabItem`에 클릭 이벤트 핸들러가 연결되어 있지 않음. 탭을 클릭해도 선택이 변경되지 않을 수 있음.

**권장 수정**: `SlidingTabItem`에 `PointerPressed` 이벤트 핸들러 추가 필요

### 2. 글라이더 애니메이션 TranslateTransform 적용

`TransformOperationsTransition`을 사용했으나 `RenderTransform`에 `TranslateTransform`을 직접 할당하는 방식으로 구현됨. 애니메이션이 예상대로 동작하지 않을 수 있음.

**권장 수정**: `TranslateTransform`을 미리 설정하고 `X` 속성만 변경하는 방식으로 전환

### 3. NotificationCount가 0일 때 배지 표시

현재 `IsVisible` 바인딩에서 `IsNotNull` 컨버터를 사용하고 있어, `NotificationCount`가 0이어도 배지가 표시될 수 있음.

**권장 수정**: `NotificationCount > 0`일 때만 표시되도록 컨버터 변경

## CSS to AXAML 변환 매핑

| CSS 속성 | AvaloniaUI 속성 |
|----------|----------------|
| `box-shadow: 0 0 1px 0 rgba(...)` | `BoxShadow="0 0 1 0 #26185ee0"` |
| `border-radius: 99px` | `CornerRadius="99"` |
| `transition: 0.25s ease-out` | `TransformOperationsTransition Duration="0:0:0.25" Easing="QuadraticEaseOut"` |
| `transform: translateX(100%)` | `RenderTransform = new TranslateTransform(50, 0)` |
| `:checked` pseudo-class | `:selected` pseudo-class |

## 빌드 결과

- **최종 상태**: 성공
- **경고**: 0개
- **에러**: 0개 (모두 수정됨)
