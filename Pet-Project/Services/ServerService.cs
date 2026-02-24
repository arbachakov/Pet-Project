using Pet_Project.Interfaces;
using Pet_Project.Model;
using Pet_Project.Models;
using Pet_Project.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet_Project.Services
{
    internal class ServerService : IServicable<Server>
    {
        private readonly ServerRepository _repository;
        private readonly IdGeneratorService _idGeneratorService;

        public ServerService(ServerRepository repository,
            IdGeneratorService idGeneratorService)
        {
            _repository = repository;
            _idGeneratorService = idGeneratorService;
        }

        public List<Server> GetAll()
        {
            return _repository.GetAll();
        }

        public string ViewAll()
        {
            string blocksInfo = "Информационные системы:\n";
            List<Server> servers = GetAll();
            if (servers.Count == 0)
            { return "ИС нет("; }
            for (int i = 0; i < servers.Count; i++)
            {
                blocksInfo += $"Название: {servers[i].Name} Id: {servers[i].Id}\n";
            }
            return blocksInfo;
        }

        public bool ChangeNameById(int id, string newName)
        {
            if (_repository.ChangeNameById(id, newName))
            { return true; }
            return false;

        }

        public Server GetById(int id)
        {
            return _repository.GetById(id);
        }

        public Server Create(string name)
        {
            Server server = new Server(name);
            server.Id = _idGeneratorService.GenerateID();
            _repository.Add(server);
            return server;
        }

        public bool DeleteById(int id)
        {
            if (_repository.DeleteById(id))
            { return true; }
            return false;
        }
    }
}
