using Company.Service.Models;
using System;
using System.Data.Entity;
using System.Linq;

namespace Company.Service.Context
{
    public class CompanyContext : DbContext
    {
        
        public CompanyContext()
            : base("name=CompanyDB")
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}