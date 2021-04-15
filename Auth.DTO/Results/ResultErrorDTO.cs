using System;
using System.Collections.Generic;
using System.Text;

namespace Auth.DTO.Results
{
    public class ResultErrorDTO : ResultDTO
    {
        public List<string> Errors { get; set; }
    }
}
