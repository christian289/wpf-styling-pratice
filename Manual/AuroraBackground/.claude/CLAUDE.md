# CLAUDE.md

이 파일은 Claude Code (claude.ai/code)가 이 프로젝트에서 작업할 때 참고하는 가이드입니다.

## 프로젝트 개요

순수 WPF로 구현한 오로라 스타일의 무한 반복 배경 애니메이션입니다. 여러 개의 구체가 궤도를 따라 회전하며 몽환적인 분위기를 연출합니다.

## 빌드 및 실행

```bash
cd AuroraBackground
dotnet build AuroraBackground.slnx
dotnet run --project AuroraBackground
```

## 프로젝트 구조 (단일 앱)

```
AuroraBackground/
└── AuroraBackground/
    ├── App.xaml / App.xaml.cs
    ├── MainWindow.xaml / MainWindow.xaml.cs
    ├── NavigationWindow.xaml / NavigationWindow.xaml.cs
    ├── HomePage.xaml / HomePage.xaml.cs
    ├── OriginalAuroraPage.xaml
    ├── VibrantAuroraPage.xaml
    ├── DeepAuroraPage.xaml
    ├── FullScreenAuroraPage.xaml
    └── OrbitingAuroraPage.xaml
```

## 핵심 애니메이션 기법

### 궤도 회전 (CSS 오로라 효과 WPF 변환)

```xaml
<TransformGroup>
    <RotateTransform Angle="0"/>       <!-- 궤도 회전 -->
    <TranslateTransform X="150" Y="0"/> <!-- 중심에서 거리 -->
</TransformGroup>
```

### 블러 효과

각 구체에 80-100px `BlurEffect`를 적용하여 부드러운 빛 번짐 구현

### 애니메이션 타이밍

6개 구체가 12초~22초의 다양한 속도로 정방향/역방향 회전하여 반복되지 않는 패턴 생성

## 컬러 팔레트

- Aurora 1: `#373372` (Deep Purple)
- Aurora 2: `#F0ACE0` (Light Pink)
- Aurora 3: `#9333EA` (Violet)
- Aurora 4: `#EC4899` (Hot Pink)
- Aurora 5: `#06B6D4` (Cyan)
- Aurora 6: `#B3588A` (Mauve)

## 단축키

- **ESC**: 애플리케이션 종료
