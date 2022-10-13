using System.Linq.Expressions;
using System.Reflection;
using ContinuousTime.Interfaces.ViewModels;

namespace ContinuousTime.ViewModels.Base;

public abstract class BaseViewModel : BindableObject, IBaseViewModel
{
    protected BaseViewModel()
    {
        CallViewModelLifeCycle();
    }

    private void CallViewModelLifeCycle()
    {
        Task.Run(Initialize);
    }

    public virtual Task Initialize()
    {
        return Task.CompletedTask;
    }
    
    public void RaisePropertyChanged<T>(Expression<Func<T>> property)
    {
        OnPropertyChanged(property.Name);
    }
}