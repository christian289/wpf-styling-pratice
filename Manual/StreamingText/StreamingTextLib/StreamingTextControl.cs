using System.Windows;
using System.Windows.Controls;

namespace StreamingTextLib;

/// <summary>
/// 실시간 타이핑 효과를 제공하는 텍스트 컨트롤
/// AI 챗봇처럼 텍스트가 스트리밍되는 듯한 UX를 구현합니다.
/// </summary>
public class StreamingTextControl : Control
{
    private CancellationTokenSource? _cancellationTokenSource;
    private int _currentCharIndex;

    static StreamingTextControl()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(StreamingTextControl),
            new FrameworkPropertyMetadata(typeof(StreamingTextControl)));
    }

    #region Dependency Properties

    /// <summary>
    /// 전체 텍스트
    /// </summary>
    public static readonly DependencyProperty TextProperty =
        DependencyProperty.Register(
            nameof(Text),
            typeof(string),
            typeof(StreamingTextControl),
            new PropertyMetadata(string.Empty, OnTextChanged));

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    /// <summary>
    /// 현재 화면에 표시되는 텍스트 (읽기 전용)
    /// </summary>
    public static readonly DependencyProperty DisplayedTextProperty =
        DependencyProperty.Register(
            nameof(DisplayedText),
            typeof(string),
            typeof(StreamingTextControl),
            new PropertyMetadata(string.Empty));

    public string DisplayedText
    {
        get => (string)GetValue(DisplayedTextProperty);
        private set => SetValue(DisplayedTextProperty, value);
    }

    /// <summary>
    /// 초당 표시할 글자 수 (기본값: 50)
    /// </summary>
    public static readonly DependencyProperty CharactersPerSecondProperty =
        DependencyProperty.Register(
            nameof(CharactersPerSecond),
            typeof(double),
            typeof(StreamingTextControl),
            new PropertyMetadata(50.0, OnCharactersPerSecondChanged));

    public double CharactersPerSecond
    {
        get => (double)GetValue(CharactersPerSecondProperty);
        set => SetValue(CharactersPerSecondProperty, value);
    }

    /// <summary>
    /// 현재 스트리밍 중인지 여부 (읽기 전용)
    /// </summary>
    public static readonly DependencyProperty IsStreamingProperty =
        DependencyProperty.Register(
            nameof(IsStreaming),
            typeof(bool),
            typeof(StreamingTextControl),
            new PropertyMetadata(false));

    public bool IsStreaming
    {
        get => (bool)GetValue(IsStreamingProperty);
        private set => SetValue(IsStreamingProperty, value);
    }

    /// <summary>
    /// 자동으로 스트리밍을 시작할지 여부 (기본값: true)
    /// </summary>
    public static readonly DependencyProperty AutoStartProperty =
        DependencyProperty.Register(
            nameof(AutoStart),
            typeof(bool),
            typeof(StreamingTextControl),
            new PropertyMetadata(true));

    public bool AutoStart
    {
        get => (bool)GetValue(AutoStartProperty);
        set => SetValue(AutoStartProperty, value);
    }

    #endregion

    #region Events

    /// <summary>
    /// 스트리밍이 완료되었을 때 발생하는 이벤트
    /// </summary>
    public event EventHandler? StreamingCompleted;

    /// <summary>
    /// 스트리밍이 취소되었을 때 발생하는 이벤트
    /// </summary>
    public event EventHandler? StreamingCancelled;

    #endregion

    #region Property Changed Handlers

    private static void OnTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is StreamingTextControl control)
        {
            control.OnTextChanged((string)e.NewValue);
        }
    }

    private static void OnCharactersPerSecondChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is StreamingTextControl control && (double)e.NewValue <= 0)
        {
            control.CharactersPerSecond = 1; // 최소값 보장
        }
    }

    private void OnTextChanged(string newText)
    {
        // 기존 스트리밍 중지
        StopStreaming();

        // 자동 시작이 활성화되어 있으면 스트리밍 시작
        if (AutoStart && !string.IsNullOrEmpty(newText))
        {
            _ = StartStreamingAsync();
        }
        else
        {
            // 자동 시작이 비활성화되어 있으면 전체 텍스트를 바로 표시
            DisplayedText = newText;
            _currentCharIndex = newText?.Length ?? 0;
        }
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// 텍스트 스트리밍을 시작합니다.
    /// </summary>
    public async Task StartStreamingAsync()
    {
        if (IsStreaming)
        {
            StopStreaming();
        }

        if (string.IsNullOrEmpty(Text))
        {
            return;
        }

        _currentCharIndex = 0;
        DisplayedText = string.Empty;
        IsStreaming = true;

        _cancellationTokenSource = new CancellationTokenSource();

        try
        {
            await StreamTextAsync(_cancellationTokenSource.Token);

            // 완료 이벤트 발생
            await Dispatcher.InvokeAsync(() => StreamingCompleted?.Invoke(this, EventArgs.Empty));
        }
        catch (OperationCanceledException)
        {
            // 취소 이벤트 발생
            await Dispatcher.InvokeAsync(() => StreamingCancelled?.Invoke(this, EventArgs.Empty));
        }
        finally
        {
            IsStreaming = false;
            _cancellationTokenSource?.Dispose();
            _cancellationTokenSource = null;
        }
    }

    /// <summary>
    /// 현재 진행 중인 스트리밍을 중지합니다.
    /// </summary>
    public void StopStreaming()
    {
        _cancellationTokenSource?.Cancel();
    }

    /// <summary>
    /// 스트리밍을 초기화하고 처음부터 다시 시작합니다.
    /// </summary>
    public async Task ResetAndRestartAsync()
    {
        StopStreaming();
        await StartStreamingAsync();
    }

    /// <summary>
    /// 표시된 텍스트를 초기화합니다.
    /// </summary>
    public void ResetDisplay()
    {
        StopStreaming();
        DisplayedText = string.Empty;
        _currentCharIndex = 0;
    }

    /// <summary>
    /// 스트리밍을 건너뛰고 전체 텍스트를 즉시 표시합니다.
    /// </summary>
    public void SkipToEnd()
    {
        StopStreaming();
        DisplayedText = Text;
        _currentCharIndex = Text?.Length ?? 0;
        StreamingCompleted?.Invoke(this, EventArgs.Empty);
    }

    #endregion

    #region Private Methods

    private async Task StreamTextAsync(CancellationToken cancellationToken)
    {
        var text = Text;
        if (string.IsNullOrEmpty(text))
        {
            return;
        }

        // 글자 간 지연 시간 계산 (밀리초)
        var delayMs = (int)(1000.0 / CharactersPerSecond);
        if (delayMs < 1) delayMs = 1; // 최소 1ms

        while (_currentCharIndex < text.Length)
        {
            cancellationToken.ThrowIfCancellationRequested();

            // UI 스레드에서 텍스트 업데이트
            await Dispatcher.InvokeAsync(() =>
            {
                _currentCharIndex++;
                DisplayedText = text[.._currentCharIndex];
            });

            // 다음 글자까지 대기
            await Task.Delay(delayMs, cancellationToken);
        }
    }

    #endregion
}
