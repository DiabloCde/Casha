namespace Casha.BLL.Interfaces
{
    public interface ILoginService
    {
        Task<string> Login(string username, string password);
    }
}
