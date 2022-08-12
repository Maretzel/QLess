using MediatR;
using MRT.CardManagement.Application.DTOs;
using MRT.CardManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace MRT.CardManagement.Application.Features.Card.Requests.Commands
{
    public class UpdateCardEntryCommand : IRequest<BaseCommandResponse>
    {
       public int Id { get; set; }
       public string TransactionType { get; set; }
       public int LoadAmount { get; set; }
    }
}
