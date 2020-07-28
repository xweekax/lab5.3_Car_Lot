using System;
using System.Collections.Generic;
using System.Text;

namespace Lab5._3_Car_Lot
{
    class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }

        public Car()
        {
            Make = "Jeep";
            Model = "Wrangler";
            Year = 2020;
            Price = 27000.00m;
        }

        public Car(string make, string model, int year, decimal price)
        {
            Make = make;
            Model = model;
            Year = year;
            Price = price;
        }

        public override string ToString()
        {
            return $"{Make, -10} {Model, -15} {Year, 4} {Price, 11:C}";
        }
    }
}
