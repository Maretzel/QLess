using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MRT.CardManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MRT.CardManagement.Persistence.Configurations.Entities
{
    public class CardTypeConfiguration : IEntityTypeConfiguration<CardType>
    {
        public void Configure(EntityTypeBuilder<CardType> builder)
        {
            builder.HasData(
                new CardType
                {
                    Id = 1,
                    Name = "Q-Less Transport Card",
                    Description = "Regular Card",
                    Validity = 5,
                    InitialLoad = 100
                },
                new CardType
                {
                    Id = 2,
                    Name = "Q-Less Discount Transport Card",
                    Description = "Discount Card",
                    Validity = 3,
                    InitialLoad = 500
                }
            );
        }
    }
}
