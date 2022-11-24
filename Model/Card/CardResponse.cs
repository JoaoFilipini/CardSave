using System;

namespace CardSave.Model
{
    public class CardResponse
    {
        public DateTime RegistrationDate { get; set; }
        public long Token { get; set; }
        public int CardId { get; set; }
    }
}
