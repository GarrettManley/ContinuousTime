using System.Linq.Expressions;
using ContinuousTime.Interfaces.ViewModels;

namespace ContinuousTime.ViewModels.Base;

public abstract class BaseViewModel : BindableObject, IBaseViewModel
{
    protected BaseViewModel()
    {
        CallViewModelLifeCycle();
    }

    public virtual Task Initialize()
    {
        return Task.CompletedTask;
    }

    private void CallViewModelLifeCycle()
    {
        Task.Run(Initialize);
    }

    protected void RaisePropertyChanged<T>(Expression<Func<T>> property)
    {
        OnPropertyChanged(property.Name);
    }
}