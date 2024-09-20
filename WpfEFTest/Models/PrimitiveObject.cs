using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfEFTest.Models
{
    public class PrimitiveObject
    {
        [Key]
        public int Id { get; set; } // 기본 키
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;

    }
}
