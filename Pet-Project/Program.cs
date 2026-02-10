
using Pet_Project.Menus;
using Pet_Project.Model.WorkerKindes;
using Pet_Project.Models;
using Pet_Project.Repositories;
using Pet_Project.Services;


// ВОПРОС Связь этих строчек с override и new
//Worker worker1 = new ServerAdmin("313", "3113");

//ServerAdmin worker2 = new ServerAdmin("313", "3113");

WorkerRepository workerRepository = new WorkerRepository();
BlockRepository blockRepository = new BlockRepository();
DepartmentRepository departmentRepository = new DepartmentRepository();

IdGeneratorService idGeneratorService = new IdGeneratorService();

WorkerService workerService = new WorkerService(workerRepository, idGeneratorService);
BlockService blockService = new BlockService(blockRepository, idGeneratorService);
DepartmentService departmentService = new DepartmentService(departmentRepository, idGeneratorService);

MenuConstructor mainMenu = new MenuConstructor();

mainMenu.SetStartText("===Главное меню===");

Action ViewOffice = OfficeView;
Action Exit = ExitMenu;


mainMenu.SetMenuLine(1, "Посмотреть офис", ViewOffice);

mainMenu.SetMenuLine(9, "Выход", Exit);


void OfficeView()
{
    Console.Clear();
    Console.WriteLine(blockService.ViewAll());
    Console.WriteLine(departmentService.ViewAll());
    Console.WriteLine(workerService.ViewAll());
    Console.WriteLine("Нажммите кнопку, чтобы вернуться...");
    Console.ReadKey();
}

void BlockWork()
{

}

void ExitMenu()
{ Console.WriteLine("Выходим..."); }





while (true)
{
    mainMenu.View();
    int unput = int.Parse(Console.ReadLine());
    mainMenu.RunByLine(unput);
}





// TODO Реализовать тип сотрудника как 

/*
 
*** ТЕОРИЯ ***

Изучить SOLID, KISS, DRY, YAGNI

Изучить модификаторы доступа

Изучить основные принципы ООП

Изучить основные виды архитектуры

*** ПРАКТИКА ***

Реализовать CRUD для офисной структуры

Реализовать реализовать обязанности админов и менеджеров

Добавить интерфейсы для сервисов/репозиториев, подумать, как заменить классы на интерфейсы

*/