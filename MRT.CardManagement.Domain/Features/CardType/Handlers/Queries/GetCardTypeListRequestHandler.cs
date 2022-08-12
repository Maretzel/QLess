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
    public class GetCardTypeListRequestHandler : IRequestHandler<GetCardTypeListRequest, List<CardTypeDto>>
    {
        private readonly IMapper _mapper;
        private readonly ICardTypeRepository _cardType;
        public GetCardTypeListRequestHandler(IMapper mapper, ICardTypeRepository cardType)
        {
            _mapper = mapper;
            _cardType = cardType;
        }
        public async Task<List<CardTypeDto>> Handle(GetCardTypeListRequest request, CancellationToken cancellationToken)
        {
            var cardTypes = await _cardType.GetAll();
            return _mapper.Map<List<CardTypeDto>>(cardTypes);
        }
    }
}
