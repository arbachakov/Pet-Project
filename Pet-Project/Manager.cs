using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet_Project
{
    internal class Manager : Worker
    {
        public List<Worker> Workers = new List<Worker>(); // Подчиненные. Как сделать, чтобы подчиненные подчиненных тоже рассчитывались? Написал метод CalculateWorkers

        public override string DoWork()
        {
            string workers = "";
            foreach (Worker worker in this.Workers)
            {
                workers += worker.Name + " " + worker.Sername + "\n";
            }
            return $"Я начальствую над: \n {workers}";
        }

        public override double CalculateSalary()
        {
            switch (JobTitle)
            {
                case JobTitle.Manager:
                    return 5000 * Workers.Count;
                case JobTitle.Director:
                    return 6000 * Workers.Count;
                case JobTitle.GeneralDirector:
                    return 7000 * Workers.Count;
                default:
                    return -1;
            }
        }

        public void CalculateWorkers() // Рекурсия, вроде должна работать
        {
            foreach (Worker worker in this.Workers)
            {
                if (worker is Manager manager)
                {
                    Workers.Union(manager.Workers);
                    manager.CalculateWorkers();
                }
            }
        }
    }
}
