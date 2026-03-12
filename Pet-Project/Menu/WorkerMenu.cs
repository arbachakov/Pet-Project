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

        public void CreateItems()
        { // TODO Настроить вызов после каждого вызова любого метода. Возможно перестроить BaseMenu
            SetStartText("===Меню Сотрудников===\n" + 
                GetWorkersInfo() + 
                GetManagementInfo());
            
            AddItem("Создать сотрудника", Create);
            AddItem("Изменить сотрудника", Change);
            AddItem("Удалить сотрудника", Delete);
            AddItem("Добавить связи менеджемента", AddRelation);
            AddItem("Удалить связи менеджемента", RemoveRelation);
        }


        void Create()
        {
            Console.WriteLine("Введите имя Сотрудника");

            string name = Console.ReadLine();

            Result<Worker> resultWorker = _service.Create(name);

            Console.WriteLine(resultWorker.Message);
        }

        void Change()
        {
            Console.WriteLine("Какого сотрудника вы хотите изменить?");

            int inputNumber = GetInputNumber();

            Console.WriteLine("Введите новое имя сотрудника");

            string newName = Console.ReadLine();

            Result<Worker> resultWorker = _service.ChangeNameById(inputNumber, newName);

            Console.WriteLine(resultWorker.Message);
        }

        void Delete()
        {
            Console.WriteLine("Какого сотрудника вы хотите удалить?");

            int inputNumber = GetInputNumber();
            Result<Worker> resultWorker = _service.DeleteById(inputNumber);

            Console.WriteLine(resultWorker.Message);
        }

        void AddRelation()
        {
            Console.WriteLine("Выберете сотруников для выбора менеджемента");
            Console.WriteLine("Кто будет руководителем? (напишите id)");

            int inputNumberManager = GetInputNumber();

            Console.WriteLine("Кто будет подчиненным? (напишите id)");

            int inputNumberWorker = GetInputNumber();

            Result<Worker> resultManager = _service.GetById(inputNumberManager);
            Result<Worker> resultWorker = _service.GetById(inputNumberWorker);

            if (resultManager.Success && resultWorker.Success)
            {
                
                Result<Worker> resultDict = _service.AddRelation(
                    resultManager.Data, resultWorker.Data );
                Console.WriteLine(resultDict.Message);
            }
            else
            {
                Console.WriteLine(resultManager.Message);
                Console.WriteLine(resultWorker.Message);
            }   
        }

        void RemoveRelation()
        {
            Console.WriteLine("Выберете сотруников для удаления из менеджемента");
            Console.WriteLine("Кто руководитель? (напишите id)");

            int inputNumberManager = GetInputNumber();

            Console.WriteLine("Кто подчиненный? (напишите id)");

            int inputNumberWorker = GetInputNumber();

            Result<Worker> resultManager = _service.GetById(inputNumberManager);
            Result<Worker> resultWorker = _service.GetById(inputNumberWorker);

            if (resultManager.Success && resultWorker.Success)
            {

                Result<Worker> resultDict = _service.RemoveRelation(
                    resultManager.Data, resultWorker.Data);
                Console.WriteLine(resultDict.Message);
            }
            else
            {
                Console.WriteLine(resultManager.Message);
                Console.WriteLine(resultWorker.Message);
            }
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

        string GetManagementInfo()
        {
            Result<Dictionary<Worker, Worker>> resultDict = _service.GetWorkerDict();

            if (resultDict.Success)
            {
                Dictionary<Worker, Worker> workersDict = resultDict.Data;

                if (workersDict.Count == 0)
                {
                    return "Нет связей для установки начальства";
                }
                else
                {
                    string managementInfo = "";

                    foreach (var item in workersDict)
                    {
                        managementInfo += item.Key.Name + "руководит" + item.Value + "\n";
                        return managementInfo;
                    }
                }
            }
            else
            {
                return resultDict.Message;
            }

            return resultDict.Message;
        }
    }
}
