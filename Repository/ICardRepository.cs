using CardSave.Model;
using System;
using System.Threading.Tasks;

namespace CardSave.Repository
{
    public interface ICardRepository
    {
        Task<CardResponse> InsertCard(CardRequest input);

        Task<CardRegisterEntity> GetCardRegister(int cardId);
        Task<CardEntity> GetCard(int cardId);
    }
}
