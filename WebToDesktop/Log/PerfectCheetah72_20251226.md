# PerfectCheetah72 변환 로그

## 변환 일시
2025-12-26

## 원본 정보
- 원작자: Galahhad
- 원본 링크: https://uiverse.io/Galahhad/perfect-cheetah-72
- 태그: theme, theme-switch, radio, dropdown

## 컴파일 에러 및 수정 내역

### 에러 1: MC3044 - MarkupExtension 문법 오류

**에러 내용:**
```
PerfectCheetah72.xaml(73,45): error MC3044: MarkupExtension 식의 닫는 '}' 뒤에 텍스트 ',0'을(를) 사용할 수 없습니다.
```

**원인:**
WPF XAML에서 `Margin` 속성에 StaticResource와 리터럴 값을 혼합하여 사용할 수 없음.

```xml
<!-- 잘못된 사용 -->
Padding="{StaticResource PerfectCheetah72.Button.Padding},0"
Margin="0,0,{StaticResource PerfectCheetah72.Button.Gap},0"
```

**수정 방법:**
`PerfectCheetah72Resources.xaml`에 Thickness 리소스를 추가하고 참조 방식 변경.

```xml
<!-- Resources 추가 -->
<Thickness x:Key="PerfectCheetah72.Button.HorizontalPadding">8,0</Thickness>
<Thickness x:Key="PerfectCheetah72.Icon.RightMargin">0,0,5,0</Thickness>
<Thickness x:Key="PerfectCheetah72.ListItem.TopMargin">0,3,0,0</Thickness>
<Thickness x:Key="PerfectCheetah72.ListItem.IconMargin">0,0,7,0</Thickness>

<!-- 수정된 사용 -->
Padding="{StaticResource PerfectCheetah72.Button.HorizontalPadding}"
Margin="{StaticResource PerfectCheetah72.Icon.RightMargin}"
```

## 잠재적 런타임 오류 가능성

### 1. Popup 외부 클릭 시 닫힘 동작
- **위치:** `PerfectCheetah72.xaml` - Popup 설정
- **설명:** `StaysOpen="False"` 설정으로 외부 클릭 시 팝업이 닫히도록 구현됨. 특정 상황에서 IsDropDownOpen 바인딩과 Popup.IsOpen 동기화 문제 발생 가능.
- **확인 필요:** 실행 후 드롭다운 열기/닫기 동작 테스트

### 2. Command 바인딩
- **위치:** `PerfectCheetah72.cs` - SelectThemeCommand
- **설명:** RoutedCommand를 사용하여 테마 선택 처리. CommandBindings가 컨트롤 생성자에서 등록되므로 템플릿 적용 전에 작동해야 함.
- **확인 필요:** 각 테마 옵션 클릭 시 정상 동작 여부

### 3. Path 아이콘 렌더링
- **위치:** `PerfectCheetah72Resources.xaml` - Geometry 리소스
- **설명:** SVG path data를 WPF Geometry로 변환. 일부 복잡한 path는 렌더링 문제 가능.
- **확인 필요:** 아이콘이 올바르게 표시되는지 확인

## 빌드 결과
- 빌드 성공
- 경고: 0개
- 오류: 0개
