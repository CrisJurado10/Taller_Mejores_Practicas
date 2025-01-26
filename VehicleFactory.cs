using DesignPatterns.Models;

using System;

namespace DesignPatterns.Factories
{
    public static class VehicleFactory
    {
        public static Vehicle CreateVehicle(string type)
        {
            return type switch
            {
                "Mustang" => new Car("Red", "Ford", "Mustang"),
                "Explorer" => new Car("Blue", "Ford", "Explorer"),
                "Escape" => new Car("Green", "Ford", "Escape"),
                _ => throw new ArgumentException($"Tipo de vehículo desconocido: {type}")
            };
        }
    }
}
