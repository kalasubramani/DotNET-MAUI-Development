using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Maui_WorkingDemo.ViewModel;

[QueryProperty("Text","Text")]
public partial class DetailViewModel:ObservableObject
{
    [ObservableProperty]
    string text;

    [RelayCommand]
    async Task GoBack()
    {
        await Shell.Current.GoToAsync("..");//navigate back to previous page
    }
}
