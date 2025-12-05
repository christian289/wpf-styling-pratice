# CLAUDE.md

이 파일은 Claude Code (claude.ai/code)가 이 저장소에서 작업할 때 참고하는 가이드입니다.

## 저장소 개요

모던 UI 디자인 패턴을 연습하는 WPF 스타일링 프로젝트 모음입니다. 각 하위 폴더는 독립적인 .NET 9.0 WPF 프로젝트이며 자체 솔루션(.slnx) 파일을 가지고 있습니다.

## 빌드 명령어

각 프로젝트는 독립적입니다. 해당 프로젝트 폴더로 이동 후 사용:

```bash
# 빌드
dotnet build <프로젝트명>.slnx

# 실행 (Gallery/데모 애플리케이션)
dotnet run --project <Gallery프로젝트폴더>
```

예시:
```bash
# Glassmorphism 갤러리 빌드 및 실행
cd Glassmorphism
dotnet build Glassmorphism.slnx
dotnet run --project GlassmorphismGallery

# Neumorphism 갤러리 빌드 및 실행
cd Neumorphism
dotnet build Neumorphism.slnx
dotnet run --project NeumorphismGallery
```

## 프로젝트 아키텍처

각 스타일링 프로젝트는 공통 구조를 따릅니다:

1. **라이브러리 프로젝트** (`*Lib`): 재사용 가능한 WPF 컨트롤 스타일 및 커스텀 컨트롤 포함
   - `Themes/Generic.xaml` - 모든 스타일이 정의된 메인 리소스 딕셔너리
   - 커스텀 컨트롤 클래스 (있는 경우)

2. **갤러리 프로젝트** (`*Gallery`): 컨트롤을 보여주는 데모 애플리케이션
   - 라이브러리 프로젝트 참조
   - `App.xaml` - 라이브러리의 리소스 딕셔너리 병합
   - `MainWindow.xaml` - 대화형 컨트롤 쇼케이스

### 저장소 내 프로젝트

| 프로젝트 | 설명 | 구조 |
|---------|------|------|
| **Glassmorphism** | 반투명 프로스티드 글래스 효과 | Lib + Gallery |
| **Neumorphism** | 듀얼 섀도우 시스템의 소프트 UI | Lib + Gallery |
| **MicroInteractions** | 2020년대 애니메이션 패턴 (리플, 슬라이드, 회전) | Lib + Gallery |
| **UIComponentsBySwetaShahWithBehance** | 모던 커스텀 컨트롤 (Button, TextBox, ToggleSwitch, Card, ProgressBar) | Library + Gallery |
| **StreamingText** | AI 챗봇 스타일 타이핑 효과 컨트롤 | Lib + Gallery |
| **AuroraBackground** | 오로라 그라데이션 배경 애니메이션 | 단일 앱 |
| **PhotoBoothCarousel** | 캐러셀 애니메이션이 있는 포토부스 UI | 단일 앱 |

## WPF 스타일링 규칙

- 컨트롤 스타일은 `Themes/Generic.xaml`에 암시적 스타일(x:Key 없음)로 정의
- 표준 WPF 컨트롤은 리소스 딕셔너리 병합 시 자동으로 스타일 적용
- 커스텀 컨트롤은 `DefaultStyleKeyProperty`를 사용하여 `Generic.xaml` 참조

### 라이브러리 스타일 병합

다른 프로젝트에서 라이브러리 스타일을 사용하려면:
```xml
<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceDictionary Source="pack://application:,,,/라이브러리명;component/Themes/Generic.xaml"/>
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

## 기술 스택

- .NET 9.0
- WPF (Windows Presentation Foundation)
- C# (nullable 활성화)
- XAML + Storyboard 애니메이션
