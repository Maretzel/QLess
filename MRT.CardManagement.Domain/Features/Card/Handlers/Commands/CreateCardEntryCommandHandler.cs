using AutoMapper;
using MediatR;
using MRT.CardManagement.Application.Contracts.Persistence;
using MRT.CardManagement.Application.DTOs;
using MRT.CardManagement.Application.Features.Card.Requests.Commands;
using MRT.CardManagement.Application.Responses;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace MRT.CardManagement.Application.Features.Card.Handlers.Commands
{
    public class CreateCardEntryCommandHandler : IRequestHandler<CreateCardEntryCommand, BaseCommandResponse>
    {

        private readonly IMapper _mapper;
        private readonly ICardRepository _cardRepository;
        private readonly ICardTypeRepository _cardTypeRepository;

        private const string SENIOR_CITIZEN_ID = "Senior Citizen ID";
        private const string PWD_ID = "Pwd ID";

        private const int QLESS_DISCOUNT = 2;
        private const int QLESS_BASIC = 1;

        public CreateCardEntryCommandHandler(ICardRepository cardRepository, 
            IMapper mapper, ICardTypeRepository cardTypeRepository)
        {
            _cardRepository = cardRepository;
            _cardTypeRepository = cardTypeRepository;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(CreateCardEntryCommand request, CancellationToken cancellationToken)
        {

            var response = new BaseCommandResponse();
            var card = _mapper.Map<MRT.CardManagement.Domain.Card>(request.CardDto);
        
            var result = true;
            if (card.CardTypeId == QLESS_DISCOUNT)
            {
                result = CheckValidDiscountId(request.CardDto);
            } 

            if (result)
            {  
                await _cardRepository.Add(card);
                response.Success = true;
                response.Message = "Successfully added new card";
            } else
            {
                card.LoadBalance = card.CardType.InitialLoad;
                card.Activated = DateTime.UtcNow;
                card.ExpirationDate = GetNewExpirationDate(request.CardDto);
                response.Message = "Error encountered in adding the card";
                response.Success = false;
            }

            return response;
        }

        public bool CheckValidDiscountId(CardDto cardDto)
        {
            bool result;
            if (cardDto.DiscountId == null)
            {
                result = false;
            } else
            {
                result = ValidateIdFormat(cardDto);
            }
            return result;
        }

        public bool ValidateIdFormat(CardDto cardDto)
        {
            bool result = false;

            if (cardDto.DiscountIdType == SENIOR_CITIZEN_ID)
            {
                result = Regex.IsMatch(cardDto.DiscountId, "^\\d{2}-\\d{4}-\\d{4}$");
            } else if (cardDto.DiscountIdType == PWD_ID)
            {
                result = Regex.IsMatch(cardDto.DiscountId, "^\\d{4}-\\d{4}-\\d{4}$");
            }
            return result;
        }

        public DateTime GetNewExpirationDate(CardDto card)
        {
            DateTime expirationDate = DateTime.Now;

            if (card.CardTypeId == QLESS_DISCOUNT)
            {
                expirationDate = DateTime.Now.AddYears(card.CardType.Validity);
            }
            else if (card.CardTypeId == QLESS_BASIC)
            {
                expirationDate = DateTime.Now.AddYears(card.CardType.Validity);
            }

            return expirationDate;
        }
    }
}
