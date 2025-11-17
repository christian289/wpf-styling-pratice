using System.Windows;

namespace StreamingTextGallery;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    // 기본 스타일 이벤트 핸들러
    private async void RestartDefault_Click(object sender, RoutedEventArgs e)
    {
        await DefaultStreamingText.ResetAndRestartAsync();
    }

    private void StopDefault_Click(object sender, RoutedEventArgs e)
    {
        DefaultStreamingText.StopStreaming();
    }

    private void SkipDefault_Click(object sender, RoutedEventArgs e)
    {
        DefaultStreamingText.SkipToEnd();
    }

    // ChatBot 스타일 이벤트 핸들러
    private async void RestartChatBot_Click(object sender, RoutedEventArgs e)
    {
        await ChatBotStreamingText.ResetAndRestartAsync();
    }

    private void StopChatBot_Click(object sender, RoutedEventArgs e)
    {
        ChatBotStreamingText.StopStreaming();
    }

    // Simple 스타일 이벤트 핸들러
    private async void RestartSimple_Click(object sender, RoutedEventArgs e)
    {
        await SimpleStreamingText.ResetAndRestartAsync();
    }

    private void StopSimple_Click(object sender, RoutedEventArgs e)
    {
        SimpleStreamingText.StopStreaming();
    }

    // 속도 조절 이벤트 핸들러
    private async void RestartSpeed_Click(object sender, RoutedEventArgs e)
    {
        await SpeedControlText.ResetAndRestartAsync();
    }

    private void SetSlow_Click(object sender, RoutedEventArgs e)
    {
        SpeedSlider.Value = 10;
    }

    private void SetNormal_Click(object sender, RoutedEventArgs e)
    {
        SpeedSlider.Value = 50;
    }

    private void SetFast_Click(object sender, RoutedEventArgs e)
    {
        SpeedSlider.Value = 200;
    }

    // 수동 제어 이벤트 핸들러
    private async void StartManual_Click(object sender, RoutedEventArgs e)
    {
        await ManualStreamingText.StartStreamingAsync();
    }

    private void StopManual_Click(object sender, RoutedEventArgs e)
    {
        ManualStreamingText.StopStreaming();
    }

    private void ResetManual_Click(object sender, RoutedEventArgs e)
    {
        ManualStreamingText.ResetDisplay();
    }

    private void SkipManual_Click(object sender, RoutedEventArgs e)
    {
        ManualStreamingText.SkipToEnd();
    }

    // 커스텀 텍스트 이벤트 핸들러
    private async void StartCustom_Click(object sender, RoutedEventArgs e)
    {
        await CustomStreamingText.StartStreamingAsync();
    }

    private void StopCustom_Click(object sender, RoutedEventArgs e)
    {
        CustomStreamingText.StopStreaming();
    }

    // 긴 텍스트 이벤트 핸들러
    private async void RestartLong_Click(object sender, RoutedEventArgs e)
    {
        await LongStreamingText.ResetAndRestartAsync();
    }

    private void StopLong_Click(object sender, RoutedEventArgs e)
    {
        LongStreamingText.StopStreaming();
    }

    private void SkipLong_Click(object sender, RoutedEventArgs e)
    {
        LongStreamingText.SkipToEnd();
    }
}
