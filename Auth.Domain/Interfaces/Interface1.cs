using Auth.DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auth.Domain.Interfaces
{
   public interface IJWTTokenService
    {
        string CreateToken(User user);
    }
}
