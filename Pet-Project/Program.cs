

using Pet_Project;

IMS SMZU = new IMS { Name = "SMZU", SalaryCost = 80 };
IMS SRPG = new IMS { Name = "SRPG", SalaryCost = 80 };

IMSAdmin ArbachakovME = new() // Почему без пустого конструктора не работает создание объекта? Создание ведь производится не через конструктор, а инициализатор
{
    Name = "Maxim",
    Sername = "Arbachakov",
    JobTitle = JobTitle.LeadingSpecialist,
    Status = Status.Working
};

IMSAdmin IvanovII = new IMSAdmin
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

