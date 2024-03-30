using Twkelat.Mobile.Models;
using Twkelat.Mobile.Repositories;

namespace Twkelat.Mobile.Pages;

[QueryProperty(nameof(Id), ("Id"))]
public partial class ViewDelegationPage : ContentPage
{
    private DelegationVM? _delegationVM;
    public ViewDelegationPage()
	{
		InitializeComponent();
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
            _delegationVM = DelegartionRepository.GetContactById(int.Parse(value));
            if (_delegationVM is not null)
            {
                TempleteName  = _delegationVM.TempleteName ;
                CommissionerName = _delegationVM.CommissionerName ;
                 Hash = BitConverter.ToString( _delegationVM.Hash)  ?? "";
                ExpirationDate =  _delegationVM.ExpirationDate.ToString() ;
                isActive.IsChecked = _delegationVM.ExpirationDate < DateTime.Today;
            }
        }
    }

    private async void btnCancel_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}