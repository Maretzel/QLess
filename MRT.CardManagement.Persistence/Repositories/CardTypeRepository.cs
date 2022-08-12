using Microsoft.EntityFrameworkCore;
using MRT.CardManagement.Application.Contracts.Persistence;
using MRT.CardManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MRT.CardManagement.Persistence.Repositories
{
    public class CardTypeRepository : GenericRepository<CardType>, ICardTypeRepository
    {
        private readonly CardManagementDbContext _dbContext;
        public CardTypeRepository(CardManagementDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        async Task<CardType> GetCardTypeDetails(int id)
        {
            var cardType = await _dbContext.CardType
                .FirstOrDefaultAsync(q => q.Id == id);

            return cardType;
        }

    }
}
