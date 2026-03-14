using Pet_Project.Repositories;
using Pet_Project.Services;
using Pet_Project.Registries;
using Pet_Project.Menu;


// ВОПРОС Связь этих строчек с override и new
//Worker worker1 = new ServerAdmin("313", "3113");

//ServerAdmin worker2 = new ServerAdmin("313", "3113");

WorkerRepository workerRepository = new WorkerRepository();
BlockRepository blockRepository = new BlockRepository();
DepartmentRepository departmentRepository = new DepartmentRepository();

IdGeneratorService idGeneratorService = new IdGeneratorService();
ManagementRegistry managementRegistry = new ManagementRegistry(workerRepository);

WorkerService workerService = new WorkerService(workerRepository, idGeneratorService, managementRegistry);
BlockService blockService = new BlockService(blockRepository, idGeneratorService);
DepartmentService departmentService = new DepartmentService(departmentRepository, idGeneratorService);


MainMenu mainMenu = new(blockService, departmentService, workerService);


//mainMenu.CreateItems();

mainMenu.Run();






// ВОПРОС для классов модели использовать Интерфейс, для классов репозиториев, сервисов использовать обобщенные классы?
// TODO Реализовать тип сотрудника как роль
// TODO Реализовать проверку меню (Забыл, что это значит)

/*
 
*** ТЕОРИЯ ***

Изучить SOLID, KISS, DRY, YAGNI

Изучить модификаторы доступа

Изучить основные принципы ООП

Изучить основные виды архитектуры

*** ПРАКТИКА ***

Реализовать реализовать обязанности админов и менеджеров

*/