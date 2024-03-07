using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twkelat.Mobile.Pages;
using Twkelat.Mobile.Repository.IRepository;
using Twkelat.Mobile.UserControl;

namespace Twkelat.Mobile.ViewModels
{
    public partial class LoginPageViewModel:BaseViewModel
    {
        public LoginPageViewModel(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
            _email = string.Empty;
            _password= string.Empty;
        }
        [ObservableProperty]
        private string _email;
        [ObservableProperty]
        private string _password;
        private readonly ILoginRepository _loginRepository;

        [ICommand]
        public async void Login()
        {
            if(!string.IsNullOrWhiteSpace(_email) && !string.IsNullOrWhiteSpace(_password))
            {
                var resultJson = await _loginRepository.Login(Email, Password);

                if (Preferences.ContainsKey(nameof(App.credData)))
                {
                    Preferences.Remove(nameof(App.credData));
                }
                if (resultJson != null)
                {
                    var data = JsonConvert.SerializeObject(resultJson);
                    Preferences.Set(nameof(App.credData), data);
                    App.credData = resultJson;
                    AppShell.Current.FlyoutHeader = new FlyoutHeaderControl();
                    _email = string.Empty ;
                    _password = string.Empty ;
                    await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
                }
            }
            
        }
    }
}
