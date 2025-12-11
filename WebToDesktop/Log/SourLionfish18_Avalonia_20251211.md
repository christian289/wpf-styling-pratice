# SourLionfish18 WPF → AvaloniaUI 변환 로그

## 변환 일시
2025-12-11

## 원본 프로젝트
- 경로: `WebToDesktop/Output/SourLionfish18/Wpf`
- 설명: 애니메이션 체크마크가 있는 둥근 체크박스 컨트롤 (Uiverse.io by mobinkakei)

## 생성된 AvaloniaUI 프로젝트
- 경로: `WebToDesktop/Output/SourLionfish18/AvaloniaUI`
- 구조:
  ```
  AvaloniaUI/
  ├── SourLionfish18.Avalonia.slnx
  ├── SourLionfish18.Avalonia.UI/
  │   ├── SourLionfish18.Avalonia.UI.csproj
  │   ├── Controls/
  │   │   └── SourLionfish18.cs
  │   └── Themes/
  │       ├── Generic.axaml
  │       ├── SourLionfish18.axaml
  │       └── SourLionfish18Resources.axaml
  └── SourLionfish18.Avalonia.Gallery/
      ├── SourLionfish18.Avalonia.Gallery.csproj
      ├── Program.cs
      ├── App.axaml
      ├── App.axaml.cs
      ├── MainWindow.axaml
      └── MainWindow.axaml.cs
  ```

## 주요 변환 내용

### 1. 프레임워크 변경
| 항목 | WPF | AvaloniaUI |
|------|-----|------------|
| TargetFramework | net10.0-windows | net9.0 |
| 기본 컨트롤 상속 | CheckBox | ToggleButton |
| XAML 확장자 | .xaml | .axaml |

### 2. 네임스페이스 변환
| WPF | AvaloniaUI |
|-----|------------|
| `http://schemas.microsoft.com/winfx/2006/xaml/presentation` | `https://github.com/avaloniaui` |
| `clr-namespace:` | `using:` |

### 3. 리소스 URI 변환
| WPF | AvaloniaUI |
|-----|------------|
| `pack://application:,,,/AssemblyName;component/Path` | `avares://AssemblyName/Path` |
| `/AssemblyName;component/Path` | `avares://AssemblyName/Path` |

### 4. 스타일 구조 변환
- WPF의 `ResourceDictionary` + `Style` → AvaloniaUI의 `Styles` + `ControlTheme`
- WPF의 `ControlTemplate.Triggers` → AvaloniaUI의 중첩된 `Style Selector`

### 5. 컨트롤 속성 변환
| WPF | AvaloniaUI |
|-----|------------|
| `DefaultStyleKeyProperty.OverrideMetadata()` | `AffectsRender<T>()` |
| `FrameworkPropertyMetadata` | (제거됨 - Avalonia는 다른 방식 사용) |

## 컴파일 에러 수정 내역

### 에러 1: CS1061 - WithInterFont 메서드 없음
- **원인**: `Avalonia.Fonts.Inter` 패키지 누락
- **해결**: `SourLionfish18.Avalonia.Gallery.csproj`에 `Avalonia.Fonts.Inter` 패키지 추가

### 에러 2: AVLN2000 - ResourceDictionary를 IStyle로 변환 불가
- **원인**: `App.axaml`에서 `StyleInclude`로 `ResourceDictionary`를 참조
- **해결**: `Generic.axaml`과 `SourLionfish18.axaml`을 `Styles` 루트로 변환

### 에러 3: AVLN3000 - ControlTheme을 Styles에 직접 추가 불가
- **원인**: `ControlTheme`은 `Styles` 컨텐츠가 아닌 `Styles.Resources`에 정의해야 함
- **해결**: `ControlTheme`을 `Styles.Resources > ResourceDictionary` 내부로 이동

## 잠재적 런타임 이슈

### 1. 애니메이션 트랜지션
- WPF의 `Storyboard` 기반 애니메이션 → Avalonia의 `Transitions` + `Style Selector`로 변환
- WPF의 정밀한 애니메이션 타이밍(EnterActions/ExitActions)을 완벽히 재현하지 못할 수 있음
- `Opacity`, `ScaleTransform` 애니메이션은 Selector 변경 시 즉시 적용되며, `BrushTransition`만 부드럽게 전환됨

### 2. ColorAnimation 미적용
- WPF의 `ColorAnimation`으로 `SolidColorBrush.Color` 직접 애니메이션 가능
- Avalonia에서는 `BrushTransition`으로 대체했으나, 동일한 효과를 내지 못할 수 있음

### 3. ScaleTransform 애니메이션 부재
- WPF는 Storyboard로 `ScaleX`, `ScaleY`를 직접 애니메이션
- Avalonia에서는 `TransformOperationsTransition`을 사용해야 하지만, 현재 구현에서는 즉시 변경됨

## 빌드 확인
```
dotnet build SourLionfish18.Avalonia.slnx
빌드했습니다.
    경고 0개
    오류 0개
```

## 패키지 버전
- Avalonia: 11.2.2
- Avalonia.Desktop: 11.2.2
- Avalonia.Themes.Fluent: 11.2.2
- Avalonia.Fonts.Inter: 11.2.2
