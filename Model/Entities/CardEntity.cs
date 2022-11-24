using System.ComponentModel.DataAnnotations;

namespace CardSave.Model
{
    public class CardEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public long CardNumber { get; set; }
        [Required]
        public int CVV { get; set; }
    }
}
