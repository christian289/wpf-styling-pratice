# CLAUDE.md

이 파일은 Claude Code (claude.ai/code)가 이 프로젝트에서 작업할 때 참고하는 가이드입니다.

## 프로젝트 개요

무인사진관용 WPF UI로, 캐러셀 효과와 터치 인터페이스를 갖춘 애니메이션 UI입니다.

## 빌드 및 실행

```bash
cd PhotoBoothCarousel/PhotoBoothCarousel
dotnet build
dotnet run
```

## 프로젝트 구조 (단일 앱)

```
PhotoBoothCarousel/
└── PhotoBoothCarousel/
    ├── App.xaml / App.xaml.cs
    ├── MainWindow.xaml / MainWindow.xaml.cs           # 기본 캐러셀
    └── TouchEnhancedWindow.xaml / TouchEnhancedWindow.xaml.cs  # 터치 강화
```

## 두 가지 버전

### MainWindow (기본 버전)
- 자동 캐러셀 애니메이션
- 3장 카드 4초마다 자동 회전
- 마우스/터치 기본 지원

### TouchEnhancedWindow (터치 강화 버전)
- 스와이프 제스처 지원
- 드래그 피드백
- 파티클 효과
- 페이지 인디케이터

`App.xaml`에서 `StartupUri`를 변경하여 버전 선택:
```xml
StartupUri="TouchEnhancedWindow.xaml"
```

## 핵심 애니메이션

### 캐러셀 회전
```csharp
_currentIndex = (_currentIndex + 1) % _cards.Count;
// 중앙: 확대 + 포커스
// 좌/우: 축소 + 회전 + 투명도 감소
```

### 터치 제스처
- `ManipulationDelta`: 드래그 오프셋 적용
- `ManipulationCompleted`: 스와이프 거리 임계값 판단 후 카드 전환

## 이징 함수

- CubicEase: 캐러셀 전환
- SineEase: 파동 효과
- ElasticEase: 탄성 진입
- BackEase: 튀는 효과

## 컬러 팔레트

- 배경: `#101010`
- 강조1: `#FF6B9E` (핑크)
- 강조2: `#6B8EFF` (블루)
- 강조3: `#FFD76B` (옐로우)
