using SokoEqCalculator.ViewModels;

namespace SokoEqCalculator.Views;

public partial class AboutView : ContentPage
{
    public AboutView(AboutViewModel viewModel)
    {
        BindingContext = viewModel;
        InitializeComponent();
    }
}