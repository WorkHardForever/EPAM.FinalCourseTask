using Microsoft.AspNet.Identity;
using ProjectManagement.AspNetMvc.PL.Models.DashboardViewModels;
using ProjectManagement.BLL.Interface.Interfacies.Services;
using ProjectManagement.AspNetMvc.PL.Infrastructure.Mappers;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Collections.Generic;

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
            //var user = await _userService.FindByIdAsync(User.Identity.GetUserId());
            //var employees = _userService.GetEmployeesIdByUser(user);

            //return View(employees);
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> CreateTask(NewTaskViewModel newTask)
        {
            var user = await _userService.FindByIdAsync(User.Identity.GetUserId());
            var employee = await _userService.FindByEmail(newTask.EmployeeEmail);
            _taskService.CreateTask(user.Profile, employee.Profile, newTask.RegisterToBllUser());

            _messageService.Send(new IdentityMessage()
            {
                Subject = $"Manager \'{user.Email.ToString()}\'",
                Body = $"\n\nTitle: {newTask.Title}\n\nDescription: {newTask.Description}\n\n{newTask.StartTime} - {newTask.DeadLine}",
                Destination = "email"
            });

            return RedirectToAction("GivenTasks");
        }

        [HttpGet]
        public async Task<ActionResult> ReceivedTasks()
        {
            var user = await _userService.FindByIdAsync(User.Identity.GetUserId());
            var tasksByState = _profileService.DivideToStateReceivedTasks(user.Profile);

            if (tasksByState != null)
            {
                var receivedTasks = new ReceivedTasksViewModel()
                {
                    Todo = tasksByState.Todo.BllTasksToViewModel(),
                    InProcess = tasksByState.InProcess.BllTasksToViewModel(),
                    Done = tasksByState.Done.BllTasksToViewModel()
                };

                return View(receivedTasks);
            }

            return View();
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
        public ActionResult ChangeStatusOfWork(int tableId, int itemId)
        {

            return View();
        }
    }
}