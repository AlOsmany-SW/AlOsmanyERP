using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlOsmanyDataModel.Models
{
    [Table("Service")]
    public class Service
    {
        public Service() { }
        public Service(Service service)
        {
            Name = service.Name;
            Fees = service.Fees;
            Discount = service.Discount;
            Surcharge = service.Surcharge;
            Notes = service.Notes;
            Image = service.Image;
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        [Required]
        public decimal Fees { get; set; }
        [Required]
        public decimal Discount { get; set; }
        [Required]
        public decimal Surcharge { get; set; }

        public string Notes { get; set; }
        public string Image { get; set; }
    }
}