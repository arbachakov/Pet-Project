using Pet_Project.Menus;
using Pet_Project.Models;
using Pet_Project.Models.OfficeStructure;
using Pet_Project.Pattern;
using Pet_Project.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet_Project.Menu.SpecialMenu
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
            AddItem("Создать отдел", Create);
            AddItem("Изменить отдел", Change);
            AddItem("Удалить отдел", Delete);
        }

        protected override void UpdateStartText()
        {
            SetStartText("=== Меню отделов ===" + "\n" +
                (_service.GetInfo().Success ?
                _service.GetInfo().Data :
                _service.GetInfo().Message));
        }


        void Create()
        {

            Console.WriteLine("Введите имя отдела");

            string name = Console.ReadLine();

            Result<Department> result = _service.Create(name);

            Console.WriteLine(result.Message);
        }

        void Change()
        {

            Console.WriteLine("Какой отдел вы хотите изменить?");

            int inputNumber = GetInputNumber();

            Console.WriteLine("Введите новое имя отдела");

            string newName = Console.ReadLine();

            Result<Department> result = _service.ChangeNameById(inputNumber, newName);

            Console.WriteLine(result.Message);
        }

        void Delete()
        {
            Console.WriteLine("Какой отдел вы хотите удалить?");

            int inputNumber = GetInputNumber();
            Result<Department> result = _service.DeleteById(inputNumber);

            Console.WriteLine(result.Message);
        }
    }
}
