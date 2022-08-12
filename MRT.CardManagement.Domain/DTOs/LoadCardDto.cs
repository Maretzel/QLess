using System;
using System.Collections.Generic;
using System.Text;

namespace MRT.CardManagement.Application.DTOs
{
    public class UpdateCardDto
    {
        public int TransactionAmount { get; set; }
        
        public string TransactionType { get; set; }

        public int Id { get; set; }
    }
}
