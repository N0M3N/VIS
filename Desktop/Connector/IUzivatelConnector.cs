using Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace Desktop.Connector
{
    internal interface IUzivatelConnector
    {
        Task<UzivatelModel> Login(string login, string password);
    }

    internal class UzivatelConnector : BaseConnector, IUzivatelConnector
    {
        public Task<UzivatelModel> Login(string login, string password)
        {
            using (var client = new HttpClient())
            {
                return TryHttpPostAs<string, UzivatelModel>(client, $"{WebApiUrl}/api/login/{login}", password );
            }
        }
    }
}
