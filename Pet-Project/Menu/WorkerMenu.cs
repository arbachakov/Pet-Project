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
    internal class WorkerMenu : BaseMenu
    {

        private readonly WorkerService _service;

        public WorkerMenu(WorkerService service)
        {
            _service = service;
        }


        string GetWorkersInfo()
        {
            Result<List<Worker>> resultWorrkers = _service.GetAll();

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

        public void CreateItems()
        { // TODO Подумать как переделать
            SetStartText("===Меню Сотрудников===\n" + GetWorkersInfo());
            
            AddItem("Создать сотрудника", Create);
            AddItem("Изменить сотрудника", Change);
            AddItem("Удалить сотрудника", Delete);
        }


        void Create()
        {
            Console.WriteLine("Введите имя Сотрудника");

            string name = Console.ReadLine();

            _service.Create(name);

            Console.WriteLine($"Сотрудник {name} успешно создан!");
        }

        void Change()
        {
            Console.WriteLine("Какого сотрудника вы хотите изменить?");

            string inputNumber = Console.ReadLine();

            bool isNumber = int.TryParse(inputNumber, out int id);

            Console.WriteLine("Введите новое имя сотрудника");

            string newName = Console.ReadLine();

            _service.ChangeNameById(id, newName);
        }

        void Delete()
        {
            Console.WriteLine("Какого сотрудника вы хотите удалить?");

            string inputNumber = Console.ReadLine();

            bool isNumber = int.TryParse(inputNumber, out int id);

            _service.DeleteById(id);

        }
    }
}
