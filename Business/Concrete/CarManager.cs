using Business.Abstract;
using Business.Constants;
using Core.Utilities;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities;
using Entities.CarDetailDto;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult Add(Car car)
        {
            if (car.Description.Length >= 2 && car.DailyPrice > 0)
            {
                return new ErrorResult(Messages.EntityAddedError);
            }
            else
            {
                _carDal.Add(car);
                return new SuccessResult(Messages.EntityAdded);
            }
        }


        public IResult Delete(Car car)
        {
            try
            {
                _carDal.Delete(car);
                return new SuccessResult(Messages.EntityDeleted);
            }
            catch (Exception ex)
            {
                return new ErrorResult(Messages.EntityDeletedError);
            }
        }


        public IDataResult <List<Car>> GetAll()
        {
            

            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.EntityListed);
        }

        public IDataResult <List<CarDetailDto>> GetCarDetails()
        {
            if (DateTime.Now.Hour == 16)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(x => x.Id == carId));
        }


        public IDataResult<List<Car>> GetCarsByColourId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ColourId == id));
        }

        public IResult Update(Car car)
        {
            return new SuccessResult(Messages.EntityUpdated);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(x => x.BrandId == id));
        }
    }
}