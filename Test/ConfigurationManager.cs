using System.IO;
using System.Xml.Linq;

namespace Test
{
    public class ConfigurationManager
    {
        private Stream _configStream;
        public ConfigurationManager(Stream configStream)
        {
            _configStream = configStream;
        }

        public string Get(string key)
        {
            using (var reader = new StreamReader(_configStream))
            {
                var doc = XDocument.Parse(reader.ReadToEnd());
                return doc.Element("config").Element(key).Value;
            }
        }
    }
}