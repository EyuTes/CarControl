using System.ComponentModel.DataAnnotations;

namespace Itancan.Core.ViewModels
{
    public class AccountFormViewModel
    {
        [Required]
        [StringLength(20)]
        public string UserName { get; set; }
        [Required]
        [StringLength(20)]
        public string Password { get; set; }
        // public IEnumerable<UserAccount> UserAccounts { get; set; }
    }
}