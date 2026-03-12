using Pet_Project.Model;
using Pet_Project.Models;
using Pet_Project.Pattern;
using Pet_Project.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet_Project.RegServertries
{
    internal class ServerAdmRegServertry
    {
        private readonly ServerRepository _repository;

        public ServerAdmRegServertry(ServerRepository repository)
        {
            _repository = repository;
        }

        private Dictionary<Worker, Server> WorkerServer = new Dictionary<Worker, Server>();

        private Dictionary<Server, Worker> ServerWorker = new Dictionary<Server, Worker>();


        public Result<Dictionary<Worker, Server>> GetWorkerServerDict()
        {
            return Result<Dictionary<Worker, Server>>.Ok(WorkerServer, "Словарь получен");
        }

        public Result<Dictionary<Server, Worker>> GetServerWorkerDict()
        {
            return Result<Dictionary<Server, Worker>>.Ok(ServerWorker, "Словарь получен");
        }

        public Result<Worker> AddRelation(Worker worker, Server server)
        {
            WorkerServer[worker] = server;
            ServerWorker[server] = worker;

            return Result<Worker>.Ok(worker, $"Добавлена связь {worker.Name} - {server.Name}");
        }

        public Result<Server> AddRelation(Server server, Worker worker)
        {
            WorkerServer[worker] = server;
            ServerWorker[server] = worker;

            return Result<Server>.Ok(server, $"Добавлена связь {worker.Name} - {server.Name}");
        }

        public Result<Worker> RemoveRelation(Worker worker, Server server)
        {
            if (WorkerServer[worker] == server && ServerWorker[server] == worker)
            {
                WorkerServer.Remove(worker);
                ServerWorker.Remove(server);
                return Result<Worker>.Ok(worker, $"Удалена связь {worker.Name} - {server.Name}");
            }
            else
            {
                return Result<Worker>.Fail($"Связь {worker.Name} - {server.Name} не найдена.");
            }
        }

    }
}
