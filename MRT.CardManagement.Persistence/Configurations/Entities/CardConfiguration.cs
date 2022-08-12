using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MRT.CardManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MRT.CardManagement.Persistence.Configurations.Entities
{

    public class CardConfiguration : IEntityTypeConfiguration<Card>
    {
        private const string SENIOR_CITIZEN_ID = "Senior Citizen ID";
        private const string PWD_ID = "Pwd ID";

        private const string QLESS_DISCOUNT = "Q-Less Discount Transport Card";
        private const string QLESS_BASIC = "Q-Less Transport Card";

        public void Configure(EntityTypeBuilder<Card> builder)
        {
            CardType cardType_basic = new CardType
            {
                Id = 1,
                Name = QLESS_BASIC,
                Validity = 5,
                InitialLoad = 500
            };

            CardType cardType_discount = new CardType
            {
                Id = 1,
                Name = QLESS_DISCOUNT,
                Validity = 3,
                InitialLoad = 300
            };

            builder.HasData(
                new Card
                {
                    Id = 1,
                    AccountNumber = "5555-1111-1111",
                    CardTypeId = 1,
                    Activated = DateTime.Today,
                    ExpirationDate = DateTime.Today.AddYears(5),
                    LoadBalance = 100
                },
                new Card
                {
                    Id = 2,
                    AccountNumber = "5555-2222-2222",
                    CardTypeId = 1,
                    Activated = DateTime.Today,
                    ExpirationDate = DateTime.Today.AddYears(5),
                    LoadBalance = 100
                },
                new Card
                {
                    Id = 3,
                    AccountNumber = "5555-3333-3333",
                    CardTypeId = 1,
                    Activated = DateTime.Today,
                    ExpirationDate = DateTime.Today.AddYears(5),
                    LoadBalance = 100
                },
                new Card
                {
                    Id = 4,
                    AccountNumber = "5555-4444-4444",
                    CardTypeId = 1,
                    Activated = DateTime.Today,
                    ExpirationDate = DateTime.Today.AddYears(5),
                    LoadBalance = 100
                },
                new Card
                {
                    Id = 5,
                    AccountNumber = "5555-5555-5555",
                    CardTypeId = 2,
                    Activated = DateTime.Today,
                    ExpirationDate = DateTime.Today.AddYears(3),
                    LoadBalance = 100,
                    DiscountIdType = SENIOR_CITIZEN_ID,
                    DiscountId = "11-1111-1111"
                },
                new Card
                {
                    Id = 6,
                    AccountNumber = "5555-6666-6666",
                    CardTypeId = 2,
                    Activated = DateTime.Today,
                    ExpirationDate = DateTime.Today.AddYears(3),
                    LoadBalance = 100,
                    DiscountIdType = PWD_ID,
                    DiscountId = "2222-2222-2222"
                },
                new Card
                {
                    Id = 7,
                    AccountNumber = "5555-7777-7777",
                    CardTypeId = 2,
                    Activated = DateTime.Today,
                    ExpirationDate = DateTime.Today.AddYears(3),
                    LoadBalance = 100,
                    DiscountIdType = SENIOR_CITIZEN_ID,
                    DiscountId = "33-3333-3333"
                },
                new Card
                {
                    Id = 8,
                    AccountNumber = "5555-8888-8888",
                    CardTypeId = 2,
                    Activated = DateTime.Today,
                    ExpirationDate = DateTime.Today.AddYears(3),
                    LoadBalance = 100,
                    DiscountIdType = PWD_ID,
                    DiscountId = "4444-4444-4444"
                }
            );
        }
    }
}
