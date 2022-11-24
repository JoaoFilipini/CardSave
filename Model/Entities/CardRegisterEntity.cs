using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardSave.Model
{
    public class CardRegisterEntity
    {
        [ForeignKey("Id")]
        public int Id { get; set; }
        public long Token { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
