using Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Desktop.Connector
{
    internal class ZakazkyConnector : BaseConnector, IZakazkyConnector
    {
        public async Task<IEnumerable<ZakazkaModel>> GetAllByUserAsync(UzivatelModel currentUser)
        {
            try
            {
                return await TryHttpPostAs<UzivatelModel, IEnumerable<ZakazkaModel>>($"{WebApiUrl}/zakazka", currentUser);
            }
            catch (Exception e)
            {
                throw new ConnectionFailedException(nameof(GetAllByUserAsync), e);
            }
        }
    }
}
