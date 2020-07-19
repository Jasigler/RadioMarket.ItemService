using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Entities
{
    public class Item
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int item_id { get; set; }

        [Required]
        public int item_owner { get; set; }

        [Required]
        public int category { get; set; }

        [Required]
        [MaxLength(50)]
        public string title { get; set; }

        [Required]
        [MaxLength(255)]
        public string description { get; set; }

        [Required]
        public int item_condition { get; set; }

        [Required]
        public int item_status { get; set; }

        [Required]
        [MaxLength(10)]
        public string price { get; set; }

    }
}
