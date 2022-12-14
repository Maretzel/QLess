using MediatR;
using MRT.CardManagement.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MRT.CardManagement.Application.Features.CardType.Requests.Queries
{
    public class GetCardTypeDetailRequest : IRequest<CardTypeDto>
    {
        public int Id { get; set; }
    }
}
