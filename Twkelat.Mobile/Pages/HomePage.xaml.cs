using AutoMapper;
using System.Collections.ObjectModel;
using System.Text.Json;
using Twkelat.Mobile.Models.Response;
using Twkelat.Mobile.Models.ViewModels;
using Twkelat.Mobile.Repositories;
using Twkelat.Mobile.Services.IServices;

namespace Twkelat.Mobile.Pages;

public partial class HomePage : ContentPage
{
    private readonly IDelegationRepository _delegationRepository;

    public HomePage(IDelegationRepository delegationRepository)
    {
        InitializeComponent();
        _delegationRepository = delegationRepository;
        SearchBar.Text = string.Empty;
        LoadDelegations();
    }

    private void listDelegations_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        listDelegations.SelectedItem = null;
    }

    private void btnAdd_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(CreateDelegationPage));

    }

    private async Task LoadDelegations()
    {
        var delegationVMs = await _delegationRepository.GetDelegationVMs();
        if(delegationVMs == null)
        {
            delegationVMs = new List<DelegationVM>();
        }
        listDelegations.ItemsSource = delegationVMs;
    }

    private async void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        var delegation = new ObservableCollection<DelegationVM>(_delegationRepository.SearchContacts(((SearchBar)sender).Text));
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

    private async void meDelegationCheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        var data =  _delegationRepository.Filter(me:meDelegationCheckBox.IsChecked, other:otherDelegationCheckBox.IsChecked);
        if(data == null)
        {
            await LoadDelegations();
        }
        else
        {
            listDelegations.ItemsSource = data;
        }
    }

    private async void otherDelegationCheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        var data = _delegationRepository.Filter(me: meDelegationCheckBox.IsChecked, other: otherDelegationCheckBox.IsChecked);
        if (data == null)
        {
            await LoadDelegations();
        }
        else
        {
            listDelegations.ItemsSource = data;
        }
    }
}