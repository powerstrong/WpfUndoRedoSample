using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfEFTest.Models
{
    public enum DataClass
    {
        JointAngle = 1,
        PrimitiveObject = 2
    }

    public class BaseData
    {
        [Key]
        public int Id { get; set; }
        public DataClass Class { get; set; }
    }
}
