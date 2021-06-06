using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            using (var db = new UsersContext())
            {
                return db.Employees.OrderByDescending(x=> x.Id).ToList();
            }
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            using (var db = new UsersContext())
            {
                return db.Employees.Where(x => x.Id == id).FirstOrDefault();
            }
        }

        // POST api/<UsersController>
        [HttpPost]
        public void Post([FromBody] NewEmployee item)
        {
            using (var db = new UsersContext())
            {
                db.Employees.Add(new Employee() { Fname= item.firstName, Lname= item.lastName, Age= item.age });
                db.SaveChanges();
            }
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] NewEmployee item)
        {
            using (var db = new UsersContext())
            {
                var updatedEmployee = db.Employees.Where(x=> x.Id == id).FirstOrDefault();
                updatedEmployee.Fname = item.firstName; 
                updatedEmployee.Lname = item.lastName;
                updatedEmployee.Age = item.age;
                db.SaveChanges();
            }
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (var db = new UsersContext())
            {
                var deletedEmployee = db.Employees.Where(x => x.Id == id).FirstOrDefault();
                db.Employees.Remove(deletedEmployee);
                db.SaveChanges();
            }
        }
    }
}
