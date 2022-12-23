using Log.Accenture.Domain.Interfaces.Persistence;
using System.Reflection;
using System.Xml.Linq;

namespace Log.Accenture.Infra.Logs.Persistence
{
    public class LogSystemPersistence : ILogSystemPersistence
    {
        public List<string> ReadFile()
        {
            //string path = @"C:\Accenture\BackEnd\Log.Accenture\Log.Accenture.Infra.Logs\Logs\auth.log";
            string path = "Logs/auth.log";
            string[] lines = System.IO.File.ReadAllLines(path);

            return lines.ToList();

        }
    }
}
