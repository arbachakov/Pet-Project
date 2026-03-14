using Pet_Project.Interfaces;
using Pet_Project.Models;
using Pet_Project.Pattern;

namespace Pet_Project.Repositories
{
    internal class ISRepository : IRepository<IS>
    {
        private List<IS> _iss = new List<IS>();

        public Result<List<IS>> GetAll()
        {
            return Result<List<IS>>.Ok(_iss, "Список получен из репозитория");
        }

        public Result<IS> Add(IS iS)
        {
            _iss.Add(iS);
            return Result<IS>.Ok(iS, $"Система {iS.Id} добавлена в репозиторий");
        }


        public Result<IS> GetById(int id)
        {
            for (int i = 0; i < _iss.Count; i++)
            {
                if (_iss[i].Id == id)
                    return Result<IS>.Ok(_iss[i], $"Система {_iss[i].Id} найдена");
            }
            return Result<IS>.Fail("Система не найдена в репозитории");
        }


        public Result<IS> ChangeNameById(int id, string newName)
        {
            Result<IS> result = GetById(id);

            if (result.Success)
            {
                // ВОПРОС Возможно ошибка
                IS iS = result.Data;
                string oldName = iS.Name;
                iS.Name = newName; // ВОПРОС Лучше сделать типы объектов через свойство, чтобы не менять сообщения...?
                return Result<IS>.Ok(iS, $"У работника с id {iS.Id} изменено имя c {oldName} на {newName}");
            }
            else
            {
                return Result<IS>.Fail(result.Message);
            }
        }

        public Result<IS> DeleteById(int id)
        {
            Result<IS> result = GetById(id);

            if (result.Success)
            {
                IS iS = result.Data;
                _iss.Remove(iS);
                return Result<IS>.Ok(iS, $"Рабочий {iS.Id} удален"); ;
            }
            else
            {
                return Result<IS>.Fail(result.Message);
            }
        }
    }
}
