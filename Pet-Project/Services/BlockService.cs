using Pet_Project.Interfaces;
using Pet_Project.Models.OfficeStructure;
using Pet_Project.Pattern;
using Pet_Project.Repositories;

namespace Pet_Project.Services
{
    internal class BlockService : IServicable<Block>
    {
        private readonly BlockRepository _repository;
        private readonly IdGeneratorService _idGeneratorService;

        public BlockService(BlockRepository blockRepository,
            IdGeneratorService idGeneratorService)
        {
            _repository = blockRepository;
            _idGeneratorService = idGeneratorService;
        }

        #region Repository
        public Result<List<Block>> GetAll()
        {
            Result<List<Block>> resultBlock = _repository.GetAll();

            if (resultBlock.Success)
            {
                return Result<List<Block>>.Ok(resultBlock.Data, resultBlock.Message);
            }
            else
            {
                return Result<List<Block>>.Fail(resultBlock.Message);
            }
        }

        public Result<string> GetInfo()
        {
            Result<List<Block>> result = _repository.GetAll();

            if (result.Success)
            {
                List<Block> bloks = result.Data;

                string info = "Блоки:\n";

                if (bloks.Count == 0)
                {
                    return Result<string>.Ok("Блоков нет.", "Информация составлена");
                }

                for (int i = 0; i < bloks.Count; i++)
                {
                    info += $"Имя: {bloks[i].Name} Id: {bloks[i].Id}\n";
                }
                return Result<string>.Ok(info, "Информация составлена");
            }
            else
            {
                return Result<string>.Fail(result.Message);
            }
        }

        public Result<Block> ChangeNameById(int id, string newName)
        {
            Result<Block> resultBlock = _repository.ChangeNameById(id, newName);

            if (resultBlock.Success)
            {
                return Result<Block>.Ok(resultBlock.Data, resultBlock.Message);
            }
            else
            {
                return Result<Block>.Fail(resultBlock.Message);
            }

        }

        public Result<Block> DeleteById(int id)
        {
            Result<Block> resultBlock = _repository.DeleteById(id);

            if (resultBlock.Success)
            {
                return Result<Block>.Ok(resultBlock.Data, resultBlock.Message);
            }
            else
            {
                return Result<Block>.Fail(resultBlock.Message);
            }
        }

        public Result<Block> GetById(int id)
        {
            Result<Block> resultBlock = _repository.GetById(id);

            if (resultBlock.Success)
            {
                return Result<Block>.Ok(resultBlock.Data, resultBlock.Message);
            }
            else
            {
                return Result<Block>.Fail(resultBlock.Message);
            }
        }

        public Result<Block> Create(string name)
        {
            Block block = new Block(name);
            block.Id = _idGeneratorService.GenerateID();

            Result<Block> resultBlock = _repository.Add(block);

            if (resultBlock.Success)
            {
                return Result<Block>.Ok(resultBlock.Data, resultBlock.Message);
            }
            else
            {
                return Result<Block>.Fail(resultBlock.Message);
            }
        }
        #endregion Repository
    }
}
