using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twkelat.Mobile.Pages;

namespace Twkelat.Mobile.ViewModels
{
    public partial class AppShellViewModel : BaseViewModel
    {
        [ICommand]
        async void SignOut()
        {
            if (Preferences.ContainsKey(nameof(App.credData)))
            {
                Preferences.Remove(nameof(App.credData));
                App.createBlockRequest = new();
			}
			await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
		}
    }
}
