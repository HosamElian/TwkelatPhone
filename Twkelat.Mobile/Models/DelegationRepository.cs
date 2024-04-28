using System.Text.Json;
using Twkelat.Mobile.Models;
using Twkelat.Mobile.Models.Request;
using Twkelat.Mobile.Models.Response;
using Twkelat.Mobile.Models.ViewModels;
using Twkelat.Mobile.Services.IServices;

namespace Twkelat.Mobile.Repositories
{
    public class DelegationRepository : IDelegationRepository
    {
        private readonly IDelegationService _delegationService;
        JsonSerializerOptions options;
        private List<DelegationVM> _DelegationVMs { get; set; } = new List<DelegationVM>();
        public DelegationRepository(IDelegationService delegationService)
        {
            _delegationService = delegationService;
            options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = false,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };
        }

        public async Task<List<DelegationVM>> GetDelegationVMs()
        {
            _DelegationVMs.Clear();

            var request = await _delegationService.GetAllAsync<APIResponse>(App.currentCivilId);
            if (request != null && request.IsSuccess)
            {
                if (request.Result != null)
                {
                    var delegations = JsonSerializer.Deserialize<List<DelegationVM>>(Convert.ToString(request.Result), options);

                    _DelegationVMs.AddRange(delegations);
                    return _DelegationVMs.ToList();

                }
            }
            return null;

        }
        public List<Templete> GetAllTemplete()
        {
            return [

                new() {Id = 1, Name= "Lawsuits", Message = "A special power of attorney to file lawsuits, lawsuits filed or filed by me personally or against me, and to appear on my behalf as a plaintiff or defendant before all courts of all types and degrees, and to plead and defend, and to sign papers related to the lawsuits, and to attend investigation, notification, notification, denial, reconciliation, arbitration, requesting an oath, rejecting it, accepting it, quarreling, and denying it. Handwriting, seals, and signatures, challenging them by forgery or by any other means, submitting evidence, requesting the appointment of experts, rejecting them, appearing before them, making statements and observations, submitting memorandums, accepting rulings, receiving and executing them, delivering papers and documents, submitting petitions and requests, reviewing all papers and documents and extracting copies of them, and filing an appeal. Cassation, reconsideration, and appeal of rulings by opposition and appeal before the Constitutional Court. He has the right to appeal opposition and all official and legal procedures required by lawsuits, request travel bans, detention, and imprisonment, cancel them, and withdraw them. He also has the right to submit complaints and represent me before police stations, the General Administration of Investigations, and the Public Prosecution. The public, and my representation in this regard before the competent authorities and review the Ministry of Justice and its various departments, in particular the Real Estate Registration Department and the Documentation Department - Archives Departments with all controls and assigning others to carry out all or some of the powers granted to him and removing him."},
                new() {Id = 2, Name= "Driving", Message="A special power of attorney for driving and traveling, with the right to sell it within the State of Kuwait only, to drive and sell the car number/make/model, shape/colour/base number, and he has the right to drive it, tour it, and travel on it to all countries, passing through the territory of the Kingdom of Saudi Arabia, and to present, deliver, and receive identification papers. The agent has the right to represent me before the various insurance companies to pay the prescribed fees, and then to represent me before the General Traffic Department and its various departments in the governorates within the State of Kuwait, in order to conduct the technical examination on it and pay the prescribed fees, including paying fines for traffic violations, if any, and receiving the car’s book. He also has the right to transfer Ownership of the car and registering it in his name and in the name of whoever he wants within the State of Kuwait, and disposing of it through sale, whether for himself or for others within the State of Kuwait. He has the right of representation before the police stations, the various investigation departments, and the traffic court, and the agent has the right to follow up, comment, complete, complete, submit, and receive all identification papers, official documents, and records in order to complete the tasks entrusted to him. Signing applications, forms, identification papers, official documents, records, and everything necessary in this regard"},
                new() {Id = 3, Name= "Review all ministries", Message="A special power of attorney to take  all necessary official and legal measures to represent me before all state ministries, departments, bodies and institutions, as well as all civil authorities, whether companies or individuals, and in particular the following ministries / the Ministry of Interior and its various departments (General Administration of Nationality and Passports) in order to request the issuance of citizenship certificates or passports. I have the General Administration for Immigration Affairs - in order to establish residency permits for employees, workers and employees covered by my sponsorship, as well as to terminate their services, cancel their residency permits, and sign employment contracts before a notary public and have them authenticated by the Ministry of Justice and the General Traffic Department, in order to conduct a technical inspection on my vehicles, renew their books, and receive them. And before all the ministries, agencies and institutions of the state, including the General Administration of Residence Affairs, the General Authority for Manpower and all its administrations, the workforce restructuring program, the executive apparatus of the state, the General Authority for the Affairs of People with Disabilities, the General Fire Department, the Ministry of Interior and its various administrations, including The Department of Naturalization, the General Corporation for Housing Welfare, the Ministry of Social Affairs and Labor, the General Corporation for Social Insurance, all governmental ministries and other non-governmental departments and committees, the Ministry of Social Affairs and Labor and its offices, the Ministry of Justice and its various departments, in particular the Department of Real Estate Registration and Authentication, and the Ministry of Trade and Industry and its various departments ( The Kuwait Chamber of Commerce and Industry, the Ministry of Finance and its various departments, the Ministry of Education and its various departments, and the Public Authority for Applied Education. The Ministry of Electricity and Water and its various departments, and the Ministry of Transportation and its various departments. The Ministry of Public Health and its various departments. The Ministry of Housing and its various departments - the Public Authority for Housing, the Kuwait Credit Bank, the Kuwait Municipality and its various departments, including the Expropriation Department and the Public Authority for Civil Information, in order to obtain my civil cards and all kinds of certificates and documents and replace lost ones, the Public Authority for Compensation Assessment, and the Public Authority for Agricultural Affairs and Fisheries Affairs. The General Organization for Social Insurance, the General Administration of Customs (air - sea - land), the Kuwaiti Flour Mills and Bakeries Company, and the Kuwaiti Catering Company. In order to complete the tasks entrusted to him, the agent has the right to follow up and accomplish everything necessary for that, submit, deliver and receive all identification papers and sign applications, forms, documents, identification papers and records. Everything necessary in this regard" },
                new() {Id = 4, Name= "marriage", Message= "A special power of attorney to take all the necessary official, legal and legitimate measures to represent me before the judge of the Personal Status Court or before one of the legal representatives authorized by the Ministry of Justice and to sign on my behalf a Qur’anic contract ( ) on citizenship with the dowry and conditions that he deems appropriate and to pay the advance dowry in her hand or in the hand of her agent and the agreement. The one who deferred the dowry (the deferred one) must sign the marriage document, receive a copy of it, and have it authenticated by all concerned authorities. The agent, in order to complete the tasks entrusted to him, has the right to follow up, comment on, accomplish, and complete all that is necessary for that, and sign the forms, applications, papers, official documents, and records, and all that is necessary in this regard before all The concerned governmental, civil and judicial authorities, and this is my authorization to do so"},
                new() {Id = 5, Name= "Bank transaction", Message = "A special power of attorney to take all necessary official and legal procedures to represent me before all Kuwaiti banks and their branches, including Kuwait Finance House and its branches, in order to open accounts in my name (except for current accounts and deposit financial amounts in them. He has the right to transfer, reserve, and withdraw financial amounts. He also has the right to close these accounts and cash checks. registered in my name and request a balance certificate. In order to complete the tasks entrusted to him, the agent has the right to follow up, comment on, complete and complete all that is necessary and sign the forms, official documents and official papers and everything necessary for that and sign the receipt and receipt and everything necessary in this regard and he has the right to review the Ministry of Commerce, Social Affairs and Labor to complete all Its transactions have." },
                new() {Id = 6, Name= "Company Create", Message = "A special power of attorney to establish a commercial company. For this purpose, he has the right to sign the articles of incorporation, choose its name, purposes and branches, and carry out all necessary legal and official procedures before all competent authorities and government departments, including the Ministry of Commerce and Industry (Kuwait Chamber of Commerce and Industry), the Ministry of Justice and its various departments - and the Real Estate Registration Department. And documentation (the Department of Contracts, Companies, Social Affairs and Labor, the Public Authority for Manpower and its Administration, the Municipality of Kuwait, the General Fire Department, the Social Insurance Corporation, the Public Authority for Civil Information, the Ministry of the Interior, the General Administration for Immigration), the Ministry of Public Health and all competent authorities for the establishment of the company - as well as The right to review Kuwaiti banks, including Kuwait Finance House and its branches, to open accounts other than current accounts, deposit, transfer, reserve, and withdraw financial amounts and extract a balance certificate from these accounts in the name of the company he intends to establish. He does not have the right to issue checks in his name or in the name of the company he intends to establish. He has the right to present and receive He submits the necessary papers and documents, has the right to sign everything necessary for that, and has the right to name the company." },
                new() {Id = 7, Name= "Company modification", Message ="A special power of attorney to take all necessary official and legal procedures to represent him before all competent authorities, in particular the Ministry of Trade and Industry, Corporate Administration, in order to submit, on his behalf, a request to enter as a partner/withdrawal/exit/waive his share for himself or to others) and make an amendment to the company’s articles of incorporation or On subsequent amendment contracts, he has the right to amend the management clause, signature, capital, redistribution of shares, legal entity, trade name, entry and exit of partners, and all other legal clauses, or any other amendments he deems necessary to introduce to the company’s contracts. He has the right to review the Kuwait Chamber of Commerce and Industry - Ministry of Justice. Documentation Department (Control of Contracts and Companies) in order to sign on his behalf the amendment contracts subsequent to the articles of incorporation before a notary (notary) after paying the prescribed fees. The agent has the right to follow up, comment, complete and complete everything necessary for that and deliver and receive all identification papers, signature and everything necessary." }
        ];
        }


        public IEnumerable<DelegationVM>? SearchContacts(string filterText)
        {
            var DelegationVM = _DelegationVMs.Where(c => !string.IsNullOrWhiteSpace(c.CommissionerName) && c.CommissionerName.StartsWith(filterText, StringComparison.OrdinalIgnoreCase)).ToList();
            if (DelegationVM == null || DelegationVM.Count <= 0)
            {
                DelegationVM = _DelegationVMs.Where(c => !string.IsNullOrWhiteSpace(c.TempleteName) && c.TempleteName.StartsWith(filterText, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            return DelegationVM;
        }

        public DelegationVM? GetbyId(int id)
        {
            return _DelegationVMs.FirstOrDefault(c => c.Id == id);
        }

        public async Task<bool> UpdateModel(ChangeBlockStateRequest request)
        {
            var response = await _delegationService.UpdateAsync<ChangeBlockStateRequest>(request);
            if (response != null)
            {
                var block = _DelegationVMs.FirstOrDefault(c => c.Id == request.Id);
                block.ExpirationDate = request.ExpirationDate;

                return true;
            }
            return false;
        }

        public Task<bool> CheckSecretKey(string key)
        {
            if (key == App.secretCode)
            {
                return Task.FromResult(true);
            }
            return Task.FromResult(false);

        }

        public IEnumerable<DelegationVM>? Filter(bool me = false, bool other = false)
        {
            var delegationVMsList = new List<DelegationVM>();
            if (me)
            {
                delegationVMsList.AddRange(_DelegationVMs.Where(d => d.FromMe));
            }
            if (other)
            {
                delegationVMsList.AddRange(_DelegationVMs.Where(d => !d.FromMe));
            }
            return delegationVMsList;
        }

        public async Task<bool> CreateBlock()
        {
            var isValid = !String.IsNullOrWhiteSpace(App.createBlockRequest.Scope);
            if (isValid)
            {
                var response = await _delegationService.CreateAsync<CreateBlockRequest>(App.createBlockRequest);

                App.createBlockRequest = new CreateBlockRequest();
                if (response != null)
                    return true;
            }

            return false;
        }
    }
}
