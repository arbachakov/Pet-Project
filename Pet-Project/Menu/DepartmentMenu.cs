using Pet_Project.Menus;
using Pet_Project.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet_Project.Menu
{
    internal class DepartmentMenu : BaseMenu
    {
        private readonly DepartmentService _service;

        public DepartmentMenu(DepartmentService departmentService)
        {
            _service = departmentService;
        }


        public void CreateItems()
        {
            SetStartText("===Меню Отделов===\n" +
                _service.ViewAll());
            AddItem("Создать отдел", Create);
            AddItem("Изменить отдел", Change);
            AddItem("Удалить отдел", Delete);
        }


        void Create()
        {
            Console.WriteLine("Введите имя отдела");

            string name = Console.ReadLine();

            _service.Create(name);

            Console.WriteLine($"Отдел {name} успешно создан!");
        }

        void Change()
        {
            Console.WriteLine("Какой отдел вы хотите изменить?");

            string inputNumber = Console.ReadLine();

            bool isNumber = int.TryParse(inputNumber, out int id);

            Console.WriteLine("Введите новое имя отдела");

            string newName = Console.ReadLine();

            _service.ChangeNameById(id, newName);
        }

        void Delete()
        {
            Console.WriteLine("Какой отдел вы хотите удалить?");

            string inputNumber = Console.ReadLine();

            bool isNumber = int.TryParse(inputNumber, out int id);

            _service.DeleteById(id);

        }
    }
}
