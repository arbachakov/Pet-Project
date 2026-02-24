using Pet_Project.Interfaces;
using Pet_Project.Models;
using Pet_Project.Models.OfficeStructure;
using Pet_Project.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet_Project.Services
{
    internal class ISService : IServicable<IS>
    {

        private readonly ISRepository _repository;
        private readonly IdGeneratorService _idGeneratorService;

        public ISService(ISRepository repository,
            IdGeneratorService idGeneratorService)
        {
            _repository = repository;
            _idGeneratorService = idGeneratorService;
        }

        public List<IS> GetAll()
        {
            return _repository.GetAll();
        }

        public string ViewAll()
        {
            string blocksInfo = "Информационные системы:\n";
            List<IS> ISS = GetAll();
            if (ISS.Count == 0)
            { return "ИС нет("; }
            for (int i = 0; i < ISS.Count; i++)
            {
                blocksInfo += $"Название: {ISS[i].Name} Id: {ISS[i].Id}\n";
            }
            return blocksInfo;
        }

        public bool ChangeNameById(int id, string newName)
        {
            if (_repository.ChangeNameById(id, newName))
            { return true; }
            return false;

        }

        public IS GetById(int id)
        {
            return _repository.GetById(id);
        }

        public IS Create(string name)
        {
            IS IS = new IS(name);
            IS.Id = _idGeneratorService.GenerateID();
            _repository.Add(IS);
            return IS;
        }

        public bool DeleteById(int id)
        {
            if (_repository.DeleteById(id))
            { return true; }
            return false;
        }

    }
}
