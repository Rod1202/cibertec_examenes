using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ExamT2_i201914968.DataAccess.EstudiantesContext;
using ExamT2_i201914968.Models;
using System.Collections.Generic;
using System.Linq;
using ExamT2_i201914968.DataAccess;

namespace ExamT2_i201914968.Controllers
{
    public class EstudiantesController : Controller
    {
        private readonly IMapper _mapper;
        private readonly EstudiantesContext _estudiantesContext;


      

        public EstudiantesController(EstudiantesContext estudiantesContext, IMapper mapper)
        {
            _estudiantesContext = estudiantesContext;
            _mapper = mapper;
        }

        public IActionResult List()
        {
            var listResult = _estudiantesContext.Estudiantes.ToList();
            var model = new EstudiantesListViewModel();
            model.List = _mapper.Map<List<EstudiantesViewModel>>(listResult);
            return View(model);
        }

        public IActionResult Add()
        {
            var model = new EstudiantesViewModel();
            model.NotasTemporales = new List<NotasViewModel>();
            return View(model);
        }

        [HttpPost]
        public IActionResult AddSavedAction(EstudiantesViewModel model)
        {    
            model.Email = "default@example.com";
            model.Phone = "00000000";
            model.Contact = "Null";
            model.ContactNumber = "000000000";

            var entity = _mapper.Map<EstudiantesEntity>(model);
            _estudiantesContext.Estudiantes.Add(entity);

            if (model.NotasTemporales != null && model.NotasTemporales.Any())
            {
                foreach (var nota in model.NotasTemporales)
                {
                    var notaEntity = new NotasEntity
                    {
                        EstudianteId = entity.Id,  
                        Curso = nota.Curso,
                        Nota = nota.Nota
                    };

                   
                    _estudiantesContext.Notas.Add(notaEntity);
                }
            }

     
            _estudiantesContext.SaveChanges();

            return RedirectToAction("List", "Estudiantes");
        }


        public IActionResult Edit(int id)
        {
            var findEstudiantes = _estudiantesContext.Estudiantes.FirstOrDefault(c => c.Id == id);
            var model = _mapper.Map<EstudiantesViewModel>(findEstudiantes);
            return View(model);
        }

        [HttpPost]
        public IActionResult EditSaved(EstudiantesViewModel model)
        {
            var findEstudiantes = _estudiantesContext.Estudiantes.FirstOrDefault(c => c.Id == model.Id);
            if (findEstudiantes != null)
            {
                _mapper.Map(model, findEstudiantes);
                _estudiantesContext.SaveChange();
            }
            return RedirectToAction("List", "Estudiantes");
        }

        [HttpGet]
        public JsonResult DeleteEstudiante(int id)
        {
            var findEstudiantes = _estudiantesContext.Estudiantes.FirstOrDefault(c => c.Id == id);
            if (findEstudiantes != null)
            {
                _estudiantesContext.Estudiantes.Remove(findEstudiantes);
                _estudiantesContext.SaveChange();
                return Json("Se eliminó de manera correcta");
            }
            return Json("No se pudo encontrar el estudiante para eliminar.");
        }

        
    }
}
