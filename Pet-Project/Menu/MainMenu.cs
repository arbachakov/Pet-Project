using Pet_Project.Menus;
using Pet_Project.Models;
using Pet_Project.Pattern;
using Pet_Project.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet_Project.Menu
{
    internal class MainMenu : BaseMenu
    {
        private readonly BlockService _blockService;
        private readonly DepartmentService _departmentService;
        private readonly WorkerService _workerService;
        private BlockMenu _blockMenu;
        private DepartmentMenu _departmentMenu;
        private WorkerMenu _workerMenu;

        public MainMenu(BlockService blockService, DepartmentService departmentService, WorkerService workerService)
        {
            _blockService = blockService;
            _departmentService = departmentService;
            _workerService = workerService;
            _blockMenu = new BlockMenu(blockService);
            _departmentMenu = new DepartmentMenu(departmentService);
            _workerMenu = new WorkerMenu(workerService);
            CreateItems();
        }


        public void CreateItems()
        {
            SetStartText("===Главное меню===");
            AddItem("Посмотреть все", ViewOffice);
            AddItem("Меню блоков", ViewBlockMenu);
            AddItem("Меню отделов", ViewDepartmentMenu);
            AddItem("Меню сотрудников", ViewWorkerMenu);

            _blockMenu.CreateItems();
            _departmentMenu.CreateItems();
            _workerMenu.CreateItems();
        }

        void ViewOffice()
        {
            Console.Clear();
            Console.WriteLine(_blockService.ViewAll());
            Console.WriteLine(_departmentService.ViewAll());
            Console.WriteLine(GetWorkersInfo());
            Console.WriteLine("Нажммите кнопку, чтобы вернуться...");
            Console.ReadKey();
        }

        void ViewBlockMenu()
        {
            _blockMenu.Run();
        }

        void ViewDepartmentMenu()
        {
            _departmentMenu.Run();
        }

        void ViewWorkerMenu()
        {
            _workerMenu.Run();
        }

        string GetWorkersInfo()
        {
            Result<List<Worker>> resultWorrkers = _workerService.GetAll();

            if (resultWorrkers.Success)
            {
                List<Worker> workers = resultWorrkers.Data;

                string workersInfo = "Сотрудники:\n";
                for (int i = 0; i < workers.Count; i++)
                {
                    workersInfo += $"Имя: {workers[i].Name} Фамилия: {workers[i].Sername} Id: {workers[i].Id}\n";
                }
                return workersInfo;
            }
            else
            {
                return resultWorrkers.Message;
            }
        }
    }
}
