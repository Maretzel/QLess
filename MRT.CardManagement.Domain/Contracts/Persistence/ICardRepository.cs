using MRT.CardManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MRT.CardManagement.Application.Contracts.Persistence
{
    public interface ICardRepository : IGenericRepository<Card>
    {
        Task<Card> GetCardDetails(int id);
    }
}
