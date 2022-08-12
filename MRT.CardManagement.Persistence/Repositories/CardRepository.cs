using Microsoft.EntityFrameworkCore;
using MRT.CardManagement.Application.Contracts.Persistence;
using MRT.CardManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MRT.CardManagement.Persistence.Repositories
{
    public class CardRepository : GenericRepository<Card>, ICardRepository
    {
        private readonly CardManagementDbContext _dbContext;
        public CardRepository(CardManagementDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Card> GetCardDetails(int id)
        {
            var card = await _dbContext.Card
                .FirstOrDefaultAsync(q => q.Id == id);

            return card;
        }
    }
}
