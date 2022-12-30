using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        [HttpGet("GetAll")] //
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

        [HttpGet("GetById/{IdEmpleado}")]
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
        [HttpPost ("Add")]
        public ActionResult Post([FromBody] ML.Empleado empleado)
        {
            ML.Result result = BL.Empleado.Add(empleado);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPost("Update")] 
        public ActionResult Update( [FromBody] ML.Empleado empleado)
        {
            ML.Result result = BL.Empleado.Update(empleado);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }
        }

        [HttpGet("Delete/{IdEmpleado}")]
        public ActionResult Delete(int IdEmpleado)
        {
            ML.Empleado empleado = new ML.Empleado();
            empleado.Estado = new ML.Estado();
            ML.Result result = BL.Empleado.Delete(IdEmpleado);
            
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }
        }
    }
}
