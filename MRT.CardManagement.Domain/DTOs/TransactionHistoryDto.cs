using MRT.CardManagement.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MRT.CardManagement.Application.DTOs
{
    public class TransactionHistoryDto : BaseDto
    {
        public CardDto Card { get; set; }
        public DateTime DateOfTransaction { get; set; }
        public string TransactionStatus { get; set; }
    }
}
