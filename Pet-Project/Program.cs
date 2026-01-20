using Pet_Project.Data.HelpModel;
using Pet_Project.Data.Models;

IS SMZU = new IS { Name = "SMZU", SalaryCost = 80 };
IS SRPG = new IS { Name = "SRPG", SalaryCost = 80 };

ISAdmin ArbachakovME = new() // Почему без пустого конструктора не работает создание объекта? Создание ведь производится не через конструктор, а инициализатор
{
    Name = "Maxim",
    Sername = "Arbachakov",
    JobTitle = JobTitle.LeadingSpecialist,
    Status = Status.Working
};

ISAdmin IvanovII = new ISAdmin
{
    Name = "Ivan",
    Sername = "Ivanov",
    JobTitle = JobTitle.ChiefSpecialist,
    Status = Status.Working
};

Manager PetrovPP = new Manager
{
    Name = "Petr",
    Sername = "Petrov",
    JobTitle = JobTitle.Manager,
    Status = Status.Working
};

PetrovPP.Workers.Add(ArbachakovME);
PetrovPP.Workers.Add(IvanovII);

ArbachakovME.DoWork();
IvanovII.DoWork();
PetrovPP.DoWork();
Console.ReadLine();

//string name; string sername;

// ArbachakovME.Deconstruct = (out name, out sername);

// TODO Сделать id
// TODO Определить где как выстраиваются связи между объектами