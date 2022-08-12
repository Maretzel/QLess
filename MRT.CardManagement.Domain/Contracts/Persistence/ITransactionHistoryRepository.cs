using MRT.CardManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MRT.CardManagement.Application.Contracts.Persistence
{
    public interface ITransactionHistoryRepository : IGenericRepository<TransactionHistory>
    {
    }
}
