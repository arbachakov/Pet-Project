using Pet_Project.Menu.SpecialMenu;
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

            Console.WriteLine(_blockService.GetInfo().Success ? 
                _blockService.GetInfo().Data : 
                _blockService.GetInfo().Message);

            Console.WriteLine(_departmentService.GetInfo().Success ?
                _departmentService.GetInfo().Data :
                _departmentService.GetInfo().Message);

            Console.WriteLine(_workerService.GetInfo().Success ?
                _workerService.GetInfo().Data :
                _workerService.GetInfo().Message);

            Console.WriteLine("Нажммите кнопку, чтобы вернуться...");
            Console.ReadKey();
        }

        protected override void UpdateStartText() { }

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


    }
}
