using MRT.CardManagement.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MRT.CardManagement.Application.Features.Card.Handlers.Commands
{
    public static class CommonCardEntryFunctions
    {

        private const string SENIOR_CITIZEN_ID = "Senior Citizen ID";
        private const string PWD_ID = "Pwd ID";

        private const string QLESS_DISCOUNT = "Q-Less Discount Transport Card";
        private const string QLESS_BASIC = "Q-Less Transport Card";
        public static DateTime GetNewExpirationDate(CardTypeDto cardTypeDto)
        {
            DateTime expirationDate = DateTime.Now;

            if (cardTypeDto.Name == QLESS_DISCOUNT)
            {
                expirationDate = DateTime.Now.AddYears(cardTypeDto.Validity);
            }
            else if (cardTypeDto.Name == QLESS_BASIC)
            {
                expirationDate = DateTime.Now.AddYears(cardTypeDto.Validity);
            }

            return expirationDate;
        }
    }
}
