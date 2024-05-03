using Twkelat.Mobile.Models;
using Twkelat.Mobile.Models.Request;
using Twkelat.Mobile.Models.ViewModels;

namespace Twkelat.Mobile.Services.IServices
{
    public interface IDelegationRepository
    {
        Task<List<DelegationVM>?> GetDelegationVMs();
        DelegationVM? GetbyId(int id);
        List<Templete> GetAllTemplete();
        IEnumerable<DelegationVM>? Filter(bool me=false, bool other=false);
        IEnumerable<DelegationVM>? SearchContacts(string filterText);
        Task<bool> UpdateModel(ChangeBlockStateRequest request);
        //Task<bool> CheckSecretKey(string key);

        Task<bool> CreateBlock();
    }
}
