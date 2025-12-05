# ThemeSwitch

Day/Night 테마 전환을 위한 토글 스위치 컨트롤입니다.

![Day Mode](https://img.shields.io/badge/Mode-Day-3D7EAE) ![Night Mode](https://img.shields.io/badge/Mode-Night-1D1F2C)

## 원본

이 컨트롤은 [uiverse.io](https://uiverse.io)의 CSS 컴포넌트를 WPF와 Avalonia로 변환한 것입니다.

**원본 UI**: [https://uiverse.io/Galahhad/strong-squid-82](https://uiverse.io/Galahhad/strong-squid-82)

**원작자**: Galahhad

## 구현

이 프로젝트는 **Claude Code (Opus 4.5)** 를 사용하여 구현되었습니다.

### 지원 플랫폼

| 플랫폼 | 프레임워크 | 상태 |
|--------|-----------|------|
| WPF | .NET 9.0 | ✅ 완료 |
| Avalonia | .NET 9.0 | ✅ 완료 |

## 빌드 및 실행

```bash
# WPF
cd Wpf && dotnet run --project ThemeSwitch.Wpf.Gallery

# Avalonia
cd Avalonia && dotnet run --project ThemeSwitch.Avalonia.Gallery
```

## 기능

- 낮/밤 테마 전환 애니메이션
- 해와 달 전환 효과
- 구름 애니메이션
- 별 페이드 인/아웃
- 글로우 링 효과
- 마우스 호버 인터랙션 (WPF)

## 라이선스

원본 UI 컴포넌트의 라이선스를 따릅니다.
