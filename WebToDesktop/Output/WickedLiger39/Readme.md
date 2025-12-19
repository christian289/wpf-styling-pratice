# WickedLiger39

Radio-buttons 스타일 컨트롤 - 성별 선택을 위한 애니메이션이 포함된 라디오 버튼 그룹

## 원본 정보

- **원작자:** ayman-ashine
- **원본 링크:** [https://uiverse.io/ayman-ashine/wicked-liger-39](https://uiverse.io/ayman-ashine/wicked-liger-39)
- **카테고리:** Radio-buttons
- **태그:** animation, form, radio, gender, multicolor

## 미리보기

4개의 성별 옵션(Male, Female, Non-binary, Unknown)을 제공하며, 각 옵션은 고유한 색상 테마와 아이콘을 가집니다. 선택 시 파동 효과와 함께 확대 애니메이션이 재생됩니다.

## 빌드 및 실행

### WPF
```bash
cd Wpf && dotnet run --project WickedLiger39.Wpf.Gallery
```

### AvaloniaUI
```bash
cd AvaloniaUI && dotnet run --project WickedLiger39.Avalonia.Gallery
```

## 컨트롤 구성

### GenderSelector
성별 선택 라디오 버튼 그룹을 담는 컨테이너 컨트롤

**속성:**
- `Header` (string): 상단에 표시되는 안내 텍스트

### GenderOption
개별 성별 옵션을 나타내는 라디오 버튼 컨트롤 (`RadioButton` 상속)

**속성:**
- `Icon` (Geometry): 아이콘 경로 데이터
- `IconBrush` (Brush): 아이콘 채우기 색상
- `IconStroke` (Brush): 아이콘 테두리 색상
- `RingBrush` (Brush): 선택 시 표시되는 링 색상
- `RippleBrush` (Brush): 파동 효과 색상
- `GroupName` (string, 상속): 라디오 버튼 그룹명

## 사용 예시

```xml
<controls:GenderSelector Header="PLEASE SELECT YOUR GENDER">
    <controls:GenderOption
        Background="{StaticResource GenderOption.Blue.Background}"
        RippleBrush="{StaticResource GenderOption.Blue.RippleBackground}"
        RingBrush="{StaticResource GenderOption.Blue.Ring}"
        IconStroke="{StaticResource GenderOption.Blue.Icon}"
        Icon="{StaticResource GenderOption.Icon.Male}"
        GroupName="Gender"
        ToolTip="Male"/>
</controls:GenderSelector>
```

## CSS to WPF 변환 매핑

| CSS (Tailwind) | WPF |
|----------------|-----|
| `rounded-full` | `CornerRadius="25"` |
| `shadow-sm shadow-[#00000050]` | `DropShadowEffect` |
| `ring-2 ring-{color}-400` | `BorderThickness="2"` + `BorderBrush` |
| `scale-110` | `ScaleTransform ScaleX/Y="1.1"` |
| `scale-[500%]` | `ScaleTransform ScaleX/Y="5"` |
| `duration-300` | `Duration="0:0:0.3"` |
| `duration-500` | `Duration="0:0:0.5"` |
| `peer-checked:` | `Trigger Property="IsChecked"` |
| `bg-{color}-100/200` | `SolidColorBrush` 리소스 |
| `stroke-{color}-400` | `Path.Stroke` |
| `fill-{color}-400` | `Path.Fill` |
| `-z-10` | 요소 순서 (먼저 선언된 요소가 뒤에 위치) |

## 색상 테마

| 테마 | Background | Ripple | Ring/Icon |
|------|------------|--------|-----------|
| Blue (Male) | `#DBEAFE` | `#BFDBFE` | `#60A5FA` |
| Pink (Female) | `#FCE7F3` | `#FBCFE8` | `#F472B6` |
| Purple (Non-binary) | `#F3E8FF` | `#E9D5FF` | `#A855F7` |
| Neutral (Unknown) | `#F5F5F5` | `#E5E5E5` | `#A3A3A3` |

## 프로젝트 구조

```
WickedLiger39/
├── Wpf/
│   ├── WickedLiger39.Wpf.slnx
│   ├── WickedLiger39.Wpf.UI/
│   │   ├── Controls/
│   │   │   ├── GenderOption.cs
│   │   │   └── GenderSelector.cs
│   │   └── Themes/
│   │       ├── Generic.xaml
│   │       ├── GenderSelector.xaml
│   │       └── GenderSelectorResources.xaml
│   └── WickedLiger39.Wpf.Gallery/
│       ├── App.xaml
│       └── MainWindow.xaml
└── AvaloniaUI/
    └── (구현 예정)
```
