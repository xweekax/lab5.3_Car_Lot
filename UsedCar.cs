using System;
using System.Collections.Generic;
using System.Text;

namespace Lab5._3_Car_Lot
{
    class UsedCar : Car
    {
        public double Mileage { get; set; }

        public UsedCar(string make, string model, int year, decimal price, double mileage) : base(make, model, year, price)
        {
            Mileage = mileage;
        }
        public override string ToString()
        {
            return base.ToString() + $"  (Used)  {Mileage, 9:#,0.0} miles";
        }
    }
}
