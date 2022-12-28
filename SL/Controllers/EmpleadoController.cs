using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        [HttpGet("api/GetAll")]
        public ActionResult GetAll()
        {
            ML.Empleado empleado = new ML.Empleado();
            empleado.Estado = new ML.Estado();
            ML.Result result = BL.Empleado.GetAll();

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet("api/GetById/{IdEmpleado}")]
        public ActionResult GetById(int IdEmpleado)
        {
            ML.Empleado empleado = new ML.Empleado();
            empleado.Estado = new ML.Estado();
            ML.Result result = BL.Empleado.GetById(IdEmpleado);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        // POST api/<EmpleadoController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<EmpleadoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EmpleadoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
