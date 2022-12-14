using MediatR;
using MRT.CardManagement.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MRT.CardManagement.Application.Features.Card.Requests.Queries
{
    public class GetCardDetailRequest : IRequest<CardDto>
    {
        public int Id { get; set; }
    }
}
