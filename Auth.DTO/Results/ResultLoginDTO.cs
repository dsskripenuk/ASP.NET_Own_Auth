using System;
using System.Collections.Generic;
using System.Text;

namespace Auth.DTO.Results
{
    public class ResultLoginDTO : ResultDTO
    {
        public string Token { get; set; }
    }
}
