using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SokoEqCalculator.Models;

namespace SokoEqCalculator.ViewModels;

[INotifyPropertyChanged]
internal partial class SettingsViewModel
{
    public string CurrentTheme { get; set; }
    private bool _foo { get; set; }
    public SettingsViewModel()
    {
        // TODO Load settings from a file
        CurrentTheme = Application.Current.RequestedTheme.ToString();

        CardProperty = new CardModel("A", "s");
        _cardObs = new CardModel("A", "s");
    }

    public CardDeckColors TwoColored { get; set; } = CardDeckColors.Two;
    public CardDeckColors FourColored { get; set; } = CardDeckColors.Four;
    public CardModel Club { get; set; } = new("A", "c");
    public CardModel Heart { get; set; } = new("A", "h");
    public CardModel Spade { get; set; } = new("A", "s");
    public CardModel Diamond { get; set; } = new("A", "d");

    public void OnThemeColorChange(AppTheme newTheme)
    {
        CurrentTheme = newTheme.ToString();
        Application.Current.UserAppTheme = newTheme;
    }

    private CardModel _cardProperty;
    public CardModel CardProperty
    {
        get => _cardProperty;
        set
        {
            _cardProperty = value;
            OnPropertyChanged();
        }
    }
    [ObservableProperty]
    private CardModel _cardObs;

    [RelayCommand]
    private void ChangeCardModel()
    {
        if (_foo)
        {
            CardProperty = new CardModel("A", "s");
            CardObs = new CardModel("A", "s");
            _foo = false;
        }
        else
        {
            CardProperty = new CardModel("K", "d");
            CardObs = new CardModel("K", "d");
            _foo = true;
        }
    }
}
