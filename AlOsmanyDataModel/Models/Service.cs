using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlOsmanyDataModel.Models
{
    [Table("Service")]
    public class Service
    {
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