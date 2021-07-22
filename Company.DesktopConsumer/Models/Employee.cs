using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.DesktopConsumer.Models
{
    class Employee
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public Decimal Salary { get; set; }
        public int DeptId { get; set; }
    }
}
