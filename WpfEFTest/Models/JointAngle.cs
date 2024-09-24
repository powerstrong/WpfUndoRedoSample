using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfEFTest.Models
{
    public class JointAngle
    {
        public JointAngle(double j1, double j2, double j3, double j4, double j5, double j6)
        {
            J1 = j1;
            J2 = j2;
            J3 = j3;
            J4 = j4;
            J5 = j5;
            J6 = j6;
        }

        [Key]
        public int Id { get; set; } // 기본 키
        public double J1 { get; set; }
        public double J2 { get; set; }
        public double J3 { get; set; }
        public double J4 { get; set; }
        public double J5 { get; set; }
        public double J6 { get; set; }
    }
}
