using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities;
using System;

class Program
{
    static void Main(string[] args)
    {
        CarManager carManager = new CarManager(new InMemoryProductDal());

        foreach (var car in carManager.GetAll())
        {
            Console.WriteLine(car.Description);
        }


        Console.ReadLine();
    }

}