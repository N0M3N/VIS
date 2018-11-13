using Models;
using System.Threading.Tasks;

namespace Desktop.Connector
{
    internal class UzivatelConnector : BaseConnector, IUzivatelConnector
    {
        public Task<UzivatelModel> Login(LoginModel creds)
        {
            return TryHttpPostAs<LoginModel, UzivatelModel>($"{WebApiUrl}/api/login", creds);
        }
    }
}
