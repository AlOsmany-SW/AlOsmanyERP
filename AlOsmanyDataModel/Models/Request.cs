using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System;

namespace AlOsmanyDataModel.Models
{
    [Table("Request")]
    public class Request
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, DefaultValue(RequestType.New)]
        public RequestType Type { get; set; }
        [Required]
        public decimal TotalFees { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public int CreatedBy { get; set; }

        public int? WorkerId { get; set; }
    }

    public enum RequestType
    {
        New,
        Assigned,
        InProgress,
        Completed
    }
}