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
    public class GetCardListRequestHandler : IRequestHandler<GetCardListRequest, List<CardDto>>
    {
        private readonly IMapper _mapper;
        private readonly ICardRepository _cardRepository;
        public GetCardListRequestHandler(IMapper mapper, ICardRepository cardRepository)
        {
            _mapper = mapper;
            _cardRepository = cardRepository;
        }
        public async Task<List<CardDto>> Handle(GetCardListRequest request, CancellationToken cancellationToken)
        {
            var cards = await _cardRepository.GetAll();
            return _mapper.Map<List<CardDto>>(cards);
        }
    }
}
