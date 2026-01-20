using Pet_Project.Data.Models;
using Pet_Project.Data.Models.OfficeStructure;
using Pet_Project.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet_Project.Core.Services
{
    internal class StaffService
    {
        // ВОПРОС Реализовать создание ID отдельной сущностью
        static Random _rnd = new Random();
        private static List<int> _staffIds;

        public static WorkerRespository workerRespository;

        private static int GenerateID()
        {
            int id;
            
            do
            {
                id = _rnd.Next(0, 100000);
            } while (!_staffIds.Contains(id));
            return id;
        }

        // TODO Реализовать изменение, удаление сотрудников
        // TODO Реализовать Обязанности сотрудников
        
        public static Manager CreateManager(string name, string sername)
        {
            Manager manager = new Manager(name,sername);
            manager.ID = GenerateID();
            workerRespository.AddWorker(manager);
            return manager;
        }

        public static ISAdmin CreateISAdmin(string name, string sername)
        {
            ISAdmin ISAdmin = new ISAdmin(name, sername);
            ISAdmin.ID = GenerateID();
            workerRespository.AddWorker(ISAdmin);
            return ISAdmin;
        }

        public static ServerAdmin CreateServerAdmin(string name, string sername)
        {
            ServerAdmin ServerAdmin = new ServerAdmin(name, sername);
            ServerAdmin.ID = GenerateID();
            workerRespository.AddWorker(ServerAdmin);
            return ServerAdmin;
        }

        public static NETAdmin CreateNETAdmin(string name, string sername)
        {
            NETAdmin NETAdmin = new NETAdmin(name, sername);
            NETAdmin.ID = GenerateID();
            workerRespository.AddWorker(NETAdmin);
            return NETAdmin;
        }
    }
}
