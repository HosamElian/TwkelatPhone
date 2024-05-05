using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using Plugin.Fingerprint;
using Plugin.Fingerprint.Abstractions;
using Twkelat.Mobile.Models.Request;
using Twkelat.Mobile.Models.Response;
using Twkelat.Mobile.Repositories;
using Twkelat.Mobile.Services.IServices;

namespace Twkelat.Mobile.Pages;
[QueryProperty(nameof(TempleteId), ("TempleteId"))]
public partial class ConfirmDelegationPage : ContentPage
{
    private readonly IFingerprint _fingerprint;
    private readonly IDelegationRepository _delegationRepository;
	private readonly IUserService _userService;

	public ConfirmDelegationPage(IFingerprint fingerprint, 
        IDelegationRepository delegationRepository,
        IUserService userService)
    {
        InitializeComponent();
        _delegationRepository = delegationRepository;
		_userService = userService;
		_fingerprint = fingerprint;
        LoadedDelegationMSG();
    }
    public string TempleteId
    {
        set
        {
            var msg = "";
			msg = _delegationRepository.GetAllTemplete().FirstOrDefault(t => t.Id == int.Parse(value))?.Message ?? "";
            LoadedDelegationMSG(msg);
        }
    }

   

    private async void Button_Clicked(object sender, EventArgs e)
    {
        var fingerRequst = new AuthenticationRequestConfiguration("Fingure Validation", "Kindly use same fingure as used to unlock user phone ");
        var result = await _fingerprint.AuthenticateAsync(fingerRequst);
        if (result.Authenticated)
        {
            await CreateBlock();
        }
        else
        {
			var genearationRequest = await _userService.GenerateCodeAsync<APIResponse>(App.currentCivilId);
			if (!genearationRequest.IsSuccess) return;

			var codeRequest = await DisplayPromptAsync("Authenticated Code", "Write your authentication Code", maxLength:10,keyboard:Keyboard.Text);
            if (codeRequest == null) return;

            var userWithCode = new CheckRequestDTO { CivilId = App.currentCivilId, Key = codeRequest };
			var request = await _userService.CheckCode<APIResponse>(userWithCode);

			if (request.IsSuccess)
			{
				CancellationTokenSource cancellationTokenSource = new();
				
				await CreateBlock();
			}
			else
			{
				CancellationTokenSource cancellationTokenSource = new();
				await Toast.Make("Wrong Code",
						  ToastDuration.Short,
						  14)
					.Show(cancellationTokenSource.Token);
			}
		}

    }

    private async Task CreateBlock()
    {
        var done = await _delegationRepository.CreateBlock();
        if (!done)
        {
			await Toast.Make("Block not created succefuly", ToastDuration.Short).Show();

        }
        else
        {
		    await Toast.Make("Block created succefuly", ToastDuration.Short).Show();
        }
		await Shell.Current.GoToAsync($"//{nameof(HomePage)}");

    }

    private void LoadedDelegationMSG(string msg = "")
    {
        entryConfirmText.Text = msg;
    }
}