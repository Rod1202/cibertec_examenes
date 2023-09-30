using Microsoft.AspNetCore.Mvc;
using System.Linq;
using ExamT1_201914968.Database.EstudiantesContext;
using ExamT1_201914968.Models;
using ExamT1_201914968.Database;

namespace ExamT1_201914968.Controllers
{
    public class EstudiantesController : Controller
    {
        private readonly EstudiantesContext _estudiantesContext;
        public EstudiantesController(EstudiantesContext estudiantesContext)
        {
            this._estudiantesContext = estudiantesContext;
        }
        public IActionResult List()
        {
            var listResult = _estudiantesContext.Estudiantes.ToList();
            EstudiantesListViewModel model = new EstudiantesListViewModel();
            model.List = (from c in listResult
                          select new EstudiantesViewModel()
                          {
                              Id = c.Id,
                              Name = c.Name,
                              LastName = c.LastName,
                              DNI = c.DNI,
                              BirthDate = c.BirthDate,
                              Email = c.Email,
                              Phone = c.Phone,
                              Contact = c.Contact,
                              ContactNumber= c.ContactNumber,
                          }).ToList();
            return View(model);
        }
        public ActionResult Add()
        {
            EstudiantesViewModel model = new EstudiantesViewModel();
            return View();
        }
        [HttpPost]
        public IActionResult AddSavedAction(EstudiantesViewModel model)
        {
            EstudiantesEntity entity = new EstudiantesEntity();
            entity.Name = model.Name;
            entity.LastName = model.LastName;
            entity.DNI = model.DNI;
            entity.BirthDate = model.BirthDate;
            entity.Email = model.Email;
            entity.Phone = model.Phone;
            entity.Contact = model.Contact;
            entity.ContactNumber = model.ContactNumber;
            _estudiantesContext.Estudiantes.Add(entity);
            _estudiantesContext.SaveChange();
            return RedirectToAction("List","Estudiantes");
        }
        public IActionResult Edit(int id)
        {
            var findEstudiantes = _estudiantesContext.Estudiantes.Where(c => c.Id == id).SingleOrDefault();
            var model = new EstudiantesViewModel();
            model.Id = findEstudiantes.Id;
            model.Name=findEstudiantes.Name;
            model.LastName=findEstudiantes.LastName;
            model.DNI = findEstudiantes.DNI;
            model.BirthDate = findEstudiantes.BirthDate;
            model.Email = findEstudiantes.Email;
            model.Phone = findEstudiantes.Phone;
            model.Contact = findEstudiantes.Contact;
            model.ContactNumber = findEstudiantes.ContactNumber;
            return View(model);
        }

        [HttpPost]
        public IActionResult EditSaved(EstudiantesViewModel model) 
        {
            var findEstudiantes = _estudiantesContext.Estudiantes.SingleOrDefault(c=>c.Id==model.Id);
            if (findEstudiantes != null) 
            {
                findEstudiantes.Name = model.Name;
                findEstudiantes.LastName = model.LastName;
                findEstudiantes.DNI = model.DNI;
                findEstudiantes.BirthDate = model.BirthDate;
                findEstudiantes.Email = model.Email;
                findEstudiantes.Phone = model.Phone;
                findEstudiantes.Contact = model.Contact;
                findEstudiantes.ContactNumber = model.ContactNumber;
                _estudiantesContext.SaveChange();
            }
            return RedirectToAction("List", "Estudiantes");
        }



        [HttpGet]
        public JsonResult DeleteEstudiante(int id) 
        {
            var findEstudiantes = _estudiantesContext.Estudiantes.SingleOrDefault(c => c.Id == id);
            _estudiantesContext.Estudiantes.Remove(findEstudiantes);
            _estudiantesContext.SaveChange();
            return Json("Se elimino de manera correcta");
        }

    }
}
