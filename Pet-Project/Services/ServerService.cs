using Pet_Project.Interfaces;
using Pet_Project.Model;
using Pet_Project.Pattern;
using Pet_Project.Repositories;

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

        #region Repository
        public Result<List<Server>> GetAll()
        {
            Result<List<Server>> resultServer = _repository.GetAll();

            if (resultServer.Success)
            {
                return Result<List<Server>>.Ok(resultServer.Data, resultServer.Message);
            }
            else
            {
                return Result<List<Server>>.Fail(resultServer.Message);
            }
        }

        public Result<string> GetInfo()
        {
            Result<List<Server>> result = _repository.GetAll();

            if (result.Success)
            {
                List<Server> servers = result.Data;

                string info = "Инф системы:\n";

                if (servers.Count == 0)
                {
                    return Result<string>.Ok("Серверов нет.", "Информация составлена");
                }

                for (int i = 0; i < servers.Count; i++)
                {
                    info += $"Имя: {servers[i].Name} Id: {servers[i].Id}\n";
                }
                return Result<string>.Ok(info, "Информация составлена");
            }
            else
            {
                return Result<string>.Fail(result.Message);
            }
        }


        public Result<Server> ChangeNameById(int id, string newName)
        {
            Result<Server> resultServer = _repository.ChangeNameById(id, newName);

            if (resultServer.Success)
            {
                return Result<Server>.Ok(resultServer.Data, resultServer.Message);
            }
            else
            {
                return Result<Server>.Fail(resultServer.Message);
            }

        }

        public Result<Server> ChangeSernameById(int id, string newSername)
        {
            Result<Server> resultServer = _repository.ChangeNameById(id, newSername);

            if (resultServer.Success)
            {
                return Result<Server>.Ok(resultServer.Data, resultServer.Message);
            }
            else
            {
                return Result<Server>.Fail(resultServer.Message);
            }
        }

        public Result<Server> DeleteById(int id)
        {
            Result<Server> resultServer = _repository.DeleteById(id);

            if (resultServer.Success)
            {
                return Result<Server>.Ok(resultServer.Data, resultServer.Message);
            }
            else
            {
                return Result<Server>.Fail(resultServer.Message);
            }
        }

        public Result<Server> GetById(int id)
        {
            Result<Server> resultServer = _repository.GetById(id);

            if (resultServer.Success)
            {
                return Result<Server>.Ok(resultServer.Data, resultServer.Message);
            }
            else
            {
                return Result<Server>.Fail(resultServer.Message);
            }
        }

        public Result<Server> Create(string name)
        {
            Server server = new Server(name);
            server.Id = _idGeneratorService.GenerateID();

            Result<Server> resultServer = _repository.Add(server);

            if (resultServer.Success)
            {
                return Result<Server>.Ok(resultServer.Data, resultServer.Message);
            }
            else
            {
                return Result<Server>.Fail(resultServer.Message);
            }
        }
        #endregion Repository
    }
}
