using Pet_Project.Interfaces;
using Pet_Project.Models;
using Pet_Project.Pattern;
using Pet_Project.Repositories;

namespace Pet_Project.Services
{
    internal class ISService : IServicable<IS>
    {

        private readonly ISRepository _repository;
        private readonly IdGeneratorService _idGeneratorService;

        public ISService(ISRepository repository,
            IdGeneratorService idGeneratorService)
        {
            _repository = repository;
            _idGeneratorService = idGeneratorService;
        }

        #region Repository
        public Result<List<IS>> GetAll()
        {
            Result<List<IS>> resultIS = _repository.GetAll();

            if (resultIS.Success)
            {
                return Result<List<IS>>.Ok(resultIS.Data, resultIS.Message);
            }
            else
            {
                return Result<List<IS>>.Fail(resultIS.Message);
            }
        }

        public Result<string> GetInfo()
        {
            Result<List<IS>> result = _repository.GetAll();

            if (result.Success)
            {
                List<IS> iSs = result.Data;

                string info = "Инф системы:\n";

                if (iSs.Count == 0)
                {
                    return Result<string>.Ok("Инф систем нет.", "Информация составлена");
                }

                for (int i = 0; i < iSs.Count; i++)
                {
                    info += $"Имя: {iSs[i].Name} Id: {iSs[i].Id}\n";
                }
                return Result<string>.Ok(info, "Информация составлена");
            }
            else
            {
                return Result<string>.Fail(result.Message);
            } 
        }



        public Result<IS> ChangeNameById(int id, string newName)
        {
            Result<IS> resultIS = _repository.ChangeNameById(id, newName);

            if (resultIS.Success)
            {
                return Result<IS>.Ok(resultIS.Data, resultIS.Message);
            }
            else
            {
                return Result<IS>.Fail(resultIS.Message);
            }

        }

        public Result<IS> ChangeSernameById(int id, string newSername)
        {
            Result<IS> resultIS = _repository.ChangeNameById(id, newSername);

            if (resultIS.Success)
            {
                return Result<IS>.Ok(resultIS.Data, resultIS.Message);
            }
            else
            {
                return Result<IS>.Fail(resultIS.Message);
            }
        }

        public Result<IS> DeleteById(int id)
        {
            Result<IS> resultIS = _repository.DeleteById(id);

            if (resultIS.Success)
            {
                return Result<IS>.Ok(resultIS.Data, resultIS.Message);
            }
            else
            {
                return Result<IS>.Fail(resultIS.Message);
            }
        }

        public Result<IS> GetById(int id)
        {
            Result<IS> resultIS = _repository.GetById(id);

            if (resultIS.Success)
            {
                return Result<IS>.Ok(resultIS.Data, resultIS.Message);
            }
            else
            {
                return Result<IS>.Fail(resultIS.Message);
            }
        }

        public Result<IS> Create(string name)
        {
            IS iS = new IS(name);
            iS.Id = _idGeneratorService.GenerateID();

            Result<IS> resultIS = _repository.Add(iS);

            if (resultIS.Success)
            {
                return Result<IS>.Ok(resultIS.Data, resultIS.Message);
            }
            else
            {
                return Result<IS>.Fail(resultIS.Message);
            }
        }
        #endregion Repository
    }
}
