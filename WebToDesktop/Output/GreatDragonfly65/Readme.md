# GreatDragonfly65

Buttons 스타일 컨트롤

## 원본 정보

- **원작자:** SmookyDev
- **원본 링크:** [https://uiverse.io/SmookyDev/great-dragonfly-65](https://uiverse.io/SmookyDev/great-dragonfly-65) (클릭 시 원본 CSS/HTML 확인 가능)

## 설명

rose-900에서 pink-700으로 그라데이션이 적용된 버튼입니다.
hover 시 `::before`와 `::after` pseudo-element가 회전하며 텍스트가 변경되는 효과가 있습니다.

### 주요 특징

- 그라데이션 배경 (rose-900 → pink-700)
- hover 시 1.05배 scale 효과
- clip-path를 활용한 불규칙한 모양의 pseudo-element
- hover 시 회전, 기울임, 텍스트 변경 애니메이션

## 빌드 명령

### WPF

```bash
cd Wpf && dotnet run --project GreatDragonfly65.Wpf.Gallery
```

### AvaloniaUI

```bash
cd AvaloniaUI && dotnet run --project GreatDragonfly65.Avalonia.Gallery
```

## CSS → WPF 변환 매핑 테이블

| CSS (Tailwind)                          | WPF 구현                                        |
| --------------------------------------- | ----------------------------------------------- |
| `bg-gradient-to-r from-rose-900 to-pink-700` | `LinearGradientBrush StartPoint="0,0.5" EndPoint="1,0.5"` |
| `hover:scale-105`                       | `ScaleTransform` + `DoubleAnimation`            |
| `duration-700`                          | `Duration="0:0:0.7"`                            |
| `rounded-e` (right corners)             | `CornerRadius="0,4,4,0"`                        |
| `::before`, `::after`                   | 추가 `Border` 요소                              |
| `clip-path: polygon(...)`               | `Border.Clip` + `PathGeometry`                  |
| `rotate-[100deg]`                       | `RotateTransform Angle="100"`                   |
| `skew-y-6`                              | `SkewTransform AngleY="6"`                      |
| `origin-bottom-right`                   | `RenderTransformOrigin="1,1"`                   |
| `origin-bottom-left`                    | `RenderTransformOrigin="0,1"`                   |
| `content-['...']`                       | `TextBlock.Text` + DependencyProperty           |
| `hover:content-['...']`                 | `Trigger.Setter` for Text change                |

## 프로젝트 구조

```
GreatDragonfly65/
├── Readme.md
├── Wpf/
│   ├── GreatDragonfly65.Wpf.slnx
│   ├── GreatDragonfly65.Wpf.Gallery/    # 데모 앱
│   └── GreatDragonfly65.Wpf.UI/         # 커스텀 컨트롤 라이브러리
│       ├── Controls/
│       │   └── GreatDragonfly65.cs
│       └── Themes/
│           ├── Generic.xaml
│           ├── GreatDragonfly65.xaml
│           └── GreatDragonfly65Resources.xaml
└── AvaloniaUI/                          # (미구현)
```

## 사용 예제

```xml
<controls:GreatDragonfly65 Content="Hover Me"/>

<!-- 커스텀 텍스트 -->
<controls:GreatDragonfly65 Content="Click Me"
                           BeforeText="CLICK"
                           BeforeHoverText="HELLO"
                           AfterText="CLICK"
                           AfterHoverText="WORLD"/>
```

## DependencyProperty

| 속성             | 타입   | 기본값        | 설명                                   |
| ---------------- | ------ | ------------- | -------------------------------------- |
| `BeforeText`     | string | "Hover ME"    | before pseudo-element 기본 텍스트      |
| `BeforeHoverText`| string | "SMOOKY"      | before pseudo-element hover 텍스트     |
| `AfterText`      | string | "Hover ME"    | after pseudo-element 기본 텍스트       |
| `AfterHoverText` | string | "SMOOKY DEV"  | after pseudo-element hover 텍스트      |
