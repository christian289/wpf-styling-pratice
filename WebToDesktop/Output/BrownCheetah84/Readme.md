# BrownCheetah84

Patterns 스타일 컨트롤 - 대각선 체크무늬 패턴 배경

## 원본 정보

- **원작자**: elijahgummer
- **원본 링크**: [https://uiverse.io/elijahgummer/brown-cheetah-84](https://uiverse.io/elijahgummer/brown-cheetah-84) (클릭 시 원본 CSS/HTML 확인 가능)
- **태그**: simple, blue, modern, pattern

## 빌드 명령

### WPF

```bash
cd Wpf && dotnet run --project BrownCheetah84.Wpf.Gallery
```

### AvaloniaUI

```bash
cd AvaloniaUI && dotnet run --project BrownCheetah84.Avalonia.Gallery
```

## CSS → WPF 변환 매핑 테이블

| CSS 속성 | CSS 값 | WPF 구현 |
|---------|--------|----------|
| `background` | `#f0f0f0` | `SolidColorBrush` (Border.Background) |
| `background` (pattern) | `linear-gradient(45deg, #3498db 25%, transparent 25%, ...)` | `DrawingBrush` + `PathGeometry` (4개 삼각형) |
| `background` (pattern) | `linear-gradient(-45deg, #3498db 25%, transparent 25%, ...)` | 위와 동일한 DrawingBrush에 병합 |
| `background-size` | `20px 20px` | `Viewport="0,0,20,20"` + `ViewportUnits="Absolute"` |
| `opacity` | `0.8` | `Border Opacity="{StaticResource BrownCheetah84.Pattern.Opacity}"` |
| `::before` | pseudo-element | Grid 내 별도 Border 레이어 |
| `position: absolute` | 전체 영역 채움 | Grid 기본 Stretch 동작 |
| `content: ""` | 빈 콘텐츠 | 불필요 (WPF에서 자동 처리) |

## 패턴 구현 상세

CSS의 대각선 체크무늬는 45도와 -45도 linear-gradient를 겹쳐서 구현합니다.
WPF에서는 이를 `DrawingBrush`와 `PathGeometry`로 변환했습니다:

```
20px × 20px 타일 내 4개의 삼각형 배치:
┌─────────────┐
│ ◤         ◥ │  ← 왼쪽 위, 오른쪽 위 삼각형
│             │
│ ◣         ◢ │  ← 왼쪽 아래, 오른쪽 아래 삼각형
└─────────────┘
```

## 프로젝트 구조

```
BrownCheetah84/
├── Readme.md
├── Wpf/
│   ├── BrownCheetah84.Wpf.slnx
│   ├── BrownCheetah84.Wpf.UI/
│   │   ├── Controls/
│   │   │   └── BrownCheetah84.cs
│   │   └── Themes/
│   │       ├── Generic.xaml
│   │       ├── BrownCheetah84.xaml
│   │       └── BrownCheetah84Resources.xaml
│   └── BrownCheetah84.Wpf.Gallery/
│       ├── App.xaml
│       └── MainWindow.xaml
└── AvaloniaUI/
    └── (미구현)
```

## 사용 방법

다른 WPF 프로젝트에서 이 컨트롤을 사용하려면:

1. `BrownCheetah84.Wpf.UI` 프로젝트 참조 추가
2. App.xaml에 리소스 딕셔너리 병합:

```xml
<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceDictionary Source="pack://application:,,,/BrownCheetah84.Wpf.UI;component/Themes/Generic.xaml" />
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

3. XAML에서 컨트롤 사용:

```xml
<controls:BrownCheetah84 xmlns:controls="clr-namespace:BrownCheetah84.Wpf.UI.Controls;assembly=BrownCheetah84.Wpf.UI" />
```
