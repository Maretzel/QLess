using MRT.CardManagement.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MRT.CardManagement.Application.DTOs
{
    public class CardTypeDto : BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int InitialLoad { get; set; }
        public int Validity { get; set; }
    }
}
