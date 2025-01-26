using DesignPatterns.Models; 
using DesignPatterns.Repositories; 
using DesignPatterns.Factories; 
using Microsoft.AspNetCore.Mvc; 
using Microsoft.Extensions.Logging; 
using System; 
using System.Diagnostics; 

namespace DesignPatterns.Controllers
{
    // Controlador principal que gestiona las acciones relacionadas con la página Home
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger; // Logger para registrar información, advertencias y errores
        private readonly IVehicleRepository _vehicleRepository; // Repositorio de vehículos para interactuar con los datos

        // Constructor que inyecta el repositorio de vehículos y el logger
        public HomeController(IVehicleRepository vehicleRepository, ILogger<HomeController> logger)
        {
            _vehicleRepository = vehicleRepository;
            _logger = logger;
        }

        // Acción para renderizar la página principal
        public IActionResult Index()
        {
            // Crear el modelo con la lista de vehículos del repositorio
            var model = new HomeViewModel
            {
                Vehicles = _vehicleRepository.GetVehicles()
            };

            // Verificar si hay un mensaje de error en la consulta
            if (Request.Query.ContainsKey("error"))
            {
                ViewBag.ErrorMessage = Request.Query["error"];
            }

            // Renderizar la vista con el modelo
            return View(model);
        }

        // Acción para agregar un vehículo tipo Mustang
        [HttpGet]
        public IActionResult AddMustang()
        {
            try
            {
                // Crear un Mustang utilizando el patrón Factory
                var mustang = VehicleFactory.CreateVehicle("Mustang");
                _vehicleRepository.AddVehicle(mustang); // Agregar el vehículo al repositorio
                return RedirectToAction("Index"); // Redirigir a la página principal
            }
            catch (Exception ex)
            {
                // Registrar el error y redirigir con un mensaje de error
                _logger.LogError(ex, "Error al agregar Mustang.");
                return Redirect($"/?error={ex.Message}");
            }
        }

        // Acción para agregar un vehículo tipo Explorer
        [HttpGet]
        public IActionResult AddExplorer()
        {
            try
            {
                var explorer = VehicleFactory.CreateVehicle("Explorer");
                _vehicleRepository.AddVehicle(explorer);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al agregar Explorer.");
                return Redirect($"/?error={ex.Message}");
            }
        }

        // Acción para agregar un vehículo tipo Escape
        [HttpGet]
        public IActionResult AddEscape()
        {
            try
            {
                var escape = VehicleFactory.CreateVehicle("Escape");
                _vehicleRepository.AddVehicle(escape);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al agregar Escape.");
                return Redirect($"/?error={ex.Message}");
            }
        }

        // Acción para agregar gasolina a un vehículo
        [HttpGet]
        public IActionResult AddGas(Guid id)
        {
            try
            {
                // Buscar el vehículo por su ID
                var vehicle = _vehicleRepository.Find(id);
                if (vehicle == null)
                {
                    throw new Exception("Vehicle not found.");
                }

                // Agregar gasolina al vehículo
                vehicle.AddGas();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al llenar tanque.");
                return Redirect($"/?error={ex.Message}");
            }
        }

        // Acción para encender el motor de un vehículo
        [HttpGet]
        public IActionResult StartEngine(Guid id)
        {
            try
            {
                var vehicle = _vehicleRepository.Find(id);
                if (vehicle == null)
                {
                    throw new Exception("Vehicle not found.");
                }

                vehicle.StartEngine();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al encender el motor.");
                return Redirect($"/?error={ex.Message}");
            }
        }

        // Acción para apagar el motor de un vehículo
        [HttpGet]
        public IActionResult StopEngine(Guid id)
        {
            try
            {
                var vehicle = _vehicleRepository.Find(id);
                if (vehicle == null)
                {
                    throw new Exception("Vehicle not found.");
                }

                vehicle.StopEngine();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al apagar el motor.");
                return Redirect($"/?error={ex.Message}");
            }
        }

        // Acción para mostrar la página de privacidad
        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }

        // Acción para manejar y mostrar errores
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
