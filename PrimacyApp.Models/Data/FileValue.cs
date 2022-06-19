using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimacyApp.Models.Data
{
    public class FileValue
    {
        public string Name { get; set; }
        public string Value { get; set; }

        public FileValue(string name, string value)
        {
            Name = name;
            Value = value;
        }
    }
}
