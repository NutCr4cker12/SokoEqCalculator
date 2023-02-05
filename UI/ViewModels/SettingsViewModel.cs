using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SokoEqCalculator.Models;

namespace SokoEqCalculator.ViewModels;

internal partial class SettingsViewModel : ObservableObject
{
    public SettingsViewModel()
    {
        CardProperty = new CardModel("A", "s");
        _cardObs = new CardModel("A", "s");
    }

    public int Iterations
    {
        get => Preferences.Default.Get(nameof(Iterations), 10_000);
        set
        {
            Preferences.Default.Set(nameof(Iterations), value);
            OnPropertyChanged();
        }
    }
    public string Theme
    {
        get => Preferences.Default.Get(nameof(Theme), Application.Current!.RequestedTheme.ToString());
        set => Preferences.Default.Set(nameof(Theme), value);
    }
    
    public void OnThemeColorChange(AppTheme newTheme)
    {
        Theme = newTheme.ToString();
        Application.Current!.UserAppTheme = newTheme;
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
