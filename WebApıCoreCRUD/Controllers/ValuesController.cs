using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApıCoreCRUD.Model;

namespace WebApıCoreCRUD.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        EmployeeContext db = new EmployeeContext();
        [Produces("application/json")]
        [HttpGet("findall")]
        public async Task<IActionResult> Findall()
        {       
            try
            {
                List<Employee> list =  db.EmpTableMy.ToList();
                return Ok(list);
            }
            catch
            {
                return BadRequest();
            }   
        }
        [Produces("application/json")]
        [HttpGet("find/{id}")]
        public async Task<IActionResult> Find(int id)
        {
            try
            {
                Employee emp = db.EmpTableMy.FirstOrDefault(x=>x.EmployeeID==id);
                return Ok(emp);
            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] Employee emp)
        {
            try
            {
                db.EmpTableMy.Add(emp);
                db.SaveChanges();
                return Ok(emp);
            }
            catch
            {
                return BadRequest();
            }
        }



        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] Employee emp)
        {
            try
            {
                db.Entry(emp).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return Ok(emp);
            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                db.Remove(db.EmpTableMy.FirstOrDefault(x=>x.EmployeeID==id));
                db.SaveChanges();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }


    }
}
