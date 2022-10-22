using Casha.Core.DbModels;
using Microsoft.IdentityModel.Tokens;

namespace Casha.BLL.Interfaces
{
    public interface ITokenService
    {
        public SecurityTokenDescriptor GenerateToken(User user);
    }
}
