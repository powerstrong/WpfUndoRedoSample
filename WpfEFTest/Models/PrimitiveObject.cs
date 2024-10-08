using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfEFTest.Models
{
    public class PrimitiveObject : BaseData
    {
        public PrimitiveObject(string name, string type)
        {
            Name = name;
            Type = type;
        }

        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;

    }
}
