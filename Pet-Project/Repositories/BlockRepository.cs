using Pet_Project.Interfaces;
using Pet_Project.Models;
using Pet_Project.Models.OfficeStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet_Project.Repositories
{
    internal class BlockRepository : IRepository<Block>
    {
        private List<Block> _blocks = new List<Block>();

        public List<Block> GetAll()
        { return _blocks; }

        public bool Add(Block block)
        {
            _blocks.Add(block);
            return true;
        }


        public Block GetById(int id)
        {
            for (int i = 0; i < _blocks.Count; i++)
            {
                if (_blocks[i].Id == id)
                    return _blocks[i];
            }
            return null;
        }


        public bool ChangeNameById(int id, string newName)
        {
            Block block = GetById(id);
            if (block != null)
            {
                block.Name = newName;
                return true;
            }
            return false;

        }


        public bool DeleteById(int id)
        {
            Block block = GetById(id);
            if (block != null)
            {
                _blocks.Remove(block);
                return true;
            }
            return false;

        }

    }
}
