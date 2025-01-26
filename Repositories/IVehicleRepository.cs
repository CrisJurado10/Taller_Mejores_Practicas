using Microsoft.Extensions.DependencyInjection;
using DesignPatterns.Repositories;
using DesignPatterns.Models;
using System.Collections.Generic;
using System;

namespace DesignPatterns.Repositories
{
    public interface IVehicleRepository
    {
        IEnumerable<Vehicle> GetVehicles();
        void AddVehicle(Vehicle vehicle);
        Vehicle Find(Guid id);
    }
}

