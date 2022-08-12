using MRT.CardManagement.Application.Contracts.Persistence;
using MRT.CardManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MRT.CardManagement.Persistence.Repositories
{
    public class TransactionHistoryRepository : GenericRepository<TransactionHistory>, ITransactionHistoryRepository
    {
        private readonly CardManagementDbContext _dbContext;
        public TransactionHistoryRepository(CardManagementDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

       
    }
}
