using System;
using System.Collections.Generic;
using System.Text;

namespace MRT.CardManagement.Application.Responses
{
    public class BaseCommandResponse
    {

        public int Id { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; } = true;
        public List<string> Errors { get; set; }
    }
}
