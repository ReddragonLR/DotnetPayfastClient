using PayfastClient.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PayfastClient.Models.Common
{
    public abstract class ModelBase
    {
        public ModelBase(string passphrase)
        {
            Passphrase = passphrase;
        }

        public string Passphrase { get; }

        public List<ChecksumComponent> ExtractChecksumValues()
        {
            List<ChecksumComponent> result = new List<ChecksumComponent>();

            // Using reflection, get properties with the CustomStringAttribute attribute.
            IEnumerable<PropertyInfo> propertiesWithAttribute = this.GetType()
                                              .GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                                              .Where(prop => prop.GetCustomAttribute<PartOfChecksumAttribute>() != null);
            foreach (var prop in propertiesWithAttribute)
            {
                var name = prop.Name;
                var value = prop.GetValue(this).ToString();
                if(!string.IsNullOrEmpty(value))
                {
                    result.Add(new ChecksumComponent(name, value));
                }
            }
            return result;
        }

        private string ExtractChecksumValuesString()
        {
            StringBuilder sb = new StringBuilder();
            var input = ExtractChecksumValues();
            foreach(var prop in input)
            {
                sb.Append($"{prop}&");
            }
            var result = sb.ToString();
            result = result.Remove(result.LastIndexOf("&"));
            return result;
        }

        public string ExtractChecksumValuesStringUrlEncodedMD5()
        {
            var md5 = ChecksumHelper.CreateMD5($"{ExtractChecksumValuesString()}&passphrase={Passphrase}");
            return HttpUtility.UrlEncode(md5, Encoding.UTF8).ToUpperInvariant();
        }
    }

    public class ChecksumComponent
    {
        public ChecksumComponent(string name, string value)
        {
            Name = name;
            Value = value;
        }
        public string Name { get; }
        public string Value { get; }
        public override string ToString()
        {
            return $"{Name}={Value}";
        }
    }
}
