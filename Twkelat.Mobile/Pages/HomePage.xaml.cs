using AutoMapper;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using Microsoft.Toolkit.Mvvm.Input;
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

	private async void listDelegations_Refreshing(object sender, EventArgs e)
	{
		await LoadDelegations();

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
        listDelegations.IsRefreshing = false;

	}


    private async void listDelegations_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (listDelegations.SelectedItem != null)
        {
            await Shell.Current.GoToAsync($"{nameof(ViewDelegationPage)}?Id={((DelegationVM)listDelegations.SelectedItem).Id}");
        }
    }
	private void listDelegations_ItemTapped(object sender, ItemTappedEventArgs e)
	{
		listDelegations.SelectedItem = null;
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
			await Toast.Make("no data match search item", ToastDuration.Short).Show();

			//await DisplayAlert("NOT FOUND", "no data exist", "ok");
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