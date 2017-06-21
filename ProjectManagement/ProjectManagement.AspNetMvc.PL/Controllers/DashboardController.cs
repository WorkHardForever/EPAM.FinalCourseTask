using Microsoft.AspNet.Identity;
using ProjectManagement.AspNetMvc.PL.Models.DashboardViewModels;
using ProjectManagement.BLL.Interface.Interfacies.Services;
using ProjectManagement.AspNetMvc.PL.Infrastructure.Mappers;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ProjectManagement.AspNetMvc.PL.Controllers
{
    [Authorize(Roles = "Default")]
    public class DashboardController : Controller
    {
        private readonly IUserService _userService;
        private readonly IUserSignInService _signInService;
        private readonly IProfileService _profileService;
        private readonly ITaskService _taskService;
        private readonly IIdentityMessageService _messageService;

        public DashboardController(IUserService userService, IUserSignInService signInService,
            IProfileService profileService, ITaskService taskService, IIdentityMessageService messageService)
        {
            _userService = userService;
            _signInService = signInService;
            _profileService = profileService;
            _taskService = taskService;
            _messageService = messageService;
        }

        [HttpGet]
        public ActionResult GivenTasks()
        {
            var employees = _profileService.GetEmployees(User.Identity.GetUserId());

            return View(employees);
        }

        [HttpGet]
        public ActionResult CreateTask()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CreateTask(NewTaskViewModel newTask)
        {
            var manager = await _userService.GetByIdWithProfile(User.Identity.GetUserId());
            var employee = await _userService.FindByEmail(newTask.EmployeeEmail);
            employee.Profile = _profileService.GetById(employee.Id);

            _taskService.CreateTask(manager.Profile, employee.Profile, newTask.NewTaskToBllTask());

            _messageService.Send(new IdentityMessage()
            {
                Subject = $"Manager \'{manager.Email.ToString()}\'",
                Body = $"\n\nTitle: {newTask.Title}\n\nDescription: {newTask.Description}\n\n{newTask.StartTime} - {newTask.DeadLine}",
                Destination = newTask.EmployeeEmail
            });

            return RedirectToAction("GivenTasks");
        }

        [HttpGet]
        public async Task<ActionResult> ReceivedTasks()
        {
            var user = await _userService.FindByIdAsync(User.Identity.GetUserId());
            var tasksByState = _profileService.DivideToStateReceivedTasks(user.Profile);

            ReceivedTasksViewModel receivedTasks;
            if (tasksByState != null)
            {
                receivedTasks = new ReceivedTasksViewModel()
                {
                    Todo = tasksByState.Todo.BllTasksToViewModel(),
                    InProcess = tasksByState.InProcess.BllTasksToViewModel(),
                    Done = tasksByState.Done.BllTasksToViewModel()
                };
            }
            else
            {
                receivedTasks = new ReceivedTasksViewModel();
            }

            return View(receivedTasks);
        }

        [HttpGet]
        public async Task<ActionResult> Statistics()
        {
            var user = await _userService.FindByIdAsync(User.Identity.GetUserId());
            var percentOfWork = _profileService.GetStateOfReceivedTasks(user.Profile);

            StatisticViewModel staticViewModel;
            if (percentOfWork == null)
            {
                staticViewModel = new StatisticViewModel()
                {
                    Todo = 0,
                    InProcess = 0,
                    Done = 100
                };
            }
            else
            {
                staticViewModel = new StatisticViewModel()
                {
                    Todo = percentOfWork.ToDo,
                    InProcess = percentOfWork.InProcess,
                    Done = percentOfWork.Done
                };
            }

            return View(staticViewModel);
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
