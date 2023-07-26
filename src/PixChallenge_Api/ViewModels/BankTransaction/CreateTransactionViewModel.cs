using PixChallenge_Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace PixChallenge_Api.ViewModels.BankTransaction
{
    public class CreateTransactionViewModel
    {
        [Required]
        public string SenderId { get; set; }
        [Required]
        public string PayeeKey { get; set; }
        [Required]
        public string KeyType { get; set; }
        [Required]
        public decimal Value { get; set; }
        public DateTime DateProcessed = DateTime.Now;
    }
}
