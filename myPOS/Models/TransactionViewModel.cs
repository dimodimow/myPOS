using myPOS.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace myPOS.Web.Models
{
    public class TransactionViewModel
    {
        public Guid Id { get; set; }
        public User TransactionFrom { get; set; }
        [Required]
        public User TransactionTo { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public string Comment { get; set; }
        [Required]
        public double Credits { get; set; }
    }
}
