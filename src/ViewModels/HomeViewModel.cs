using ContinuousTime.ViewModels.Base;

namespace ContinuousTime.ViewModels;

public class HomeViewModel : BaseViewModel
{
    private string _currentTime;

    public string CurrentTime
    {
        get => _currentTime;
        set
        {
            _currentTime = value;
            RaisePropertyChanged(() => CurrentTime);
        }
    }

    public override async Task Initialize()
    {
        await base.Initialize();

        CurrentTime = DateTime.Now.ToLongTimeString();
    }
}