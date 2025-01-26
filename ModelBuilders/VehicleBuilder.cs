using System;
using System.Collections.Generic;
using DesignPatterns.Models;

namespace DesignPatterns.ModelBuilders
{
    public class VehicleBuilder
    {
        private readonly Vehicle _vehicle;

        public VehicleBuilder(string color, string brand, string model)
        {
            // Instanciar una clase concreta, como Car
            _vehicle = new Car(color, brand, model)
            {
                Properties = new Dictionary<string, object>() // Asegurarte de que Properties es accesible
            };
        }

        public VehicleBuilder AddYear()
        {
            _vehicle.Properties["Year"] = DateTime.Now.Year;
            return this;
        }

        public VehicleBuilder AddProperty(string key, object value)
        {
            _vehicle.Properties[key] = value;
            return this;
        }

        public VehicleBuilder AddDefaultProperties()
        {
            AddYear();
            AddProperty("FuelType", "Gasoline");
            AddProperty("MaxSpeed", 200);
            AddProperty("Seats", 4);
            return this;
        }

        public Vehicle Build()
        {
            return _vehicle;
        }
    }
}
