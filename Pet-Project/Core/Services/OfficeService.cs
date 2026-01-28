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

        private readonly OfficeRepository _officeRepository;

        public OfficeService(OfficeRepository officeRepository)
        {
            _officeRepository = officeRepository;
        }

        // TODO Добавить функции удаления, изменения блоков и Служб

        // ВОПРОС Для каждой офисной единицы (блок и служба, возможно отделы) нужно создавать свой сервис?
        // Типо БлокСервис, СлужбаСервис, ОтделСервис... По SOLID

        public  void CreateBlock(string name)
        {
            Block block = new Block() { Name = name };

            _officeRepository.blocks.Add(block);
        }

        public void CreateDepartment(string name)
        {
            Department department = new Department() {Name = name};

            _officeRepository.departments.Add(department);
        }
    }
}
