using Kanban_EntityFramework_RepositoryPattern.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Kanban_EntityFramework_RepositoryPattern.Server.Controllers
{
    public class TaskItemController : Controller
    {
        private ITaskItemRepository _taskItemRepository;

        public TaskItemController()
        {
            _taskItemRepository = new TaskItemRepository(new KanbanContext());
        }

        public TaskItemController(ITaskItemRepository taskItemRepository)
        {
            _taskItemRepository = taskItemRepository;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = _taskItemRepository.GetAll();
            return View(model);
        }

        [HttpGet]
        public ActionResult AddTaskItem()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddTaskItem(TaskItem model)
        {
            if (ModelState.IsValid)
            {
                _taskItemRepository.Insert(model);
                _taskItemRepository.Save();
                return RedirectToAction("Index", "TaskItem");
            }
            return View();
        }

        [HttpPost]
        public ActionResult EditTaskItem(int TaskItemId)
        {
            TaskItem model = _taskItemRepository.GetById(TaskItemId);
            return View(model);
        }

        [HttpPost]
        public ActionResult EditTaskItem(TaskItem model)
        {
            if (ModelState.IsValid)
            {
                _taskItemRepository.Update(model);
                _taskItemRepository.Save();
                return RedirectToAction("Index", "TaskItem");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult DeleteTaskItem(int TaskItemId)
        {
            TaskItem model = _taskItemRepository.GetById(TaskItemId);
            return View(model);
        }

        [HttpGet]
        public ActionResult Delete(int TaskItemId)
        {
            _taskItemRepository.Delete(TaskItemId);
            _taskItemRepository.Save();
            return RedirectToAction("Index", "TaskItem");
        }
    }
}
