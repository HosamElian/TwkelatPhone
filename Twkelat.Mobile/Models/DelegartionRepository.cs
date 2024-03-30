using Twkelat.Mobile.Models;

namespace Twkelat.Mobile.Repositories
{
    public static class DelegartionRepository
    {
        private static List<DelegationVM> _delegation =
            [
             new() { Id = 1, TempleteName = "General", CommissionerName = "Ahmed", Hash = [1, 2, 3, 4, 5, 6], ExpirationDate = DateTime.Today },
             new() { Id = 2, TempleteName = "General", CommissionerName = "Ahmed", Hash = [1, 2, 3, 4, 5, 6], ExpirationDate = DateTime.Today },
             new() { Id = 3, TempleteName = "General", CommissionerName = "Ahmed", Hash = [1, 2, 3, 4, 5, 6], ExpirationDate = DateTime.Today },
             new() { Id = 4, TempleteName = "General", CommissionerName = "Ahmed", Hash = [1, 2, 3, 4, 5, 6], ExpirationDate = DateTime.Today },
             new() { Id = 5, TempleteName = "Private", CommissionerName = "Hosam", Hash = [1, 2, 3, 4, 5, 6], ExpirationDate = DateTime.Today },
             new() { Id = 6, TempleteName = "General", CommissionerName = "Ahmed", Hash = [1, 2, 3, 4, 5, 6], ExpirationDate = DateTime.Today },
             new() { Id = 7, TempleteName = "General", CommissionerName = "Ahmed", Hash = [1, 2, 3, 4, 5, 6], ExpirationDate = DateTime.Today }

            ];
        public static List<DelegationVM> GetAllDelegations()
        {
            return _delegation;
        }

        public static DelegationVM GetContactById(int id)
        {
            return _delegation.FirstOrDefault(d => d.Id == id);
        }

        public static void RemoveContact(int id)
        {
            var item = _delegation.FirstOrDefault(d => d.Id == id);
            if (item != null)
                _delegation.Remove(item);
        }

        public static IEnumerable<DelegationVM>? SearchContacts(string filterText)
        {
            var DelegationVM = _delegation.Where(c => !string.IsNullOrWhiteSpace(c.CommissionerName) && c.CommissionerName.StartsWith(filterText, StringComparison.OrdinalIgnoreCase)).ToList();
            if (DelegationVM == null || DelegationVM.Count <= 0)
            {
                DelegationVM = _delegation.Where(c => !string.IsNullOrWhiteSpace(c.TempleteName) && c.TempleteName.StartsWith(filterText, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            return DelegationVM;
        }
    }
}
