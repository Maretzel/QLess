using AutoMapper;
using MediatR;
using MRT.CardManagement.Application.Contracts.Persistence;
using MRT.CardManagement.Application.DTOs;
using MRT.CardManagement.Application.Features.TransactionHistory.Requests.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MRT.CardManagement.Application.Features.TransactionHistory.Handlers.Queries
{
    public class GetTransactionDetailRequestHandler : IRequestHandler<GetTransactionDetailRequest, TransactionHistoryDto>
    {
        private readonly IMapper _mapper;
        private readonly ITransactionHistoryRepository _transactionHistoryRepository;
        public GetTransactionDetailRequestHandler(IMapper mapper, ITransactionHistoryRepository transactionHistoryRepository)
        {
            _mapper = mapper;
            _transactionHistoryRepository = transactionHistoryRepository;
        }
        public async Task<TransactionHistoryDto> Handle(GetTransactionDetailRequest request, CancellationToken cancellationToken)
        {
            var transactionHistory = await _transactionHistoryRepository.Get(request.Id);
            return _mapper.Map<TransactionHistoryDto>(transactionHistory);
        }
    }
}
