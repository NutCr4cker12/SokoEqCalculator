using SokoEqCalculator.ViewModels;

namespace SokoEqCalculator.Views;

public partial class MainPage : ContentPage
{
    public MainPage(MainViewModel mainViewModel)
    {
        BindingContext = mainViewModel;
        InitializeComponent();
    }
}

