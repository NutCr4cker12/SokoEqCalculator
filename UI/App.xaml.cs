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

    protected override Window CreateWindow(IActivationState activationState)
    {
        var window = base.CreateWindow(activationState);
#if WINDOWS
        window.Width = 580;
        window.Height = 1180;

        window.Y = 100;
#endif
        var w = window.Width;
        var h = window.Height;

        var x = window.X;
        var y = window.Y;

        var minW = window.MinimumWidth;
        var minH = window.MinimumHeight;

        var maxW = window.MaximumWidth;
        var maxH = window.MaximumHeight;
        return window;
    }
}
