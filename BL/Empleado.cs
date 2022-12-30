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

        public static ML.Result Add(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.EignacioLeenkenGroupContext context= new DL.EignacioLeenkenGroupContext())
                {
                    int query = context.Database.ExecuteSqlRaw($"EmpleadoAdd '{empleado.NombreEmpleado}','{empleado.ApellidoPaterno}','{empleado.ApellidoPaterno}',{empleado.Estado.IdEstado}");
                    if (query>0)
                    {
                        result.Message = "Se ingresaron los datos correctamente";
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un problema";
            }
            return result;
        }

        public static ML.Result Update(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.EignacioLeenkenGroupContext context= new DL.EignacioLeenkenGroupContext())
                {
                    int query = context.Database.ExecuteSqlRaw($"EmpleadoUpdate {empleado.IdEmpleado},'{empleado.NombreEmpleado}','{empleado.ApellidoPaterno}','{empleado.ApellidoMaterno}','{empleado.Estado.IdEstado}'");
                    if (query>0)
                    {
                        result.Message = "Se actualizaron los datos correctamente";
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un problema";
            }

            return result;
        }

        public static ML.Result Delete(int IdEmpleado)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.EignacioLeenkenGroupContext context= new DL.EignacioLeenkenGroupContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"EmpleadoDelete {IdEmpleado}");

                    if (query>0)
                    {
                        result.Message = "Se elimino correctamente el registro";
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un problema";
            }
            return result;
        }
    }
}
