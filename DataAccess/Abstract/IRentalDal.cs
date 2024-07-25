using Core.Entities;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IRentalDal : IEntityRepository<Rental>
    {
        public bool IsCarAvailable(int carId)
        {
            using (var context = new RentACarContext())
            {
                return !context.Rentals.Any(r => r.CarId == carId && r.ReturnDate == null);
            }
        }
    }
}
