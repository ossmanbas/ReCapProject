using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsolesUI
{
    //SOLID
    //Open Closed Principle => Yazılıma yeni bir özellik ekliyor isek mevcuttaki hiçbir koda dokunulmaz!!
    class Program
    {
        static void Main(string[] args)
        {
            //CarTest();
            // BrandTest();
            //UserTest();
            //RentTest();

        }
        private static void RentTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            //rentalManager.Add(new Rental { CarId = 1, CustomerId = 1, RentDate = DateTime.Now});

            var result = rentalManager.GetAll();
            if (result.Success)
            {
                foreach (var rent in result.Data)
                {
                    Console.WriteLine(rent.CarId + " - " + rent.RentDate);
                }
            }
        }

        private static void UserTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            userManager.Add(new User { FirstName = "Osman", LastName = "Baş", Email = "osmanbastr12@gmail.com", Password = "123" });
            userManager.Add(new User { FirstName = "Furkan", LastName = "Taşçı", Email = "esquetta@gmail.com", Password = "345" });
            userManager.Add(new User { FirstName = "Mehmet Ali", LastName = "Okudan", Email = "okudanmaois@gmail.com", Password = "567" });
            userManager.Add(new User { FirstName = "Berkay", LastName = "TÜRK", Email = "tavuklupilav@gmail.com", Password = "789" });
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.Name);
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            //carManager.Add(new Car { BrandId = 1, ColorId = 2, DailyPrice = 0, ModelYear = 2020, Description = "TOGG " });
            //carManager.Add(new Car { BrandId = 2, ColorId = 1, DailyPrice = 850000, ModelYear = 2022, Description = "Mercedes CL-180" });
            carManager.Update(new Car { Id = 1, BrandId = 1, ColorId = 2, DailyPrice = 220000, ModelYear = 2020, Description = "TOGG" });

            var result = carManager.GetAll();
            if (result.Success)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.Description + " / " + car.ModelYear + " -- " + car.DailyPrice + " TL");

                }
            }
            else
            {
                Console.WriteLine(result.Message);

            }

        }
    }
}
