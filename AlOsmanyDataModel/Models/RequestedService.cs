using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace AlOsmanyDataModel.Models
{
    [Table("RequestedService")]
    public class RequestedService : Service
    {
        public RequestedService() { }
        public RequestedService(Service service) : base(service)
        {
            CreatedAt = DateTime.UtcNow;
            ServiceId = service.Id;
        }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public int ServiceId { get; set; }

        [Required]
        public int RequestId { get; set; }
    }
}
