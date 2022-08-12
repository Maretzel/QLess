using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MRT.CardManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MRT.CardManagement.Persistence.Configurations.Entities
{
    public class TransactionHistoryConfiguration : IEntityTypeConfiguration<TransactionHistory>
    {
        public void Configure(EntityTypeBuilder<TransactionHistory> builder)
        {
        }
    }
}
