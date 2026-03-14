using Pet_Project.Pattern;

namespace Pet_Project.Interfaces
{
    internal interface IRepository<T>
    {
        public Result<T> Add(T value);

        public Result<T> GetById(int id);

        public Result<T> ChangeNameById(int id, string newName);

        public Result<T> DeleteById(int id);

    }
}
