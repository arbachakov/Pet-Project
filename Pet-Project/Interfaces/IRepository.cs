using Pet_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet_Project.Interfaces
{
    internal interface IRepository<T>
    {
        public bool Add(T value);

        public T GetById(int id);

        public bool ChangeNameById(int id, string newName);

        public bool DeleteById(int id);

    }
}
