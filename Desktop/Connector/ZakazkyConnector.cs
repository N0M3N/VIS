using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Models;

namespace Desktop.Connector
{
    internal class ZakazkyConnector : BaseConnector, IZakazkyConnector
    {
        public async Task<IEnumerable<ZakazkaModel>> GetAllByUserAsync(UzivatelModel currentUser)
        {
            using(var client = new HttpClient())
            {
                return await TryHttpRequestAs<IEnumerable<ZakazkaModel>>(client, $"{WebApiUrl}/api/zakazka/{currentUser.Id}");
            }
        }
    }
}
