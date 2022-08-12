using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MRT.CardManagement.Application.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        ICardRepository CardRepository { get; }
     
        Task Save();
    }
}
