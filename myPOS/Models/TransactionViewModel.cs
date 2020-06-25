using myPOS.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace myPOS.Web.Models
{
    public class TransactionViewModel
    {
        public Guid Id { get; set; }
        [Display(Name = "From")]
        public User TransactionFrom { get; set; }
        [Required]
        [Display(Name = "To")]
        public User TransactionTo { get; set; }
        [Required]
        [Display(Name = "Phone")]
        public string PhoneNumber { get; set; }
        public string Comment { get; set; }
        [Display(Name = "Created")]
        public DateTime? CreatedOn { get; set; }
        [Required]
        public double Credits { get; set; }
    }
}
