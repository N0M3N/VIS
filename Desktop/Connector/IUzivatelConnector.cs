using Models;
using System.Threading.Tasks;

namespace Desktop.Connector
{
    internal interface IUzivatelConnector
    {
        Task<UzivatelModel> Login(LoginModel creds);
    }

    internal class UzivatelConnector : BaseConnector, IUzivatelConnector
    {
        public Task<UzivatelModel> Login(LoginModel creds)
        {
            return TryHttpPostAs<LoginModel, UzivatelModel>($"{WebApiUrl}/api/login", creds);
        }
    }
}
