using CommunityToolkit.Maui.Behaviors;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twkelat.Mobile.Models;
using Twkelat.Mobile.Pages;
using Twkelat.Mobile.Repository.IRepository;
using Twkelat.Mobile.UserControl;

namespace Twkelat.Mobile.ViewModels
{
    public partial class LoginPageViewModel:BaseViewModel
    {
        public LoginPageViewModel(IUserRepository loginRepository)
        {
            _loginRepository = loginRepository;
            _email = string.Empty;
            _password= string.Empty;
        }
        [ObservableProperty]
        private string _email;
        [ObservableProperty]
        private string _password;
        
        //[ObservableProperty]
        //private TextValidationBehavior _passwordValidator;
        //[ObservableProperty]
        //private MultiValidationBehavior _emailValidator;


        private readonly IUserRepository _loginRepository; 
        
        [ICommand]
        public async void Login()
        {
            if(!string.IsNullOrWhiteSpace(_email) && !string.IsNullOrWhiteSpace(_password))
            {
                //if (_emailValidator.IsNotValid)
                //{

                //}
                //if(_passwordValidator.IsNotValid)
                //{

                //}
                var resultJson = await _loginRepository.Login(new LoginModel() { Email = Email, Password = Password });

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
