using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interface
{
    public interface ITokenService
    {
        // Method to create a JWT token for a given user
        string CreateToken(AppUser user);
    }
}