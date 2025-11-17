# StreamingText Control for WPF

실시간 타이핑 효과를 제공하는 WPF 커스텀 컨트롤입니다. Claude Desktop이나 ChatGPT와 같은 AI 챗봇에서 볼 수 있는 스트리밍 텍스트 UX를 구현합니다.

## 주요 기능

- ⚡ **실시간 타이핑 효과**: 텍스트가 한 글자씩 타이핑되는 듯한 자연스러운 애니메이션
- 🎨 **다양한 스타일**: 기본, ChatBot, Simple 스타일 제공
- ⚙️ **속도 조절**: `CharactersPerSecond` 속성으로 타이핑 속도 자유롭게 조절 (1~200)
- 🎯 **자동/수동 모드**: `AutoStart` 속성으로 자동 시작 여부 설정
- 🔄 **완벽한 제어**: 시작, 중지, 재시작, 건너뛰기 메서드 제공
- 📢 **이벤트 지원**: `StreamingCompleted`, `StreamingCancelled` 이벤트

## 프로젝트 구조

```
StreamingText/
├── StreamingTextLib/              # 컨트롤 라이브러리
│   ├── StreamingTextControl.cs   # 메인 컨트롤 클래스
│   └── Themes/
│       └── Generic.xaml           # 컨트롤 스타일 및 템플릿
└── StreamingTextGallery/          # 데모 애플리케이션
    ├── MainWindow.xaml            # 데모 페이지
    └── MainWindow.xaml.cs         # 이벤트 핸들러
```

## 빌드 및 실행

### 요구사항
- .NET 9.0 SDK
- Windows 운영체제
- Visual Studio 2022 (권장) 또는 Visual Studio Code

### 빌드 방법

```bash
# 라이브러리 빌드
cd StreamingTextLib
dotnet build

# 데모 애플리케이션 빌드 및 실행
cd ../StreamingTextGallery
dotnet build
dotnet run
```

또는 Visual Studio에서 `StreamingTextGallery.csproj`를 열고 F5를 눌러 실행하세요.

## 사용 방법

### 1. 기본 사용법

```xml
<Window xmlns:st="clr-namespace:StreamingTextLib;assembly=StreamingTextLib">
    <st:StreamingTextControl
        Text="안녕하세요! 실시간 타이핑 효과입니다."
        CharactersPerSecond="50"/>
</Window>
```

### 2. 속성 설정

```xml
<st:StreamingTextControl
    Text="표시할 전체 텍스트"
    CharactersPerSecond="50"        <!-- 초당 50글자 -->
    AutoStart="True"                 <!-- 자동 시작 -->
    FontSize="16"
    Foreground="Black"/>
```

### 3. 스타일 적용

```xml
<!-- ChatBot 스타일 (다크 테마) -->
<st:StreamingTextControl
    Style="{StaticResource ChatBotStyle}"
    Text="AI 챗봇 스타일 텍스트"/>

<!-- Simple 스타일 (미니멀) -->
<st:StreamingTextControl
    Style="{StaticResource SimpleStyle}"
    Text="심플한 스타일 텍스트"/>
```

### 4. 코드 비하인드에서 제어

```csharp
// 스트리밍 시작
await streamingTextControl.StartStreamingAsync();

// 스트리밍 중지
streamingTextControl.StopStreaming();

// 처음부터 다시 시작
await streamingTextControl.ResetAndRestartAsync();

// 건너뛰고 전체 텍스트 즉시 표시
streamingTextControl.SkipToEnd();

// 디스플레이 리셋
streamingTextControl.ResetDisplay();
```

### 5. 이벤트 처리

```csharp
streamingTextControl.StreamingCompleted += (s, e) =>
{
    Console.WriteLine("스트리밍 완료!");
};

streamingTextControl.StreamingCancelled += (s, e) =>
{
    Console.WriteLine("스트리밍 취소됨");
};
```

## 속성 (Properties)

| 속성 | 타입 | 기본값 | 설명 |
|------|------|--------|------|
| `Text` | string | "" | 표시할 전체 텍스트 |
| `DisplayedText` | string | "" | 현재 화면에 표시된 텍스트 (읽기 전용) |
| `CharactersPerSecond` | double | 50.0 | 초당 표시할 글자 수 (1~200) |
| `IsStreaming` | bool | false | 현재 스트리밍 중인지 여부 (읽기 전용) |
| `AutoStart` | bool | true | 자동으로 스트리밍 시작 여부 |

## 메서드 (Methods)

| 메서드 | 반환 타입 | 설명 |
|--------|-----------|------|
| `StartStreamingAsync()` | Task | 텍스트 스트리밍 시작 |
| `StopStreaming()` | void | 스트리밍 중지 |
| `ResetAndRestartAsync()` | Task | 초기화 후 재시작 |
| `ResetDisplay()` | void | 표시된 텍스트 초기화 |
| `SkipToEnd()` | void | 전체 텍스트 즉시 표시 |

## 이벤트 (Events)

| 이벤트 | 설명 |
|--------|------|
| `StreamingCompleted` | 스트리밍 완료 시 발생 |
| `StreamingCancelled` | 스트리밍 취소 시 발생 |

## 스타일

### 1. 기본 스타일 (Default)
- 깔끔하고 범용적인 디자인
- 스트리밍 중 커서(▊) 표시

### 2. ChatBot 스타일
- AI 챗봇에 최적화
- 다크 테마 (`#2D3748` 배경, `#F7FAFC` 텍스트)
- 모노스페이스 폰트 (Consolas)
- 둥근 모서리 및 그림자 효과

### 3. Simple 스타일
- 최소한의 디자인
- 투명 배경
- 스트리밍 중 파이프(|) 커서

## 사용 사례

### AI 챗봇 인터페이스
```xml
<st:StreamingTextControl
    Style="{StaticResource ChatBotStyle}"
    Text="{Binding AIResponse}"
    CharactersPerSecond="60"/>
```

### 알림 메시지
```xml
<st:StreamingTextControl
    Text="새로운 메시지가 도착했습니다."
    CharactersPerSecond="40"
    AutoStart="True"/>
```

### 튜토리얼/가이드
```xml
<st:StreamingTextControl
    Text="{Binding TutorialText}"
    CharactersPerSecond="30"
    AutoStart="False"/>
```

## 기술 스택

- .NET 9.0
- WPF (Windows Presentation Foundation)
- C# 12
- XAML

## 성능 고려사항

- 비동기 방식으로 구현되어 UI 스레드 블로킹 없음
- `CancellationToken`을 사용한 안전한 취소 처리
- `Dispatcher.InvokeAsync`로 UI 업데이트 최적화
- 메모리 효율적인 `string` 슬라이싱 (`text[.._currentCharIndex]`)

## 라이선스

이 프로젝트는 학습 및 연습 목적으로 만들어졌습니다.

## 기여

버그 리포트나 기능 제안은 이슈로 남겨주세요.

---

**Made with ❤️ using WPF**
