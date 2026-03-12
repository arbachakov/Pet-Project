using Pet_Project.Interfaces;
using Pet_Project.Models.OfficeStructure;
using Pet_Project.Repositories;

namespace Pet_Project.Services
{
    internal class BlockService : IServicable<Block>
    {
        private readonly BlockRepository _blockRepository;
        private readonly IdGeneratorService _idGeneratorService;

        public BlockService(BlockRepository blockRepository,
            IdGeneratorService idGeneratorService)
        {
            _blockRepository = blockRepository;
            _idGeneratorService = idGeneratorService;
        }

        public List<Block> GetAll()
        {
            return _blockRepository.GetAll();
        }

        public string ViewAll()
        {
            string blocksInfo = "Блоки:\n";
            List<Block> blocks = GetAll();
            if (blocks.Count == 0)
            { return "Блоков нет("; }
            for (int i = 0; i < blocks.Count; i++)
            {
                blocksInfo += $"Название: {blocks[i].Name} Id: {blocks[i].Id}\n";
            }
            return blocksInfo;
        }

        public bool ChangeNameById(int id, string newName)
        {
            if (_blockRepository.ChangeNameById(id, newName))
            { return true; }
            return false;

        }

        public Block GetById(int id)
        {
            return _blockRepository.GetById(id);
        }

        public Block Create(string name)
        {
            Block block = new Block(name);
            block.Id = _idGeneratorService.GenerateID();
            _blockRepository.Add(block);
            return block;
        }

        public bool DeleteById(int id)
        {
            if (_blockRepository.DeleteById(id))
            { return true; }
            return false;
        }
    }
}
