using MediatR;
using MRT.CardManagement.Application.DTOs;
using MRT.CardManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace MRT.CardManagement.Application.Features.Card.Requests.Commands
{
    public class CreateCardEntryCommand : IRequest<BaseCommandResponse>
    {
        public CardDto CardDto;
    }
}
