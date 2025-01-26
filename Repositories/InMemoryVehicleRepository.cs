using DesignPatterns.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DesignPatterns.Repositories
{
    public class InMemoryVehicleRepository : IVehicleRepository
    {
        private readonly List<Vehicle> _vehicles = new List<Vehicle>();

        public IEnumerable<Vehicle> GetVehicles()
        {
            return _vehicles;
        }

        public void AddVehicle(Vehicle vehicle)
        {
            _vehicles.Add(vehicle);
        }

        public Vehicle Find(Guid id)
        {
            return _vehicles.FirstOrDefault(v => v.ID == id);
        }
    }

}
