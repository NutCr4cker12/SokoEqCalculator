using CommunityToolkit.Mvvm.ComponentModel;
using SokoEqCalculator.Models;

namespace SokoEqCalculator.ViewModels;

internal partial class SettingsViewModel : ObservableObject
{
    public SettingsViewModel()
    {
        _cardObs = new CardModel(0, "A", "s");
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
    [ObservableProperty]
    private CardModel _cardObs;
}
