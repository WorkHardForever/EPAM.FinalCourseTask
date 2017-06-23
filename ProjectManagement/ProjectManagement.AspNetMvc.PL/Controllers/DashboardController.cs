using ProjectManagement.AspNetMvc.PL.Models.DashboardViewModels;
using ProjectManagement.BLL.Interface.Interfacies.Services;
using ProjectManagement.AspNetMvc.PL.Infrastructure.Mappers;
using System.Web.Mvc;
using ProjectManagement.BLL.Interface.Entities;

namespace ProjectManagement.AspNetMvc.PL.Controllers
{
    [Authorize(Roles = "default")]
    public class DashboardController : Controller
    {
        private readonly IUserService _userService;
        private readonly IProfileService _profileService;
        private readonly ITaskService _taskService;

        public DashboardController(IUserService userService, IProfileService profileService, ITaskService taskService)
        {
            _userService = userService;
            _profileService = profileService;
            _taskService = taskService;
        }

        [HttpGet]
        public ActionResult GivenTasks()
        {
            //var employees = _profileService.GetEmployees(User.Identity.GetUserId());

            //return View(employees);
            return View();
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

            //_messageService.SendNewTask(manager.Profile, employee);

            //_messageService.Send(new IdentityMessage()
            //{
            //    Subject = $"Manager \'{manager.Email.ToString()}\'",
            //    Body = $"\n\nTitle: {newTask.Title}\n\nDescription: {newTask.Description}\n\n{newTask.StartTime} - {newTask.DeadLine}",
            //    Destination = newTask.EmployeeEmail
            //});

            return RedirectToAction("GivenTasks");
        }

        [HttpGet]
        public ActionResult ReceivedTasks()
        {
            //var user = await _userService.FindByIdAsync(User.Identity.GetUserId());
            //var tasksByState = _profileService.DivideToStateReceivedTasks(user.Profile);

            //ReceivedTasksViewModel receivedTasks;
            //if (tasksByState != null)
            //{
            //    receivedTasks = new ReceivedTasksViewModel()
            //    {
            //        Todo = tasksByState.Todo.BllTasksToViewModel(),
            //        InProcess = tasksByState.InProcess.BllTasksToViewModel(),
            //        Done = tasksByState.Done.BllTasksToViewModel()
            //    };
            //}
            //else
            //{
            //    receivedTasks = new ReceivedTasksViewModel();
            //}

            //return View(receivedTasks);

            return View();
        }

        [HttpGet]
        public ActionResult Statistics()
        {
            //var user = await _userService.FindByIdAsync(User.Identity.GetUserId());
            //var percentOfWork = _profileService.GetStateOfReceivedTasks(user.Profile);

            //StatisticViewModel staticViewModel;
            //if (percentOfWork == null)
            //{
            //    staticViewModel = new StatisticViewModel()
            //    {
            //        Todo = 0,
            //        InProcess = 0,
            //        Done = 100
            //    };
            //}
            //else
            //{
            //    staticViewModel = new StatisticViewModel()
            //    {
            //        Todo = percentOfWork.ToDo,
            //        InProcess = percentOfWork.InProcess,
            //        Done = percentOfWork.Done
            //    };
            //}

            //return View(staticViewModel);

            return View();
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

        [HttpPost]
        public ActionResult ChangeStatus(int tableId, int itemId)
        {

            return View();
        }
    }
}
