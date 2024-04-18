using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace AlOsmanyDataModel.Models
{
    [Table("RequestedService")]
    public class RequestedService
    {
        public RequestedService() { }
        public RequestedService(Service service, int count, bool urgent)
        {
            Name = service.Name;
            Count = count;
            Urgent = urgent;
            Fees = service.Fees * count;
            Discount = service.Discount * count;
            Surcharge = service.Surcharge * count;
            Notes = service.Notes;
            Image = service.Image;

            if (count >= 100)
                Discount += (Fees * 10 / 100);

            if (urgent)
                Surcharge += (Fees * 30 / 100);

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
        public int Count { get; set; }
        [Required]
        public bool Urgent { get; set; }

        [Required]
        public int ServiceId { get; set; }

        [Required]
        public int RequestId { get; set; }

        public string Notes { get; set; }
        public string Image { get; set; }
    }
}
