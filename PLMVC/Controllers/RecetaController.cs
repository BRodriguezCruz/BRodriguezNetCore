using Microsoft.AspNetCore.Mvc;

namespace PLMVC.Controllers
{
    public class RecetaController : Controller
    {
        public IActionResult GetAll()
        {
            ML.Receta receta = new ML.Receta();
            ML.Result result = BL.Receta.GetAll();

            if (result.Correct)
            {
                receta.Recetas = result.Objects;
            }
            return View(receta);
        }

        [HttpGet]
        public IActionResult Form(int? idReceta)
        {
            ML.Receta receta = new ML.Receta();
            receta.Paciente = new ML.Paciente();

            ML.Result resultPacientes = BL.Paciente.GetAll();  

            if (idReceta != null)
            {
                ML.Result result = BL.Receta.GetById(idReceta.Value);

                if (result.Correct)
                {                    
                    receta = (ML.Receta)result.Object;
                    receta.Paciente.Pacientes = resultPacientes.Objects;
                }                
            }
            else
            {
                receta.Paciente.Pacientes = resultPacientes.Objects;
            }
            return View(receta);
        }


        [HttpPost]
        public IActionResult Form (ML.Receta receta)
        {
            ML.Result result = new ML.Result();

            if(receta.IdReceta == 0)
            {
                
                result = BL.Receta.Add(receta);

                if (result.Correct)
                {
                    ViewBag.Message = "REGISTRO AGREGADO EXITOSAMENTE";
                }
                else
                {
                    ViewBag.Message = "ERROR, REGISTRO NO AGREGADO";
                }
            }
            else
            {
                result = BL.Receta.Update(receta);

                if (result.Correct)
                {
                    ViewBag.Message = "REGISTRO ACTUALIZADO EXITOSAMENTE";
                }
                else
                {
                    ViewBag.Message = "ERROR, REGISTRO NO ACTUALIZADO";
                }
            }
            return PartialView("Modal");
        }
    }
}
