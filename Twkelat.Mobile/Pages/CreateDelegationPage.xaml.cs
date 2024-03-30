using Twkelat.Mobile.Models;

namespace Twkelat.Mobile.Pages;

public partial class CreateDelegationPage : ContentPage
{
    DateTime MaxDate;
    DateTime MinDate;
    int selectedTempleteId = 0;
    int selectedScopeId = 0;
    List<Templete> templetes;
    List<Scope> scopes;
    public CreateDelegationPage()
    {
        InitializeComponent();
        MinDate = DateTime.Today;
        MaxDate = DateTime.Today.AddYears(1);
        templetes = new List<Templete>()
        {
            new() {Id = 1, Name= "Templete1" },
            new() { Id = 2, Name = "Templete2" },
            new() {Id = 3, Name= "Templete3" }
        };
        templetePicker.Title = "Select a Templete";
        templetePicker.ItemsSource = templetes;
        templetePicker.ItemDisplayBinding = new Binding(nameof(Templete.Name));

        scopes = new List<Scope>() 
        {
            new() {Id = 1, Name= "Scope1" },
            new() { Id = 2, Name = "Scope2" },
            new() {Id = 3, Name= "Scope3" }
        };
        scopePicker.Title = "Select a Scope";
        scopePicker.ItemsSource = scopes;
;       scopePicker.ItemDisplayBinding = new Binding(nameof(Scope.Name));
    }

    private async void datePickerOfExpiration_DateSelected(object sender, DateChangedEventArgs e)
    {
        if (datePickerOfExpiration.Date < MinDate)
        {
            await DisplayAlert("Wrong Date", "Selected date Can't be less than today", "ok");
            datePickerOfExpiration.Date = MinDate;
        }
        if (datePickerOfExpiration.Date > MaxDate)
        {
            await DisplayAlert("Wrong Date", "Selected date Can't be More than Year", "ok");
            datePickerOfExpiration.Date = MaxDate;
        }
        await DisplayAlert("Good Date", "Good Date Selection", "ok");

    }

    private async void Next_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"{nameof(ConfirmDelegationPage)}");

    }

    private void TempletePicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;
        if (selectedIndex != -1)
        {
            selectedTempleteId = templetes[selectedIndex].Id;
            picker.SelectedIndex = selectedIndex;
        }
    }

    private void scopePicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;
        if (selectedIndex != -1)
        {
            selectedScopeId = scopes[selectedIndex].Id;
            picker.SelectedIndex = selectedIndex;
        }
    }
}