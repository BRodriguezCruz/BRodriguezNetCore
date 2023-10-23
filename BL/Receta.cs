using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;

namespace BL
{
    public class Receta
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.BrodriguezNetCoreContext context = new DL.BrodriguezNetCoreContext())
                {
                    var query = context.RecetaMedicas.FromSqlRaw("RecetaGetAll").ToList();

                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var registro in query)
                        {
                            ML.Receta receta = new ML.Receta();

                            receta.IdReceta = registro.IdReceta;
                            receta.FechaConsulta = (registro.FechaConsulta).ToString();
                            receta.Diagnostico = registro.Diagnostico;
                            receta.NombreMedico = registro.NombreMedico;
                            receta.NotaAdicional = registro.NotaAdicional;

                            receta.Paciente = new ML.Paciente();
                            receta.Paciente.IdPaciente = registro.IdPaciente;
                            receta.Paciente.Nombre = registro.NombrePaciente;

                            result.Objects.Add(receta);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ha ocurrido un error al mostrar las recetas";
                    }
                }
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
                result.Correct = false;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result GetById(int idReceta)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.BrodriguezNetCoreContext context = new DL.BrodriguezNetCoreContext())
                {
                    var query = context.RecetaMedicas.FromSqlRaw($"RecetaGetById {idReceta}").AsEnumerable().SingleOrDefault();

                    if (query != null)
                    {
                        ML.Receta receta = new ML.Receta();

                        receta.IdReceta = query.IdReceta;
                        receta.FechaConsulta = (query.FechaConsulta).ToString();
                        receta.Diagnostico = query.Diagnostico;
                        receta.NombreMedico = query.NombreMedico;
                        receta.NotaAdicional = query.NotaAdicional;

                        receta.Paciente = new ML.Paciente();
                        receta.Paciente.IdPaciente = query.IdPaciente;
                        receta.Paciente.Nombre = query.NombrePaciente;

                        result.Object = receta;
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ha ocurrido un error al mostrar las recetas";
                    }
                }
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
                result.Correct = false;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result Add(ML.Receta receta)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.BrodriguezNetCoreContext context = new DL.BrodriguezNetCoreContext())
                {
                    
                    var query = context.Database.ExecuteSqlRaw($"RecetaAdd '{receta.FechaConsulta}', '{receta.Diagnostico}', '{receta.NombreMedico}', '{receta.NotaAdicional}', {receta.Paciente.IdPaciente}");
                    
                    if (query > 0){
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch(Exception ex)
            {
                result.ErrorMessage = ex.Message;
                result.Correct = false;
                result.Ex = ex;
            }

            return result;
        }

        public static ML.Result Update(ML.Receta receta)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.BrodriguezNetCoreContext context = new DL.BrodriguezNetCoreContext())
                {

                    var query = context.Database.ExecuteSqlRaw($"RecetaUpdate {receta.IdReceta},'{receta.FechaConsulta}', '{receta.Diagnostico}', '{receta.NombreMedico}', '{receta.NotaAdicional}', {receta.Paciente.IdPaciente}");

                    /*
                      var query = context.Database.ExecuteSqlRaw($"RecetaUpdate @IdReceta, @FechaConsulta, @Diagnostico, @NombreMedico, @NotaAdional, @IdPaciente",
                                                            new SqlParameter("IdReceta",receta.IdReceta),
                                                            new SqlParameter("FechaConsulta", receta.FechaConsulta),
                                                            new SqlParameter("Diagnostico", receta.Diagnostico),
                                                            new SqlParameter("NombreMedico", receta.NombreMedico),
                                                            new SqlParameter("NotaAdional", receta.NotaAdicional),
                                                            new SqlParameter("IdPaciente", receta.Paciente.IdPaciente)); */
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
                result.Correct = false;
                result.Ex = ex;
            }

            return result;
        }
        public static ML.Result Delete(int idReceta)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.BrodriguezNetCoreContext context = new DL.BrodriguezNetCoreContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"RecetaDelete {idReceta}");

                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct =false;
                    }
                }

            }
            catch( Exception ex )
            {
                result.ErrorMessage = ex.Message;
                result.Correct = false;
                result.Ex = ex;
            }

            return result;
        }
    }
}