using AutoMapper;
using MediatR;
using MRT.CardManagement.Application.Contracts.Persistence;
using MRT.CardManagement.Application.Features.CardType.Requests.Commands;
using MRT.CardManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MRT.CardManagement.Application.Features.CardType.Handlers.Commands
{
    public class CreateCardTypeCommandHandler : IRequestHandler<CreateCardTypeCommand, BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICardTypeRepository _cardTypeRepository;
        public CreateCardTypeCommandHandler(ICardTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _cardTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(CreateCardTypeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var cardType = _mapper.Map<MRT.CardManagement.Domain.CardType>(request.CardTypeDto);
            cardType = await _cardTypeRepository.Add(cardType);

            response.Success = true;
            response.Message = "Creation Failed";
            response.Id = cardType.Id;
            return response;
        }
    }
}
