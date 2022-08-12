using MRT.CardManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MRT.CardManagement.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CardManagementDbContext _context;
        private ICardRepository _cardRepository;
        public UnitOfWork(CardManagementDbContext context)
        {
            _context = context;
        }

        ICardRepository IUnitOfWork.CardRepository =>
            _cardRepository ??= new CardRepository(_context);

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
   
}
