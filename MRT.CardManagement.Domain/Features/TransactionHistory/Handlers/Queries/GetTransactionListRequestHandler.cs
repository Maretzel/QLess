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
    public class GetTransactionListRequestHandler : IRequestHandler<GetTransactionListRequest, List<TransactionHistoryDto>>
    {
        private readonly IMapper _mapper;
        private readonly ITransactionHistoryRepository _transactionHistoryRepository;
        public GetTransactionListRequestHandler(IMapper mapper, ITransactionHistoryRepository transactionHistoryRepository)
        {
            _mapper = mapper;
            _transactionHistoryRepository = transactionHistoryRepository;
        }
        public async Task<List<TransactionHistoryDto>> Handle(GetTransactionListRequest request, CancellationToken cancellationToken)
        {
            var transactionHistory = await _transactionHistoryRepository.GetAll();
            return _mapper.Map<List<TransactionHistoryDto>>(transactionHistory);
        }
    }
}
