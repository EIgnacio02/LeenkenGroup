using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Estado
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.EignacioLeenkenGroupContext context = new DL.EignacioLeenkenGroupContext())
                {
                    var query = context.Estados.FromSqlRaw("EstadoGetAll").ToList();

                    result.Objects = new List<object>();
                    
                    if (query != null)
                    {
                        foreach (var obj in query)
                        {
                            ML.Estado estado = new ML.Estado();

                            estado.IdEstado = obj.IdEstado;
                            estado.NombreEstado = obj.Estado1;

                            result.Objects.Add(obj);
                        }
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error";
            }
            return result;
        }
    }
}
