using MediatR;
using MRT.CardManagement.Application.DTOs;
using MRT.CardManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace MRT.CardManagement.Application.Features.CardType.Requests.Commands
{
    public class CreateCardTypeCommand : IRequest<BaseCommandResponse>
    {
        public CardTypeDto CardTypeDto { get; set; }
    }
}
