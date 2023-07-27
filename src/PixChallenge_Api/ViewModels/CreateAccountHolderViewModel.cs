using PixChallenge_Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace PixChallenge_Api.ViewModels
{
    public class CreateAccountHolderViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string KeyType{ get; set; }
        [Required]
        public string ValueKey { get; set; }
    }
}
