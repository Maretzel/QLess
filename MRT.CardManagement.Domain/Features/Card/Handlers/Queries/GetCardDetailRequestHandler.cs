using AutoMapper;
using MediatR;
using MRT.CardManagement.Application.Contracts.Persistence;
using MRT.CardManagement.Application.DTOs;
using MRT.CardManagement.Application.Features.Card.Requests.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MRT.CardManagement.Application.Features.Card.Handlers.Queries
{
    public class GetCardDetailRequestHandler : IRequestHandler<GetCardDetailRequest, CardDto>
    {
        private readonly IMapper _mapper;
        private readonly ICardRepository _cardRepository;
        public GetCardDetailRequestHandler(IMapper mapper, ICardRepository cardRepository)
        {
            _mapper = mapper;
            _cardRepository = cardRepository;
        }
        public async Task<CardDto> Handle(GetCardDetailRequest request, CancellationToken cancellationToken)
        {
            var card = await _cardRepository.Get(request.Id);
            return _mapper.Map<CardDto>(card);
        }
    }
}
