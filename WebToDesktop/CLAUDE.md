# CLAUDE.md

이 파일은 Claude Code (claude.ai/code)가 이 프로젝트에서 작업할 때 참고하는 가이드입니다.

## 프로젝트 개요

Web에서 디자인된 UI 컴포넌트를 WPF와 Avalonia 커스텀 컨트롤로 변환하는 프로젝트입니다.

## 폴더 구조

```
WebToDesktop/
└── {테마명}/
    ├── Wpf/
    │   ├── {테마명}.Wpf.slnx
    │   ├── {테마명}.Wpf.Lib/           # 커스텀 컨트롤 라이브러리
    │   │   ├── Controls/               # 커스텀 컨트롤 클래스
    │   │   └── Themes/
    │   │       ├── Generic.xaml        # ResourceDictionary 병합만
    │   │       └── {컨트롤명}.xaml     # 실제 스타일 정의
    │   └── {테마명}.Wpf.Gallery/       # 데모 앱
    └── Avalonia/
        ├── {테마명}.Avalonia.slnx
        ├── {테마명}.Avalonia.Lib/      # 커스텀 컨트롤 라이브러리
        │   ├── Controls/               # 커스텀 컨트롤 클래스
        │   └── Themes/
        │       ├── Generic.axaml       # ResourceDictionary 병합만
        │       └── {컨트롤명}.axaml    # 실제 스타일 정의
        └── {테마명}.Avalonia.Gallery/  # 데모 앱
```

## 빌드 명령어

```bash
# WPF 빌드 및 실행
cd {테마명}/Wpf
dotnet build {테마명}.Wpf.sln
dotnet run --project {테마명}.Wpf.Gallery

# Avalonia 빌드 및 실행
cd {테마명}/Avalonia
dotnet build {테마명}.Avalonia.sln
dotnet run --project {테마명}.Avalonia.Gallery
```

## sln to slnx 명령어 (.NET 9.0.2 이상이면 사용)

- slnx 파일 생성 성공 후 sln 파일은 제거

```bash
dotnet sln migrate
```

## 스타일 파일 분리 규칙

1. **Generic.xaml / Generic.axaml**: ResourceDictionary 병합만 담당
2. **{컨트롤명}.xaml / {컨트롤명}.axaml**: 개별 컨트롤의 실제 스타일 정의

### WPF 병합 예시

```xml
<!-- Generic.xaml -->
<ResourceDictionary.MergedDictionaries>
    <ResourceDictionary Source="/라이브러리명;component/Themes/컨트롤명.xaml"/>
</ResourceDictionary.MergedDictionaries>
```

### Avalonia 병합 예시

```xml
<!-- Generic.axaml -->
<ResourceDictionary.MergedDictionaries>
    <ResourceInclude Source="avares://라이브러리명/Themes/컨트롤명.axaml"/>
</ResourceDictionary.MergedDictionaries>
```

## CSS → XAML 변환 패턴

| CSS                   | WPF                       | Avalonia                  |
| --------------------- | ------------------------- | ------------------------- |
| `radial-gradient`     | `RadialGradientBrush`     | `RadialGradientBrush`     |
| `linear-gradient`     | `LinearGradientBrush`     | `LinearGradientBrush`     |
| `box-shadow`          | `DropShadowEffect`        | `BoxShadow`               |
| `border-radius`       | `CornerRadius`            | `CornerRadius`            |
| `::before`, `::after` | 추가 `Border`/`Rectangle` | 추가 `Border`/`Rectangle` |

## 기술 스택

- .NET 9.0
- WPF (net9.0-windows)
- Avalonia 11.x
