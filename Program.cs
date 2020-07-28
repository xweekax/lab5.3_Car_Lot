using System;
using System.Threading;

namespace Lab5._3_Car_Lot
{

    class Program
    {
        static CarLot jcCarLot = new CarLot();

        static void Main(string[] args)
        {            
            bool shopping = true;

            jcCarLot.AddCar(new Car());
            jcCarLot.AddCar(new Car("Ford", "Fusion", 2020, 28000));
            jcCarLot.AddCar(new Car("Bugatti", "Veyron", 2020, 750000));
            jcCarLot.AddCar(new UsedCar("Chevy", "Impala", 2016, 8000, 52000));
            jcCarLot.AddCar(new UsedCar("Jeep", "Patriot Sport", 2010, 6000, 148000));
            jcCarLot.AddCar(new UsedCar("Jeep", "Patriot", 2016, 12000, 48000));
            
            do
            {
                Console.Clear();

                Console.WriteLine("Welcome to JC Car Lot\n");
                jcCarLot.PrintCars();
                Console.WriteLine($"{1 + jcCarLot.CarCount, 2}. Add a car");
                Console.WriteLine($"{2 + jcCarLot.CarCount, 2}. Quit");
                Console.WriteLine();

                int choice = 0;

                while (choice <= 0 || choice > jcCarLot.CarCount+2)
                {
                    Console.Write("Which car would you like? ");
                    int.TryParse(Console.ReadLine(), out choice);
                }

                if (choice == jcCarLot.CarCount+2)
                {
                    Console.WriteLine("Thanks for shopping with us!");
                    shopping = false;
                }

                else if(choice == jcCarLot.CarCount+1)
                {
                    AddCar();
                    Console.WriteLine();
                }

                else
                {
                    BuyCar(choice - 1);
                    Console.WriteLine();
                }

            } while (shopping);
        }

        public static void AddCar()
        {
            string validation = " ";
            string make, model;
            int year = 0;
            decimal price = 0;
            double miles = 0;

            Console.WriteLine("\nEnter Q/Quit to abort\n");

            make = GetDetails("What is the Make of the car? ");
            if (make == "")
            {
                return;
            }

            model = GetDetails("What is the Model of the car? ");
            if (model == "")
            {
                return;
            }

            while (validation != "")
            {
                validation = GetDetails("What is the Year of the car? ");
                if (int.TryParse(validation, out year))
                {
                    break;
                }
            }
            if (validation == "")
            {
                return;
            }

            while (validation != "")
            {
                validation = GetDetails("What is the Price of the car? ");
                if (decimal.TryParse(validation, out price))
                {
                    break;
                }
            }
            if (validation == "")
            {
                return;
            }

            while (validation != "y" && validation != "n")
            {
                validation = GetDetails("Is this a Used car? (y/n): ").ToLower();
                if (validation == "")
                {
                    return;
                }
            }
            if (validation == "y")
            {
                while (validation != "")
                {
                    validation = GetDetails("What is the Mileage of the car? ");
                    if (double.TryParse(validation, out miles))
                    {
                        break;
                    }
                }
                if (validation == "")
                {
                    return;
                }
                jcCarLot.AddCar(new UsedCar(make, model, year, price, miles));
            }
            else
            {
                jcCarLot.AddCar(new Car(make, model, year, price));
            }

        }

        public static void BuyCar(int indexOfCar)
        {
            string input = "";

            Console.WriteLine($"\n{jcCarLot[indexOfCar]}");
            Console.WriteLine();

            while (input != "n" && input != "y")
            {
                input = GetDetails("Would you like to buy this car? (y/n): ").ToLower();
            }

            if (input == "y")
            {
                jcCarLot.RemoveCar(jcCarLot[indexOfCar]);
                Console.WriteLine("Excellent! We will get the finacial department on the job!");
                Thread.Sleep(1500);
            }

        }

        public static string GetDetails(string prompt)
        {
            bool abort = false;
            string input = "";

            if (!abort)
            {
                while (input == "")
                {
                    Console.Write(prompt);
                    input = Console.ReadLine();

                    if (input.ToLower() == "q" || input.ToLower() == "quit")
                    {
                        abort = true;
                    }
                }
            }
            return abort ? "" : input;
        }
    }
}
