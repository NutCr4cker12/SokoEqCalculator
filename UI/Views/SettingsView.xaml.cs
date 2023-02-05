using SokoEqCalculator.ViewModels;

namespace SokoEqCalculator.Views;

public partial class SettingsView : ContentPage
{
    public SettingsView()
    {
        InitializeComponent();
    }

    private void OnThemeStyleChanged(object sender, CheckedChangedEventArgs e)
    {
        if (BindingContext is not SettingsViewModel settingsViewModel)
        {
            throw new ArgumentNullException($"Can't change app theme style, {nameof(BindingContext)} was null");
        }

        if (sender is not RadioButton radioButton)
        {
            throw new ArgumentNullException($"Can't change app theme style, sender was not {nameof(RadioButton)}");
        }

        // Invoke the change function only on the newly selected value
        if (!radioButton.IsChecked)
        {
            return;
        }

        var newTheme = radioButton.Value switch
        {
            "Unspecified" => AppTheme.Unspecified,
            "Light" => AppTheme.Light,
            "Dark" => AppTheme.Dark,
            _ => throw new ArgumentOutOfRangeException(nameof(radioButton.Value), radioButton.Value, "out of range")
        };
        settingsViewModel.OnThemeColorChange(newTheme);
    }
}