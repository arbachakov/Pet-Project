using Pet_Project.Core.Services;
using Pet_Project.Data.Models;
using Pet_Project.Data.Repositories;
using Pet_Project.UI.Menus;

OfficeRepository officeRepository = new OfficeRepository();
WorkerRespository workerRespository = new WorkerRespository();

IdGeneratorService idGeneratorService = new IdGeneratorService();
OfficeService officeService = new OfficeService(officeRepository);
WorkerService workerService = new WorkerService(workerRespository, idGeneratorService);

UIOperator uiOperator = new UIOperator(officeService, workerService);

MainMenu.Show(uiOperator);


// ВОПРОС Связь этих строчек с override и new
Worker worker1 = new ServerAdmin("313", "3113");

ServerAdmin worker2 = new ServerAdmin("313", "3113");


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