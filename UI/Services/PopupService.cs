using CommunityToolkit.Maui.Views;

namespace SokoEqCalculator.Services;

internal interface IPopupService
{
    Task ShowPopup(Popup popup);
}

internal class PopupService : IPopupService
{
    public async Task ShowPopup(Popup popup) =>
        //Application.Current!.MainPage!.ShowPopup(popup);
        await Application.Current.MainPage.ShowPopupAsync(popup);
}