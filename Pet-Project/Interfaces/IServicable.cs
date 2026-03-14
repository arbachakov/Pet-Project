using Pet_Project.Pattern;
namespace Pet_Project.Interfaces
{
    internal interface IServicable<T>
    {
        public Result<List<T>> GetAll();

        public Result<string> GetInfo();
        public Result<T> ChangeNameById(int id, string newName);

        public Result<T> GetById(int id);

        // ВОПРОС Это подумать
        public Result<T> Create(string name);

        public Result<T> DeleteById(int id);
    }
}
