using Pet_Project.Interfaces;
using Pet_Project.Model;
using Pet_Project.Pattern;

namespace Pet_Project.Repositories
{
    internal class ServerRepository : IRepository<Server>
    {
        private List<Server> _servers = new List<Server>();

        public Result<List<Server>> GetAll()
        { 
            return Result<List<Server>>.Ok(_servers, "Список получен из репозитория"); 
        }

        // TODO Добавить больше подробностей
        public Result<Server> Add(Server server)
        {
            _servers.Add(server);
            return Result<Server>.Ok(server, $"Сервер {server.Id} добавлен в репозиторий");
        }


        public Result<Server> GetById(int id)
        {
            for (int i = 0; i < _servers.Count; i++)
            {
                if (_servers[i].Id == id)
                    return Result<Server>.Ok(_servers[i], $"Рабочий {_servers[i].Id} найден");
            }
            return Result<Server>.Fail("Рабочий не найден в репозитории");
        }


        public Result<Server> ChangeNameById(int id, string newName)
        {
            Result<Server> result = GetById(id);

            if (result.Success)
            {
                Server server = result.Data;
                string oldName = server.Name;
                server.Name = newName;
                return Result<Server>.Ok(server, $"У работника с id {server.Id} изменено имя c {oldName} на {newName}");
            }
            else
            {
                return Result<Server>.Fail(result.Message);
            }
        }

        public Result<Server> DeleteById(int id)
        {
            Result<Server> result = GetById(id);

            if (result.Success)
            {
                Server server= result.Data;
                _servers.Remove(server);
                return Result<Server>.Ok(server, $"Рабочий {server.Id} удален"); ;
            }
            else
            {
                return Result<Server>.Fail(result.Message);
            }
        }
    }
}
