using Microsoft.AspNetCore.Mvc;

namespace SL.Controllers
{
    public class EstadoController : Controller
    {
        [HttpGet("api/GetAll")]
        public ActionResult Getall()
        {
            ML.Estado estado=new ML.Estado();
            ML.Result result = BL.Estado.GetAll();

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
    }
}
