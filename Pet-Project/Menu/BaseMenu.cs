using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet_Project.Menus
{
    internal abstract class BaseMenu
    {

        private class MenuItem
        {
            public string Text { get; set; }
            public Action Action { get; set; }

            public MenuItem(string textItem, Action action) 
            {
                Text = textItem;
                Action = action;
            }
        }

        private List<MenuItem> _items = new();
        
        private string _startText;

        public void SetStartText(string newStartText) => _startText = newStartText;

        public void AddItem(string textItem, Action action)
        {
            MenuItem menuItem = new(textItem, action);
            _items.Add(menuItem);
        }

        abstract protected void UpdateStartText();

        public void Run()
        {
            while (true)
            {
                Console.Clear();

                UpdateStartText();

                Console.WriteLine(_startText);

                for (int i = 0; i < _items.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {_items[i].Text}");
                }
                Console.WriteLine("0. Выход");

                int choice = GetInputNumberMenu();

                if(choice == 0)
                    break;

                _items[choice - 1].Action.Invoke();
            }
        }

        protected int GetInputNumberMenu()
        {
            while (true)
            {
                int input = GetInputNumber();

                if (input < 0 || input > _items.Count)
                {
                    Console.WriteLine($"Введено некорректное число! " +
                        $"Используйте числа от 1 до {_items.Count} или 0");
                    continue;
                }

                return input;
            }
        }

        protected int GetInputNumber()
        {
            while (true)
            {
                Console.WriteLine("Введите число:");

                string input = Console.ReadLine();

                bool isNumber = int.TryParse(input, out int choice);

                if (!isNumber)
                {
                    Console.WriteLine("Введено не число! Попробуем заново");
                    continue;
                }
                return choice;
            }
        }
    }
}
