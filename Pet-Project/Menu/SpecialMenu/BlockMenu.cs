using Pet_Project.Menus;
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
    internal class BlockMenu : BaseMenu
    {

        private readonly BlockService _service;

        public BlockMenu(BlockService blockService)
        {
            _service = blockService;
        }


        public void CreateItems()
        {
            AddItem("Создать блок", Create);
            AddItem("Изменить блок", Change);
            AddItem("Удалить блок", Delete);
        }

        protected override void UpdateStartText()
        {
            SetStartText("=== Меню Блоков ===" + "\n" +
                (_service.GetInfo().Success ?
                _service.GetInfo().Data :
                _service.GetInfo().Message));
        }

        void Create()
        {

            Console.WriteLine("Введите имя Блока");

            string name = Console.ReadLine();

            Result<Block> result = _service.Create(name);

            Console.WriteLine(result.Message);
        }

        void Change()
        {

            Console.WriteLine("Какой Блок вы хотите изменить?");

            int inputNumber = GetInputNumber();

            Console.WriteLine("Введите новое имя Блока");

            string newName = Console.ReadLine();

            Result<Block> result = _service.ChangeNameById(inputNumber, newName);

            Console.WriteLine(result.Message);
        }

        void Delete()
        {
            Console.WriteLine("Какой Блок вы хотите удалить?");

            int inputNumber = GetInputNumber();
            Result<Block> result = _service.DeleteById(inputNumber);

            Console.WriteLine(result.Message);
        }

    }
}
