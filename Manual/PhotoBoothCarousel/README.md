# 🎨 WPF 애니메이션 캐러셀 UI - 무인사진관

애니메이션과 캐러셀 효과를 갖춘 무인사진관용 WPF UI입니다.

## ✨ 주요 기능

### 🎬 풍부한 애니메이션

- **무한 반복 배경 애니메이션**: 대기 화면에서 계속 재생되는 부드러운 Floating 애니메이션
- **캐러셀 효과**: 3개의 카드가 자동으로 회전하며 포커스되는 효과
- **파티클 애니메이션**: 떠다니는 파티클로 생동감 있는 배경 연출
- **Glow & Shimmer**: 빛나는 효과와 반짝임으로 현대적인 느낌 구현

### 🖐️ 터치 인터페이스

- **스와이프 제스처**: 좌우 스와이프로 카드 네비게이션
- **드래그 피드백**: 실시간 드래그 반응
- **터치 최적화**: 큰 버튼과 명확한 인터랙션 영역

### 🎨 현대적인 디자인

- **다크 테마**: MOODIT 스타일의 다크 모던 UI (#101010 기반)
- **그라데이션**: 화려한 색상 조합 (Pink, Blue, Yellow)
- **블러 효과**: 부드러운 그림자와 블러로 깊이감 표현
- **글래스모피즘**: 반투명 효과로 세련된 느낌

## 📦 프로젝트 구조

```
PhotoBoothCarousel/
├── App.xaml                      # 애플리케이션 리소스 및 테마
├── App.xaml.cs                   # 애플리케이션 진입점
├── MainWindow.xaml               # 기본 캐러셀 UI
├── MainWindow.xaml.cs            # 기본 캐러셀 로직
├── TouchEnhancedWindow.xaml      # 터치 강화 버전 UI
├── TouchEnhancedWindow.xaml.cs   # 터치 강화 버전 로직
└── PhotoBoothCarousel.csproj     # 프로젝트 파일
```

## 🚀 실행 방법

### 요구사항

- **.NET 9 SDK** 이상
- **Windows 10/11** (WPF는 Windows 전용)
- **Visual Studio 2022** 또는 **Visual Studio Code** (선택사항)

### 빌드 및 실행

```bash
# 1. 프로젝트 복원
dotnet restore

# 2. 빌드
dotnet build

# 3. 실행 (기본 버전)
dotnet run
```

### 두 가지 버전

#### 📱 **기본 버전** (MainWindow)

- 자동 캐러셀 애니메이션
- 3장의 카드가 4초마다 자동 회전
- 마우스/터치 기본 지원

**실행 방법**: `App.xaml`에서 기본 설정된 버전입니다.

#### 🎯 **터치 강화 버전** (TouchEnhancedWindow)

- 스와이프 제스처 지원
- 드래그 앤 드롭으로 카드 이동
- 더 많은 파티클 및 애니메이션 효과
- 페이지 인디케이터
- 가격 정보 표시

**실행 방법**: `App.xaml` 파일을 수정하세요.

```xml
<!-- App.xaml에서 StartupUri 변경 -->
<Application x:Class="PhotoBoothCarousel.App"
             ...
             StartupUri="TouchEnhancedWindow.xaml">
```

## 🎨 디자인 특징

### 색상 팔레트

```
배경: #101010 (다크 블랙)
강조1: #FF6B9E (핑크)
강조2: #6B8EFF (블루)
강조3: #FFD76B (옐로우)
텍스트: #FFFFFF (화이트)
```

### 애니메이션 이징

- **CubicEase**: 부드러운 캐러셀 전환
- **SineEase**: 자연스러운 파동 효과
- **ElasticEase**: 탄성있는 진입 애니메이션
- **BackEase**: 살짝 튀는 듯한 효과

### 카드 레이아웃

- **클래식 컷**: 4장의 사진 촬영 (₩8,000)
- **비디오 부스**: 15초 동영상 촬영 (₩10,000)
- **프리미엄 패키지**: 사진 + 영상 + 프레임 (₩15,000)

## 🔧 커스터마이징

### 색상 변경

`App.xaml`의 리소스 딕셔너리에서 색상을 변경할 수 있습니다:

```xml
<Color x:Key="AccentColor">#YOUR_COLOR</Color>
```

### 애니메이션 속도 조정

각 Window의 코드비하인드에서 타이머 간격을 조정:

```csharp
// MainWindow.xaml.cs
_carouselTimer.Interval = TimeSpan.FromSeconds(4); // 원하는 초로 변경
```

### 카드 개수 변경

XAML에 카드를 추가하고, 코드비하인드에서 `_cards` 리스트에 등록하면 됩니다.

## 📝 주요 코드 설명

### 캐러셀 회전 로직

```csharp
private void AnimateCarouselRotation()
{
    // 현재 인덱스 증가
    _currentIndex = (_currentIndex + 1) % _cards.Count;

    // 각 카드의 위치에 따라 스케일, 회전, 투명도 애니메이션 적용
    // 중앙 카드: 확대 + 포커스
    // 좌/우 카드: 축소 + 회전 + 투명도 감소
}
```

### 터치 제스처 처리

```csharp
private void Grid_ManipulationDelta(object sender, ManipulationDeltaEventArgs e)
{
    // 드래그 오프셋 적용
    double deltaX = e.DeltaManipulation.Translation.X;
    ApplyDragOffset(deltaX);
}

private void Grid_ManipulationCompleted(object sender, ManipulationCompletedEventArgs e)
{
    // 스와이프 거리가 임계값을 넘으면 카드 전환
    if (Math.Abs(totalDeltaX) > SwipeThreshold)
    {
        NavigateToCard(nextIndex);
    }
}
```

## 🎯 무인사진관 최적화

### 터치스크린 환경

- 큰 터치 영역 (버튼 최소 80x40px)
- 명확한 시각적 피드백
- 직관적인 제스처 (좌우 스와이프)

### 대기 화면 애니메이션

- **무한 반복**: 모든 배경 애니메이션은 RepeatBehavior.Forever
- **부드러운 전환**: Easing 함수로 자연스러운 움직임
- **저사양 최적화**: 하드웨어 가속 활용 (WPF의 자동 최적화)

### 실제 배포 시 고려사항

1. **전체화면 모드**: `WindowState="Maximized"` 및 `WindowStyle="None"`
2. **화면 해상도**: 기본 1920x1080, 필요시 Viewbox로 자동 조정
3. **터치 스크린 캘리브레이션**: Windows 터치 설정 확인
4. **자동 시작**: Windows 시작 프로그램에 등록

## 🛠️ 기술 스택

- **.NET 9.0**
- **WPF (Windows Presentation Foundation)**
- **XAML**
- **C# 13**
- **Storyboard Animations**
- **Touch/Manipulation API**

## 📱 스크린샷 설명

### 기본 버전 (MainWindow)

- 3개의 카드가 자동으로 회전
- 중앙 카드 확대 및 포커스 효과
- 부드러운 배경 애니메이션

### 터치 강화 버전 (TouchEnhancedWindow)

- 스와이프로 카드 전환
- 파티클 효과
- 페이지 인디케이터
- 가격 정보 표시

## 🚀 향후 개발 계획

- [ ] 실제 카메라 통합
- [ ] 결제 시스템 연동
- [ ] 사진 편집 기능
- [ ] QR 코드 다운로드
- [ ] 프린터 연동
- [ ] 관리자 대시보드
- [ ] 통계 및 분석

## 📄 라이선스

이 프로젝트는 학습 및 연습 목적으로 제작되었습니다.

## 🙏 참고

디자인 영감: -

---

**Made with ❤️ using WPF and .NET 9**
