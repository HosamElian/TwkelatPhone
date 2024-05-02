using Plugin.Fingerprint;
using Plugin.Fingerprint.Abstractions;
using Twkelat.Mobile.Repositories;
using Twkelat.Mobile.Services.IServices;

namespace Twkelat.Mobile.Pages;
[QueryProperty(nameof(TempleteId), ("TempleteId"))]
public partial class ConfirmDelegationPage : ContentPage
{
    private readonly IFingerprint _fingerprint;
    private readonly IDelegationRepository _delegationRepository;
    public ConfirmDelegationPage(IFingerprint fingerprint, IDelegationRepository delegationRepository)
    {
        InitializeComponent();
        _delegationRepository = delegationRepository;
        _fingerprint = fingerprint;
        LoadedDelegationMSG();
    }
    public string TempleteId
    {
        set
        {
            var msg = "";
            if (int.Parse(value) == 8)
            {
                msg = "A general power of attorney to manage his properties in any place, whether present or future, whether real estate, movable property, or anything that is called property, renting it to whomever he wants, renting according to the conditions he sees fit, signing lease contracts, extending their term, renewing them, canceling them, and assigning them, collecting the rent, giving the necessary clearances for that, performing repairs and renovations, and building real estate. And contracting with engineers, contractors and workers and agreeing with them regarding the prices of buildings and building materials, and in representing him before the valuation committees in the event of expropriation of part or all of the real estate and receiving the compensation he deserves for that, and in executing on the debtors’ funds and registering the mortgage, renewing it and writing it off, and in representing him before the notary public, the municipality, and my administration. Real estate registration and documentation and before all state ministries, agencies and institutions, including the General Administration of Residence Affairs, the Public Authority for Manpower and all its administrations, the workforce restructuring program, the executive apparatus of the state, the General Authority for the Affairs of People with Disabilities, the General Fire Department, the Ministry of Interior and its various departments, including the Department of Nationality, the General Administration for Immigration Affairs, the Traffic Department, the General Corporation for Housing Welfare, the Ministry of Social Affairs and Labor, the General Corporation for Social Insurance, all governmental ministries and other non-governmental departments and committees, and signing the necessary papers and records and submitting and withdrawing all documents, insurances, fees and the like. In receiving money in its various forms, acknowledging its receipt, and giving general receipts, in depositing and disbursing trusts and any amount due from any party in accordance with the applicable laws and regulations, in collecting and disbursing cheques, transfers, bonds, and promissory notes, and in buying, selling, mortgaging, and bartering any property, real estate, fixed or movable property, at the appropriate price and conditions. In signing contracts for purchase, sale, mortgage, exchange, and exchange of any property, real estate, or fixed or movable property, at the appropriate price and conditions, in paying and receiving the price and the remainder, in concluding deposit and loan contracts, in signing the necessary papers and documents, in requesting the removal of common property, dividing property, and separating it by agreement or judgment, and in signing... The contracts related to this, and in the withdrawal and withdrawal from inheritances for the consideration he deems appropriate, and in the request for pre-emption and waiver thereof, and in the establishment of companies and participation in them, and their amendment, merger, dissolution, and liquidation, and the signing of the documents related to that, and applying for bids and tenders, and the purchase of stocks, bonds, and shares, and the like, and in selling or exchanging them, and collecting their price, and receiving Coupons, selling, receiving certificates of bonus shares and profits, and paying what must be paid, in accordance with the controls and provisions in force within the stock market, in transferring rights and bills, in accounting and approving every account before any party, and in all banking and banking transactions, including opening and closing accounts, except for opening current accounts. The agent has the right to withdraw amounts and deposit them in his name with banks and companies, to issue and receive automatic debit cards and their secret numbers, in addition to borrowing, lending, credits, facilities, and similar transactions in various banks and financial institutions, and to sign their papers, and to file lawsuits and appear in lawsuits filed by him or against him. Before all courts of all types and degrees, in pleading, defending, signing papers related to lawsuits, attending the investigation, reporting, notifying, denying, conciliation, acknowledging, clearing up, discharging debts, receiving and fulfilling rights, arbitration, requesting an oath, rejecting it, accepting it, quarreling, denying lines, seals, and signatures, challenging them by forgery, waiving that, and presenting evidence and requesting Appointing experts, dismissing them, and appearing before them, making statements and observations, submitting memorandums, handing over and receiving papers and documents, submitting petitions and requests, reviewing all papers and documents and extracting copies of them, filing appeals and cassation, reconsidering and appealing, defending the unconstitutionality of laws, initiating procedures related to them, and appearing before the Constitutional Court. All the official and legal procedures that are needed in lawsuits before any party, waiving them, abandoning litigation before all levels of courts, receiving rulings, accepting them, waiving them and implementing them, requesting imprisonment, seizure, travel bans and their removal, reconciliation, evacuation, imprisoning the debtor, receiving what is ruled upon, and arrests in general, and he has the right to appoint whomever he wants to do everything he wants. One or more of it, and he can dismiss him whenever he wants, and he has the right to cancel all the actions mentioned above, except for the sale of Kuwaiti cars abroad.";
            }
            else
            {
                msg = _delegationRepository.GetAllTemplete().FirstOrDefault(t => t.Id == int.Parse(value))?.Message ?? "";

            }
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
            string codeRequest = await DisplayPromptAsync("Authentication Code", "Write you Authentication Code");
            var response = _delegationRepository.CheckSecretKey(codeRequest).Result;
            if(response)
            {
                await CreateBlock();
            }
            else
            {
                await DisplayAlert("Unauthenticated", "Creation denied", "OK");
                await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
            }
        }

    }

    private async Task CreateBlock()
    {
        var done = await _delegationRepository.CreateBlock();
        if (!done)
        {
            await DisplayAlert("Error", "Block not created succefuly", "ok");
        }
        await Shell.Current.GoToAsync($"//{nameof(HomePage)}");

    }

    private void LoadedDelegationMSG(string msg = "")
    {
        entryConfirmText.Text = msg;
    }
}