using AutoMapper;
using MediatR;
using MRT.CardManagement.Application.Contracts.Persistence;
using MRT.CardManagement.Application.DTOs;
using MRT.CardManagement.Application.Features.CardType.Requests.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MRT.CardManagement.Application.Features.CardType.Handlers.Queries
{
    public class GetCardTypeDetailRequestHandler : IRequestHandler<GetCardTypeDetailRequest, CardTypeDto>
    {
        private readonly IMapper _mapper;
        private readonly ICardTypeRepository _cardType;
        public GetCardTypeDetailRequestHandler(IMapper mapper, ICardTypeRepository cardType)
        {
            _mapper = mapper;
            _cardType = cardType;
        }

        public async Task<CardTypeDto> Handle(GetCardTypeDetailRequest request, CancellationToken cancellationToken)
        {
            var cardType = await _cardType.Get(request.Id);

            return _mapper.Map<CardTypeDto>(cardType);
        }
    }
}
