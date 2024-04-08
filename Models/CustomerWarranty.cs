using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DummyCrud.Models
{
    public class CustomerWarranty
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [StringLength(512)]
        public string Name { get; set; }

        [Required]
        [StringLength(64)]
        [EmailAddress]
        public string EmailID { get; set; }

        [Required]
        [StringLength(16)]
        public string Phone { get; set; }

        [Required]
        [StringLength(512)]
        public string Address { get; set; }

        [Required]
        [StringLength(64)]
        public string ProductName { get; set; }

        [Required]
        [StringLength(64)]
        public string Model { get; set; }

        [Required]
        [StringLength(64)]
        public string PurchasedFrom { get; set; }

        [Required]
        [StringLength(512)]
        public string InvoiceURL { get; set; }

        [Required]
        [StringLength(512)]
        public string SSURL { get; set; }

        [StringLength(50)]
        public string PurchaseDate { get; set; }

        public DateTime? CreatedOn { get; set; }
    }
}
