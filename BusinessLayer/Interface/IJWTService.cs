using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    /// <summary>
    /// Interface for JWT service that provides functionality to generate JWT tokens.
    /// </summary>
    public interface IJwtService
    {
        string GenerateToken(UserEntity user);
    }
}
