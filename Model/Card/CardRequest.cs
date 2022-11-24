using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CardSave.Model
{
    public class CardRequest : IValidatableObject
    {
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public long CardNumber { get; set; }
        [Required]
        public int CVV { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (CardNumber.ToString().Length > 16)
            {
                yield return new ValidationResult("The maximum number of characters to Card Number is 16", new[] { nameof(CardNumber) });
            }
            if (CVV.ToString().Length > 5)
            {
                yield return new ValidationResult("The maximum number of characters to CVV is 5", new[] { nameof(CVV) });
            }
        }
    }
}
