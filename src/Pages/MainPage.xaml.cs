using System.Windows.Input;
using ContinuousTime.Interfaces.Services;
using ContinuousTime.Pages.Base;

namespace ContinuousTime.Pages;

public partial class MainPage : BasePage
{
    private string _timeLabelText;

    private readonly ITimeService _timeService;
    public ICommand ButtonCommand { get; set; }

    public MainPage()
    {
        ButtonCommand = new Command(() => OnButtonClicked());
        InitializeComponent();
    }

    public string TimeLabelText
    {
        get => _timeLabelText;
        set
        {
            if (TimeLabelText == value)
            {
                return;
            }

            _timeLabelText = value;
            // PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TimeLabelText)));
        }
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        TimeLabelText = _timeService?.GetCurrentTime().ToString();
    }

    private static Task OnButtonClicked()
    {
        return Shell.Current.GoToAsync(nameof(HomePage));
    }
}