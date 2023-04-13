using Microsoft.AspNetCore.Mvc;
using Kanban_EntityFramework_RepositoryPattern.Shared;

namespace Kanban_EntityFramework_RepositoryPattern.Server.Controllers
{

    public class ProjectController : Controller
    {
        private IProjectRepository _projectRepository;

        public ProjectController()
        {
            _projectRepository = new ProjectRepository(new KanbanContext());
        }

        public ProjectController(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = _projectRepository.GetAll();
            return View(model);
        }

        [HttpGet]
        public ActionResult AddProject()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProject(Project model)
        {
            if (ModelState.IsValid)
            {
                _projectRepository.Insert(model);
                _projectRepository.Save();
                return RedirectToAction("Index", "Project");
            }
            return View();
        }

        [HttpPost]
        public ActionResult EditProject(int ProjectId)
        {
            Project model = _projectRepository.GetById(ProjectId);
            return View(model);
        }

        [HttpPost]
        public ActionResult EditProject(Project model)
        {
            if(ModelState.IsValid)
            {
                _projectRepository.Update(model);
                _projectRepository.Save();
                return RedirectToAction("Index", "Project");
            }
            else 
            { 
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult DeleteProject(int ProjectId)
        {
            Project model = _projectRepository.GetById(ProjectId);
            return View(model);
        }

        [HttpGet]
        public ActionResult Delete(int ProjectId)
        {
            _projectRepository.Delete(ProjectId);
            _projectRepository.Save();
            return RedirectToAction("Index", "Project");
        }
    }
}
