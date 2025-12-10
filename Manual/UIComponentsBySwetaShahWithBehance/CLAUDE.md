# CLAUDE.md

이 파일은 Claude Code (claude.ai/code)가 이 프로젝트에서 작업할 때 참고하는 가이드입니다.

## 프로젝트 개요

Behance의 Sweta Shah 디자인을 참고한 모던 WPF 커스텀 컨트롤 라이브러리입니다. 암시적 스타일이 아닌 **커스텀 컨트롤 클래스**를 사용합니다.

## 빌드 및 실행

```bash
# 솔루션 빌드
dotnet build UIComponentsBySwetaShahWithBehance.slnx

# 갤러리 실행
dotnet run --project UIComponentsBySwetaShahWithBehanceGallery
```

## 프로젝트 구조

```
UIComponentsBySwetaShahWithBehance/
├── UIComponentsBySwetaShahWithBehanceLibrary/
│   ├── UIComponentsBySwetaShahWithBehanceButton.cs
│   ├── UIComponentsBySwetaShahWithBehanceTextBox.cs
│   ├── UIComponentsBySwetaShahWithBehanceToggleSwitch.cs
│   ├── UIComponentsBySwetaShahWithBehanceCard.cs
│   ├── UIComponentsBySwetaShahWithBehanceProgressBar.cs
│   ├── Converters/ValueConverters.cs
│   └── Themes/Generic.xaml
└── UIComponentsBySwetaShahWithBehanceGallery/
```

## 커스텀 컨트롤

### UIComponentsBySwetaShahWithBehanceButton
- 속성: `ButtonStyle` (Primary/Success/Warning/Danger/Outline), `CornerRadius`, `Icon`

### UIComponentsBySwetaShahWithBehanceTextBox
- 속성: `Placeholder`, `Icon`, `CornerRadius`

### UIComponentsBySwetaShahWithBehanceToggleSwitch
- 속성: `OnText`, `OffText`

### UIComponentsBySwetaShahWithBehanceCard
- 속성: `Header`, `CornerRadius`, `Elevation`, `IsHoverable`

### UIComponentsBySwetaShahWithBehanceProgressBar
- 속성: `CornerRadius`, `ProgressColor`, `ShowPercentage`

## 네임스페이스

```xml
xmlns:ui="clr-namespace:UIComponentsBySwetaShahWithBehanceLibrary;assembly=UIComponentsBySwetaShahWithBehanceLibrary"
```

## 핵심 컬러

- Primary: `#6C5CE7`
- Accent: `#00CEC9`
- Success: `#00B894`
- Warning: `#FDCB6E`
- Danger: `#FF7675`
