# SwiftChicken44 변환 로그

## 변환 정보

- 변환 날짜: 2025-12-21
- 원본: HTML/CSS (uiverse.io)
- 대상: WPF CustomControl

## 컴파일 에러 및 수정 내용

### 에러 1: MC4111 - Trigger 대상 'PART_Shadow'을 찾을 수 없습니다

**에러 내용:**
```
SwiftChicken44.xaml(49,62): error MC4111: Trigger 대상 'PART_Shadow'을(를) 찾을 수 없습니다.
대상은 모든 Setters, Triggers 또는 대상을 사용하는 Conditions 앞에 표시되어야 합니다.
```

**원인:**
- ControlTemplate.Triggers에서 Border.Effect 내부에 정의된 DropShadowEffect (`x:Name="PART_Shadow"`)를 TargetName으로 참조할 수 없음
- WPF에서 Effect는 Property이지 Element가 아니므로 직접 참조 불가

**수정 방법:**
1. `SwiftChicken44Resources.xaml`에 각 상태별 DropShadowEffect를 리소스로 정의:
   - `SwiftChicken44.Shadow.Valid` (녹색 그림자)
   - `SwiftChicken44.Shadow.Invalid` (빨간색 그림자)
2. Trigger에서 Border의 Effect 속성에 해당 리소스를 직접 할당:
   ```xml
   <Setter TargetName="PART_Border" Property="Effect" Value="{StaticResource SwiftChicken44.Shadow.Valid}"/>
   ```

---

### 에러 2: MC3072 - 'Spacing' 속성이 없습니다

**에러 내용:**
```
MainWindow.xaml(11,77): error MC3072: XML 네임스페이스 'http://schemas.microsoft.com/winfx/2006/xaml/presentation'에 'Spacing' 속성이 없습니다.
```

**원인:**
- WPF의 StackPanel에는 `Spacing` 속성이 없음 (AvaloniaUI에서는 지원)
- WPF 제한사항으로 인한 문제

**수정 방법:**
- `Spacing="20"` 대신 각 자식 요소에 `Margin="0,0,0,20"` 적용

---

## 잠재적 Runtime 에러 가능성

### 1. DropShadowEffect 리소스 공유 문제

**가능성:** 낮음

**설명:**
- StaticResource로 DropShadowEffect를 참조할 경우, 여러 컨트롤이 동일한 Effect 인스턴스를 공유할 수 있음
- WPF에서 Effect는 Freezable이므로 일반적으로 공유가 가능하지만, 런타임에서 속성 변경 시 문제가 발생할 수 있음

**확인 필요:**
- 여러 SwiftChicken44 컨트롤을 동시에 사용할 때 그림자 효과가 정상 작동하는지 확인

### 2. IsValid 속성 바인딩 관련

**가능성:** 낮음

**설명:**
- `IsValid` 속성이 `bool?` (nullable)로 정의되어 있어 null, true, false 세 가지 상태 지원
- Trigger에서 `Value="True"` 및 `Value="False"`만 처리하므로 null 상태는 기본 스타일 유지

**확인 필요:**
- MVVM 바인딩 시 nullable bool 값이 정상적으로 전달되는지 확인

---

## 생성된 파일 목록

```
SwiftChicken44.Wpf.slnx
SwiftChicken44.Wpf.Gallery/
├── SwiftChicken44.Wpf.Gallery.csproj
├── App.xaml
├── App.xaml.cs
├── MainWindow.xaml
└── MainWindow.xaml.cs
SwiftChicken44.Wpf.UI/
├── SwiftChicken44.Wpf.UI.csproj
├── Controls/
│   └── SwiftChicken44.cs
├── Themes/
│   ├── Generic.xaml
│   ├── SwiftChicken44.xaml
│   └── SwiftChicken44Resources.xaml
└── Properties/
    └── AssemblyInfo.cs
```
