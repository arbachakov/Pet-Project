using Pet_Project.Menus;
using Pet_Project.Models.OfficeStructure;
using Pet_Project.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet_Project.Menu
{
    internal class BlockMenu : BaseMenu
    {

        private readonly BlockService _service;

        public BlockMenu(BlockService blockService)
        {
            _service = blockService;
        }


        public void CreateItems()
        {
            SetStartText("===Меню блоков===\n" +
                _service.ViewAll());
            AddItem("Создать блок", Create);
            AddItem("Изменить блок", Change);
            AddItem("Удалить блок", Delete);
        }


        void Create()
        {
            Console.WriteLine("Введите имя блока");

            string name = Console.ReadLine();
            
            _service.Create(name);

            Console.WriteLine($"Блок {name} успешно создан!");
            Console.ReadKey();
        }

        void Change()
        {
            Console.WriteLine("Какой блок вы хотите изменить?");

            string inputNumber = Console.ReadLine();

            bool isNumber = int.TryParse(inputNumber, out int id);

            Console.WriteLine("Введите новое имя блока");

            string newName = Console.ReadLine();

            _service.ChangeNameById(id, newName);

            Console.WriteLine("Блок переименован");
            Console.ReadKey();
        }

        void Delete()
        {
            Console.WriteLine("Какой блок вы хотите удалить?");

            string inputNumber = Console.ReadLine();

            bool isNumber = int.TryParse(inputNumber, out int id);

            _service.DeleteById(id);

            Console.WriteLine("Блок удален!");
            Console.ReadKey();
        }

    }
}
