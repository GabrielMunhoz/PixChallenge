using PixChallenge_Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace PixChallenge_Api.ViewModels.BankTransaction
{
    public class CreateTransactionViewModel
    {
        [Required]
        public string SenderKey { get; set; }
        [Required]
        public string PayeeKey { get; set; }
        [Required]
        public KeyType KeyType { get; set; }
        [Required]
        public decimal Value { get; set; }
        public DateTime DateProcessed = DateTime.Now;
    }
}
