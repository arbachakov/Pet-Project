using Pet_Project.Data.Models.OfficeStructure;
using Pet_Project.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Pet_Project.Core.Services
{
    internal class OfficeService
    {
        public static OfficeRepository OfficeRepository;


        // TODO Добавить функции удаления, изменения блоков и Служб

        public static void CreateBlock(string name)
        {
            Block block = new Block() { Name = name };

            OfficeRepository.blocks.Add(block);
        }

        public static void CreateDepartment(string name)
        {
            Department department = new Department() {Name = name};

            OfficeRepository.departments.Add(department);
        }
    }
}
