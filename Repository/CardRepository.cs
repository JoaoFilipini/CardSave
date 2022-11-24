using CardSave.DBContexts;
using CardSave.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardSave.Repository
{
    public class CardRepository : ICardRepository
    {
        private readonly AppDbContext _dbContext;

        public CardRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CardResponse> InsertCard(CardRequest input)
        {
            var request = new CardEntity
            {
                CardNumber = input.CardNumber,
                CustomerId = input.CustomerId,
                CVV = input.CVV
            };

            await _dbContext.AddAsync(request);
            await _dbContext.SaveChangesAsync();

            var result = await SaveCardRegister(request);

            return result;
        }

        public async Task<CardRegisterEntity> GetCardRegister(int cardId)
        {
            var result = await _dbContext.CardRegister.AsNoTracking().FirstOrDefaultAsync(x => x.Id == cardId);

            return result;
        }

        public async Task<CardEntity> GetCard(int cardId)
        {
            var result = await _dbContext.Card.AsNoTracking().FirstOrDefaultAsync(x => x.Id == cardId);

            return result;
        }

        private async Task<CardResponse> SaveCardRegister(CardEntity model)
        {
            var cardResponse = new CardRegisterEntity
            {
                Id = model.Id,
                RegistrationDate = DateTime.Now,
                Token = GenerateToken(model.CVV, model.CardNumber),
            };

            await _dbContext.AddAsync(cardResponse);
            await _dbContext.SaveChangesAsync();

            var result = new CardResponse
            {
                CardId = cardResponse.Id,
                RegistrationDate = cardResponse.RegistrationDate,
                Token = cardResponse.Token
            };

            return result;
        }

        private static int MathMod(int a, int b)
        {
            int c = ((a % b) + b) % b;
            return c;
        }
        private static IEnumerable<T> ShiftRight<T>(IList<T> values, int shift)
        {
            for (int index = 0; index < values.Count; index++)
            {
                yield return values[MathMod(index - shift, values.Count)];
            }
        }

        private static long GenerateToken(int cvv, long cardNumber)
        {
            var lastFourDigitsCardNumber = cardNumber.ToString()[Math.Max(0, cardNumber.ToString().Length - 4)..];

            var intList = lastFourDigitsCardNumber.Select(x => Convert.ToInt32(x.ToString())).ToList();

            var convert = ShiftRight(intList, cvv);

            var result = int.Parse(string.Join(",", convert).Replace(",", ""));

            return Convert.ToInt64(result);
        }
    }
}
