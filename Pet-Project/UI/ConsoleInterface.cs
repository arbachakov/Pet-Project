using Pet_Project.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Pet_Project.UI
{
    internal class ConsoleInterface
    {
        public static void HelloMenu()
        {
            Console.WriteLine("Вас приветствует симулятор офиса");
            Console.ReadKey();
            Console.Clear();
        }


        public static void MainMenu()
        {
            Console.WriteLine(@"Чем займемся сейчас?
                1. Просмотр офиса;
                2. Создать блок;
                3. Создать службу;
                4. Создать работника;
                5. Выход
                7. Экспорт офиса (в разработке); 
                0. Импорт офиса (В разработке)."); // TODO добавить экспорт и импорт

            // Переделать 2 в поработать с блоками
            // Переделать 3 в поработать со службами
            // Переделать 4 в поработать с людьми


            string userAnswer = Console.ReadLine();

            bool isNumber = int.TryParse(userAnswer, out int numberUserAnswer);

            if (!isNumber)
            {
                Console.WriteLine("Введено не число");
            }

            switch (numberUserAnswer)
            {
                case 1:
                    // TODO Реализовать взаимодействие с объектами
                    break;
                case 2:
                    // TODO Реализовать взаимодействие с блоками
                    break;
                case 3:
                    // TODO Реализовать взаимодействие со службами
                    break;
                case 4:
                    // TODO Реализовать взаимодействие с людьми
                    break;
                case 5:
                    Console.WriteLine("До свидания :-)");
                    Console.ReadKey();
                    return; //????????? ВОПРОС правильно?
                default:
                    Console.WriteLine("Введено неверное число");
                    break;
            }
        }

        public static void CreateWorker()
        {
            Console.WriteLine(@"Выберете какого сотрудника хотите создать:
                            1. Начальник;
                            2. Сотрудник САСДУ;
                            3. Сотрудник СПАК;
                            4. Сотрудник СТ;");

            string userAnswer = Console.ReadLine();

            bool isNumber = int.TryParse(userAnswer, out int numberUserAnswer);
            
            // TODO Оформить в цикл
            if (!isNumber)
            {
                Console.WriteLine("Введено не число");
                // CreateWorker();
                // Так Можно???
            }

            GetNameSername(out string name, out string sername);

            switch (numberUserAnswer)
            {
                case 1:
                    // Создать сотрудника с именем и фамилией
                    // TODO Вынести это говно отсюда
                    
                    StaffService.CreateManager(name, sername);
                    break;
                case 2:
                    StaffService.CreateISAdmin(name, sername);
                    break;
                case 3:
                    StaffService.CreateServerAdmin(name, sername);
                    break;
                case 4:
                    StaffService.CreateNETAdmin(name, sername);
                    break;
                default:
                    Console.WriteLine("Введено неверное число");
                    break;
            }

            // ВОПРОС нужно это дело оформлять в метод?
            Console.WriteLine($"{name} {sername} добавлен в наш дружный офис!");
            Console.Clear();

            MainMenu();


            void GetNameSername(out string name, out string sername)
            {
                Console.WriteLine("Напишите имя сотрудника");
                name = Console.ReadLine();
                Console.WriteLine("Напишите фамилию сотрудника");
                sername = Console.ReadLine();
            }
        }

        public static void CreateBlock()
        {
            Console.WriteLine("Введите название блока");

            string userAnswer = Console.ReadLine();

            OfficeService.CreateBlock(userAnswer);

            Console.WriteLine($"{userAnswer} добавлен в наш дружный офис!");
            Console.Clear();

            MainMenu();
        }

        public static void CreateDeparttment()
        {
            Console.WriteLine("Введите название Службы");

            string userAnswer = Console.ReadLine();

            OfficeService.CreateDepartment(userAnswer);

            Console.WriteLine($"{userAnswer} добавлен в наш дружный офис!");
            Console.Clear();

            MainMenu();
        }
    }
}
