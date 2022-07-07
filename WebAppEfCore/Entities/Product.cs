using System.ComponentModel.DataAnnotations;

namespace WebAppEfCore.Entities
{
    public class Product : BaseEntity
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [ConcurrencyCheck]
        public string Name { get; set; }

        [Required]
        public int Stock { get; set; }
    }
}
