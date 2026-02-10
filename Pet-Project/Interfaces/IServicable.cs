using Pet_Project.Models.OfficeStructure;
using Pet_Project.Repositories;
using Pet_Project.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet_Project.Interfaces
{
    internal interface IServicable<T>
    {
        public List<T> GetAll();

        public string ViewAll();
        public bool ChangeNameById(int id, string newName);

        public T GetById(int id);

        // ВОПРОС Это подумать
        public T Create(string name);

        public bool DeleteById(int id);
    }
}
