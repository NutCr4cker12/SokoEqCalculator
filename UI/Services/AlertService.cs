namespace SokoEqCalculator.Services;

public interface IAlertService
{
    Task ShowAlert(string title, string message, string ok = "OK");
}

internal class AlertService : IAlertService
{
    public async Task ShowAlert(string title, string message, string ok = "OK")
    {
        await Application.Current.MainPage.DisplayAlert(title, message, ok);
    }
}