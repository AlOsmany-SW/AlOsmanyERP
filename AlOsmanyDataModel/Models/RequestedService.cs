using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace AlOsmanyDataModel.Models
{
    [Table("RequestedService")]
    public class RequestedService
    {
        public RequestedService() { }
        public RequestedService(Service service)
        {
            Name = service.Name;
            Fees = service.Fees;
            Discount = service.Discount;
            Surcharge = service.Surcharge;
            Notes = service.Notes;
            Image = service.Image;

            CreatedAt = DateTime.UtcNow;
            ServiceId = service.Id;
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

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public int ServiceId { get; set; }

        [Required]
        public int RequestId { get; set; }

        public string Notes { get; set; }
        public string Image { get; set; }
    }
}
