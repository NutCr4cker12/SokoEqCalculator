namespace SokoEqCalculator;

public partial class App : Application
{
    public static ResourceDictionary Colors => Current.Resources.MergedDictionaries.First();
    public App()
    {
        InitializeComponent();

        MainPage = new AppShell();
    }
}
