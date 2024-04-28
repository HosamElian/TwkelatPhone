using Twkelat.Mobile.Models.Request;
using Twkelat.Mobile.Models.ViewModels;
using Twkelat.Mobile.Services.IServices;

namespace Twkelat.Mobile.Pages;

[QueryProperty(nameof(Id), ("Id"))]
public partial class ViewDelegationPage : ContentPage
{
    private DelegationVM? _delegationVM;
    private string? _oldValue;
    private readonly IDelegationRepository _delegationRepository;
    private readonly IDelegationService _delegationService;

    public ViewDelegationPage(IDelegationRepository delegationRepository, 
                              IDelegationService delegationService)
    {
        InitializeComponent();
        _delegationRepository = delegationRepository;
        _delegationService = delegationService;
    }

    public string TempleteName
    {
        get
        {
            return entryTempleteName.Text;
        }
        set
        {
            entryTempleteName.Text = value;
        }
    }

    public string CommissionerName
    {
        get
        {
            return entryCommissionerName.Text;
        }
        set
        {
            entryCommissionerName.Text = value;
        }
    }

    public string Hash
    {
        get
        {
            return entryHash.Text;
        }
        set
        {
            entryHash.Text = value;
        }
    }

    public string ExpirationDate
    {
        get
        {
            return entryExpirationDate.Text;
        }
        set
        {
            entryExpirationDate.Text = value;
        }
    }
    public string Id
    {
        set
        {
            try
            {
                _delegationVM = _delegationRepository.GetbyId(int.Parse(value));
                if (_delegationVM is not null)
                {
                    TempleteName = _delegationVM.TempleteName;
                    CommissionerName = _delegationVM.CommissionerName;
                    Hash = BitConverter.ToString(_delegationVM.Hash) ?? "";
                    ExpirationDate = _delegationVM.ExpirationDate.ToString();
                    isActive.IsChecked = _delegationVM.ExpirationDate < DateTime.Today;
                    btnSaved.IsVisible = false;
                }
            }catch (Exception ex)
            {
            }
            
        }
    }

    private async void btnCancel_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }

    private void isActive_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        var chechbox = (CheckBox)sender;
        _oldValue = entryExpirationDate.Text;
        if (chechbox.IsChecked == false)
        {
            entryExpirationDate.Text = DateTime.Today.AddDays(-1).ToString();
        }
        else
        {
            entryExpirationDate.Text = DateTime.Today.AddDays(1).ToString();
        }
        btnSaved.IsVisible = true;
    }

    private async void btnSaved_Clicked(object sender, EventArgs e)
    {
        if (btnSaved.IsVisible)
        {
            try
            {
                var saved = await _delegationRepository.UpdateModel(new ChangeBlockStateRequest
                {
                    Id = _delegationVM.Id,
                    ExpirationDate = Convert.ToDateTime(ExpirationDate),
                    State = _delegationVM.ExpirationDate > DateTime.Now,
                });
                if (saved)
                {
                    await DisplayAlert("Notification", "Saving Succefuly", "ok");
                    await Shell.Current.GoToAsync("..");
                }
                else
                {
                    await DisplayAlert("Notification", "Saving Faild", "ok");
                    await Shell.Current.GoToAsync("..");
                }

            }
            catch (Exception ex)
            {
                await DisplayAlert("Notification", ex.Message, "ok");

            }

        }

    }
}