# 🌌 Aurora Background - WPF

순수 WPF로 구현한 오로라 스타일의 무한 반복 배경 애니메이션입니다.

## ✨ 주요 특징

### 🎨 오로라 효과
- **6개의 궤도 회전 구체**: 각각 다른 속도와 방향으로 회전
- **방사형 그라데이션**: 중앙에서 투명으로 부드럽게 전환
- **강력한 블러 효과**: 80-100px 블러로 몽환적인 분위기
- **색상 블렌딩**: 겹쳐진 레이어들의 자연스러운 색상 혼합

### 🌊 애니메이션
- **무한 반복**: `RepeatBehavior.Forever`로 영구 실행
- **다양한 속도**: 12초~22초 범위의 다양한 회전 주기
- **양방향 회전**: 시계 방향과 반시계 방향 혼합
- **펄스 효과**: 배경 레이어의 부드러운 투명도 변화

### 🎨 색상 팔레트

```
Aurora 1: #373372 (Deep Purple)
Aurora 2: #F0ACE0 (Light Pink)
Aurora 3: #9333EA (Violet)
Aurora 4: #EC4899 (Hot Pink)
Aurora 5: #06B6D4 (Cyan)
Aurora 6: #B3588A (Mauve)
```

## 🚀 실행 방법

### 요구사항
- **.NET 9 SDK** 이상
- **Windows 10/11**
- **Visual Studio 2022** 또는 **Visual Studio Code** (선택사항)

### 빌드 및 실행

```bash
# 1. AuroraBackground 폴더로 이동
cd AuroraBackground

# 2. 프로젝트 복원
dotnet restore

# 3. 빌드
dotnet build

# 4. 실행
dotnet run
```

### Visual Studio에서 실행
1. `AuroraBackground.csproj` 파일을 더블클릭
2. F5 키로 디버깅 시작
3. ESC 키로 종료

## 🔧 구현 세부사항

### 궤도 회전 애니메이션

WPF의 `TransformGroup`을 사용하여 CSS의 오로라 효과를 재현:

```xaml
<TransformGroup>
    <RotateTransform Angle="0"/>      <!-- 궤도 회전 -->
    <TranslateTransform X="150" Y="0"/> <!-- 중심에서 거리 -->
</TransformGroup>
```

- **RotateTransform**: 0°에서 360°로 회전 (또는 역방향)
- **TranslateTransform**: 중심으로부터의 오프셋 설정
- 두 변환의 조합으로 원형 궤도 생성

### 블러 효과

```xaml
<Ellipse.Effect>
    <BlurEffect Radius="80"/>
</Ellipse.Effect>
```

각 구체에 80-100px의 강력한 블러를 적용하여 부드러운 빛 번짐 효과 구현

### 방사형 그라데이션

```xaml
<RadialGradientBrush GradientOrigin="0.5,0.5" Center="0.5,0.5">
    <GradientStop Color="#CC373372" Offset="0"/>    <!-- 중앙: 80% 불투명 -->
    <GradientStop Color="#66373372" Offset="0.5"/>  <!-- 중간: 40% 불투명 -->
    <GradientStop Color="#00373372" Offset="1"/>    <!-- 외곽: 완전 투명 -->
</RadialGradientBrush>
```

## 📊 애니메이션 타이밍

| 구체 | 지속시간 | 방향 | 오프셋 |
|------|----------|------|--------|
| Orb 1 | 12초 | 정방향 | (150, 0) |
| Orb 2 | 15초 | 역방향 | (-120, 80) |
| Orb 3 | 18초 | 정방향 | (0, -130) |
| Orb 4 | 20초 | 역방향 | (100, 100) |
| Orb 5 | 14초 | 정방향 | (-100, -100) |
| Orb 6 | 22초 | 역방향 | (130, -80) |

서로 다른 타이밍으로 인해 패턴이 반복되지 않는 독특한 애니메이션 생성

## 🎯 성능 최적화

### WPF 하드웨어 가속
- WPF는 자동으로 GPU 가속 활용
- `BlurEffect`는 하드웨어 가속 지원
- 부드러운 60 FPS 유지

### 레이어 구조
1. **Base Layer**: 정적 그라데이션 배경
2. **Static Pulsating Layer**: 2개의 펄스 구체
3. **Orbital Layer**: 6개의 회전 구체
4. **Content Layer**: UI 콘텐츠 (반투명 글래스모피즘)

## 🎨 커스터마이징

### 색상 변경

`App.xaml`의 색상 리소스를 수정:

```xaml
<Color x:Key="Aurora1">#YOUR_COLOR</Color>
```

### 애니메이션 속도 조정

`MainWindow.xaml`의 Storyboard Duration 수정:

```xaml
<LinearDoubleKeyFrame KeyTime="0:0:12" Value="360"/>
<!-- KeyTime을 원하는 초로 변경 -->
```

### 블러 강도 조정

각 Ellipse의 BlurEffect Radius 변경:

```xaml
<BlurEffect Radius="80"/> <!-- 원하는 값으로 변경 (20-150 권장) -->
```

### 구체 개수 추가

1. `App.xaml`에 새로운 `AuroraGradient` 추가
2. `MainWindow.xaml`에 새로운 `Ellipse` 추가
3. 새로운 `Storyboard` 생성 및 시작

## 🌟 무인사진관 활용

이 오로라 배경은 무인사진관의 대기 화면으로 완벽합니다:

- ✅ **무한 반복**: 고객 대기 시간 동안 계속 재생
- ✅ **화려한 시각 효과**: 주목도 높은 디스플레이
- ✅ **부드러운 애니메이션**: 눈의 피로 최소화
- ✅ **현대적인 디자인**: 젊은 고객층 선호
- ✅ **성능 최적화**: 장시간 실행 가능

### 포토부스 UI와 통합

`PhotoBoothCarousel` 프로젝트와 결합하여 사용 가능:

1. AuroraBackground를 전체 배경으로 사용
2. PhotoBoothCarousel의 카드를 상단에 오버레이
3. 통합된 화려한 대기 화면 완성

## 🛠️ 기술 스택

- **.NET 9.0**
- **WPF (Windows Presentation Foundation)**
- **XAML**
- **C# 13**
- **Storyboard Animations**
- **RadialGradientBrush**
- **BlurEffect (Hardware Accelerated)**
- **TransformGroup (Rotate + Translate)**

## 📚 참고 자료

- CSS Aurora UI 원본: [Aurora UI - How to create with CSS](https://dev.to/albertwalicki/aurora-ui-how-to-create-with-css-4b6g)
- WPF Animation: [Microsoft Docs](https://docs.microsoft.com/en-us/dotnet/desktop/wpf/graphics-multimedia/animation-overview)

## 🎬 동작 원리

### CSS vs WPF 변환

**CSS (원본)**
```css
animation: rotate 12s linear infinite;

@keyframes rotate {
  to {
    transform: rotate(1turn) translate(100px) rotate(-1turn);
  }
}
```

**WPF (구현)**
```xaml
<Storyboard RepeatBehavior="Forever">
    <DoubleAnimation
        Storyboard.TargetProperty="(RotateTransform.Angle)"
        From="0" To="360" Duration="0:0:12"/>
</Storyboard>

<TransformGroup>
    <RotateTransform/>
    <TranslateTransform X="100"/>
</TransformGroup>
```

## ⌨️ 단축키

- **ESC**: 애플리케이션 종료

## 📄 라이선스

이 프로젝트는 학습 및 연습 목적으로 제작되었습니다.

---

**Made with 🌌 using WPF and .NET 9**
