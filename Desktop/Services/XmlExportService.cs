using System;
using System.IO;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Desktop.Services
{
    internal class XmlExportService : IFileExportService
    {
        public Task<bool> Export(string path, object data)
        {
            return Task.Run(() =>
            {
                try
                {
                    if (File.Exists(path)) File.Delete(path);

                    using (var stream = File.Create(path))
                    {
                        var serializer = new DataContractSerializer(data.GetType());
                        serializer.WriteObject(stream, data);
                    }

                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            });
        }
    }
}
