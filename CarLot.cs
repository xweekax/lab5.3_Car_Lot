using System;
using System.Collections.Generic;
using System.Text;

namespace Lab5._3_Car_Lot
{
    class CarLot
    {
        List<Car> inventory;
        public int CarCount { get { return inventory.Count; } }

        public Car this[int index]
        {
            get { return inventory[index]; }
        }

        public CarLot()
        {
            inventory = new List<Car>();
        }

        public void PrintCars()
        {
            for (int index = 0; index < inventory.Count; index++)
            {
                Console.WriteLine($"{index+1, 2}. {inventory[index]}");
            }

        }
        public void AddCar(Car toAdd)
        {
            inventory.Add(toAdd);
        }

        public void RemoveCar(Car toRemove)
        {
            inventory.Remove(toRemove);
        }
    }
}
