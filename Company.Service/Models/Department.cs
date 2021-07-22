using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Company.Service.Models
{
    //[DataContract]
    public class Department
    {
        [Key]
        public int DeptId { get; set; }
        public String Name { get; set; }


        //public virtual ICollection<Employee> Employees { get; set; }
        //    = new HashSet<Employee>();

        /// [IgnoreDataMember]

        //[JsonIgnore]  // if i just want to end up here means that get employee with department and stop not returning
        // department employees
        [JsonIgnore]
        public virtual ICollection<Employee> Employees { get; set; }
            = new HashSet<Employee>();
    }
}