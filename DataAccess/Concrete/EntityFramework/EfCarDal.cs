using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities;
using Entities.CarDetailDto;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car,RentACarContext>,ICarDal
    {

        public List<CarDetailDto> GetCarDetails()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join col in context.Colours
                             on c.ColourId equals col.Id
                             select new CarDetailDto
                             {
                                 CarName = c.Description,
                                 BrandName = b.Name,
                                 ColourName = col.Name,
                                 DailyPrice = c.DailyPrice
                             };
                return result.ToList();
            }
        }
        
    }
} 
