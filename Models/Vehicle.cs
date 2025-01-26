using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPatterns.Models
{
    public abstract class Vehicle
    {
        private bool _isEngineOn;

        public Guid ID { get; private set; }
        public string Color { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public double Gas { get; private set; } // Nivel de gasolina
        public double FuelLimit { get; set; }   // Límite de gasolina permitido
        public Dictionary<string, object> Properties { get; set; } // Cambia a "public set"


        // Propiedad abstracta
        public abstract int Tires { get; }

        public Vehicle(string color, string brand, string model, double fuelLimit = 10)
        {
            ID = Guid.NewGuid();
            Color = color;
            Brand = brand;
            Model = model;
            FuelLimit = fuelLimit;
            Gas = 0; // Gasolina inicial
            Properties = new Dictionary<string, object>(); // Inicializar aquí
        }

        public void AddGas()
        {
            if (Gas + 0.1 <= FuelLimit)
            {
                Gas += 0.1; // Incrementa la gasolina
            }
            else
            {
                throw new Exception("Gas tank is full."); // Error si se excede el límite
            }
        }

        public bool IsEngineOn()
        {
            return _isEngineOn;
        }

        public void StartEngine()
        {
            if (_isEngineOn)
            {
                throw new Exception("Engine is already on.");
            }

            if (NeedsGas())
            {
                throw new Exception("Not enough gas. Please refuel.");
            }

            _isEngineOn = true; // Enciende el motor
        }

        public void StopEngine()
        {
            if (!_isEngineOn)
            {
                throw new Exception("Engine is already off.");
            }

            _isEngineOn = false; // Apaga el motor
        }

        public bool NeedsGas()
        {
            return Gas <= 0; // Verifica si hay gasolina
        }
    }


}