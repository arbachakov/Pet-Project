
using Pet_Project.Menu;
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

MainMenu mainMenu = new(blockService, departmentService, workerService);


//mainMenu.CreateItems();

mainMenu.Run();







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