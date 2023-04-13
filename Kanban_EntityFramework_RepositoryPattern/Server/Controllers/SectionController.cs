using Kanban_EntityFramework_RepositoryPattern.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Kanban_EntityFramework_RepositoryPattern.Server.Controllers
{
    public class SectionController : Controller
    {
        private ISectionRepository _sectionRepository;

        public SectionController()
        {
            _sectionRepository = new SectionRepository(new KanbanContext());
        }

        public SectionController(ISectionRepository sectionRepository)
        {
            _sectionRepository = sectionRepository;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = _sectionRepository.GetAll();
            return View(model);
        }

        [HttpGet]
        public ActionResult AddSection()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSection(Section model)
        {
            if (ModelState.IsValid)
            {
                _sectionRepository.Insert(model);
                _sectionRepository.Save();
                return RedirectToAction("Index", "Section");
            }
            return View();
        }

        [HttpPost]
        public ActionResult EditSection(int SectionId)
        {
            Section model = _sectionRepository.GetById(SectionId);
            return View(model);
        }

        [HttpPost]
        public ActionResult EditSection(Section model)
        {
            if (ModelState.IsValid)
            {
                _sectionRepository.Update(model);
                _sectionRepository.Save();
                return RedirectToAction("Index", "Section");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult DeleteSection(int SectionId)
        {
            Section model = _sectionRepository.GetById(SectionId);
            return View(model);
        }

        [HttpGet]
        public ActionResult Delete(int SectionId)
        {
            _sectionRepository.Delete(SectionId);
            _sectionRepository.Save();
            return RedirectToAction("Index", "Section");
        }
    }
}
