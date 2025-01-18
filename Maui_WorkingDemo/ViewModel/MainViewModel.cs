

using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace Maui_WorkingDemo.ViewModel
{
    //implement MVVM by inheriting ObservableObject
    public partial class MainViewModel :ObservableObject
    {
        IConnectivity connectivity;
        public MainViewModel(IConnectivity connectivity)
        {
            Items = new ObservableCollection<string>();
            this.connectivity = connectivity;   
        }

        [ObservableProperty]
        ObservableCollection<String> items;

        [ObservableProperty]//a mechanism for tracking changes in properties within the ViewMode, and update view accordingly
        string text;

        [RelayCommand]
        async Task Add()
        {
            //add items 
            if (string.IsNullOrWhiteSpace(Text)) return;

            if(connectivity.NetworkAccess!=NetworkAccess.Internet)
            {
                await Shell.Current.DisplayAlert("Uh Oh!", "No Internet", "OK");
                return;
            }

            Items.Add(Text);
            Text=string.Empty;
        }

        [RelayCommand]
        void Delete(string s)
        {
            if(Items.Contains(s)) Items.Remove(s);  
        }

        [RelayCommand]
        async Task Tap(string s)
        {
            await Shell.Current.GoToAsync($"{nameof(DetailPage)}?Text={s}");
        }
    }
}
