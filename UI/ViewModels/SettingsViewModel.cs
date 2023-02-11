using CommunityToolkit.Mvvm.ComponentModel;

namespace SokoEqCalculator.ViewModels;

public partial class SettingsViewModel : ObservableObject
{
    public SettingsViewModel()
    {
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
        set
        {
            Preferences.Default.Set(nameof(Theme), value);
            OnPropertyChanged();
        }
    }
    
    public void OnThemeColorChange(AppTheme newTheme)
    {
        Theme = newTheme.ToString();
        Application.Current!.UserAppTheme = newTheme;
    }
}
