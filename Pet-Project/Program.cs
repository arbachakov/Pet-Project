using Pet_Project.Core.Services;
using Pet_Project.Data.Repositories;
using Pet_Project.UI.Menus;

OfficeRepository officeRepository = new OfficeRepository();
WorkerRespository workerRespository = new WorkerRespository();

IdGeneratorService idGeneratorService = new IdGeneratorService();
OfficeService officeService = new OfficeService(officeRepository);
WorkerService workerService = new WorkerService(workerRespository, idGeneratorService);

UIOperator uiOperator = new UIOperator(officeService, workerService);

MainMenu.Show(uiOperator);

