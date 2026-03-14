using Pet_Project.Interfaces;
using Pet_Project.Models.OfficeStructure;
using Pet_Project.Pattern;

namespace Pet_Project.Repositories
{
    internal class BlockRepository : IRepository<Block>
    {
        private List<Block> _blocks = new List<Block>();

        public Result<List<Block>> GetAll() 
        {
            return Result<List<Block>>.Ok(_blocks, "Список получен из репозитория");
        }

        public Result<Block> Add(Block block)
        {
            _blocks.Add(block);
            return Result<Block>.Ok(block, $"Рабочий {block.Id} добавлен в репозиторий");
        }


        public Result<Block> GetById(int id)
        {
            for (int i = 0; i < _blocks.Count; i++)
            {
                if (_blocks[i].Id == id)
                    return Result<Block>.Ok(_blocks[i], $"Рабочий {_blocks[i].Id} найден");
            }
            return Result<Block>.Fail("Рабочий не найден в репозитории");
        }


        public Result<Block> ChangeNameById(int id, string newName)
        {
            Result<Block> result = GetById(id);

            if (result.Success)
            {
                Block block = result.Data;
                string oldName = block.Name;
                block.Name = newName;
                return Result<Block>.Ok(block, $"У работника с id {block.Id} изменено имя c {oldName} на {newName}");
            }
            else
            {
                return Result<Block>.Fail(result.Message);
            }
        }


        public Result<Block> DeleteById(int id)
        {
            Result<Block> result = GetById(id);

            if (result.Success)
            {
                Block block = result.Data;
                _blocks.Remove(block);
                return Result<Block>.Ok(block, $"Рабочий {block.Id} удален"); ;
            }
            else
            {
                return Result<Block>.Fail(result.Message);
            }
        }

    }
}
