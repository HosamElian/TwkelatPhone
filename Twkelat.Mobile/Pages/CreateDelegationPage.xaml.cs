using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using Twkelat.Mobile.Enum;
using Twkelat.Mobile.Models;
using Twkelat.Mobile.Models.Request;
using Twkelat.Mobile.Services.IServices;

namespace Twkelat.Mobile.Pages;

public partial class CreateDelegationPage : ContentPage
{
    DateTime MaxDate;
    DateTime MinDate;
    int _selectedTempleteId = 8;
    List<Templete> _templetes;
    private readonly IDelegationRepository _delegationRepository;

    public CreateDelegationPage(IDelegationRepository delegationRepository)
    {
        InitializeComponent();
        _delegationRepository = delegationRepository;
        MinDate = DateTime.Today;
        MaxDate = DateTime.Today.AddYears(1);
        _templetes = _delegationRepository.GetAllTemplete();
        templetePicker.Title = "Select a Templete";
        templetePicker.ItemsSource = _templetes;
        templetePicker.ItemDisplayBinding = new Binding(nameof(Templete.Name));
    }


    private async void Next_Clicked(object sender, EventArgs e)
    {
        if (_selectedTempleteId == 0)
        {
            await DisplayAlert("Error", "Please Select Templete", "Ok");
            return;
        }
        if (String.IsNullOrWhiteSpace(scopeTXT.Text))
        {
            await DisplayAlert("Error", "Please Write The Scope", "Ok");
            return;
        }

        if (String.IsNullOrWhiteSpace(civilIdTXT.Text))
        {
            await DisplayAlert("Error", "Please Write the Civil Id", "Ok");
            return;
        }

        var data = new CreateBlockRequest()
        {
            TempleteId = _selectedTempleteId,
            CreateByCivilId = App.currentCivilId,
            CreateForCivilId = civilIdTXT.Text,
            ExpirationDate = datePickerOfExpiration.Date,
            Scope = scopeTXT.Text,
            PowerAttorneyTypeId = PublicRB.IsChecked ? (int)PowerAttonaryEnum.Public : (int)PowerAttonaryEnum.Private,
        };

        App.createBlockRequest = data;
        await Shell.Current.GoToAsync($"{nameof(ConfirmDelegationPage)}?TempleteId={(int)_selectedTempleteId}");
    }
    private void PublicRB_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        _selectedTempleteId = 8;
        templetePicker.Title = "";
        templetePicker.IsEnabled = false;
    }
    private void PrivateRB_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        templetePicker.Title = "";
        _selectedTempleteId = 0;
        templetePicker.IsEnabled = true;
    }
    private async void datePickerOfExpiration_DateSelected(object sender, DateChangedEventArgs e)
    {
        if (datePickerOfExpiration.Date < MinDate)
        {
            await Toast.Make("The date Can't be less than today", ToastDuration.Short).Show();
            //await DisplayAlert("Invalid Date", "The date Can't be less than today", "ok");
            datePickerOfExpiration.Date = MinDate;
        }
        if (datePickerOfExpiration.Date > MaxDate)
        {
			await Toast.Make("The date Can't be More than Year", ToastDuration.Short).Show();

			//await DisplayAlert("Invalid Date", "The date Can't be More than Year", "ok");
            datePickerOfExpiration.Date = MaxDate;
        }
    }
    private void TempletePicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;
        if (selectedIndex != -1)
        {
            _selectedTempleteId = _templetes[selectedIndex].Id;
            picker.SelectedIndex = selectedIndex;
        }
    }
}