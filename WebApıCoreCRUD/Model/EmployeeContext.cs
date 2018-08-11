using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApıCoreCRUD.Model
{
    public class EmployeeContext:DbContext
    {
        public DbSet<Employee> EmpTableMy { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseSqlServer(@"Data Source=DESKTOP-42E6ERP;Initial Catalog=EmpDB;Integrated Security=True;");
        }
    }
}
