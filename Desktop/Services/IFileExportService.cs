using System.Threading.Tasks;

namespace Desktop.Services
{
    internal interface IFileExportService
    {
        Task<bool> Export(string path, object data);
    }
}
