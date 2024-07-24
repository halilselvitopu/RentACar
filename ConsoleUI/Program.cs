using Business.Concrete;
using Core.Utilities.Results;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities;
using System;

class Program
{
    static void Main(string[] args)
    {
        //CarTest();
        //BrandTest();
        CarTest();
    }

    private static void ColorTest()
    {
        ColourManager colourManager = new ColourManager(new EfColourDal());

        foreach (var colour in colourManager.GetAll().Data)
        {
            Console.WriteLine($"{colour.Name}");
        }
    }

    private static void BrandTest()
    {
        BrandManager brandManager = new BrandManager(new EfBrandDal());

        foreach (var brand in brandManager.GetAll().Data)
        {
            Console.WriteLine($"{brand.Name}");
        }
    }

    private static void CarTest()
    {
        CarManager carManager = new CarManager(new EfCarDal());

        var result = carManager.GetCarDetails();

        if (result.Success == true)
        {
            foreach (var car in result.Data)
            {
                Console.WriteLine(car.CarName + "/" + car.BrandName);
            }
        }
        else
        {
            Console.WriteLine(result.Message);
        }


    }
}



