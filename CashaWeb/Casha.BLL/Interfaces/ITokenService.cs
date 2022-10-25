using Casha.Core.DbModels;

namespace Casha.BLL.Interfaces
{
    public interface ITokenService
    {
        public string GenerateToken(User user, IList<string> roles);
    }
}
