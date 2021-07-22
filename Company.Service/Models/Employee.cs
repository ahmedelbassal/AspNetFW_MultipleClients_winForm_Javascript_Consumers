using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Company.Service.Models
{
    //[DataContract]
    public class Employee
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public Decimal Salary { get; set; }

        [ForeignKey("Department")]
        public int DeptId { get; set; }

        //[IgnoreDataMember]

        //[JsonIgnore]
        public virtual Department Department { get; set; }
        //public Department Department { get; set; }
    }
}