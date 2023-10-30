namespace lab2;

public class Lab2Task2
{
    public class Car
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
    }

    public class Customer
    {
        public string CarModel { get; set; }
        public int CarId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
    }


    public static void RunTask2(int CarIdToSelect)
    {
        List<Car> cars = new List<Car>
        {
            new Car {Id = 1,  Brand = "Toyota", Model = "Corolla", Year = 2016, Color = "Black" },
            new Car {Id = 2,  Brand = "Mazda", Model = "CX-7", Year = 2016, Color = "Black" },
            new Car {Id = 3,  Brand = "BMW", Model = "M5", Year = 2016, Color = "Black" },
            new Car {Id = 4,  Brand = "BMW", Model = "X6", Year = 2016, Color = "Black" },
            new Car {Id = 5,  Brand = "Ford", Model = "Kuga", Year = 2016, Color = "Black" },
            new Car {Id = 6,  Brand = "VW", Model = "Transit", Year = 2016, Color = "Black" },

        };

        List<Customer> customers = new List<Customer>
        {
            new Customer { CarModel = "Corolla", CarId = 1, Name = "Danny", PhoneNumber = "1234567890" },
            new Customer { CarModel = "BMW", CarId = 3,Name = "Boris", PhoneNumber = "1234567890" },
            new Customer { CarModel = "Mazda",CarId = 2, Name = "Stepan", PhoneNumber = "1234567890" },
            new Customer { CarModel = "VW",CarId = 6, Name = "Kelly", PhoneNumber = "1234567890" },

        };

        var carQuery = from car in cars
            where car.Id == CarIdToSelect
            select car;

        var customerQuery = from customer in customers
            where customer.CarId == CarIdToSelect
            select customer;

        foreach (var car in carQuery)
        {
            Console.WriteLine($"Brand: {car.Brand}, Model: {car.Model}, Year: {car.Year}, Color: {car.Color}");
        }

        foreach (var customer in customerQuery)
        {
            Console.WriteLine($"Name: {customer.Name}, Phone Number: {customer.PhoneNumber}");
        }
    }
}