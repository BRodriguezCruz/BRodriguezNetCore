using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Receta
    {
        public static void GetAll()
        {
            ML.Result result = BL.Receta.GetAll();    // ESTO ES IGUAL A LO DE ABAJO PERO SIMPLIFICADO
                      
            if (result.Correct)
            {
                foreach (ML.Receta receta in result.Objects)
                {
                    Console.WriteLine("Lista generada exitosamente");
                    Console.WriteLine($"ID RECETA: {receta.IdReceta}");
                    Console.WriteLine($"FECHA DE CONSULTA: {receta.FechaConsulta}");
                    Console.WriteLine($"DIAGNOSTICO: {receta.Diagnostico}");
                    Console.WriteLine($"NOMBRE DEL MEDICO: {receta.NombreMedico}");
                    Console.WriteLine($"NOTA ADICIONAL: {receta.NotaAdicional}");
                    Console.WriteLine($"ID DEL PACIENTE: {receta.Paciente.IdPaciente}");
                    Console.WriteLine("--------------------------------------");
                }
            }
            else
            {
                Console.WriteLine($"La lista no pudo ser generada porque: {result.ErrorMessage}");
            }
        }

        public static void GetById()
        {
            ML.Receta receta = new ML.Receta();
            Console.WriteLine("Escriba el ID de la receta a encontrar: ");
            int idReceta = int.Parse(Console.ReadLine());

            ML.Result result = BL.Receta.GetById(idReceta); //Igualamos el objeto result al metodo GetById para acceder a la prop
            //                                              correct y hace una condicion cuando se cumpla

            if (result.Correct)
            {
                //Unboxing
                receta = (ML.Receta)result.Object;
                Console.WriteLine("Lista generada exitosamente");
                Console.WriteLine($"ID RECETA: {receta.IdReceta}");
                Console.WriteLine($"FECHA DE CONSULTA: {receta.FechaConsulta}");
                Console.WriteLine($"DIAGNOSTICO: {receta.Diagnostico}");
                Console.WriteLine($"NOMBRE DEL MEDICO: {receta.NombreMedico}");
                Console.WriteLine($"NOTA ADICIONAL: {receta.NotaAdicional}");
                Console.WriteLine($"ID DEL PACIENTE: {receta.Paciente.IdPaciente}");
                Console.WriteLine("--------------------------------------");
            }
            else
            {
                Console.WriteLine($"Error al mostrar la receta: {result.ErrorMessage}");
            }
        }

        public static void Add()
        {
            ML.Receta receta = new ML.Receta();

            Console.WriteLine("Escribe la fecha de consulta: ");
            receta.FechaConsulta = Console.ReadLine();
            Console.WriteLine("Escribe el diagnostico dado: ");
            receta.Diagnostico = Console.ReadLine();
            Console.WriteLine("Escribe el nombre del medico: ");
            receta.NombreMedico = Console.ReadLine();
            Console.WriteLine("Escribe si hay nota adicional ");
            receta.NotaAdicional = Console.ReadLine();
            Console.WriteLine("Escribe el ID del Paciente: ");
            //INSTANCIA PARA ALMACENAR DATOS DESDE AFUERA (1era vez que se utiliza)
            receta.Paciente = new ML.Paciente();
            receta.Paciente.IdPaciente = int.Parse(Console.ReadLine());
            
            ML.Result result = BL.Receta.Add(receta);

            if (result.Correct)
            {
                Console.WriteLine("RECETA AGRAGADO EXITOSAMENTE");
            }
            else
            {
                Console.WriteLine($"ERROR,LA RECETA NO SE AGREGO: {result.ErrorMessage}");
            }
        }

        public static void Update()
        {
            ML.Receta receta = new ML.Receta();

            Console.WriteLine("Escribe el ID de la receta a consultar: ");
            receta.IdReceta = int.Parse(Console.ReadLine());

            Console.WriteLine("Escribe la fecha de consulta: ");
            receta.FechaConsulta = Console.ReadLine();
            Console.WriteLine("Escribe el diagnostico dado: ");
            receta.Diagnostico = Console.ReadLine();
            Console.WriteLine("Escribe el nombre del medico: ");
            receta.NombreMedico = Console.ReadLine();
            Console.WriteLine("Escribe si hay nota adicional ");
            receta.NotaAdicional = Console.ReadLine();
            Console.WriteLine("Escribe el ID del Paciente: ");
            //INSTANCIA PARA ALMACENAR DATOS DESDE AFUERA (1era vez que se utiliza)
            receta.Paciente = new ML.Paciente();
            receta.Paciente.IdPaciente = int.Parse(Console.ReadLine());

            ML.Result result = BL.Receta.Update(receta);

            if (result.Correct)
            {
                Console.WriteLine("RECETA ACTUALIZADA EXITOSAMENTE");
            }
            else
            {
                Console.WriteLine($"LA RECETA NO SE ACTUALIZO CORRECTAMENTE: {result.ErrorMessage}");
            }
        }

        public static void Delete()
        {
            ML.Receta receta = new ML.Receta();

            Console.WriteLine("Escribe el ID de la receta a eliminar: ");
            int idReceta = int.Parse(Console.ReadLine());


            ML.Result result = BL.Receta.Delete(idReceta);

            if (result.Correct)
            {
                Console.WriteLine("RECETA ELIMINADA EXITOSAMENTE");
            }
            else
            {
                Console.WriteLine($"ERROR, LA RECETA NO SE ELIMINO: {result.ErrorMessage}");
            }
        }
    }
}
