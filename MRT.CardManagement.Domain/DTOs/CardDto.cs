using MRT.CardManagement.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MRT.CardManagement.Application.DTOs
{
    public class CardDto : BaseDto
    {
        public string AccountNumber { get; set; }
        public CardTypeDto CardType { get; set; }
        public DateTime? Activated { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public int LoadBalance { get; set; }
        public string DiscountId { get; set; }
        public string DiscountIdType { get; set; }
        public int CardTypeId { get; set; }
    }
}
