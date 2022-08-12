using MediatR;
using MRT.CardManagement.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MRT.CardManagement.Application.Features.TransactionHistory.Requests.Queries
{
    public class GetTransactionDetailRequest : IRequest<TransactionHistoryDto>
    {
        public int Id { get; set; }
    }
}
