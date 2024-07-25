using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            if (IsCarAvailable(rental.CarId))
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.EntityAdded);
            }
            else
            {
                return new ErrorResult(Messages.EntityAddedError);
            }
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.EntityDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.EntityListed);
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.EntityUpdated);
        }

        private bool IsCarAvailable(int carId)
        {
            var result = !_rentalDal.GetAll(r => r.CarId == carId && r.ReturnDate == null).Any();
            return result;
        }
    }
}
