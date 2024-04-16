using DummyCrud.Data;
using DummyCrud.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DummyCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIController : ControllerBase
    {
        public DBContext _dbContext;
        public APIController(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("get")]
        public IActionResult GetData()
        {
            var data = _dbContext.CustomerWarranties.ToList();
            return Ok(data);
        }

        [HttpPost("add")]
        public IActionResult AddData([FromBody] CustomerWarranty model)
        {
            if (ModelState.IsValid)
            {
                _dbContext.CustomerWarranties.Add(model);
                _dbContext.SaveChanges();
                return Ok("Data added successfully!");
            }
            else
            {
                return BadRequest("Invalid model state.");
            }
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteData(int id)
        {
            var customer = _dbContext.CustomerWarranties.FirstOrDefault(c => c.ID == id);
            if (customer == null)
            {
                return NotFound("Customer not found.");
            }

            _dbContext.CustomerWarranties.Remove(customer);
            _dbContext.SaveChanges();

            return Ok("Customer deleted successfully!");
        }

        [HttpPut("edit")]
        public IActionResult EditData([FromBody] CustomerWarranty model)
        {
            if (ModelState.IsValid)
            {
                _dbContext.CustomerWarranties.Add(model);
                _dbContext.SaveChanges();
                return Ok("Data added successfully!");
            }
            else
            {
                return BadRequest("Invalid model state.");
            }
        }

    }
}
