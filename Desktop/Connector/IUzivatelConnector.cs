using Models;
using System.Threading.Tasks;

namespace Desktop.Connector
{
    internal interface IUzivatelConnector
    {
        Task<UzivatelModel> Login(LoginModel creds);
    }
}
