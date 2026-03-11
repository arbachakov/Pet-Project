using Pet_Project.Interface;
using Pet_Project.Interfaces;
using Pet_Project.Models;
using Pet_Project.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet_Project.Repositories
{
    internal class WorkerRepository //: IRepository<Worker>
    {
        private List<Worker> _workers = new List<Worker>();

        public Result<List<Worker>> GetAll() //List<Worker>
        {
            if (this._workers.Count == 0)
            {
                return Result<List<Worker>>.Fail("Список пуст");
            }
            else
            {
                return Result<List<Worker>>.Ok(_workers, "Список получен из репозитория");
            }
        }

        public Result<Worker> Add(Worker worker) // bool
        {
            _workers.Add(worker);
            return Result<Worker>.Ok(worker,$"Рабочий {worker.Id} добавлен в репозиторий");
        }
            

        public Result<Worker> GetById(int id) //_workers[i]
        {
            for (int i = 0; i < _workers.Count; i++)
            {
                if (_workers[i].Id == id)
                    return Result<Worker>.Ok(_workers[i], $"Рабочий {_workers[i].Id} найден");
            }
            return Result<Worker>.Fail("Рабочий не найден в репозитории");
        }


        public Result<Worker> ChangeNameById(int id, string newName) // bool
        {
            Result<Worker> workerResult = GetById(id);

            if(workerResult.Success)
            {
                Worker worker = workerResult.Data;
                string oldName = worker.Name;
                worker.Name = newName;
                return Result<Worker>.Ok(worker, $"У работника с id {worker.Id} изменено имя c {oldName} на {newName}");
            }
            else
            {
                return Result<Worker>.Fail(workerResult.Message);
            }


            //Worker worker = GetById(id);
            //if (worker != null) 
            //{ 
            //    worker.Name = newName; 
            //    return true; 
            //}
            //return false;
        }

        public Result<Worker> ChangeSernameById(int id, string newSername)
        {
            Result<Worker> workerResult = GetById(id);

            if (workerResult.Success)
            {
                Worker worker = workerResult.Data;
                string oldSername = worker.Sername;
                worker.Sername = newSername;
                return Result<Worker>.Ok(worker, $"У работника с id {worker.Id} изменено имя c {oldSername} на {newSername}");
            }
            else
            {
                return Result<Worker>.Fail(workerResult.Message);
            }

            //Worker worker = GetById(id);
            //if (worker != null)
            //{
            //    worker.Sername = newSername;
            //    return true;
            //}
            //return false;
        }

        public Result<Worker> DeleteById(int id) // bool
        {
            Result<Worker> workerResult = GetById(id);

            if(workerResult.Success)
            {
                Worker worker = workerResult.Data;
                _workers.Remove(worker);
                return Result<Worker>.Ok(worker, $"Рабочий {worker.Id} удален"); ;
            }
            else
            {
                return Result<Worker>.Fail(workerResult.Message);
            }
            //Worker worker = GetById(id);
            //if (worker != null)
            //{
            //    _workers.Remove(worker);
            //    return true;
            //}
            //return false;

        }

        //public void ChangeNameById(int id, string newName)
        //{
        //    // ВОПРОС Почему это работает??
        //    IWorkable worker = _workers.GetWorkerById(id);

        //    worker.Name = newName;
        //}




    }
}
