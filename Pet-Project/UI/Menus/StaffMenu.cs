using Pet_Project.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Pet_Project.UI.Menus
{
    internal class StaffMenu
    {


        public static void ShowAndHandle(UIOperator uIOperator)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== РАБОТА С СОТРУДНИКАМИ ===");
                Console.WriteLine();
                GetAllWorkers(uIOperator);
                Console.WriteLine();
                Console.WriteLine("1. Создать сотрудника"); // CRUD
                Console.WriteLine("2. Изменить работника");
                Console.WriteLine("3. Удалить работника");
                Console.WriteLine("0. Назад");
                Console.Write("\nВыберите: ");

                string input = Console.ReadLine();
                if (!int.TryParse(input, out int choice))
                {
                    Console.WriteLine("Вы ввели что-то не то.. Попробуйте другую цифру :)");
                    Console.WriteLine("\n\nНажмите кнопку...");
                    Console.ReadKey();
                    continue;
                }

                if (choice == 0) { return; }

                HandleChoice(choice, uIOperator);

                Console.WriteLine("Нажмите клавишу");
                Console.ReadKey();
            }
        }

        private static void GetAllWorkers(UIOperator uiOperator) // ВОПРОС методы в разных слоях лучше именовать одинаково?
        {
            Console.WriteLine(uiOperator.ExecuteCommand("GET_ALL_WORKERS"));
        }

        private static void HandleChoice(int choice, UIOperator uIOperator)
        {
            switch (choice)
            {
                case 1:
                    {
                        while (true)
                        {
                            Console.WriteLine("Создаем сотрудника");
                            Console.WriteLine("Имя:");
                            string name = Console.ReadLine();

                            if (name.Length < 2 || name.Length > 20 || Regex.IsMatch(name, @"\p{IsCyrillic}"))
                            {
                                Console.WriteLine("Имя должно состоять из букв русского алфавита не короче 2 и не длиннее 20 символов!!!");
                                Console.WriteLine("Попробуем заново");
                                Console.WriteLine("\n\nНажмите кнопку...");
                                Console.ReadKey();
                                continue;
                            }


                            Console.WriteLine("Фамилия:");
                            string sername = Console.ReadLine();

                            if (sername.Length < 2 || sername.Length > 20 || Regex.IsMatch(sername, @"\p{IsCyrillic}"))
                            {
                                Console.WriteLine("Фамилия должна состоять из букв русского алфавита не короче 2 и не длиннее 20 символов!!!");
                                Console.WriteLine("Попробуем заново");
                                Console.WriteLine("\n\nНажмите кнопку...");
                                Console.ReadKey();
                                continue;
                            }


                            Console.WriteLine("Тип 1 - Менеджер, 2 - Админ ИС" +
                                "3 - Админ серверов, 4 - Админ сетевой");

                            string typeInput = Console.ReadLine();

                            if (!int.TryParse(typeInput, out int type))
                            {
                                Console.WriteLine("Вы ввели что-то не то.. Попробуйте другую цифру :)");
                                Console.WriteLine("\n\nНажмите кнопку...");
                                Console.ReadKey();
                                continue;
                            }


                            var data = new Dictionary<string, object>()
                        {
                            {"name", name},
                            {"sername", sername},
                            {"type", type }
                        };

                            var response = uIOperator.ExecuteCommand("CREATE_WORKER", data);
                            Console.WriteLine(response);
                            break;
                        }
                        break;
                    }
                case 2:
                    {
                        while (true)
                        {
                            Console.WriteLine("Какого сотрудника рассмотрим на редактирование? (id)");
                            string input = Console.ReadLine();
                            if (!int.TryParse(input, out int id))
                            {
                                Console.WriteLine("Вы ввели что-то не то.. Попробуйте другую цифру :)");
                                continue;
                            }
                            EditWorkerMenu(uIOperator, id);
                        }
                    break;
                    }
                case 3:
                    {
                        while (true)
                        {
                            Console.WriteLine("Какого сотрудника удалим? (id)");
                            string input = Console.ReadLine();
                            if (!int.TryParse(input, out int id))
                            {
                                Console.WriteLine("Вы ввели что-то не то.. Попробуйте другую цифру :)");
                                continue;
                            }
                            uIOperator.ExecuteCommand("DELETE_WORKER_BY_ID", id);
                        }
                    }
                    
                default:
                    Console.WriteLine("Неизвестная программа, Попробуйте другую цифру :)");
                    break;
            }
        }

        public static void EditWorkerMenu(UIOperator uIOperator ,int  Id)
        {
            string workerInfo = uIOperator.ExecuteCommand("GET_WORKER_BY_ID", Id);
            string[] worker = workerInfo.Split(',');
            string workerName = worker[0];
            string workerSername = worker[1];
            string workerId = worker[2];

            Dictionary<string, object> data = new Dictionary<string, object>()
            {
                { "name", null},
                {"sername", null},
                {"workerId", workerId }
            };


            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== РЕДАКТИРОВАНИЕ СОТРУДНИКА ===");

                Console.WriteLine($"Имя: {workerName}");
                Console.WriteLine($"Фамилия: {workerSername}");
                Console.WriteLine($"Id: {workerId}");

                Console.WriteLine("1. Изменить Имя");
                Console.WriteLine("2. Изменить Фамилию");
                Console.WriteLine("3. Сохранить изменения");
                Console.WriteLine("0. Назад");
                Console.Write("\nВыберите: ");

                string input = Console.ReadLine();
                if (!int.TryParse(input, out int choice))
                {
                    continue;
                }
                switch (choice)
                {
                    case 1:
                        {
                            Console.WriteLine("Введите новое имя");
                            string newName = Console.ReadLine();
                            data["name"] = newName;
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Введите новую фамилию");
                            string newSername = Console.ReadLine();
                            data["sername"] = newSername;
                            break;
                        }
                    case 0:
                        {
                            ShowAndHandle(uIOperator);
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Введено неверное число"); 
                            break;
                        }
                }
            }
        }
    }
}
