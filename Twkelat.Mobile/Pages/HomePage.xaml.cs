using System.Collections.ObjectModel;
using Twkelat.Mobile.Models;
using Twkelat.Mobile.Repositories;

namespace Twkelat.Mobile.Pages;

public partial class HomePage : ContentPage
{
    public HomePage()
    {
        InitializeComponent();
        SearchBar.Text = string.Empty;
        LoadDelegations();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"{nameof(CreateDelegationPage)}");

    }



    private void listDelegations_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        listDelegations.SelectedItem = null;
    }

    private void btnAdd_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(CreateDelegationPage));

    }

    private void Delete_Clicked(object sender, EventArgs e)
    {
        MenuItem? menuItem = sender as MenuItem;
        if (menuItem != null)
        {
            DelegationVM? delegationVM = menuItem.CommandParameter as DelegationVM;
            if (delegationVM != null)
            {
                DelegartionRepository.RemoveContact(delegationVM.Id);
                LoadDelegations();
            }
        }
    }

    private void LoadDelegations()
    {
        var delegations = new ObservableCollection<DelegationVM>(DelegartionRepository.GetAllDelegations());
        listDelegations.ItemsSource = delegations;
    }

    private async void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        var delegation = new ObservableCollection<DelegationVM>(DelegartionRepository.SearchContacts(((SearchBar)sender).Text));
        if (delegation != null)
        {
            listDelegations.ItemsSource = delegation;
        }
        else
        {
            await DisplayAlert("NOT FOUND", "no data exist", "ok");
        }
    }

    private async void listDelegations_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (listDelegations.SelectedItem != null)
        {
            await Shell.Current.GoToAsync($"{nameof(ViewDelegationPage)}?Id={((DelegationVM)listDelegations.SelectedItem).Id}");
        }
    }
}