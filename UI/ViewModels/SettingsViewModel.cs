namespace SokoEqCalculator.ViewModels;
internal class SettingsViewModel
{
    public string CurrentTheme { get; set; }

    public SettingsViewModel()
    {
        // TODO Load settings from a file
        CurrentTheme = Application.Current.RequestedTheme.ToString();
    }

    public void OnThemeColorChange(AppTheme newTheme)
    {
        CurrentTheme = newTheme.ToString();
        Application.Current.UserAppTheme = newTheme;
    }

}
