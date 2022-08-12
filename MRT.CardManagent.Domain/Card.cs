using MRT.CardManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MRT.CardManagement.Domain
{
    public class Card : BaseDomainEntity
    {
        public string AccountNumber { get; set; }
        public CardType CardType { get; set; }
        public DateTime? Activated { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public int LoadBalance { get; set; }
        public string DiscountId { get; set; }
        public string DiscountIdType { get; set; }
        public int CardTypeId { get; set; }
    }
}
