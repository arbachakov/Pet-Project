using Pet_Project.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet_Project.UI.Menus
{
    internal class MainMenu
    {
        //private readonly UIOperator _uiOperator;
        //private readonly StaffMenu _staffMenu;

        //public MainMen(UIOperator uiOperator, StaffMenu staffMenu)
        //{
        //    _uiOperator = uiOperator;
        //    _staffMenu = staffMenu;
        //}


        // ВОПРОС Почему в других классах мы создаем приватный класс высшего слоя, а тут передаем в метод? Какие особенности? 
        public static void Show(UIOperator uiOperator)
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("=== ГЛАВНОЕ МЕНЮ ===");
                Console.WriteLine("1. Просмотр офиса;");
                Console.WriteLine("2. Работа со структурой офиса;");
                Console.WriteLine("3. Работа с сотрудниками;");
                Console.WriteLine("0. Выход");

                string input = Console.ReadLine();
                if (!int.TryParse(input, out int choice))
                {
                    Console.WriteLine("Вы ввели что-то не то.. Попробуйте другую цифру :)");
                    Console.WriteLine("\n\nНажмите кнопку...");
                    Console.ReadKey();
                    continue;
                }
                if (choice == 0)
                {
                    Console.WriteLine("До свидания!\n\nНажмите кнопку...");
                    Console.ReadKey();
                    break;
                }
                
                HandleChoice(choice, uiOperator);
            }
        }

        public static void HandleChoice(int choice, UIOperator uiOperator)
        {
            switch (choice)
            {
                case 1:
                    {
                        Console.WriteLine("Все хорошо тут в офисе! Иди назад.  (В РАЗРАБОТКЕ)");
                        Console.WriteLine("\n\nНажмите кнопку...");
                        Console.ReadKey();
                        Show(uiOperator);
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("Все хорошо тут в офисе! Иди назад.  (В РАЗРАБОТКЕ)");
                        Console.WriteLine("\n\nНажмите кнопку...");
                        Console.ReadKey();
                        Show(uiOperator);
                        break;
                    }
                case 3:
                    {
                        StaffMenu.ShowAndHandle(uiOperator);
                        break;
                    }
                case 0:
                    {
                        Console.WriteLine("До свидания!\nнажмите кнопку...");
                        Console.ReadKey();
                        break;
                    }
                default:
                    {
                        break;
                    }


            }
        }

    }
}
