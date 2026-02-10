using Pet_Project.Menus;
using Pet_Project.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet_Project.Menu
{
    internal class MainMenu
    {
        private readonly BlockService _blockService;
        private readonly DepartmentService _departmentService;
        private readonly WorkerService _workerService;

        public MainMenu(BlockService blockService, DepartmentService departmentService, WorkerService workerService)
        {
            _blockService = blockService;
            _departmentService = departmentService;
            _workerService = workerService;
        }


        private MenuConstructor menu = new MenuConstructor();

        void Run()
        {
            menu.SetStartText("===Главное меню===");
            Action ViewOfficeAction = ViewOffice;
            Action ViewBlockAction = ViewBlockMenu;
            Action ViewDepartmentAction = ViewDepartmentMenu;
            Action ViewWorkerAction = ViewDepartmentMenu;

            menu.SetMenuLine(1, "Посмотреть офис", ViewOfficeAction);
            menu.SetMenuLine(2, "Поработать с блоками", ViewBlockAction);
            menu.SetMenuLine(3, "Поработать с отделами", ViewDepartmentAction);
            menu.SetMenuLine(4, "Поработать с рабочими", ViewWorkerAction);
        }

        void ViewOffice()
        {
            Console.Clear();
            Console.WriteLine(_blockService.ViewAll());
            Console.WriteLine(_departmentService.ViewAll());
            Console.WriteLine(_workerService.ViewAll());
            Console.WriteLine("Нажммите кнопку, чтобы вернуться...");
            Console.ReadKey();
        }

        void ViewBlockMenu()
        {

        }

        void ViewDepartmentMenu()
        {

        }

        void ViewWorkerMenu()
        {

        }
    }
}
