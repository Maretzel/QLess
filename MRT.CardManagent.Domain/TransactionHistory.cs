using MRT.CardManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MRT.CardManagement.Domain
{
    public class TransactionHistory : BaseDomainEntity
    {
        public Card Card { get; set; }
        public DateTime DateOfTransaction { get; set; }
        public string TransactionStatus { get; set; }
    }
}
