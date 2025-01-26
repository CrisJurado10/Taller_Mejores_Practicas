using DesignPatterns.Models;
using DesignPatterns.ModelBuilders;
using System;

namespace DesignPatterns.Factories
{
    // Clase estática que implementa el patrón Factory Method
    public static class VehicleFactory
    {
        // Método público para crear un vehículo basado en el tipo proporcionado
        public static Vehicle CreateVehicle(string type)
        {
            // Utilizamos una expresión switch para determinar qué tipo de vehículo crear
            return type switch
            {
                // Si el tipo es "Mustang", se crea un vehículo con color rojo, marca Ford y modelo Mustang
                "Mustang" => new VehicleBuilder("Red", "Ford", "Mustang")
                                    .AddDefaultProperties() // Agregamos las propiedades por defecto al vehículo
                                    .Build(), // Construimos el objeto final del vehículo

                // Si el tipo es "Explorer", se crea un vehículo con color azul, marca Ford y modelo Explorer
                "Explorer" => new VehicleBuilder("Blue", "Ford", "Explorer")
                                    .AddDefaultProperties()
                                    .Build(),

                // Si el tipo es "Escape", se crea un vehículo con color verde, marca Ford y modelo Escape
                "Escape" => new VehicleBuilder("Green", "Ford", "Escape")
                                    .AddDefaultProperties()
                                    .Build(),

                // Si el tipo no coincide con los casos anteriores, se lanza una excepción
                _ => throw new ArgumentException($"Tipo de vehículo desconocido: {type}")
            };
        }
    }
}
