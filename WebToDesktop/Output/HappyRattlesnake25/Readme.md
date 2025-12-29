# HappyRattlesnake25

Patterns 스타일 컨트롤 - 기하학적 패턴 배경

## 원본 정보

- **원작자**: csemszepp (Afif13)
- **원본 링크**: [https://uiverse.io/csemszepp/happy-rattlesnake-25](https://uiverse.io/csemszepp/happy-rattlesnake-25)
- **태그**: simple, material design, pattern

## 빌드 및 실행

### WPF

```bash
cd Wpf && dotnet run --project HappyRattlesnake25.Wpf.Gallery
```

### AvaloniaUI

```bash
cd AvaloniaUI && dotnet run --project HappyRattlesnake25.Avalonia.Gallery
```

## CSS → WPF 변환 매핑 테이블

| CSS | WPF | 설명 |
|-----|-----|------|
| `conic-gradient` | `DrawingBrush` + `GeometryDrawing` | WPF에서 conic-gradient 미지원, 기하학적 도형으로 근사 |
| `--s: 65px` | `TileSize` DependencyProperty | 패턴 타일 크기 |
| `--c1: #dadee1` | `Color1` / `HappyRattlesnake25.Brush1` | 밝은 회색 (배경색) |
| `--c2: #4a99b4` | `Color2` / `HappyRattlesnake25.Brush2` | 청록색 (주요 강조색) |
| `--c3: #9cceb5` | `Color3` / `HappyRattlesnake25.Brush3` | 연한 녹색 (보조 강조색) |
| `background-size: calc(2 * var(--s)) var(--s)` | `Viewport="0,0,130,65"` | 타일 크기 (2*65 x 65) |
| `width: 100%; height: 100%` | Control이 부모 크기를 채움 | 기본 동작 |

## 사용 예시

```xml
<Window xmlns:controls="clr-namespace:HappyRattlesnake25.Wpf.UI.Controls;assembly=HappyRattlesnake25.Wpf.UI">
    <Grid>
        <controls:HappyRattlesnake25 />
    </Grid>
</Window>
```

## 프로젝트 구조

```
HappyRattlesnake25/
├── Wpf/
│   ├── HappyRattlesnake25.Wpf.slnx
│   ├── HappyRattlesnake25.Wpf.Gallery/     # 데모 앱
│   └── HappyRattlesnake25.Wpf.UI/          # 커스텀 컨트롤 라이브러리
│       ├── Controls/
│       │   └── HappyRattlesnake25.cs
│       └── Themes/
│           ├── Generic.xaml
│           ├── HappyRattlesnake25.xaml
│           └── HappyRattlesnake25Resources.xaml
└── AvaloniaUI/                              # (미구현)
```
