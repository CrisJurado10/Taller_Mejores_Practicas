using DesignPatterns.Models;
using DesignPatterns.Repositories;
using System;

namespace DesignPatterns.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;

        public VehicleService(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public void AddVehicle(string color, string brand, string model)
        {
            var vehicle = new Car(color, brand, model);
            _vehicleRepository.AddVehicle(vehicle);
        }

        public void StartEngine(string id)
        {
            var vehicle = _vehicleRepository.Find(id);
            if (vehicle == null)
            {
                throw new Exception("Vehicle not found.");
            }
            vehicle.StartEngine();
        }

        public void StopEngine(string id)
        {
            var vehicle = _vehicleRepository.Find(id);
            if (vehicle == null)
            {
                throw new Exception("Vehicle not found.");
            }
            vehicle.StopEngine();
        }

        public void AddGas(string id)
        {
            var vehicle = _vehicleRepository.Find(id);
            if (vehicle == null)
            {
                throw new Exception("Vehicle not found.");
            }
            vehicle.AddGas();
        }
    }

    public interface IVehicleService
    {
        void AddVehicle(string color, string brand, string model);
        void StartEngine(string id);
        void StopEngine(string id);
        void AddGas(string id);
    }
}
