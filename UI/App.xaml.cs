namespace SokoEqCalculator;

public partial class App : Application
{
    public static ResourceDictionary Colors => Current!.Resources.MergedDictionaries.First();
    public App()
    {
        LoadAppTheme();
        InitializeComponent();

        MainPage = new AppShell();
    }

    public static AppTheme StringToTheme(string theme) => theme switch
    {
        "Unspecified" => AppTheme.Unspecified,
        "Light" => AppTheme.Light,
        "Dark" => AppTheme.Dark,
        _ => throw new ArgumentOutOfRangeException(nameof(theme), theme, "out of range")
    };
    private void LoadAppTheme()
    {
        var preferredTheme = Preferences.Default.Get("Theme", Current!.RequestedTheme.ToString());
        Current.UserAppTheme = StringToTheme(preferredTheme);
    }
}
