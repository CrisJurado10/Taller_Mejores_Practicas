using DesignPatterns.Models;
using System;
using System.Collections.Generic;

namespace DesignPatterns.Repositories
{
    public class DBVehicleRepository : IVehicleRepository
    {
        private readonly List<Vehicle> _vehicles = new List<Vehicle>();

        public IEnumerable<Vehicle> GetVehicles()
        {
            return _vehicles; // Devuelve una colección compatible con IEnumerable
        }

        public void AddVehicle(Vehicle vehicle)
        {
            _vehicles.Add(vehicle);
        }

        public Vehicle Find(Guid id)
        {
            return _vehicles.Find(v => v.ID == id); // Busca un vehículo por ID
        }
    }
}
