using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Empleado
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.EignacioLeenkenGroupContext context = new DL.EignacioLeenkenGroupContext())
                {
                    var query = context.Empleados.FromSqlRaw("EmpleadoGetAll").ToList();

                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var obj in query)
                        {
                            ML.Empleado empleado = new ML.Empleado();

                            empleado.IdEmpleado = obj.IdEmpleado;
                            empleado.NumeroNomina=obj.NumeroNomina;
                            empleado.NombreEmpleado = obj.Nombre;
                            empleado.ApellidoPaterno = obj.ApellidoPaterno;
                            empleado.ApellidoMaterno = obj.ApellidoMaterno;

                            empleado.Estado = new ML.Estado();
                            empleado.Estado.IdEstado = (int)obj.IdEstado;
                            empleado.Estado.NombreEstado = obj.NombreEstado;

                            result.Objects.Add(empleado);
                        }
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result GetById(int IdEmpleado)
        {
            ML.Result result = new ML.Result();

            try
            {

                using (DL.EignacioLeenkenGroupContext context = new DL.EignacioLeenkenGroupContext())
                {
                    var query = context.Empleados.FromSqlRaw($"EmpleadoGetById {IdEmpleado}").AsEnumerable().FirstOrDefault();
                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        ML.Empleado empleado = new ML.Empleado();

                        empleado.IdEmpleado = query.IdEmpleado;
                        empleado.NumeroNomina = query.NumeroNomina;
                        empleado.NombreEmpleado = query.Nombre;
                        empleado.ApellidoPaterno = query.ApellidoPaterno;
                        empleado.ApellidoMaterno = query.ApellidoMaterno;

                        empleado.Estado = new ML.Estado();
                        empleado.Estado.IdEstado = (int)query.IdEstado;
                        empleado.Estado.NombreEstado = query.NombreEstado;

                        result.Object=empleado;
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
