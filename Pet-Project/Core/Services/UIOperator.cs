using Pet_Project.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Pet_Project.Core.Services
{
    internal class UIOperator
    {
        private readonly OfficeService _officeService;
        private readonly WorkerService _workerService;

        public UIOperator(OfficeService officeService, WorkerService workerService)
        {
            _officeService = officeService;
            _workerService = workerService;
        }


        public string ExecuteCommand(string command,int id)
        {
            switch (command)
            {
                case "GET_WORKER_BY_ID":
                    {
                        return _workerService.GetWorkerById(id);
                    }
                case "DELETE_WORKER_BY_ID":
                    {
                        bool deleted = _workerService.DeleteWorkerById(id) ;
                        return deleted ? $"Пользователь {id} удален" : $"Пользователь {id} не удален";
                        break;
                    }
                default:
                    { return "Ошибка"; }
            }
        }

        public string ExecuteCommand(string command, Dictionary<string, object> data = null) // ВОПРОС  "= null" или лучше отдельный метод с перегрузкой сделать
        {
            switch (command)
            {
                case "GET_ALL_WORKERS":
                    {
                        List<string> workers = _workerService.GetAllWorkers();
                        string result = "";
                        if (workers == null)
                        {
                            result = "Список сотрудников пуст(";
                            return result;
                        }
                        foreach (string worker in workers)
                        {
                            result += worker + "\n";
                        }

                        return result;
                    }
                case "CHANGE_WORKER_DATA":
                    {
                        if (data["name"] != null)
                        {
                            _workerService.ChangeWorkerNameById((int)data["workerId"], (string)data["name"]);
                        }
                        if (data["sername"] != null)
                        {
                            _workerService.ChangeWorkerSernameById((int)data["workerId"], (string)data["sename"]);
                        }
                        break;
                    }
                case "CREATE_WORKER":
                {
                    string name = (string)data["name"]; // ВОПРОС Использование таких словарей норм? Взаимная связь Оператора и СтаффМеню
                    string sername = (string)data["sername"];
                    int type = (int)data["type"];

                    if(type == 1)
                    {
                        _workerService.CreateManager(name, sername);
                        return $"Успешно создан менеджер {name} {sername}";
                    }
                    else if(type == 2)
                    {
                        _workerService.CreateISAdmin(name, sername);
                        return $"Успешно создан админ ИС {name} {sername}";
                    }
                    if (type == 3)
                    {
                        _workerService.CreateServerAdmin(name, sername);
                        return $"Успешно создан админ ИС {name} {sername}";
                    }
                    if (type == 4)
                    {
                        _workerService.CreateNETAdmin(name, sername);
                        return $"Успешно создан админ ИС {name} {sername}";
                    }

                        break;
                }
                default:
                    return $"Ошибка";

            }
            return "";
        }


    }
}
