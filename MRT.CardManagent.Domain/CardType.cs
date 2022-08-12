using MRT.CardManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MRT.CardManagement.Domain
{
    public class CardType : BaseDomainEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int InitialLoad { get; set; }
        public int Validity { get; set; }
    }
}
