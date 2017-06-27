using ProjectManagement.AspNetMvc.PL.Infrastructure.Mappers.DashboardMappers;
using ProjectManagement.AspNetMvc.PL.Models.DashboardViewModels;
using ProjectManagement.BLL.Interface.Interfacies.Services;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ProjectManagement.AspNetMvc.PL.Controllers
{
    [Authorize(Roles = "default")]
    public class DashboardController : Controller
    {
        private readonly IUserService _userService;
        private readonly IProfileService _profileService;
        private readonly ITaskService _taskService;
        private readonly IMessageService _messageService;

        public DashboardController(IUserService userService, IProfileService profileService,
            ITaskService taskService, IMessageService messageService)
        {
            _userService = userService;
            _profileService = profileService;
            _taskService = taskService;
            _messageService = messageService;
        }

        [HttpGet]
        public ActionResult GivenTasks()
        {
            var manager = _userService.GetByLogin(User.Identity.Name);
            var people = _profileService.GetEmployeesWithTasks(manager.Profile);
            var employees = people.ToEmployeesViewModel();
            return View(employees);
        }

        [HttpGet]
        public ActionResult CreateTask()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateTask(NewTaskViewModel newTask)
        {
            var manager = _userService.GetByLogin(User.Identity.Name);
            var employee = _profileService.GetByEmail(newTask.EmployeeEmail);
            var task = newTask.NewTaskToBllTask();
            task.Manager = manager.Profile;
            task.Employee = employee;

            _taskService.Create(task);

            _messageService.SendEmail(
                email: newTask.EmployeeEmail,
                subject: $"New Task: {manager.Profile.Name} {manager.Profile.Surname}",
                message:
                $"Title: {newTask.Title}<br /><br />Description: {newTask.Description}<br /><br />{newTask.StartTime} - {newTask.DeadLine}<br /><br />Manager email: {manager.Profile.Email}"
            );

            ViewBag.Status = $"Task #{task.Id} was create successful!";
            return RedirectToAction("GivenTasks");
        }

        [HttpGet]
        public ActionResult ReceivedTasks()
        {
            var employee = _userService.GetByLogin(User.Identity.Name);
            var tasksByState = _profileService.DivideByStateReceivedTasks(employee.Profile);
            var receivedTasks = tasksByState.ToReceivedTasksViewModel();
            return View(receivedTasks);
        }

        [HttpGet]
        public ActionResult Statistics()
        {
            var employee = _userService.GetByLogin(User.Identity.Name);
            var percentOfWork = _profileService.GetReceivedTaskPercentState(employee.Profile);
            var statisticViewModel = percentOfWork.ToStatisticViewModel();
            return View(statisticViewModel);
        }

        [HttpPost]
        public ActionResult ChangeStatus(int taskId)
        {
            _taskService.ChangeStatus(taskId);
            return RedirectToAction("ReceivedTasks");
        }

        [HttpGet]
        public ActionResult AboutTask(int id)
        {
            var task = _taskService.GetById(id);
            var aboutTaskViewModel = task.ToAboutTaskViewModel();
            return View(aboutTaskViewModel);
        }

        [ChildActionOnly]
        public ActionResult LeftColumnDashboardPartial()
        {
            return PartialView();
        }

        [ChildActionOnly]
        public ActionResult ButtonDashboardPartial()
        {
            return PartialView();
        }
    }
}