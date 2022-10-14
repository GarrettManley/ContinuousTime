using ContinuousTime.ViewModels;

namespace ContinuousTime.Pages;

public partial class HomePage
{
    public HomePage(HomeViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}