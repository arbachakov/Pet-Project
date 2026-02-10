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
    internal class BlockMenu
    {

        private readonly BlockService _blockService;

        public BlockMenu(BlockService blockService)
        {
            _blockService = blockService;
        }

        MenuConstructor menu = new MenuConstructor();

        void Run()
        {
            menu.SetStartText("===Блоки===\n" +
                _blockService.ViewAll());

            Action CreateBlockAction = CreateBlock;
            Action ChangeBlockAction = ChangeBlock;
            Action DeleteBlocktAction = DeleteBlock;
            Action ExitAction = Exit;


            menu.SetMenuLine(1, "Создать блок", CreateBlockAction);
            menu.SetMenuLine(2, "Изменить блок", ChangeBlockAction);
            menu.SetMenuLine(3, "Удалить блок", DeleteBlocktAction);
            menu.SetMenuLine(4, "Назад", ExitAction);
        }

        void CreateBlock()
        {
            Console.WriteLine("Введите имя блока");

            string name = Console.ReadLine();
            
            _blockService.Create(name);

            Console.WriteLine($"Блок {name} успешно создан!");
        }

        void ChangeBlock()
        {
            Console.WriteLine("Какой блок вы хотите изменить?");

            string inputNumber = Console.ReadLine();

            bool isNumber = int.TryParse(inputNumber, out int id);

            Console.WriteLine("Введите новое имя блока");

            string newName = Console.ReadLine();

            _blockService.ChangeNameById(id, newName);
        }

        void DeleteBlock()
        {
            Console.WriteLine("Какой блок вы хотите удалить?");

            string inputNumber = Console.ReadLine();

            bool isNumber = int.TryParse(inputNumber, out int id);

            _blockService.DeleteById(id);

            Console.WriteLine("Введите новое имя блока");

            string newName = Console.ReadLine();

            _blockService.ChangeNameById(id, newName);
        }

        void Exit()
        {
            Console.WriteLine("Выходим в главное меню");

        }

    }
}
