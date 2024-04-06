using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlOsmanyDataModel.Models
{
    [Table("User")]
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, Index(IsUnique = true), StringLength(50)]
        public string UserName { get; set; }
        [Required, StringLength(50)]
        public string Password { get; set; }

        [Required, StringLength(100)]
        public string FullName { get; set; }

        [Required]
        public UserRole Role { get; set; }

        public string PhoneNumber { get; set; }
        public string Image { get; set; }
    }

    public enum UserRole
    {
        Admin,
        Manager,
        Worker,
        Customer
    }
}