# LovelyDragon72

호버 시 부드러운 애니메이션 효과가 있는 프로필 카드 컨트롤

## 원본 정보
- **출처**: [uiverse.io](https://uiverse.io)
- **원작자**: gagan-gv
- **태그**: card, hover, smooth, about me

## 빌드 및 실행

```bash
cd Wpf && dotnet run --project LovelyDragon72.Wpf.Gallery
```

## 컨트롤 사용법

```xml
<controls:LovelyDragon72 FirstName="John"
                         LastName="Doe"
                         ImageSource="{StaticResource ProfileImage}"/>
```

### 속성

| 속성 | 타입 | 기본값 | 설명 |
|------|------|--------|------|
| `FirstName` | string | "John" | 이름 첫 번째 줄 |
| `LastName` | string | "Doe" | 이름 두 번째 줄 |
| `ImageSource` | object | null | 프로필 이미지 |

## CSS → WPF 변환 매핑

| CSS | WPF |
|-----|-----|
| `width: 190px` | `Width="190"` |
| `height: 254px` | `Height="254"` |
| `background: #f0f0f0` | `SolidColorBrush` |
| `border-radius: 10px` | `CornerRadius="10"` |
| `transition: all 0.5s` | `Storyboard` + `Duration="0:0:0.5"` |
| `:hover` | `IsMouseOver` Trigger |
| `box-shadow` | `DropShadowEffect` |
| `opacity: 0/1` | `Opacity` 속성 애니메이션 |
| SVG `<path>` | `<Path Data="...">` |

## 프로젝트 구조

```
Wpf/
├── LovelyDragon72.Wpf.slnx
├── LovelyDragon72.Wpf.Gallery/    # 데모 앱
│   ├── App.xaml
│   └── MainWindow.xaml
└── LovelyDragon72.Wpf.UI/         # 컨트롤 라이브러리
    ├── Controls/
    │   └── LovelyDragon72.cs
    └── Themes/
        ├── Generic.xaml
        ├── LovelyDragon72.xaml
        └── LovelyDragon72Resources.xaml
```

## 미리보기

호버 효과:
1. 배경색이 회색에서 파란색으로 변경
2. 상단 blob 장식이 축소
3. 프로필 이미지 영역이 확장
4. 이름이 사라지고 소셜 아이콘이 표시
5. 그림자 효과 추가
