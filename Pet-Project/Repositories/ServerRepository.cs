using Pet_Project.Interfaces;
using Pet_Project.Model;
using Pet_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet_Project.Repositories
{
    internal class ServerRepository : IRepository<Server>
    {
        private List<Server> _servers = new List<Server>();

        public List<Server> GetAll()
        { return _servers; }

        public bool Add(Server server)
        {
            _servers.Add(server);
            return true;
        }


        public Server GetById(int id)
        {
            for (int i = 0; i < _servers.Count; i++)
            {
                if (_servers[i].Id == id)
                    return _servers[i];
            }
            return null;
        }


        public bool ChangeNameById(int id, string newName)
        {
            IS IS = GetById(id);
            if (IS != null)
            {
                IS.Name = newName;
                return true;
            }
            return false;
        }

        public bool DeleteById(int id)
        {
            IS IS = GetById(id);
            if (IS != null)
            {
                _servers.Remove(IS);
                return true;
            }
            return false;

        }
    }
}
