using CardSave.Model;
using CardSave.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CardSave.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly ICardRepository _cardRepository;

        public CardController(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CardRequest input)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = await _cardRepository.InsertCard(input);
            return Ok(result);
        }

        [HttpGet]
        [Route(template: "card-register/{cardId}")]
        public async Task<IActionResult> GetCardRegister([FromRoute] int cardId)
        {
            var result = await _cardRepository.GetCardRegister(cardId);

            return result == null ? NotFound() : Ok(result);
        }

        [HttpGet]
        [Route(template: "card/{cardId}")]
        public async Task<IActionResult> GetCard([FromRoute] int cardId)
        {
            var result = await _cardRepository.GetCard(cardId);

            return result == null ? NotFound() : Ok(result);
        }
    }
}
