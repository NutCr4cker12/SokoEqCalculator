using SokoEqCalculator.ViewModels;

namespace SokoEqCalculator.Views;

public partial class MainPage : ContentPage
{
    public MainPage(MainViewModel viewModel)
    {
        BindingContext = viewModel;
        InitializeComponent();
    }
}

